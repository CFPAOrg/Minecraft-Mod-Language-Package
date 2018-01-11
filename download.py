#!/usr/bin/python3
# @Author TartaricAcid
# @Credit asdflj
# @Title 批量模组下载工具
######################################

print("download Script Loading")

import urllib.request
import urllib.parse
import re
import time

# 读取 log 文件，做到增量更新
download_log = open("download.log", 'r', encoding='UTF-8')

# 创建映射表，记录更新情况
log_dict = dict()

# 将上次产生的日志记录到映射表中
for entry in download_log.readlines():
    if entry != None and entry[0] != '#' and '=' in entry:
        entry_list = entry.split('=', 1)         # 依据等号切分日志文件条目
        log_dict[entry_list[0]] = entry_list[1]

download_log.close()

# 对应不同版本的URL参数，留作备用
# version = ['1.7.10', 'filter-game-version=' + urllib.parse.quote('2020709689:4449') ]
# version = ['1.8.9', 'filter-game-version=' + urllib.parse.quote('2020709689:5806') ]
# version = ['1.9.4', 'filter-game-version=' + urllib.parse.quote('2020709689:6084') ]
# version = ['1.10.2', 'filter-game-version=' + urllib.parse.quote('2020709689:6170') ]
# version = ['1.11.2, 'filter-game-version=' + urllib.parse.quote('2020709689:6452') ]
version = ['1.12.2', 'filter-game-version=' +
           urllib.parse.quote('2020709689:6756')]

# 创建并重置日志文件，记录下载进度
download_log = open("download.log", 'w', encoding='UTF-8')
download_log.writelines(
    "# " + time.strftime("%Y-%m-%d-%H:%M:%S", time.localtime()) + "\n\n")
print("# " + time.strftime("%Y-%m-%d-%H:%M:%S", time.localtime()) + "\n\n")
download_log.close()

# 开始遍历 curseforge 页面，暂定为前 30 页
for num in range(1, 30):
    # 限定版本，按照下载量排序
    url = "https://www.curseforge.com/minecraft/mc-mods?" + \
        version[1] + "&filter-sort=downloads" + "&page=" + str(num)
    data = urllib.request.urlopen(url).read()
    data = data.decode('utf-8')

    # 正则抓取 mod id
    modid = re.findall(r"href=\"/minecraft/mc-mods/(.*)/download\"", data)

    for i in modid:
        # 找到 mod 下载页面
        url = "https://www.curseforge.com/minecraft/mc-mods/" + \
            i + "/files/?" + version[1]
        data = urllib.request.urlopen(url).read()
        data = data.decode('utf-8')

        # 正则抓取文件id，文件名称
        project_file_id = re.findall(r"\"ProjectFileID\": (.*),", data)

        try:
            # 这一块会出问题
            # alpha版本模组不会提供下载界面
            # 但是限定版本页面中却会出现
            # 故用 try 语句来抓取错误
            project_file_id[0]

            url = "https://www.curseforge.com/minecraft/mc-mods/" + \
                i + "/download/" + project_file_id[0] + "/file"
            # 用 geturl 方法得到真正的下载地址
            real_url = urllib.request.urlopen(url).geturl()

            # 输出到屏幕
            print("###############################" + "\n"
                  + "下载模组：" + i + "\n"
                  + "下载地址：" + real_url + "\n"
                  + "文件ID：" + project_file_id[0] + "\n"
                  + "页数：" + str(num) + "\n"
                  + "###############################")

            # 开始尝试检测映射表
            try:
                if int(log_dict[i]) == int(project_file_id[0]):
                    print("这个模组已经下载过了\n")
                    # 写入日志中
                    download_log = open("download.log", 'a', encoding='UTF-8')
                    download_log.write(i + "=" + project_file_id[0] + "\n")
                    download_log.close()
                else:
                    # 下载 mod
                    urllib.request.urlretrieve(
                        real_url, "./mods/" + project_file_id[0])
                    print(i + " 模组更新完毕\n")
                    # 写入日志中
                    download_log = open("download.log", 'a', encoding='UTF-8')
                    download_log.write(i + "=" + project_file_id[0] + "\n")
                    download_log.close()
            except:
                print("新增模组：" + i)
                # 下载 mod，因为网速不行，暂时关闭
                urllib.request.urlretrieve(
                    real_url, "./mods/" + project_file_id[0])
                print(i + " 模组更新完毕\n")
                # 写入日志中
                download_log = open("download.log", 'a', encoding='UTF-8')
                download_log.write(i + "=" + project_file_id[0] + "\n")
                download_log.close()
        except:
            print("看起来这个模组目前只有alpha版本，不建议下载\n")

print("download Script Stop Load")
