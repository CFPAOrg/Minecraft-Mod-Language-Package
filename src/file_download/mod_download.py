import threading
import time

import requests

from src.baka_init import *
from src.baka_utilities import *


class ModDownloader(threading.Thread):
    # 初始化
    # mod_downloader_url：具体的下载链接
    def __init__(self, mod_downloader_url, mod_downloader_filename, mod_downloader_tmp_dirs):
        threading.Thread.__init__(self)
        self.url = mod_downloader_url
        self.filename = mod_downloader_filename
        self.dirs = mod_downloader_tmp_dirs

    # 主体程序
    def run(self):
        with open(self.dirs + "/" + self.filename, 'wb') as mod_downloader_file:
            mod_downloader_file.write(requests.get(self.url, headers=HEADERS, proxies=PROXIES).content)
            logging.debug("文件已写入：" + mod_downloader_file.name)


def main(mod_download_tmp_dir):
    logging.info("==================  下载函数开始  ==================")

    # 先将数据凑成可用的下载链接，下载文件名
    tmp_download_url = []
    for i in MOD_DOWNLOAD:
        tmp_download_url.append(["https://minecraft.curseforge.com/projects/{}/files/{}/download".format(i[0], i[2]),
                                 i[0]])

    # 而后进行切片
    tmp_download_url_slice = list_slice(tmp_download_url, THREADS_NUM)

    logging.info("开始下载需要更新的模组")
    for i in tmp_download_url_slice:
        th = []
        for j in i:
            th.append(ModDownloader(j[0], j[1], mod_download_tmp_dir))
        for j in range(len(i)):
            th[j].start()
            time.sleep(0.5)
        for j in range(len(i)):
            th[j].join()

    logging.info("==================  下载函数结束  ==================")


if __name__ == '__main__':
    MOD_DOWNLOAD = [['wopper', 9999, 2456802, 1501179427],
                    ['spikes', 9999, 2456132, 1501050067],
                    ['ocean-floor-clay-sand-and-dirt', 9999, 2433720, 1497400177],
                    ['random-utilities', 9999, 2454583, 1500745478]]
    main("../../tmp_mods")
