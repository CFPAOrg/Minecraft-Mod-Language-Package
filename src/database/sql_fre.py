#!/usr/bin/python3
import pymysql
import os
import yaml

# 读取数据库密码用户
# 是的，open 函数不能识别 linux 下的 ～ 符号！
PATH_ = os.popen('echo $HOME').read().replace('\n', '')
with open('{}/.ssh/mysql.yml'.format(PATH_), 'r') as f:
    config = yaml.load(f)
    USER = config['user']
    PASSWD = config['passwd']
    IGNORE = config['ignore']  # 忽略列表，是一个 list

# 高频词的统计总会有一些东西来捣乱
# 所有我们需要分两次，一次不剔除，一次剔除干扰项
db = pymysql.connect(host='localhost', user=USER,
                     passwd=PASSWD, db='test', charset='utf8mb4')
cursor = db.cursor()
# 如果表存在则删除
cursor.execute('DROP TABLE IF EXISTS TOTAL')
cursor.execute('DROP TABLE IF EXISTS TOTAL_DEL')

# 使用预处理语句创建表
# 限定只装入 64 字符汉字
cursor.execute("""CREATE TABLE TOTAL (
         zh_cn VARCHAR(64),
         fre INT)
         CHARSET='utf8mb4'""")
cursor.execute("""CREATE TABLE TOTAL_DEL (
         zh_cn VARCHAR(64),
         fre INT)
         CHARSET='utf8mb4'""")


def import_sql(sql_name):
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
            fre_sql = 'INSERT INTO {} (zh_cn, fre) VALUES ("{}", {})'.format(sql_name, zh_cn, fre)
            cursor.execute(fre_sql)
    db.commit()


# 不剔除的查找
import_sql('TOTAL')

# 剔除查找，方法很简单，改名
# 先判断 IGNORE 是否为空
if len(IGNORE) != 0:
    # 遍历开始改名
    for n in IGNORE:
        if os.path.exists('../../project/assets/{}/lang/zh_cn.lang'.format(n)):
            os.system('mv ../../project/assets/{}/lang/zh_cn.lang ../../project/assets/{}/lang/zh_cn'.format(n, n))
    import_sql('TOTAL_DEL')
    # 别忘了改回来
    for n in IGNORE:
        if os.path.exists('../../project/assets/{}/lang/zh_cn'.format(n)):
            os.system('mv ../../project/assets/{}/lang/zh_cn ../../project/assets/{}/lang/zh_cn.lang'.format(n, n))


# 关闭数据库连接
db.close()
