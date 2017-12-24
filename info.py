#!/usr/bin/python3
# @Author TartaricAcid
# @Title 语言文件分析工具
######################################

print("info Script Loading")

import re
import os

zh_dict = dict()
info_list = list()

for root, dirs, files in os.walk("./assets", topdown=False):
    for name in files:
        modid = re.findall(r"./assets/(.*)/lang/zh_cn.lang", os.path.join(root, name))
        try:
            zh_file = open("./assets/" + modid[0] + "/lang/zh_cn.lang", 'r', encoding='UTF-8')
            total = english = chinese = 0

            for entry in zh_file.readlines():
                if entry != None and '=' in entry:
                    entry_list = entry.split('=', 1)        # 依据等号切分语言文件条目
                    zh_dict[entry_list[0]] = entry_list[1]

                    total = total + 1
                    is_chinese = False

                    if zh_dict[entry_list[0]] != None:
                        for charset in zh_dict[entry_list[0]]:
                            if u'\u4e00' <= charset <= u'\u9fff':
                                is_chinese = True
                                break
                    if is_chinese:
                        chinese = chinese + 1
                    else:
                        english = english + 1

            info_list.append(modid[0] + "/" + str(total) + "/" +  str(english) + "/" + str(chinese))
        except:
            pass

info_list.sort()

html = open("index.html", 'w', encoding='UTF-8')
html.writelines("<!DOCTYPE html><html lang=\"zh\"><head><meta charset=\"UTF-8\"><title>语言进度列表</title><meta name=\"viewport\" content=\"width=device-width,initial-scale=1\"><link rel=\"stylesheet\" href=\"css/index.css\"><link rel=\"stylesheet\" href=\"http://cdn.static.runoob.com/libs/bootstrap/3.3.7/css/bootstrap.min.css\"><script src=\"http://cdn.static.runoob.com/libs/jquery/2.1.1/jquery.min.js\"></script><script src=\"http://cdn.static.runoob.com/libs/bootstrap/3.3.7/js/bootstrap.min.js\"></script></head><body><div class=\"container\">")

width, num = 0, 1
for entry in info_list:
    entry_list = entry.split("/", 3)

    html.write("<div class=\"mod\"><div class=\"progress progress-striped\"><div class=\"progress-bar progress-bar-success\"role=\"progressbar\"aria-valuenow=\"60\"aria-valuemin=\"0\"aria-valuemax=\"100\"style=\"width:")

    if int(entry_list[1]) == 0:
        width = 100;
    else:
        width = (int(entry_list[3])/int(entry_list[1])*100)
    html.write(str(width))

    html.write("%;\"><span class=\"sr-only\"></span></div></div><span class=\"label label-info\">")
    html.write("总计条目：" + entry_list[1])
    html.write("</span><span class=\"label label-primary\">")
    html.write("英文：" + entry_list[2])
    html.write("</span><span class=\"label label-success\">")
    html.write("中文：" + entry_list[3])
    html.write("</span><h3><span class=\"label label-default\">")
    html.write(str(num) + "</span>" + entry_list[0] + "</h3></div>")

    num = num + 1

html.write("</div></body></html>")
