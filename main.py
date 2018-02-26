#!/usr/bin/python3
import os
import re
import time
import src.weblate.weblate

# 首先是对 weblate 进行操控
src.weblate.weblate.weblate_operation()

# 我知道这一块代码很不符合规范
# 但是写着好用，以后也许会改
# 也许……

# 清除先前的临时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')

# 更新一遍仓库
os.system('git pull')

# mod 信息抓取
import src.crawler.mod_info_get

# modpack 信息抓取、下载、解压
import src.crawler.modpack_info_get
import src.crawler.modpack_downloader
import src.unzip.modpack_unzip

# modpack 中的 mod 信息抓取
import src.crawler.modpack_mod_info_get

# 开始下载 mod
import src.crawler.mod_downloader
import src.crawler.modpack_mod_downloader

# 最后，解压语言文件
import src.unzip.mod_unzip

# 开始处理语言文件
import src.handle.handle
import src.handle.properties_handle
import src.handle.lang_sort

# 清除黑名单文件夹
import src.redundancy.black_dir_del

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
    import src.mail.stats_get
    import src.mail.send_mail

# 接下来检查指定用户的 github，并发送邮件提醒
import src.github.github_info_email

# 最后 commit, push
os.system('git commit -m "Auto Update, Date: {}"'.format(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime())))
os.system('git push')