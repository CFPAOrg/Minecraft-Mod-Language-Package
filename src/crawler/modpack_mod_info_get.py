import csv
import urllib.request
import urllib.error
import threading
import re
import yaml
import time
import os
import json

DOWNLOAD_LIST = []
ALL_URL_LIST = []


# 定义一个能够初始化的函数，检验 int 数据
# config_var：传入的配置文件参数
# top_var：配置文件上限
def int_config_init(config_var, top_var):
    if type(config_var) != 'int':
        config_var = 1
    elif config_var <= 0 or config_var > top_var:
        config_var = 1
    return config_var


# 定义一个能够初始化的函数，检验 list 数据
# config_var：传入的配置文件参数
# top_var：配置文件上限
def list_config_init(config_var):
    # 判定是不是 list
    if type(config_var) != 'list':
        config_var = ['baka943']
    # list 是不是为空
    elif len(config_var) == 0:
        config_var = ['baka943']
    # list 里面每个元素是不是都是 str
    else:
        for i in range(len(config_var)):
            if type(config_var[i]) != 'str':
                config_var[i] = 'baka943'
    return config_var


# 读取配置文件
with open('config.yml', 'r') as f:
    config = yaml.load(f)
    THREAD_NUM = int_config_init(config['threads_num'], 943)
    BLACK_LIST = list_config_init(config['mod_blacklist'])
    VERSION = config['version']

# 版本映射表
VERSION_DICT = {
    '1.7.10': '2020709689:4449',
    '1.8.9': '2020709689:5806',
    '1.9.4': '2020709689:6084',
    '1.10.2': '2020709689:6170',
    '1.11.2': '2020709689:6452',
    '1.12.2': '2020709689:6756'
}


# 遍历 logs 文件夹下文件，按照文件名进行排序
def get_file_name(log_path):
    file_list = os.listdir(log_path)

    def custom_sort(string):
        string = string.replace('-', '')
        string = string.rstrip('.csv')
        return int(string)

    file_list.sort(key=custom_sort, reverse=True)
    return file_list


# 将 logs 文件夹下特定文件转换为 list 数据
def csv_to_list(log_path):
    with open(log_path + get_file_name(log_path)[0], 'r') as c:
        csv_list = list(csv.reader(c))
        return csv_list


# 下载列表调节，强制设置为线程的整数倍
def download_list_tweaker(download_list):
    left = THREAD_NUM - (len(DOWNLOAD_LIST) % THREAD_NUM)
    for i in range(left):
        download_list.append('baka943')     # 充满智慧与力量的数值
    return download_list


# 与 mod 日志对比函数，得出应该检索的 mod 信息
def list_should_download():
    # 获取 modpacks 中的 mod 列表
    # 读取 manifest.json 文件，将其转换为 list
    mod_list_1 = []
    for modpack in os.listdir('/tmp/modpacks/manifest/'):
        path = '/tmp/modpacks/manifest/{}/manifest.json'.format(modpack)
        with open(path, 'r') as f:
            manifest = json.load(f)
            for project in manifest['files']:
                mod_list_1.append(project['projectID'])
    mod_list_1 = list(set(mod_list_1))    # 剔除重复元素

    # 将其与 mod 爬取的做对比，防止重复下载
    # 现将 mod 中的日志读取为 mod_list_2
    mod_list_2 = csv_to_list('logs/mods/')

    # 是的，接下来是蛋疼至极的部分！！！
    # Python 的二维 list 不支持某一列索引！！！
    # 所以，我们需要遍历，导出一个索引
    list_index = []
    for n in range(len(mod_list_2)):
        list_index.append(mod_list_2[n][1])

    # 在将 mod_list_1 与 list_index 对比，剔除重复的，得到 mod_list_3
    mod_list_3 = []
    for i in mod_list_1:
        if str(i) not in list_index:
            mod_list_3.append(str(i))

    # 接下来，将 mod_list_5 拓展为线程的整数倍
    mod_list_3 = download_list_tweaker(mod_list_3)
    return mod_list_3


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


# 我们还需要一个能够获取 url name 的下载函数
def url_name_get(url, user_agent='baka943', num_retries=2):
    print('下载链接：' + url)
    headers = {'User-agent': user_agent}
    request = urllib.request.Request(url, headers=headers)
    try:
        url_name_full = urllib.request.urlopen(request).geturl()
        url_name_list = re.findall(
            r'https://minecraft.curseforge.com/projects/(.*)', url_name_full)
        if len(url_name_list) == 0:
            url_name = None
        elif url_name_list[0] not in BLACK_LIST:
            url_name = url_name_list[0]
        else:
            url_name = None
    except urllib.error.URLError as e:
        print('错误：' + e.reason)
        url_name = None
        if num_retries > 0:
            if hasattr(e, 'code') and 500 <= e.code < 600:
                return url_name_get(url, user_agent, num_retries - 1)
    return url_name


# 一个包含异常处理的信息抓取函数
def get_info(url, regex):
    page = download(url)
    info = re.findall(regex, str(page))
    if len(info) == 0:
        return None
    else:
        return info[0]


# 多线程
class MultiThread(threading.Thread):
    def __init__(self, func, args, name=''):
        threading.Thread.__init__(self)
        self.name = name
        self.func = func
        self.args = args

    def run(self):
        self.func(self.args)


# 页面下载
def func_page_download(i):
    project_id = DOWNLOAD_LIST[i]

    # url name 获取
    url = 'https://minecraft.curseforge.com/projects/' + DOWNLOAD_LIST[i]
    url_name = url_name_get(url)

    # file id 获取
    file_url = 'https://minecraft.curseforge.com/projects/' + project_id + \
        '/files?filter-game-version=' + VERSION_DICT.get(VERSION)
    file_id = get_info(
        file_url, r'class="button tip fa-icon-download icon-only" href="/projects/.*?/files/(.*?)/download"')

    # 将 url name, project_id, file_id 装入 list 中
    if url_name != None and file_id != None:
        list = [url_name, project_id, file_id]
        ALL_URL_LIST.append(list)


# 多线程下载实例
def main_mod_download(n):
    threads = []
    for m in range(THREAD_NUM):
        t = MultiThread(func_page_download, n + m,
                        func_page_download.__name__)
        threads.append(t)

    for m in range(THREAD_NUM):
        threads[m].start()

    for m in range(THREAD_NUM):
        threads[m].join()


# 最后就是获取完整列表了
DOWNLOAD_LIST = list_should_download()
for n in range(len(DOWNLOAD_LIST) // THREAD_NUM):
    main_mod_download(n * THREAD_NUM)

# 结果记入 csv 文件中
csv_time = time.strftime("%Y-%m-%d-%H-%M-%S", time.localtime())
with open('logs/modpacks/mods/' + csv_time + '.csv', 'w') as c:
    csv_writer = csv.writer(c)
    csv_writer.writerow(["Url Name", "Project ID", "File ID"])
    for i in ALL_URL_LIST:
        csv_writer.writerow(i)
