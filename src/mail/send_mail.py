#!/usr/bin/python3
import yaml
import time
import os
import base64
import re
from smtplib import SMTP_SSL

# 读取配置文件
with open('config.yml', 'r') as f:
    config = yaml.load(f)
    send_list = config['email']

# 从加密过的字节码文件中获取 Gmail 邮箱密码
PASSWD = os.popen('cat ~/.ssh/password').read().replace("\n", "")
PASSWD = str.encode(PASSWD)
for i in range(15):
    PASSWD = base64.b64decode(PASSWD)
PASSWD = re.findall('b\'(.*?)\'', str(PASSWD))[0]

# 开始写入发件邮箱、收件邮箱、发件主题、时间头文件
from_ = 'bakabaka943@gmail.com'
to_ = send_list
time_ = time.strftime("%Y-%m-%d %H:%M", time.localtime())
headers = [
    'From: %s' % from_,
    'To: %s' % ', '.join(to_),
    'Subject: Weblate 仓库更新提醒：' + time_,
]

# 接下来开始写信件主体
body = []
with open('/tmp/email.txt', 'r') as email:
    for line in email.readlines():
        body.append(line)

# 拼凑成整个邮件
msg = '\r\n\r\n'.join(('\r\n'.join(headers), '\r\n'.join(body)))

# 开始用 SMTP/SSL 进行信件传输
s = SMTP_SSL('smtp.gmail.com', 465)
s.login(from_, PASSWD)
s.sendmail(from_, to_, msg)
s.quit
