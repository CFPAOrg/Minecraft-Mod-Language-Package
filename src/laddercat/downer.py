import asyncio
import aiohttp
import orjson
from pathlib import Path
import os.path
import random
import zipfile
import tempfile
import glob
import re
from typing import List
import shutil
import laddercat.utils as utils
import laddercat.config as config
import chardet
import maya
import datetime
import traceback

infos = orjson.loads(open("./modinfo.json").read())
done = False
version = "1.12.2"
wait_a_little = False
date = {}

if not Path("./project/assets").exists():
    Path("./project/assets").mkdir(parents=True)

if not Path("./cache").exists():
    Path("./cache").mkdir()

if not Path("./database/cache.json").exists():
    Path("./database/cache.json").touch()
    Path("./database/cache.json").write_text(r"{}", "utf-8", "replace")
else:
    date = orjson.loads(Path("./database/cache.json").read_text("utf-8", "replace"))

async def worker(queue: asyncio.Queue, session: aiohttp.ClientSession):
    global done, wait_a_little
    while True:
        if done:
            return
        else:
            try:
                info = await asyncio.wait_for(queue.get(), 100)
            except asyncio.exceptions.TimeoutError:
                print("等待超过了100秒, 如果在接下来120秒内没有响应将退出.")
                try:
                    info = await asyncio.wait_for(queue.get(), 120)
                except asyncio.exceptions.TimeoutError:
                    print("已经等待了120秒, 生成器没有输出, 该协程退出.")
                    break

        """
        if Path(f"./mods/{info['name']}").exists():
            # 校验其长度
            size = os.path.getsize(Path(f"./mods/{info['name']}").absolute())
            if size == info['file-length']:
                print(f"warn: {info['name']} 已存在, 跳过.")
                continue
            else:
                print(f"warn: {info['name']} 不完整, 重新爬取")
        """

        print(f"开始获取 [{info['name']}][{info['url']}] ")
        try:
            async with session.get(info['url']) as response:
                file_content = await response.read()
                with tempfile.TemporaryFile("r+b") as f:
                    f.write(file_content)
                    f.seek(0)
                    zipFile = zipfile.ZipFile(f)
                    with tempfile.TemporaryDirectory() as td_name:
                        # td = TemporaryDirectory
                        zipFile.extractall(td_name)

                        td_path = Path(td_name)
                        paths = glob.glob(str(td_path.absolute()) + "/assets/*/lang")
                        domains = [i.string[i.start():i.end()] for i in [
                            re.search(r"(?<=(assets\/))[a-zA-Z0-9]*(?=(\/lang))", i.replace("\\", "/"))\
                            for i in paths 
                        ] if i]
                        for domain in domains:
                            if not domain:
                                continue

                            if f"{info['name']}::{domain}" in config.namespace_domain_blacklist:
                                print(f"检测到模组 {info['name']} 正在尝试修改被列入命名空间黑名单的资源域 {domain}, 已阻止.")
                                continue

                            domain_dir = Path(f"./project/assets/{domain}")
                            if not domain_dir.exists():
                                domain_dir.absolute().mkdir()

                            domain_lang = domain_dir / "lang"
                            if not domain_lang.exists():
                                domain_lang.absolute().mkdir()

                            # touch 各个文件
                            touch_list: List[Path] = [
                                (td_path / "assets" / domain / "lang" / filename) for filename in [
                                    "en_us.lang", "zh_cn.lang", "en_us_old.lang", "zh_cn_old.lang"
                                ]
                            ]
                            for filename in touch_list:
                                if not filename.exists():
                                    filename.touch()

                            # 复制文件到{tmp}/assets/{domain}/lang下
                            domain_root = Path(f"./project/assets/{domain}")
                            project_en_us: Path = domain_root/"lang"/"en_us.lang"
                            project_zh_cn: Path = domain_root/"lang"/"zh_cn.lang"
                            if project_en_us.exists() and project_en_us.is_file():
                                shutil.copy(
                                    str(project_en_us.absolute()),
                                    str(td_path / "assets" / domain / "lang" / "en_us_old.lang")
                                )
                            if project_zh_cn.exists() and project_zh_cn.is_file():
                                shutil.copy(
                                    str(project_zh_cn.absolute()),
                                    str(td_path / "assets" / domain / "lang" / "zh_cn.lang")
                                )

                            # 复制重构完毕.
                            # 开始预处理....
                            # ph = pre handle
                            ph_en_us: Path = td_path / "assets" / domain / "lang" / "en_us.lang"
                            if ph_en_us.exists() and ph_en_us.is_file():
                                ph_en_us.write_text(
                                    ph_en_us.read_text(encoding="utf-8", errors="replace"),
                                    encoding="utf-8", errors="replace"
                                )
                                # 自动转换编码

                                if not utils.is_properties_language_file(str(ph_en_us.absolute())):
                                    utils.language_file_delete_and_fix(str(ph_en_us.absolute()))

                        # 开始删除..
                        for item in config.delete_list:
                            if os.path.exists(td_name + "/assets/" + item):
                                shutil.rmtree(td_name + "/assets/" + item)
                            if Path(f"./project/assets/{item}").exists():
                                print(f"删除项 [{item}]")
                                shutil.rmtree(f"./project/assets/{item}")
                            if item in domains:
                                domains.remove(item)

                        # 开始复制
                        for i in domains:
                            local_lang = Path(f"./project/assets/{i}/lang/en_us.lang")

                            if not local_lang.exists():
                                with open(str(local_lang.absolute()), "a") as f:
                                    f.write("")
                            else:
                                # 不需要处理 en_us_old.lang 了
                                pass
                            
                            shutil.copyfile(f"{td_name}/assets/{i}/lang/en_US.lang", str(local_lang.absolute()))
                            # 处理date文件
                        print(f"处理 [{info['name']}] 完毕.")
        except Exception as e:
            print(f"在爬取 [{info['name']}] 时发生了错误, 尝试重新排入队列", type(e))
            traceback.print_exc()
            wait_a_little = True
            await queue.put(info)

async def proer(queue: asyncio.Queue, session: aiohttp.ClientSession):
    global done, wait_a_little
    for page in infos:
        for mod in page:
            # 寻找可用版本:
            FileInfo = None
            deep = False

            if mod['slug'] in config.mod_blacklist_slug:
                print(f"模组 [{mod['name']}] 被列入黑名单, 已跳过")
                continue
            
            """
            date_cache = Path(f"./cache/{mod['id']}.json")
            if date_cache.exists():
                # 一次检查.
                date = maya.parse(orjson.loads(date_cache.read_text("utf-8"))['date'])
                if date:
                    timediff = maya.now() - date
                    if datetime.timedelta(**config.update_setting) > timediff:
                        print(f"模组 [{mod['name']}] 未到更新时间({date.add(**config.update_setting)}), 已跳过")
                        continue
            """
            update_date = date.get(str(mod['id']))
            if update_date:
                # 一次检查.
                date_ = maya.parse(update_date)
                if date_:
                    timediff = maya.now() - date_
                    if datetime.timedelta(**config.update_setting) > timediff:
                        print(f"模组 [{mod['name']}] 未到更新时间({date_.add(**config.update_setting)}), 已跳过")
                        continue
            

            print(f"开始找寻模组 [{mod['name']}] 可用于版本 [{version}] 的jar文件")
            for i in mod['latestFiles']:
                if version in i['gameVersion']:
                    print(f"已找到模组 [{mod['name']}] 可用于版本 [{version}] 的jar文件")
                    FileInfo = i
                    break
            else:
                print(f"未找到模组 [{mod['name']}] 可用于版本 [{version}] 的jar文件, 开始请求远端数据库以寻找可用的版本")
                deep = True

            if deep:
                for versionInfo in mod['gameVersionLatestFiles']:
                    if versionInfo['gameVersion'] == version:
                        print(f"已找到远端数据库中模组 [{mod['name']}] 可用于版本 [{version}] 的jar文件, 开始深层数据取出")
                        info_url = f'https://addons-ecs.forgesvc.net/api/v2/addon/{mod["id"]}/file/{versionInfo["projectFileId"]}'
                        async with session.get(info_url) as response:
                            FileInfo = await response.json()
                else:
                    print(f"未找到模组 [{mod['name']}] 可用于版本 [{version}] 的jar文件, 跳过.")
                    continue


            if not FileInfo:
                print(f"warn: {mod['name']} 没有版本 {version} 可用的文件, 跳过")
                continue
            
            # 存储更新日期
            ## 可能会找不到文件, touch it
            """
            if not date_cache.exists():
                date_cache.touch()

            date_cache.write_text(orjson.dumps({
                "date": maya.now().rfc2822()
            }).decode('utf-8'), encoding="utf-8")
            """
            date[str(mod['id'])] = maya.now().rfc2822()

            url = FileInfo["downloadUrl"]
            name = FileInfo["fileName"]
            length = FileInfo["fileLength"]
            if wait_a_little:
                await asyncio.sleep(3)
                wait_a_little = False

            await queue.put({
                "url": url,
                "name": name,
                "file-length": length
            })
    done = True

def clean():
    for item in config.delete_list:
        if Path(f"./project/assets/{item}").exists():
            print(f"删除项 [{item}]")
            shutil.rmtree(f"./project/assets/{item}")

def main():
    queue = asyncio.Queue(config.queue_num)

    loop = asyncio.get_event_loop()
    session = aiohttp.ClientSession(loop=loop)
    tasks = []

    for _ in range(config.async_worker_number):
        tasks.append(loop.create_task(worker(queue, session)))

    tasks.append(loop.create_task(proer(queue, session)))

    try:
        loop.run_until_complete(asyncio.wait(tasks))
    except KeyboardInterrupt:
        print("检测到Ctrl-C, 自动保存断点数据.")
        Path("./database/cache.json").write_text(
            orjson.dumps(date).decode(),
            encoding="utf-8", errors="replace"
        )
        print("断点数据保存完毕, 将在下一次爬取时自动读取断点数据")
        import sys
        sys.exit()
    loop.run_until_complete(session.close())

    print("开始事后大扫除.")
    clean()
    print("扫除完毕.")

    print("开始保存更新时间数据")
    Path("./database/cache.json").write_text(
        orjson.dumps(date).decode(),
        encoding="utf-8", errors="replace"
    )
    print("更新时间数据保存完毕")

main()