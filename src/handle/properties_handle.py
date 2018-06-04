import os
import re
import javaproperties


# 专为带有 #PARSE_ESCAPES 注释的语言文件而诞生的处理程序


# 获取语言文件，处理得到一个 dict
def lang_to_dict(file_path):
    with open(file_path, 'r', errors='ignore') as f:
        lang_dict = javaproperties.load(f)
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
    # 存放带有 #PARSE_ESCAPES 注释的模组列表
    properties_mod_list = []
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
    # 判断是否有 #PARSE_ESCAPES 注释
    # 在 forge 中，有此注释的语言文件，会被严格按照 Java Properties 格式解析
    for change_mod in change_mod_list:
        # 没有英文文本的要剔除
        if not os.path.exists('project/assets/{}/lang/en_us.lang'.format(change_mod)):
            continue
        # 有 #PARSE_ESCAPES 注释的计算在内
        with open('project/assets/{}/lang/en_us.lang'.format(change_mod), 'r', errors='ignore') as lang:
            for line in lang.readlines():
                if '#PARSE_ESCAPES' in line:
                    properties_mod_list.append(change_mod)
    return properties_mod_list


# 开始遍历文件了
file_list = who_should_handle()
for modid in file_list:
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
    # 这一块不用 javaproperties 作者提供的轮子，因为它用的是 Latin-1 编码
    with open('project/assets/{}/lang/zh_cn.lang'.format(modid), 'w', errors='ignore') as f:
        f.writelines('#PARSE_ESCAPES\n')
        for key in dict_out.keys():
            # 先修正各种转义问题
            # key 中的 : 字符转义
            key_escape = key.replace(':', '\\:')
            # value 中的 \n 转义
            value_escape = dict_out[key].replace('\n', '\\n')
            # 然后写成文件
            f.writelines(key_escape + '=' + value_escape + '\n')

    # 剔除空 en_us.lang 文件
    if os.path.getsize('project/assets/{}/lang/en_us.lang'.format(modid) == 0):
        os.system('rm -rf project/assets/{}'.format(modid))
