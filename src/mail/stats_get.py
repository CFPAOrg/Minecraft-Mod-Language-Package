#!/usr/bin/python3
import os
import re
import time

# 通过 git 来获取更新信息
os.system('git add .')
# 抓取出新增的部分，因为只有增加的模组才需要 phi 重新导入
string = os.popen('git status | grep "新文件："')
# 正则抓取出有用的信息
new_mod_list = re.findall(
    r'project/assets/(.*?)/lang/en_us.lang', string.read())

# 信件的开始部分
file_top = '''phi！醒醒！你需要更新仓库了！
本次更新时间：{}
本次新增了 {} 个模组：
'''.format(time.strftime("%Y-%m-%d %H:%M:%S", time.localtime()), len(new_mod_list))

# 更新列表写成 txt 文件，等会让其他程序来当做邮件发送
with open('/tmp/email.txt', 'w') as md:
    md.writelines(file_top)
    for i in range(len(new_mod_list)):
        name = new_mod_list[i]
        url = 'https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/tree/1.12.2/project/assets/{}/lang'.format(
            name)
        md.write('【{}】{} 模组：{}\n'.format(i + 1, name, url))
