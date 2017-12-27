#!/usr/bin/python3
# @Author TartaricAcid
# @Title 批量本地化更新工具
######################################

print("all_update_1 Script Loading")

# 读取文件
assets_en = open("en_us.lang", 'r', encoding='UTF-8')
assets_zh = open("zh_cn_old.lang", 'r', encoding='UTF-8')
assets_out = open("en_zh.lang", 'w', encoding='UTF-8')

# 放置中英文映射表
en_dict = dict()
zh_dict = dict()

# 放置英文空key，用以for循环查找
en_key = list()

for entry in assets_en.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        en_key.append(entry_list[0])            # 空key文件为之后for循环查找提供参考
        en_dict[entry_list[0]] = entry_list[1]

for entry in assets_zh.readlines():
    if entry != None and entry[0] != '#' and entry[0] != '/' and '=' in entry:
        entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
        zh_dict[entry_list[0]] = entry_list[1]

for entry in en_key:
    try:        # 如果给定的英文key在中文映射表中不存在，抛出异常
        assets_out.writelines(entry + '=' + zh_dict[entry])
    except:     # 接收异常，对英文key和英文value进行拼接
        assets_out.writelines(entry + '=' + en_dict[entry])

assets_en.close()
assets_zh.close()
assets_out.close()

print("all_update_1 Script Stop Load")
