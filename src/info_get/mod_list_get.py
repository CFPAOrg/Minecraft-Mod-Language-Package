import re
import threading
import time

import requests

from src.baka_init import *


# 获取模组信息的多线程类的构建
class ModInfoGet(threading.Thread):
    # 初始化
    # mig_page_num：具体的页数
    # mode：模式（1：curseforge 模组区；2：feed the beast 整合区）
    def __init__(self, mig_page_num, mig_mode):
        threading.Thread.__init__(self)
        self.num = mig_page_num
        self.mode = mig_mode

    # 主体程序
    def run(self):
        # 正式爬取
        if self.mode == 1:
            mig_page = requests.get(
                "https://minecraft.curseforge.com/mc-mods"
                "?filter-game-version={}&filter-sort=5&page={}".format(VERSION, self.num),
                headers=HEADERS,
                proxies=PROXIES).text

            # 正则抓取所有模组列表
            mig_list = re.findall(r'<a href="/projects/(.*?)">', mig_page)
            MOD_LIST.extend(mig_list)

        if self.mode == 2:
            modpack_info_get_page = requests.get(
                "https://www.feed-the-beast.com/modpacks"
                "?filter-game-version={}&filter-sort=5&page={}".format(VERSION, self.num),
                headers=HEADERS,
                proxies=PROXIES).text

            # 正则抓取所有整合列表
            modpack_info_get_list = re.findall(r'<a href="/projects/(.*?)">', modpack_info_get_page)
            MODPACK_LIST.extend(modpack_info_get_list)


class ModpackModInfoGet(threading.Thread):
    # 初始化
    # mig_page：具体的页面
    def __init__(self, mmig_id):
        threading.Thread.__init__(self)
        self.id = mmig_id

    # 主体程序
    def run(self):
        # 此处混有 FTB 和 CurseForge 的包，两者实际上 URL 不太相同，但是爬虫部分可以通用
        # 不妨通过找到相同之处，然后稍作修改即可
        url_var = "www.feed-the-beast.com"  # 这个变量决定 URL
        if self.id in MODPACK_WHITELIST:
            url_var = "minecraft.curseforge.com"

        # 正式爬取
        mmig_page = requests.get(
            "https://{}/projects/{}/files?filter-game-version={}".format(url_var, self.id, VERSION),
            headers=HEADERS,
            proxies=PROXIES).text

        # 正则抓取该页面最新版整合
        mmig_list = re.findall(
            r'class="overflow-tip twitch-link" href="/projects/.*?/files/(\d+)"', mmig_page)

        # 提取出模组列表
        if len(mmig_list) != 0:
            mmig_file_page = requests.get("https://{}/projects/{}/files/{}".format(url_var, self.id, mmig_list[0]),
                                          headers=HEADERS,
                                          proxies=PROXIES).text

            # 正则抓取整合所使用的模组列表
            mmig_modlist = re.findall(r'<a href="/projects/(\d+)">', mmig_file_page)

            # 将数字 ID 翻译成语义化 ID
            for mmig_i in mmig_modlist:
                # 先转换下类型（否则后面的判定会因为类型不匹配而出现错误）
                mmig_i = int(mmig_i)

                # 转置映射表，因为要通过数字 ID 获取语义化 ID
                # 使用 copy 来复制 dict，否则可能会因为多线程原因发生 dictionary changed size during iteration 错误
                mmig_new_dict = {mmig_v: mmig_k for mmig_k, mmig_v in URL_ID_MAP.copy().items()}

                # asdflj 的列表并不完备，所有需要进一步检查列表的不完备性
                if mmig_i not in mmig_new_dict.keys():
                    # 获取重定向连接
                    mmig_url = requests.get("https://www.feed-the-beast.com/projects/{}".format(mmig_i),
                                            headers=HEADERS, proxies=PROXIES).url
                    # 正则抓取处语义化 ID
                    mmig_match = re.findall(r"/projects/(.*?)$", mmig_url)
                    # 判定抓取情况，进行存储
                    if len(mmig_match) > 0:
                        logging.debug("源表中不存在的映射：" + str(mmig_match))
                        mmig_new_dict[mmig_i] = mmig_match[0]
                        # 别忘记这个数据
                        URL_ID_MAP[mmig_match[0]] = mmig_i

                # 判定之前的模组列表中是否已经存在此模组，而后才进行装入
                # 发现可能会存入空数据，所有再进行一步判定
                if mmig_new_dict[mmig_i] not in MOD_LIST and len(mmig_new_dict[mmig_i]) > 0:
                    MOD_LIST.append(mmig_new_dict[mmig_i])


def main():
    logging.info("==================  模组列表获取函数开始  ==================")

    # 下面是逐个多线程获取信息的部分
    th_list = []  # 放置线程的 list
    # 模组页面多线程
    for num in range(1, MOD_PAGE + 1):
        # 逐次放入线程
        th_list.append(ModInfoGet(num, 1))
    for th in th_list:
        # 延时 0.5 秒逐个启动线程
        th.start()
        time.sleep(0.5)
    for th in th_list:
        # 回收线程
        th.join()

    # 整合页面多线程
    th_list.clear()  # 打扫干净屋子再请客
    for num in range(1, MODPACK_PAGE + 1):
        # 逐次放入线程
        th_list.append(ModInfoGet(num, 2))
    for th in th_list:
        # 延时 0.5 秒逐个启动线程
        th.start()
        time.sleep(0.5)
    for th in th_list:
        # 回收线程
        th.join()

    # 整合中模组列表
    th_list.clear()  # 打扫干净屋子再请客
    # 从 asdflj 的 api 处获取文字 ID 和语义化 ID 的映射表
    # 从而方便获取整合中的模组列表
    # 此网站现已失效
    # URL_ID_MAP.update(requests.get("https://mc.meitangdehulu.com/message/mods_url_map"
    #                               "?api_key=" + ASDFLJ_API_KEY).json()["data"])
    # logging.info("从 asdflj 源中成功获取映射表")

    # 本地缓存的映射表，装入 URL_ID_MAP 中
    local_cache_map = CURSOR.execute("SELECT URL, ID from URL_ID_MAP")
    for row in local_cache_map:
        #if row[0] not in URL_ID_MAP.keys():
            # logging.debug("服务端 API 中不存在的映射：" + str(row))
        URL_ID_MAP[row[0]] = row[1]

    # 存入整合白名单
    MODPACK_LIST.extend(MODPACK_WHITELIST)
    logging.info("白名单整合已添加：" + str(MODPACK_WHITELIST))

    # 剔除整合黑名单
    for i in MODPACK_LIST.copy():
        if i in MODPACK_BLACKLIST:
            MODPACK_LIST.remove(i)
    logging.info("黑名单整合已剔除：" + str(MODPACK_BLACKLIST))

    for modpack in MODPACK_LIST:
        # 逐次放入线程
        th_list.append(ModpackModInfoGet(modpack))
    for th in th_list:
        # 延时 0.5 秒逐个启动线程
        th.start()
        time.sleep(0.5)
    for th in th_list:
        # 回收线程
        th.join()

    # 添加白名单
    MOD_LIST.extend(MOD_WHITELIST)
    logging.info("白名单已经添加进模组列表中：" + str(MOD_WHITELIST))

    # 开始剔除黑名单
    for i in MOD_LIST.copy():
        if i in MOD_BLACKLIST:
            MOD_LIST.remove(i)
    logging.info("黑名单模组列表已剔除：" + str(MOD_BLACKLIST))

    # 开始执行数据存储，出现错误则回滚
    try:
        # 存储模组列表
        for i in MOD_LIST:
            CURSOR.execute("INSERT OR IGNORE INTO MOD_LIST (URL) "
                           "VALUES ('{}');".format(i))
        CONN.commit()

        # 存储映射表
        for k, v in URL_ID_MAP.items():
            # API 获取的数据有可能为空，判定一下
            if len(k) > 0:
                CURSOR.execute("INSERT OR IGNORE INTO URL_ID_MAP (URL, ID) "
                               "VALUES ('{}', {});".format(k, v))
        CONN.commit()

        # 存储模组列表
        for i in MODPACK_LIST:
            CURSOR.execute("INSERT OR IGNORE INTO MODPACK_LIST (URL) "
                           "VALUES ('{}');".format(i))
        CONN.commit()
        logging.info("数据存储完毕")
    except sqlite3.Error as sql_error:
        CONN.rollback()
        logging.fatal("数据存储失败：" + str(sql_error))

    logging.info("==================  信息获取函数结束  ==================")


if __name__ == '__main__':
    main()
