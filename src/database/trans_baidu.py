#!/usr/bin/python3
import urllib.request
import urllib.error
import urllib.parse
import os
import yaml
import random
import hashlib
import json

# 读取数据库密码用户
# 是的，open 函数不能识别 linux 下的 ～ 符号！
PATH_ = os.popen('echo $HOME').read().replace('\n', '')
with open('{}/.ssh/mysql.yml'.format(PATH_), 'r') as f:
    config = yaml.load(f)
    APPID = config['appid']
    KEY = config['secretKey']


# 一个拥有全面功能的下载函数
def download(url, user_agent='baka943', num_retries=2):
    print('下载链接：' + url)
    headers = {'User-agent': user_agent}
    request = urllib.request.Request(url, headers=headers)
    try:
        html = urllib.request.urlopen(request).read()
    except urllib.error.URLError as e:
        print('错误：' + e.reason)
        html = None
        if num_retries > 0:
            if hasattr(e, 'code') and 500 <= e.code < 600:
                return download(url, user_agent, num_retries - 1)
    return html


# 传入百度翻译需要的相关数据
base_url = 'https://fanyi-api.baidu.com/api/trans/vip/translate'
fromLang = 'en'
toLang = 'zh'
salt = random.randint(1, 65536)
zh_cn = {}  # 空 dict 用来放置读取的语言文件

# 开始读取英文文件
with open('en_us.lang', 'r', encoding='utf-8') as lang:
    for line_full in lang.readlines():
        # 剔除非语言文件部分
        if line_full is not None and line_full[0] != '#' and line_full[0] != '/' and '=' in line_full:
            line = line_full.split('=', 1)
            word = line[1].split(' ')  # 空格分词，判定个数
            if 0 < len(word) <= 4:  # 个数在 1~4 间参与翻译，因为长句往往翻译质量不佳
                q = line[1]  # 英文存入 url 中
                string = str(APPID) + q + str(salt) + KEY
                sign = hashlib.md5(string.encode('utf-8')).hexdigest()  # 计算 md5，这是 url 中必须的一步
                # 拼接成完整的 url，注意传入的翻译要转义
                fin_url = '{}?&q={}&from={}&to={}&appid={}&salt={}&sign={}'.format(base_url,
                                                                                   urllib.parse.quote(q),
                                                                                   fromLang,
                                                                                   toLang,
                                                                                   APPID,
                                                                                   str(salt),
                                                                                   str(sign))
                a = download(fin_url).decode('utf-8')  # 得到的是 byte 类型，所以要转义成 utf-8
                trans = json.loads(a)  # 返回的是 json 数据，我们调用 json 模块进行处理
                # 判定翻译的中文是不是空，不为空，装入 dict 中
                if len(trans['trans_result'][0]['dst']) != 0:
                    zh_cn[line[0]] = trans['trans_result'][0]['dst']

# 最后，写成中文文件
with open('zh_cn.lang', 'w', encoding='utf-8') as lang:
    for k, v in zh_cn.items():
        lang.writelines(k + '=' + v + '\n')
