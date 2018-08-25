# !/usr/bin/python3
import os


def del_empty(modid=''):
    lang_list = []
    with open('project/assets/{}/lang/en_us.lang'.format(modid), 'r', encoding='utf-8', errors='ignore') as lang:
        # 读取所有的英文文件
        for i in lang.readlines():
            if i is not None and i[0] != '#' and '=' in i:
                il = i.split('=', 1)
                if il[1].replace('\n', '') == '':
                    print(i)
                    continue
            lang_list.append(i)

    with open('project/assets/{}/lang/en_us.lang'.format(modid), 'w', encoding='utf-8', errors='ignore') as lang_:
        for j in lang_list:
            lang_.writelines(j)


for modid in os.listdir('project/assets/'):
    if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(modid)):
        continue
    if not os.path.exists('project/assets/{}/lang/zh_cn.lang'.format(modid)):
        continue
    del_empty(modid)
