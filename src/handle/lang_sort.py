import os

for modid in os.listdir('project/assets/'):
    if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(modid)):
        continue
    if not os.path.exists('project/assets/{}/lang/zh_cn.lang'.format(modid)):
        continue
    with open('project/assets/{}/lang/zh_cn.lang'.format(modid), 'r+', encoding='utf-8') as lang:
        lang_index = lang.readlines()   # 将文件读取成 list
        lang_index.sort()   # list 排序
        lang.seek(0, 0)     # 将指针重定向至文件开头
        lang_list = []      # 空 list 放置剔除换行符条目
        for i in lang_index:    # 剔除无用换行符
            if i != '\n':
                lang_list.append(i)
        lang.writelines(lang_list)     # 重新写入文件
