#!/usr/bin/python3
import os
import re
import time

# 清除先前的零时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')

# 更新一遍仓库
os.system('git pull')

# mod 信息抓取

# modpack 信息抓取、下载、解压

# modpack 中的 mod 信息抓取

# 开始下载 mod

# 最后，解压语言文件

# 开始处理语言文件

# 清除黑名单文件夹

# 再次清除先前的零时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')

# 最后，自动 commit，并依据更新情况是否发送邮件
# 通过 git 来获取更新信息
os.system('git add .')
# 抓取出新增的部分，因为只有增加的模组才需要 phi 重新导入
string = os.popen('git status | grep "new file:"')
# 正则抓取出有用的信息
new_mod_list = re.findall(
    r'project/assets/(.*?)/lang/en_us.lang', string.read())

# 是否为空？为空不发邮件
if len(new_mod_list) != 0:
    pass

# 最后 commit, push
os.system('git commit -m "Auto Update, Date: {}"'.format(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())))
os.system('git push')
