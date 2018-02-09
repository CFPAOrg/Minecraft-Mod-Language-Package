import os


# 获取语言文件，处理得到一个 dict
def lang_to_dict(file_path):
    lang_dict = {}
    with open(file_path, 'r', errors='ignore') as f:
        for line in f.readlines():
            if line != None and line[0] != '#' and line[0] != '/' and '=' in line:
                line_list = line.split('=', 1)
                lang_dict[line_list[0]] = line_list[1]
    return lang_dict


# 传入 dict1（英文）、dict2（模组中的中文）、dict3（weblate上面的中文）
def lang_handle(dict1, dict2, dict3):
    dict_out = {}
    for k in dict1.keys():
        if k in dict3:
            dict_out[k] = dict3[k]
            continue
        elif k in dict2:
            dict_out[k] = dict2[k]
    return dict_out


# 判定哪些文件应该处理
def who_should_handle():
    change_mod_list = []
    # 通过 git 来获取更新信息
    os.system('git add .')
    # 抓取出新增的部分，因为只有增加的模组才需要 phi 重新导入
    string = os.popen(
        'git status | egrep -o "new file:(.*?)|modified:(.*?)"').read()
    # 正则抓取出有用的信息
    change_mod_list = re.findall(
        r'project/assets/(.*?)/lang/.*?.lang', string)
    # 剔除重复数据
    change_mod_list = list(set(change_mod_list))
    return change_mod_list


# 开始遍历文件了
file_list = who_should_handle()
for modid in file_list:
    dict_out = {}

    # 先判定 en_us.lang 是否存在
    if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(modid)):
        continue

    # 而后开始转换为 dict
    en_us_dict = lang_to_dict(
        'project/assets/{}/lang/en_us.lang'.format(modid))
    zh_cn_old_dict = lang_to_dict(
        'project/assets/{}/lang/zh_cn_old.lang'.format(modid))
    zh_cn_dict = lang_to_dict(
        'project/assets/{}/lang/zh_cn.lang'.format(modid))

    # 处理，得到最终的 dict
    dict_out = lang_handle(en_us_dict, zh_cn_old_dict, zh_cn_dict)

    # 写入文件
    with open('project/assets/{}/lang/zh_cn.lang'.format(modid), 'w') as f:
        for key in dict_out.keys():
            f.writelines(key + '=' + dict_out[key])

    # 剔除空 en_us.lang 文件
    if os.path.getsize('project/assets/{}/lang/en_us.lang'.format(modid) == 0):
        os.system('rm -rf project/assets/{}'.format(modid))
