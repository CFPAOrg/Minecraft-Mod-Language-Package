import re
import zipfile
import json
import os
import io

from src.bytecode_parse.parser import JavaClass
from src.baka_init import *


# 解压获取语言文件的解压函数
def unzip(unzip_file_name, unzip_path_mods, unzip_path_assets):
    with zipfile.ZipFile(unzip_path_mods + "/" + unzip_file_name, "r") as z:
        logging.info("开始解压 " + z.filename + " 文件")
        # asset domain和mod id集合，都可能有多个
        asset_domain=set()
        mod_id=set()
        # 遍历文件列表
        for i in z.filelist:
            # 找出所有的中英文语言文件
            if re.match(r'assets/.*?/lang/(en_us|en_US|zh_cn|zh_CN)\.lang', i.filename):
                # 因为统一需要小写文件名，同时有复杂需求：
                # en_us.lang -> 保持不变
                # zh_cn.lang -> zh_cn_old.lang
                # 所以此次需要尝试替换下字符串
                zip_tmp_file_path = unzip_path_assets + "/" + i.filename.lower().replace("zh_cn.lang", "zh_cn_old.lang")
                # 剔除最后 11 字符，这样正好获取得到了文件夹路径
                zip_tmp_dir_path = unzip_path_assets + "/" + i.filename[:-11]

                # 类似的方法拿到asset domain文件夹名
                asset_name = i.filename[7:-16].lower()
                asset_domain.add(asset_name)

                # 先判定文件夹在不在，不在的话创建文件夹
                # exist_ok 用来跳过文件夹存在错误
                if not os.path.exists(zip_tmp_dir_path):
                    os.makedirs(zip_tmp_dir_path, exist_ok=True)

                # 开始将文件解压，提取出来
                with z.open(i.filename) as f:
                    # 同时增加 errors 参数，如果有那种瞎编码的作者，错误编码字符会被问号替换
                    with open(zip_tmp_file_path, "wb") as tmp:
                        # 强制重写编码，防止某些作者另辟蹊径
                        tmp.write(f.read())

        # 接下来解析modid
        # 先尝试从Forge缓存的注释中解析modid
        fml_cache_annotation_file='META-INF/fml_cache_annotation.json'
        if fml_cache_annotation_file in z.namelist():
            with z.open(fml_cache_annotation_file) as f:
                f=io.TextIOWrapper(f,encoding='utf8')
                annotations = json.load(f)
                for class_ann in annotations.values():
                    if not 'annotations' in class_ann:
                        continue
                    for ann in class_ann['annotations']:
                        if ann['type'] == 'CLASS' and ann['name'] == 'Lnet/minecraftforge/fml/common/Mod;':
                            mod_id.add(ann['values']['modid']['value'])
        if len(mod_id) != 0:
            return (mod_id,asset_domain)
        # 如果没有缓存的注释文件或没有找到modid
        else:
            # 没有asset，也不用再找modid了
            if len(asset_domain)==0:
                return (mod_id,asset_domain)

            # 解析所有class文件的常量池，找modid
            success=True
            for i in z.filelist:
                if i.filename.endswith('.class'):
                    with z.open(i.filename,'r') as f:
                        # 这个disassembler功能不是很完善，可能会报错
                        try:
                            jc = JavaClass(f.read())
                            strings = jc.get_constant_string()
                            for i in range(len(strings) - 2):
                                if strings[i] == 'Lnet/minecraftforge/fml/common/Mod;':
                                    for j in range(1,5):
                                        if strings[i+j] == 'modid':
                                            mod_id.add(strings[i+j+1])
                                            break
                        except Exception as e:
                            success = False

            # 没有报错，返回
            if success:
                return (mod_id,asset_domain)

            # 有报错，但至少找到了一个modid
            elif len(mod_id)!=0:
                # TODO: log
                # 在绝大多数使用场景下，我们并不需要找到一个jar包里所有注册的mod的id，所以这里可以直接返回
                # TODO: 用config控制这里的行为
                return (mod_id,asset_domain)

            # 虽然mcmod.info往往不能信...但现在我们走投无路了
            if 'mcmod.info' in z.namelist():
                with z.open('mcmod.info') as f:
                    try:
                        modinfo=json.load(f)
                        for info in modinfo:
                            mod_id.add(info['modid'])
                    except:
                        # TODO: log
                        pass

    return (mod_id,asset_domain)


def main(path_mods, path_assets):
    logging.info("==================  解压部分开始  ==================")
    # 开始遍历模组临时文件夹，解压得到内部的语言文件，并更新 ASSET_MAP
    for zf in os.listdir(path_mods):
        # 如果是 zip 文件，进行解压
        if zipfile.is_zipfile(path_mods + "/" + zf):
            mod_id,asset_domain = unzip(zf, path_mods, path_assets)
            if len(asset_domain) != 0:
                if len(mod_id) == 0:
                    logging.error('%s模组 modid 解析失败' % zf)
                for modid in mod_id:
                    if not modid in ASSET_MAP:
                        ASSET_MAP[modid]=[]
                    for domain in asset_domain:
                        if not domain in ASSET_MAP[modid]:
                            ASSET_MAP[modid].append(domain)
    # ASSET_MAP 中加入 Unknown
    all_assets = os.listdir('./project/assets')
    known_domain = []
    list(map(known_domain.extend, [ASSET_MAP[modid] for modid in ASSET_MAP if not modid == '<UNKNOWN>']))
    Unknown = [domain for domain in all_assets if not domain in known_domain]
    ASSET_MAP['<UNKNOWN>'] = Unknown

    # 保存 ASSET_MAP
    for modid in ASSET_MAP:
        ASSET_MAP[modid].sort()
    with open(ASSET_MAP_FILE, 'w') as f:
        f.write(json.dumps(ASSET_MAP, indent=4, sort_keys=True))
    logging.info("==================  解压部分结束  ==================")


if __name__ == '__main__':
    main("../../tmp_mods", "../../tmp_assets")
