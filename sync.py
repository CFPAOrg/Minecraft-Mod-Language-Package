#!/usr/bin/python3
# @Author TartaricAcid
# @Title 自动同步脚本
######################################

# 是的，我要同步weblate上翻译的汉化项目
# 不同的作者，放置文件的位置不同
# 甚至版本的分支页不相同
# 鉴于整体位置比较固定，一般不会变动
# weblate上面目前翻译项目并不多
# 故采用硬编码方式获取文件

import urllib.request
import urllib.parse
import os

# 读取 log 文件，做到增量更新
weblate = open("weblate.md", 'r', encoding='UTF-8')

# 接下来，下载weblate汉化文件
for lines in weblate.readlines():
    path, url = lines.split('|', 1)
    if path == "file_path" or path == ":--:":
        continue
    os.makedirs(path)
    urllib.request.urlretrieve(url, path + "/zh_cn.lang")

weblate.close()
