#!/usr/bin/python3
import pymysql
import os
import yaml
import sys

# 读取数据库密码用户
# 是的，open 函数不能识别 linux 下的 ～ 符号！
PATH_ = os.popen('echo $HOME').read().replace('\n', '')
with open('{}/.ssh/mysql.yml'.format(PATH_), 'r') as f:
    config = yaml.load(f)
    USER = config['user']
    PASSWD = config['passwd']


# 获取英文语言文件，处理得到一个 dict
def lang_to_dict(file_path):
    lang_dict = {}
    with open(file_path, 'r', errors='ignore') as f:
        for line in f.readlines():
            if line is not None and line[0] != '#' and line[0] != '/' and '=' in line:
                # 剔除行末尾 \n
                line = line.rstrip('\n')
                # 将可能破坏 SQL 语句的符号清除
                line = line.replace("'", "")
                line = line.replace('"', '')
                line_list = line.split('=', 1)
                word = line_list[1].split(' ')
                if 0 < len(word) <= 5:
                    lang_dict[line_list[0]] = word
    return lang_dict


# 获取中文语言文件，处理得到一个 dict
def lang_to_dict_zh(file_path):
    lang_dict = {}
    with open(file_path, 'r', errors='ignore') as f:
        for line in f.readlines():
            if line is not None and line[0] != '#' and line[0] != '/' and '=' in line:
                # 剔除行末尾 \n
                line = line.rstrip('\n')
                # 将可能破坏 SQL 语句的符号清除
                line = line.replace("'", "")
                line = line.replace('"', '')
                line_list = line.split('=', 1)
                if 0 < len(line_list[1]) <= 32:
                    lang_dict[line_list[0]] = line_list[1]
    return lang_dict


# 打开数据库连接
db = pymysql.connect(host='localhost', user=USER,
                     passwd=PASSWD, db='test', charset='utf8mb4')
# 创建一个游标对象 cursor
cursor = db.cursor()
# 如果表存在则删除
cursor.execute('DROP TABLE IF EXISTS LANG_DICT')

# 使用预处理语句创建表
# 限定只装入 16 字符汉字，256 字符英文
cursor.execute("""CREATE TABLE LANG_DICT (
         modid VARCHAR(32),
         en_us_1 VARCHAR(64),
         en_us_2 VARCHAR(64),
         en_us_3 VARCHAR(64),
         en_us_4 VARCHAR(64),
         en_us_5 VARCHAR(64),
         zh_cn VARCHAR(64))
         CHARSET='utf8mb4'""")

# 导入的数据 list
data_list = []
# 开始遍历文件了
for modid in os.listdir('../../project/assets'):
    # 先判定 en_us.lang 是否存在
    if not os.path.exists('../../project/assets/{}/lang/en_us.lang'.format(modid)):
        continue

    # 而后开始转换为 dict
    en_us_dict = lang_to_dict(
        '../../project/assets/{}/lang/en_us.lang'.format(modid))
    zh_cn_dict = lang_to_dict_zh(
        '../../project/assets/{}/lang/zh_cn.lang'.format(modid))

    # 开始写入数据库
    for k in zh_cn_dict.keys():
        if k in en_us_dict.keys():
            for i in range(5):
                try:
                    en_us_dict[k][i]
                except:
                    en_us_dict[k].append(' ')

            data_list.append('("{}", "{}", "{}", "{}", "{}", "{}", "{}")'.format(modid,
                                                                                 en_us_dict[k][0],
                                                                                 en_us_dict[k][1],
                                                                                 en_us_dict[k][2],
                                                                                 en_us_dict[k][3],
                                                                                 en_us_dict[k][4],
                                                                                 zh_cn_dict[k]))

# 生成 SQL 语句
sql = 'INSERT INTO LANG_DICT (modid, en_us_1,  en_us_2, en_us_3, en_us_4, en_us_5, zh_cn) ' \
      + 'VALUES {}'.format(','.join(data_list))
try:
    # 执行 SQL 语句
    cursor.execute(sql)
except:
    print(sql)
    sys.exit()

# commit 数据
db.commit()
# 关闭数据库连接
db.close()
