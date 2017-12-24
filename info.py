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

                    if zh_dict[entry_list[0]] != None:
                        for charset in zh_dict[entry_list[0]]:
                            # 开始逐个分析字符串
                            # 在 4e00 到 9fa5 之间为 20902 个基本汉字
                            if u'\u4e00' <= charset <= u'\u9fa5':
                                is_chinese = True
                                break
                    if is_chinese:
                        chinese = chinese + 1
                    else:
                        english = english + 1

            # 将分析得到的数据全部处理，放入 list 中
            info_list.append(modid[0] + "/" + str(total) +
                             "/" + str(english) + "/" + str(chinese))
        except:
            pass

# 然后排序，这样就能够得到按照字母排序的模组信息了
info_list.sort()

# 创建 index.html 文件
html = open("index.html", 'w', encoding='UTF-8')

# 写入头文件
html.writelines("<!DOCTYPE html><html lang=\"zh\"><head><meta charset=\"UTF-8\"><title>语言进度列表</title><meta name=\"viewport\" content=\"width=device-width,initial-scale=1\"><link rel=\"stylesheet\" href=\"css/index.css\"><link rel=\"stylesheet\" href=\"http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css\"><script src=\"http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js\"></script><script src=\"http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js\"></script></head><body><div class=\"container\">")

# 开始写入单独的<div>记录相关信息
# width, num 分别记录进度和序号
width, num = 0, 1
for entry in info_list:
    # 开始拆分字符串，读取出数据
    entry_list = entry.split("/", 3)

    html.write("<div class=\"mod\"><div class=\"progress progress-striped\"><div class=\"progress-bar progress-bar-success\"role=\"progressbar\"aria-valuenow=\"60\"aria-valuemin=\"0\"aria-valuemax=\"100\"style=\"width:")

    # 极个别模组处理后不存在语言文件，分母为0，强制限定其为100%
    if int(entry_list[1]) == 0:
        width = 100
    else:
        width = int(entry_list[3]) / int(entry_list[1]) * 100
    html.write(str(width))

    html.write(
        "%;\"><span class=\"sr-only\"></span></div></div><span class=\"label label-info\">")
    html.write("总计条目：" + entry_list[1])
    html.write("</span><span class=\"label label-primary\">")
    html.write("英文：" + entry_list[2])
    html.write("</span><span class=\"label label-success\">")
    html.write("中文：" + entry_list[3])
    html.write("</span><h3><span class=\"label label-default\">")
    html.write(str(num) + "</span>" + entry_list[0] + "</h3></div>")

    # 别忘了，序号加一
    num = num + 1

html.write("</div></body></html>")
