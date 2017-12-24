#!/usr/bin/python3
# @Author TartaricAcid
# @Title 批量本地化更新工具（增量更新版本）
######################################

print("add_update Script Loading")

import operator

# 读取文件
asset_old = open("zh_cn_old.lang", 'r', encoding='UTF-8')
asset_new = open("zh_cn_new.lang", 'r', encoding='UTF-8')
asset_zh = open("zh_cn.lang", 'w', encoding='UTF-8')

# 放置映射表
old_dict = dict()
new_dict = dict()

# 放置key，用以for循环查找
new_key = list()

for entry in asset_old.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        old_dict[entry_list[0]] = entry_list[1]

for entry in asset_new.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        new_key.append(entry_list[0])            # 空key文件为之后for循环查找提供参考
        new_dict[entry_list[0]] = entry_list[1]

for entry in new_key:
    try:
        if operator.eq(new_dict[entry], old_dict[entry]):
            pass
        else:
            asset_zh.writelines(entry + '=' + new_dict[entry])
    except:     # 接收异常，对英文key和英文value进行拼接
        asset_zh.writelines(entry + '=' + new_dict[entry])

asset_old.close()
asset_new.close()
asset_zh.close()

print("add_update Script Stop Load")
