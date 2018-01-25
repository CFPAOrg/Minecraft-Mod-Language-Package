import csv
import threading
import re
import time
import os
import shutil

# 我不是很喜欢 python 的解压模块
# 我喜欢 shell 的 unzip 工具
for mod in os.listdir('/tmp/mods/'):
    # 会把先前的 assets 文件夹也记录上，忽略它
    if mod == "assets":
        continue

    # 然后记录需要解压的语言文件
    name_unzip_list = ['en_US.lang', 'en_us.lang', 'zh_CN.lang', 'zh_cn.lang']

    # 遍历解压，鉴于 shell 的特性，所以不存在的会直接跳过，无须担心
    for name_unzip in name_unzip_list:
        os.system(
            'unzip -o /tmp/mods/{} assets/*/lang/{} -d /tmp/mods/'.format(mod, name_unzip))

for mod in os.listdir('/tmp/mods/assets/'):
    # 记录需要更改的字典
    name_change_dict = {"en_US.lang": "en_us.lang",
                        "zh_CN.lang": "zh_cn_old.lang",
                        "zh_cn.lang": "zh_cn_old.lang"}

    # 遍历进行改名
    for key, value in name_change_dict.items():
        if os.path.exists('/tmp/mods/assets/{}/lang/{}'.format(mod, key)):
            shutil.move('/tmp/mods/assets/{}/lang/{}'.format(mod, key),
                        '/tmp/mods/assets/{}/lang/{}'.format(mod, value))

# 拆包得到的中英文文件强制挪回来
os.system('cp -rf /tmp/mods/assets/* ./project/assets')

# 遍历 project/assets 文件夹
# 强制补全所有的 zh_cn.lang 和 zh_cn_old.lang
# 与其处理特殊问题，不如直接统一规格
for mod in os.listdir('./project/assets/'):
    zh_cn_path = './project/assets/{}/lang/zh_cn.lang'.format(mod)
    zh_cn_old_path = './project/assets/{}/lang/zh_cn_old.lang'.format(mod)
    if not os.path.exists(zh_cn_path):
        os.system('touch ' + zh_cn_path)
    if not os.path.exists(zh_cn_old_path):
        os.system('touch ' + zh_cn_old_path)
