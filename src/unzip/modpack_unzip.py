import csv
import threading
import re
import time
import os
import shutil

# 我不是很喜欢 python 的解压模块
# 我喜欢 shell 的 unzip 工具
for modpack in os.listdir('/tmp/modpacks/'):
    # 会把先前的 assets 文件夹也记录上，忽略它
    if modpack == "manifest":
        continue

    path = '/tmp/modpacks/manifest/{}'.format(modpack)
    os.system('mkdir -p ' + path)
    # 遍历解压，鉴于 shell 的特性，所以不存在的会直接跳过，无须担心
    os.system(
        'unzip -o /tmp/modpacks/{} manifest.json -d {}/'.format(modpack, path))
