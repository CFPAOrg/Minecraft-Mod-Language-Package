import os


# 剔除冗余的函数，传入 dict1（模组中中文）和 dict2（weblate上面的翻译）
def redundancy_del(dict1, dict2):
    dict3 = {}
    for i in dict2.keys():
        try:
            if not dict2[i] == dict1[i]:
                dict3[i] = dict2[i]
        except:
            dict3[i] = dict2[i]
    return dict3


# 获取语言文件，处理得到一个 dict
def lang_to_dict(file_path):
    lang_dict = {}
    with open(file_path, 'r', errors='ignore') as f:
        for line in f.readlines():
            if line is not None and line[0] != '#' and line[0] != '/' and '=' in line:
                line_list = line.split('=', 1)
                lang_dict[line_list[0]] = line_list[1]
    return lang_dict


# 临时文件创建
os.system('cp -rf ./project ./project-tmp')

# 处理主程序
for modid in os.listdir('project-tmp/assets'):
    # 先判定我们将要处理的东西是否存在
    if not os.path.exists('project-tmp/assets/{}/lang/zh_cn.lang'.format(modid)):
        continue
    if not os.path.exists('project-tmp/assets/{}/lang/zh_cn_old.lang'.format(modid)):
        continue

    # 然后先剔除英文
    os.system('rm -f project-tmp/assets/{}/lang/en_us.lang'.format(modid))

    # weblate 中文文件改名
    os.system(
        'mv project-tmp/assets/{}/lang/zh_cn.lang project-tmp/assets/{}/lang/zh_cn_tmp.lang'.format(modid, modid))

    # 处理得到 dict
    zh_cn_old = lang_to_dict(
        'project-tmp/assets/{}/lang/zh_cn_old.lang'.format(modid))
    zh_cn_tmp = lang_to_dict(
        'project-tmp/assets/{}/lang/zh_cn_tmp.lang'.format(modid))
    zh_cn = redundancy_del(zh_cn_old, zh_cn_tmp)

    # 写成语言文件
    with open('project-tmp/assets/{}/lang/zh_cn.lang'.format(modid), 'w') as f:
        for key in zh_cn.keys():
            f.writelines(key + '=' + zh_cn[key])

    # 删除不需要的文件
    os.system('rm -f project-tmp/assets/{}/lang/zh_cn_old.lang'.format(modid))
    os.system('rm -f project-tmp/assets/{}/lang/zh_cn_tmp.lang'.format(modid))

    # 最后判断文件是否为空
    if os.path.getsize('project-tmp/assets/{}/lang/zh_cn.lang'.format(modid)) == 0:
        os.system('rm -rf project-tmp/assets/{}'.format(modid))
