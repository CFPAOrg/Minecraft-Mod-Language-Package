#!/usr/bin/python3
# @Author TartaricAcid
# @Title 批量本地化更新工具
######################################

print("all_update_3 Script Loading")

import operator

# 读取文件
old = open("en_us.lang", 'r', encoding='UTF-8', errors='ignore')
new = open("zh_cn_out.lang", 'r', encoding='UTF-8', errors='ignore')
out = open("zh_cn_del.lang", 'w', encoding='UTF-8')

# 放置映射表
old_dict = dict()
new_dict = dict()

# 放置key，用以for循环查找
new_key = list()

for entry in old.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        old_dict[entry_list[0]] = entry_list[1]

for entry in new.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        new_key.append(entry_list[0])            # 空key文件为之后for循环查找提供参考
        new_dict[entry_list[0]] = entry_list[1]

for entry in new_key:
    try:
        if operator.eq(new_dict[entry], old_dict[entry]):
            pass
        else:
            out.writelines(entry + '=' + new_dict[entry])
    except:     # 接收异常，对英文key和英文value进行拼接
        out.writelines(entry + '=' + new_dict[entry])

old.close()
new.close()
out.close()

print("all_update_3 Script Stop Load")
