import csv
import os
import threading
import urllib.error
import urllib.request

import yaml


# 定义一个能够初始化的函数
# config_var：传入的配置文件参数
# top_var：配置文件上限
def int_config_init(config_var, top_var):
    if str(type(config_var)) != '<class \'int\'>':
        config_var = 1
    elif config_var <= 0 or config_var > top_var:
        config_var = 1
    return config_var


# 读取配置文件
with open('config.yml', 'r') as f:
    config = yaml.load(f)
    THREAD_NUM = int_config_init(config['threads_num'], 943)


# list 数据的布尔操作
# 能够对比新旧两个 list 数据，返回新的 list 数据
def list_boolean_operation(list_old, list_new):
    list_processed = []
    for n in list_new:
        if n not in list_old and n[2] != None:
            list_processed.append(n)
    return list_processed


# 遍历 logs 文件夹下文件，按照文件名进行排序
def get_file_name():
    file_list = os.listdir('logs/modpacks/mods/')

    def custom_sort(string):
        string = string.replace('-', '')
        string = string.rstrip('.csv')
        return int(string)

    file_list.sort(key=custom_sort, reverse=True)
    return file_list


# 将 logs 文件夹下特定文件转换为 list 数据
def csv_to_list(i):
    with open('logs/modpacks/mods/' + get_file_name()[i], 'r') as c:
        csv_list = list(csv.reader(c))
        return csv_list


# 一个拥有全面功能的下载函数
def download(url, filename, num_retries=2):
    print('下载链接：' + url)
    try:
        urllib.request.urlretrieve(url, filename)
    except urllib.error.URLError as e:
        print('错误：' + e.reason)
        return False
    return True


# 多线程
class MultiThread(threading.Thread):
    def __init__(self, func, args, name=''):
        threading.Thread.__init__(self)
        self.name = name
        self.func = func
        self.args = args

    def run(self):
        self.func(self.args)


# 下载函数具体实现，通过传入整型数值，来下载对应的 mod
def func_mod_download(i):
    url = 'https://minecraft.curseforge.com/projects/{}/files/{}/download'.format(
        DOWNLOAD_LIST[i][0], DOWNLOAD_LIST[i][2])
    filename = '/tmp/mods/{}'.format(DOWNLOAD_LIST[i][0])
    download(url, filename)


# 多线程下载实例
def main_mod_download(n):
    threads = []
    for m in range(THREAD_NUM):
        t = MultiThread(func_mod_download, n + m, func_mod_download.__name__)
        threads.append(t)

    for m in range(THREAD_NUM):
        threads[m].start()

    for m in range(THREAD_NUM):
        threads[m].join()


# 下载列表调节，强制设置为线程的整数倍
def download_list_tweaker(download_list):
    left = THREAD_NUM - (len(DOWNLOAD_LIST) % THREAD_NUM)
    for i in range(left):
        baka_list = ['baka943', '999', '999']     # 充满智慧与力量的数值
        download_list.append(baka_list)
    return download_list


# 存放 mods 的临时文件夹创建
def make_temp_dir():
    if not os.path.exists('/tmp/mods'):
        os.mkdir('/tmp/mods')


# 最后就是下载了
make_temp_dir()
DOWNLOAD_LIST = list_boolean_operation(csv_to_list(1), csv_to_list(0))
download_list_tweaker(DOWNLOAD_LIST)
for n in range(len(DOWNLOAD_LIST) // THREAD_NUM):
    main_mod_download(n * THREAD_NUM)
