#!/usr/bin/python3
# @Author TartaricAcid
# @Title 特殊模组检索下载
######################################

print("download Script Loading")

import urllib.request
import urllib.parse
import operator
import re
import time
import json

# 读取 log 文件，做到增量更新
modpack_download_log = open("modpack_download.log", 'r', encoding='UTF-8')
download_log = open("download.log", 'r', encoding='UTF-8')

# 创建映射表，记录更新情况
modpack_log_dict = dict()     # 用来记录特殊mod下载
log_dict = dict()     # 用来记录常规mod下载
all_dict = dict()     # 用来拼合上述两个dict，方便之后的查找

# 将上次产生的日志记录到映射表中
for entry in modpack_download_log.readlines():
    if entry != None and entry[0] != '#' and '=' in entry:
        entry_list = entry.split('=', 1)         # 依据等号切分日志文件条目
        modpack_log_dict[entry_list[0]] = entry_list[1]
modpack_download_log.close()

for entry in download_log.readlines():
    if entry != None and entry[0] != '#' and '=' in entry:
        entry_list = entry.split('=', 1)         # 依据等号切分日志文件条目
        log_dict[entry_list[0]] = entry_list[1]
download_log.close()

# 拼合两个dict
all_dict = log_dict.copy()
all_dict.update(modpack_log_dict)

# 对应不同版本的URL参数，留作备用
# version = ['1.7.10', 'filter-game-version=' + urllib.parse.quote('2020709689:4449') ]
# version = ['1.8.9', 'filter-game-version=' + urllib.parse.quote('2020709689:5806') ]
# version = ['1.9.4', 'filter-game-version=' + urllib.parse.quote('2020709689:6084') ]
# version = ['1.10.2', 'filter-game-version=' + urllib.parse.quote('2020709689:6170') ]
# version = ['1.11.2, 'filter-game-version=' + urllib.parse.quote('2020709689:6452') ]
version = ['1.12.2', 'filter-game-version=' +
           urllib.parse.quote('2020709689:6756')]

modpack_download_log = open("modpack_download.log", 'w', encoding='UTF-8')
with open('manifest.json', 'r') as f:
    data = json.load(f)

for manifest in data["files"]:
    url = "https://minecraft.curseforge.com/mc-mods/" + str(manifest["projectID"])
    try:
        real_url = urllib.request.urlopen(url).geturl()
    except:
        print("no mod found")
        continue
    mod_url_name = re.findall(r"https://minecraft.curseforge.com/projects/(.*)", real_url)

    # 设定一个变量，用来返回检验结果
    is_have = False
    for (key, value) in all_dict.items():
        if operator.eq(key, mod_url_name[0]):
            is_have = True
        else:
            continue

    if not is_have:
        modpack_download_log.write(mod_url_name[0] + "=" + str(manifest["fileID"]) + "\n")

modpack_download_log.close()

modpack_download_log = open("modpack_download.log", 'r', encoding='UTF-8')
# 将上次产生的日志记录到映射表中
for entry in modpack_download_log.readlines():
    if entry != None and entry[0] != '#' and '=' in entry:
        entry_list = entry.split('=', 1)         # 依据等号切分日志文件条目
        modpack_log_dict[entry_list[0]] = entry_list[1]
modpack_download_log.close()
print(modpack_log_dict)

# 创建并重置日志文件，记录下载进度
modpack_download_log = open("modpack_download.log", 'w', encoding='UTF-8')
modpack_download_log.writelines(
    "# " + time.strftime("%Y-%m-%d-%H:%M:%S", time.localtime()) + "\n\n")
print("# " + time.strftime("%Y-%m-%d-%H:%M:%S", time.localtime()) + "\n\n")
modpack_download_log.close()

for (key, value) in modpack_log_dict.items():
    #try:
    url = "https://minecraft.curseforge.com/projects/" + key + "/file/" + value + "/download"
    print(url)
    # 用 geturl 方法得到真正的下载地址
    real_url = urllib.request.urlopen(url).geturl()

    # 输出到屏幕
    print("###############################" + "\n"
          + "下载模组：" + key + "\n"
          + "下载地址：" + real_url + "\n"
          + "文件ID：" + value + "\n"
          + "###############################")

    print("新增模组：" + key)
    # 下载 mod，因为网速不行，暂时关闭
    urllib.request.urlretrieve(real_url, "./mods/" + value)
    print(key + " 模组更新完毕\n")
    # 写入日志中
    modpack_download_log = open("modpack_download.log", 'a', encoding='UTF-8')
    modpack_download_log.write(key + "=" + value + "\n")
    modpack_download_log.close()
    #except:
        #print("看起来这个模组目前找不到\n")

print("download Script Stop Load")
