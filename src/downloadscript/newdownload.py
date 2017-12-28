#!/usr/bin/python3
# @Author TartaricAcid FledgeXu
# @Credit asdflj
# @Title 批量模组下载工具
######################################

import time
import re
import queue
import threading
import datetime
import requests
from requests.utils import requote_uri

print("Download Script Loading")
starttime = datetime.datetime.now()
LOG_DICT = {}  # 记录更新的哈希表
COURSEFOGE_PAGES = 20  # 要下载curseforge的页数
GAME_VERSION = '1.12.2'  # 要下载的游戏版本
DOWNLOAD_COURSEFORGE_PAGE_THREADS = 5  # 允许几个线程同时下载
MAX_MOD_DOWNLOAD_THREADS = 20  # 最多允许同时几个线程获取mod的下载链接
MODID_QUEUE = queue.Queue()  # 记录modid用队列
MOD_INFO_QUEUE = queue.Queue()
# 对应不同版本的URL参数，留作备用
VERSION_LIST = {
    '1.7.10': '2020709689:4449',
    '1.8.9': '2020709689:5806',
    '1.9.4': '2020709689:6084',
    '1.10.2': '2020709689:6170',
    '1.11.2': '2020709689:6452',
    '1.12.2': '2020709689:6756'
}


class get_coursefogr_page(threading.Thread):
    def __init__(self, download_url, modidqueue):
        threading.Thread.__init__(self)
        self.url = download_url
        self.modidqueue = modidqueue

    def run(self):
        data = requests.request(
            method='get', url=self.url).text  # 得到courseforge页面原始数据
        modid = re.findall(r"href=\"/minecraft/mc-mods/(.*)/download\"", data)
        for i in modid:
            self.modidqueue.put(i)  # 将modid存入队列中


class get_mod_download_link(threading.Thread):
    def __init__(self, modidqueue, version_number, mod_info_queue):
        threading.Thread.__init__(self)
        self.modid = modidqueue.get()
        self.modidqueue = modidqueue
        self.version_number = version_number
        self.mod_info_queue = mod_info_queue

    def run(self):
        mod_download_page = "https://www.curseforge.com/minecraft/mc-mods/{}/files/?{}".format(
            self.modid, self.version_number)
        try:
            mod_dowload_page_raw = requests.get(
                requote_uri(mod_download_page)).text
        except OSError:
            self.modidqueue.put(self.modid)
            print("获取下载列表页面失败，将重新尝试")
            exit()
        project_file_id = re.findall(r"\"ProjectFileID\": (.*),",
                                     mod_dowload_page_raw)
        if len(project_file_id) != 0:
            raw_download_url = "https://www.curseforge.com/minecraft/mc-mods/{}/download/{}/file".format(
                self.modid, project_file_id[0])
            try:
                real_url = requests.request(
                    method='get', url=raw_download_url, allow_redirects=False)
            except OSError:
                self.modidqueue.put(self.modid)
                print("获取下载链接失败将会重新尝试")
                exit()
            real_url = real_url.headers.get('Location')
            print('''
            ###############################
            # 下载模组：{}
            # 下载地址：{}
            # 文件ID： {}
            # ###############################'''.format(
                self.modid, real_url, project_file_id[0]))
            self.mod_info_queue.put([self.modid, real_url, project_file_id[0]])
        else:
            print("{}可能是Alpha版本没有下载地址.".format(self.modid))


# 读取已经历史记录

with open('download.log', 'U', encoding='UTF-8') as download_log:
    for entry in download_log.readlines():
        if (entry is not None) and (entry[0] != '#') and ('=' in entry):
            entry_list = entry.split('=', 1)  # 依据等号切分日志文件条目
            LOG_DICT[entry_list[0]] = entry_list[1]

# 生成获取modid获取页面，并生成处理线程放入列表
DOWNLOAD_COURSEFORGE_PAGE_THREAD_LIST = []  # 列表:存放处理页面线程
for num in range(1, COURSEFOGE_PAGES + 1):
    url = ("https://www.curseforge.com/minecraft/mc-mods?{}"
           "&filter-sort=downloads&page={}").format(GAME_VERSION, str(num))
    DOWNLOAD_COURSEFORGE_PAGE_THREAD_LIST.append(
        get_coursefogr_page(url, MODID_QUEUE))

# 控制线程数，并多线程获取Modid
COUNTER = 0
while True:
    if (len(threading.enumerate()) <= DOWNLOAD_COURSEFORGE_PAGE_THREADS + 1
        ) and (COUNTER <= len(DOWNLOAD_COURSEFORGE_PAGE_THREAD_LIST) - 1):
        DOWNLOAD_COURSEFORGE_PAGE_THREAD_LIST[COUNTER].start()
        COUNTER = COUNTER + 1
    elif (len(threading.enumerate()) == 1) and (
            COUNTER > len(DOWNLOAD_COURSEFORGE_PAGE_THREAD_LIST) - 1):
        break

while True:
    if (not MODID_QUEUE.empty()) and (len(threading.enumerate()) <= MAX_MOD_DOWNLOAD_THREADS + 1):
        temp = get_mod_download_link(MODID_QUEUE,
                                     VERSION_LIST.get(GAME_VERSION),
                                     MOD_INFO_QUEUE)
        temp.start()
    elif (MODID_QUEUE.empty) and (len(threading.enumerate()) == 1):
        break

with open('download.log', 'w+', encoding='UTF-8') as download_log:
    download_log.writelines("# {}{}".format(time.strftime(
        "%Y-%m-%d %H:%M:%S", time.localtime()), "\n\n"))
    while not MOD_INFO_QUEUE.empty():
        modinfoinstance = MOD_INFO_QUEUE.get()
        try:
            if int(LOG_DICT[modinfoinstance[0]]) == int(modinfoinstance[2]):
                print("{} 不需要更新".format(modinfoinstance[0]))
            else:
                print("{} 已经更新".format(modinfoinstance[0]))
        except KeyError:
            print("{} 是新添加的Mod".format(modinfoinstance[0]))
        download_log.writelines("{}={}\n".format(
            modinfoinstance[0], modinfoinstance[2]))

endtime = datetime.datetime.now()

print("本次一共执行了 {} 秒".format((endtime - starttime).seconds))
