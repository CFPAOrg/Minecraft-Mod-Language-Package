#!/usr/bin/python3
import pymysql
import os
import yaml


def get_max_sub(str_1, str_2):
    # 生成一个二维矩阵
    mixer_list = [[0 for i in range(len(str_2) + 1)] for j in range(len(str_1) + 1)]
    max_length = 0  # 记录最大长度
    num = 0  # 记录字符串结尾位置
    for i in range(len(str_1)):
        for j in range(len(str_2)):
            if str_1[i] == str_2[j]:
                mixer_list[i + 1][j + 1] = mixer_list[i][j] + 1
                if mixer_list[i + 1][j + 1] > max_length:
                    max_length = mixer_list[i + 1][j + 1]
                    num = i + 1
    return str_1[num - max_length:num]


# 接下来分析一个长度不固定的字符串
# 传入一个 list，然后找出这几个字符串中最大的相似部分
def get_max_list(str_list):
    common_list = []  # 用来装相同字符串
    for n in range(len(str_list)):
        for m in range(n + 1, len(str_list)):
            common_list.append(get_max_sub(str_list[n], str_list[m]))
    # 找出最大重复
    index = list(set(common_list))  # 索引，通过两次变换就可以得到不重复索引，减少搜索量
    max_element = None  # 记录最大相似元素的容器
    max_num = 0  # 最大相似元素出现次数
    for s in index:
        # 索引中有空元素，需要剔除
        if s == '':
            continue
        fre = 0
        for r in common_list:
            if s == r:
                fre = fre + 1
        if fre > max_num:
            max_num = fre
            max_element = s
    print('出现次数：' + str(max_num))
    return max_element


# 读取数据库密码用户
# 是的，open 函数不能识别 linux 下的 ～ 符号！
PATH_ = os.popen('echo $HOME').read().replace('\n', '')
with open('{}/.ssh/mysql.yml'.format(PATH_), 'r') as f:
    config = yaml.load(f)
    USER = config['user']
    PASSWD = config['passwd']

# 打开数据库连接
db = pymysql.connect(host='localhost', user=USER,
                     passwd=PASSWD, db='test', charset='utf8mb4')
# 创建一个游标对象 cursor
cursor = db.cursor()

'''
# 如果表存在则删除
cursor.execute('DROP TABLE IF EXISTS DICT')
# 使用预处理语句创建表
# 限定只装入 32 字符汉字，512 字符英文
cursor.execute("""CREATE TABLE DICT (
         en_us VARCHAR(512),
         zh_cn VARCHAR(32))
         CHARSET='utf8mb4'""")
'''


# 查询函数，能够返回最匹配值
def sql_dict_find(str_find):
    list_ = []
    # 遍历数据库
    for col in range(5):
        sql = "SELECT * FROM LANG_DICT WHERE en_us_{}='{}'".format(col + 1, str_find)
        cursor.execute(sql)
        for e in cursor.fetchall():
            list_.append(e[6])
    return get_max_list(list_)


zh_cn = {}  # 空 dict 用来放置读取的语言文件
# 开始读取英文文件
with open('en_us.lang', 'r', encoding='utf-8') as lang:
    for line_full in lang.readlines():
        # 剔除非语言文件部分
        if line_full is not None and line_full[0] != '#' and line_full[0] != '/' and '=' in line_full:
            line = line_full.split('=', 1)
            word = line[1].split(' ')  # 空格分词，判定个数
            if 0 < len(word) <= 4:  # 个数在 1~4 间参与翻译，因为长句往往翻译质量不佳
                for c in word:
                    c = c.replace('\n', '')
                    c = c.replace(' ', '')
                    if sql_dict_find(c) is not None:
                        line[1] = line[1].replace(c, sql_dict_find(c))
                zh_cn[line[0]] = line[1].replace(' ', '')

# 最后，写成中文文件
with open('zh_cn_sql.lang', 'w', encoding='utf-8') as lang:
    for k, v in zh_cn.items():
        lang.writelines(k + '=' + v)