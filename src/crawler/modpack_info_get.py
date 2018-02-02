import csv
import urllib.request
import urllib.error
import threading
import re
import yaml
import time


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
    MODPACK_PAGE = int_config_init(config['modpack_page'], 50)
    VERSION = config['version']
    BLACK_LIST = list_config_init(config['modpack_blacklist'])
    WHITE_LIST = list_config_init(config['modpack_whitelist'])

# 版本映射表
VERSION_DICT = {
    '1.7.10': '2020709689:4449',
    '1.8.9': '2020709689:5806',
    '1.9.4': '2020709689:6084',
    '1.10.2': '2020709689:6170',
    '1.11.2': '2020709689:6452',
    '1.12.2': '2020709689:6756'
}

ALL_URL_LIST = []


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


# 一个包含异常处理的信息抓取函数
def get_info(url, regex):
    page = download(url)
    info = re.findall(regex, str(page))
    if len(info) == 0:
        return None
    else:
        return info[0]


# 一个判定是否位于黑名单的函数
def is_black_list(url_name):
    if url_name in BLACK_LIST:
        return True
    else:
        return False


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
    # 获取 url name
    url = 'https://minecraft.curseforge.com/modpacks?filter-game-version=' + \
        VERSION_DICT.get(VERSION) + '&filter-sort=downloads&page=' + str(i + 1)
    main_page = download(url)
    url_name_list = re.findall(
        r'<a href="/projects/(.*?)">', str(main_page))

    # 获取 Project ID 和最新的 File ID
    for url_name in url_name_list:
        # 先判定是否位于黑名单中
        if is_black_list(url_name):
            continue

        # Project ID 获取
        modpack_url = 'https://minecraft.curseforge.com/projects/' + url_name
        project_id = get_info(
            modpack_url, r'<div class="info-data">(.*?)</div>')

        # file id 获取
        file_url = 'https://minecraft.curseforge.com/projects/' + url_name + \
            '/files?filter-game-version=' + VERSION_DICT.get(VERSION)
        file_id = get_info(
            file_url, r'class="overflow-tip twitch-link" href="/projects/.*?/files/(.*?)"')

        # 将 url_name, project_id, file_id 装入 list 中
        list = [url_name, project_id, file_id]
        ALL_URL_LIST.append(list)


# 白名单下载
def func_whitelist_dowload(url_name):
    # 先判定是否位于黑名单中
    if not is_black_list(url_name):
        # Project ID 获取
        modpack_url = 'https://minecraft.curseforge.com/projects/' + url_name
        project_id = get_info(
            modpack_url, r'<div class="info-data">(.*?)</div>')

        # file id 获取
        file_url = 'https://minecraft.curseforge.com/projects/' + url_name + \
            '/files?filter-game-version=' + VERSION_DICT.get(VERSION)
        file_id = get_info(
            file_url, r'class="overflow-tip twitch-link" href="/projects/.*?/files/(.*?)"')

        # 将 url_name, project_id, file_id 装入 list 中
        info_list = [url_name, project_id, file_id]
        ALL_URL_LIST.append(info_list)


# 多线程下载实例
def main_page_download():
    threads = []
    for i in range(MODPACK_PAGE):
        t = MultiThread(func_page_download, i, func_page_download.__name__)
        threads.append(t)

    for i in range(MODPACK_PAGE):
        threads[i].start()

    for i in range(MODPACK_PAGE):
        threads[i].join()


# 多线程下载白名单文件
def wiltelist_page_download():
    threads = []
    for i in range(len(WHITE_LIST)):
        t = MultiThread(func_whitelist_dowload,
                        WHITE_LIST[i], func_page_download.__name__)
        threads.append(t)

    for i in range(len(WHITE_LIST)):
        threads[i].start()

    for i in range(len(WHITE_LIST)):
        threads[i].join()


main_page_download()
wiltelist_page_download()

# 结果记入 csv 文件中
csv_time = time.strftime("%Y-%m-%d-%H-%M-%S", time.localtime())
with open('logs/modpacks/' + csv_time + '.csv', 'w') as c:
    csv_writer = csv.writer(c)
    csv_writer.writerow(["Url Name", "Project ID", "File ID"])
    for i in ALL_URL_LIST:
        csv_writer.writerow(i)
