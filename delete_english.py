#!/usr/bin/python3
# @Author TartaricAcid
# @Title 英文、非语言字符剔除工具
######################################

print("delete_english Script Loading")

import re
import os
import time

# 开始遍历 assets 文件夹
for root, dirs, files in os.walk("./assets", topdown=False):
    for name in files:
        # 找到符合这个正则匹配的语言文件
        modid = re.findall(r"./assets/(.*)/lang/zh_cn.lang",
                           os.path.join(root, name))

        # 不符合的会抛出异常，先用try语句包裹
        try:
            modname = modid[0]
        except:
            print("路径不存在")
            continue

        # 存储语言文件映射表
        zh_dict = dict()
        # 放置key，用以for循环查找
        zh_key = list()

        zh_file = open(
            "./assets/" + modname + "/lang/zh_cn.lang", 'r', encoding='UTF-8')

        # 这一块读取行数居然发生过一个错误，貌似是解码问题
        # 还是写个try except来避免吧

        try:
            # 开始遍历读取语言文件value
            for entry in zh_file.readlines():
                if entry != None and '=' in entry:
                    entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
                    zh_dict[entry_list[0]] = entry_list[1]  # 将语言文件全部写入映射表中
                    # 空key文件为之后for循环查找提供参考
                    zh_key.append(entry_list[0])

            zh_file.close()
        except:
            print(modid[0] + "编码有错")
            break

        # 重新打开语言文件，这次开始剔除英文文本
        zh_file = open(
            "./assets/" + modname + "/lang/zh_cn.lang", 'w', encoding='UTF-8')

        # 开始遍历分析字符串
        for entry in zh_key:
            is_chinese = False  # 记录是否为中文文本
            for charset in zh_dict[entry]:
                # 开始逐个分析字符串
                # 在 4e00 到 9fa5 之间为 20902 个基本汉字
                if u'\u4e00' <= charset <= u'\u9fa5':
                    is_chinese = True
                    break

            # 如果是中文，那就写入key
            if is_chinese:
                zh_file.writelines(entry + '=' + zh_dict[entry])

        zh_file.close()
