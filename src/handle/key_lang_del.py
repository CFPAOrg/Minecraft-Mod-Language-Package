# !/usr/bin/python3
import os
import yaml

with open('config.yml', 'r', encoding='utf-8') as f:
    config = yaml.load(f)
    DEL_KEY = config['del_key']


def del_key(modid=''):
    lang_list = []
    with open('project/assets/{}/lang/en_us.lang'.format(modid), 'r', encoding='utf-8', errors='ignore') as lang:
        # 读取所有的英文文件
        for i in lang.readlines():
            # 找出正确的语言文件
            if i is not None and i[0] != '#' and '=' in i:
                il = i.split('=', 1)
                if il[0] in DEL_KEY:
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

    del_key(modid)
