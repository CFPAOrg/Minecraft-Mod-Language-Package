#!/usr/bin/python3
# @Author TartaricAcid
# @Title 语言文件分析工具
######################################

print("info Script Loading")

import re
import os

# 存储语言文件映射表
zh_dict = dict()
# 存储分析信息
info_list = list()

# 开始遍历 assets 文件夹
for root, dirs, files in os.walk("./assets", topdown=False):
    for name in files:
        # 找到符合这个正则匹配的语言文件
        modid = re.findall(r"./assets/(.*)/lang/zh_cn.lang",
                           os.path.join(root, name))

        # 不符合的会抛出异常，先用try语句包裹
        try:
            zh_file = open(
                "./assets/" + modid[0] + "/lang/zh_cn.lang", 'r', encoding='UTF-8')

            # 分析数据记录初始化
            total = english = chinese = 0

            # 开始遍历读取语言文件value
            for entry in zh_file.readlines():
                if entry != None and '=' in entry:
                    entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
                    zh_dict[entry_list[0]] = entry_list[1]

                    total = total + 1   # 记录总条目
                    is_chinese = False  # 记录是否为中文文本
                    is_english = False  # 记录是否为英文文本

                    if zh_dict[entry_list[0]] != None:
                        for charset in zh_dict[entry_list[0]]:
                            # 开始逐个分析字符串
                            # 在 4e00 到 9fa5 之间为 20902 个基本汉字
                            if u'\u4e00' <= charset <= u'\u9fa5':
                                is_chinese = True
                                break
                            # 在 0041 到 005a, 0061 到 007a 之间为 26 个基本英文字母
                            elif (u'\u0041' <= charset <= u'\u005a') or (u'\u0061' <= charset <= u'\u007a'):
                                is_english = True
                    if is_chinese:
                        chinese = chinese + 1
                    elif is_english:
                        english = english + 1

            # 将分析得到的数据全部处理，放入 list 中
            info_list.append(modid[0] + "/" + str(total) +
                             "/" + str(english) + "/" + str(chinese))
        except:
            pass

# 然后排序，这样就能够得到按照字母排序的模组信息了
info_list.sort()

# 创建 process.md 文件
process = open("process.md", 'w', encoding='UTF-8')

# 写入头文件
process.writelines("| 序号 | modid | 总条目 | 未翻译条目 | 已翻译条目 | 翻译比重 | \n")
process.write("| :--: | :--: | :--: | :--: | :--: | :--: | \n")

# width, num 分别记录进度和序号
width, num = 0, 1
# 这三个用以统计全局数据
total_all, total_en, total_zh = 0, 0, 0

for entry in info_list:
    # 开始拆分字符串，读取出数据
    entry_list = entry.split("/", 3)

    # 先统计全局数据
    total_all = total_all + int(entry_list[1])
    total_en = total_en + int(entry_list[2])
    total_zh = total_zh + int(entry_list[3])

    # 极个别模组处理后不存在语言文件，分母为0，强制限定其为100%
    if int(entry_list[1]) == 0:
        width = 100
    else:
        width = (int(entry_list[1]) - int(entry_list[2])
                 ) / int(entry_list[1]) * 100
    width = round(width, 2)

    process.write(" | " + str(num) + " | " + entry_list[0] + " | " + entry_list[1] +
                  " | " + entry_list[2] + " | " + entry_list[3] + " | " + str(width) + "% | " + "\n")

    # 别忘了，序号加一
    num = num + 1

# 最后，行尾加上全局统计数据
process.write("### 总计词条数：" + str(total_all) + "\n")
process.write("### 英文条数：" + str(total_en) + "\n")
process.write("### 中文条数：" + str(total_zh) + "\n")
process.write(
    "### 完成率：" + str(round(((total_all - total_en) / total_all * 100), 2)) + "%\n")

process.close()
