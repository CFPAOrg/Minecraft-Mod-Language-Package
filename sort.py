import os

for modid in os.listdir('project/assets/'):
    if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(modid)):
        continue
    if not os.path.exists('project/assets/{}/lang/zh_cn.lang'.format(modid)):
        continue
    with open('project/assets/{}/lang/zh_cn.lang'.format(modid), 'r+') as lang:
        lang_entry = lang.readlines()   # 将文件读取成 list
        lang_entry.sort()   # list 排序
        lang.seek(0, 0)     # 将指针重定向至文件开头
        lang.writelines(lang_entry)     # 重新写入文件
