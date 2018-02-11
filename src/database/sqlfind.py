#!/usr/bin/python3
import pymysql
import os

# 打开数据库连接
db = pymysql.connect(host='localhost', user='',
                     passwd='', db='test', charset='utf8mb4')
# 创建一个游标对象 cursor
cursor = db.cursor()
# 如果表存在则删除
cursor.execute('DROP TABLE IF EXISTS TOTAL')

# 使用预处理语句创建表
# 限定只装入 64 字符汉字
cursor.execute("""CREATE TABLE TOTAL (
         zh_cn VARCHAR(64),
         fre INT)
         CHARSET='utf8mb4'""")

# 精彩绝伦的高频词查找，来自于 phi
# 亮点在于 sort | uniq -c | sort -bnr
a = os.popen(
    "grep '=' ../../project/assets/*/lang/zh_cn.lang | cut -d = -f 2 | grep -v '^\s*$' |"
    "sort | uniq -c | sort -bnr | head -500 | sed 's/^[][ ]*//g'")

# 导入数据库
for i in a.read().split('\n'):
    if len(i) != 0:
        zh_cn = i.split(' ', 1)[1]
        fre = i.split(' ', 1)[0]
        fre_sql = 'INSERT INTO TOTAL (zh_cn, fre) VALUES ("{}", {})'.format(zh_cn, fre)
        cursor.execute(fre_sql)
db.commit()

# 关闭数据库连接
db.close()
