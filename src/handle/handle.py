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


# 开始遍历文件了
file_list = os.listdir('project/assets/')
for modid in file_list:
    dict_out = {}
    if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(modid)):
        continue
    en_us_dict = lang_to_dict(
        'project/assets/{}/lang/en_us.lang'.format(modid))
    zh_cn_old_dict = lang_to_dict(
        'project/assets/{}/lang/zh_cn_old.lang'.format(modid))
    zh_cn_dict = lang_to_dict(
        'project/assets/{}/lang/zh_cn.lang'.format(modid))
    dict_out = lang_handle(en_us_dict, zh_cn_old_dict, zh_cn_dict)
    with open('project/assets/{}/lang/zh_cn.lang'.format(modid), 'w') as f:
        for key in dict_out.keys():
            f.writelines(key + '=' + dict_out[key])
