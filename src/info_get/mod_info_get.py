import re
import threading
import time

import requests

from src.baka_init import *
from src.baka_utilities import *


# 获取模组信息的多线程类的构建
class ModpageInfoGet(threading.Thread):
    # 初始化
    # mpig_page_url：具体的页面
    def __init__(self, mpig_page_url):
        threading.Thread.__init__(self)
        self.url = mpig_page_url

    # 主体程序
    def run(self):
        # 正式爬取
        mpig_page = requests.get(
            "https://www.curseforge.com/minecraft/mc-mods/{}/files/all?filter-game-version={}".format(self.url, VERSION),
            headers=HEADERS, proxies=PROXIES).text

        # 正则抓取所有文件列表及其日期
        mpig_newest_file_id = re.findall(r'<a data-action="file-link" href="/minecraft/mc-mods/.*?/files/(\d+)">', mpig_page)

        # 判断数据存在后，存入数据
        if len(mpig_newest_file_id) > 0:
            MOD_INFO.append([self.url,  # 语义化 ID
                             int(mpig_newest_file_id[0])])  # 最新文件ID


def multi_thread_download(mod_list):
    # 开始对模组切片，进行多线程信息获取
    tmp_mod_list = list_slice(mod_list, THREADS_NUM)

    # 开始多线程下载
    for i in tmp_mod_list:
        logging.debug("多线程信息获取开始……")
        threads = []  # 存储实例化线程的 list

        # 装载线程
        for j in range(len(i)):
            tmp_t = ModpageInfoGet(i[j])  # 实例化临时线程
            threads.append(tmp_t)  # 存入实例化临时线程

        # 启动线程
        for j in range(len(i)):
            threads[j].start()
            # 延时 0.1 秒逐个启动线程
            time.sleep(0.1)

        # 等待线程结束
        for j in range(len(i)):
            threads[j].join()

        logging.debug("多线程信息获取结束")

def main():
    logging.info("==================  信息获取函数开始  ==================")

    # 提取上次更新的模组文件信息，等会用作对比更新用
    local_cache_mod_info = CURSOR.execute("SELECT * from MOD_INFO")
    for row in local_cache_mod_info:
        MOD_INFO_OLD.append([row[0], row[1]])
    logging.debug("上次模组文件信息已经提取")

    multi_thread_download(MOD_LIST)

    # 对比，算出增量更新的内容，方便后面进行下载
    for i in MOD_INFO:
        in_old = False  # 布尔值，判断是否在其中
        for j in MOD_INFO_OLD:
            # URL 相等时
            if i[0] == j[0]:
                # 文件 ID 变了
                if i[2] != j[2]:
                    MOD_DOWNLOAD.append(i)
                in_old = True  # 我在里面了
                break  # 既然 URL 相等了，那么后面不用比较了，进行下一个 URL 比较

        # 如果执行到这里还没 break，那说明没在老 INFO 里面
        if not in_old:
            MOD_DOWNLOAD.append(i)

    # 存储模组列表，存储之前先清空该表格
    CURSOR.execute("DELETE FROM MOD_INFO;")
    for i in MOD_INFO:
        CURSOR.execute("INSERT OR IGNORE INTO MOD_INFO (URL, FILE_ID) "
                       "VALUES ('{}', {});".format(i[0], i[1]))
    CONN.commit()

    # 存储需要下载的模组列表，存储之前先清空该表格
    CURSOR.execute("DELETE FROM MOD_DOWNLOAD;")
    for i in MOD_DOWNLOAD:
        CURSOR.execute("INSERT OR IGNORE INTO MOD_DOWNLOAD (URL, FILE_ID) "
                       "VALUES ('{}', {});".format(i[0], i[1]))
    CONN.commit()
    logging.info("数据存储完毕")

    logging.info("==================  信息获取函数结束  ==================")


if __name__ == '__main__':
    main()
