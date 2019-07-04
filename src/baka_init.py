import logging
import os
import sqlite3
import tempfile
import json

import yaml

# 日志初始化
logging.basicConfig(
    level=logging.DEBUG,
    format="[%(asctime)s] [%(threadName)s/%(levelname)s] [%(filename)s]: %(message)s",
    datefmt="%H:%M:%S"
)

# 版本映射表
VERSION_DICT = {
    '1.7.10': '2020709689:4449',
    '1.8.9': '2020709689:5806',
    '1.9.4': '2020709689:6084',
    '1.10.2': '2020709689:6170',
    '1.11.2': '2020709689:6452',
    '1.12': '1738749986:628',
    '1.12.2': '2020709689:6756'
}

# 用变量暂存数据
MOD_LIST = []  # 存储所有需要维护的模组列表
MODPACK_LIST = []  # 存储所有需要维护的整合列表
URL_ID_MAP = {}  # 存储 URL ID -> 数字 ID 的映射表
MOD_INFO_OLD = []  # 存储上次更新的模组详细文件信息
MOD_INFO = []  # 存储最新的所有需要维护的模组详细文件信息
MOD_DOWNLOAD = []  # 存储本次更新需要重下的模组
ASSET_MAP = {} # 存储 modid -> asset domain 的映射表

ASSET_MAP_FILE = './database/asset_map.json'
MOD_LIST_FILE = './database/mod_list.json'

# 从环境变量中获取私密数据
WEBLATE_TOKEN = os.environ.get("WEBLATE_TOKEN")
ASDFLJ_API_KEY = os.environ.get("ASDFLJ_API_KEY")

# 爬虫 UA
HEADERS = {
    'User-Agent': 'Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) '
                  'Chrome/55.0.2883.103 Safari/537.36'
}

# 代理 IP
PROXIES = {
    # "http": "http://127.0.0.1:1080",
    # "https": "http://127.0.0.1:1080"
}

# 读取配置文件
with open("./config.yml", "r", encoding="UTF-8") as c:
    config_y = yaml.load(c)

    VERSION = VERSION_DICT[str(config_y['version'])]  # 爬取版本

    MOD_WHITELIST = config_y['mod_whitelist']  # 白名单列表
    MOD_BLACKLIST = config_y['mod_blacklist']  # 黑名单列表
    MODPACK_WHITELIST = config_y['modpack_whitelist']  # 整合包白名单
    MODPACK_BLACKLIST = config_y['modpack_blacklist']  # 整合包黑名单

    MOD_PAGE = config_y['mod_page']  # 爬取页数
    MODPACK_PAGE = config_y['modpack_page']  # FTB 整合爬取页数
    THREADS_NUM = config_y['threads_num']

    DEL_LIST = config_y['del_list']
    DEL_KEY = config_y['del_key']

    logging.info("配置文件读取完毕")

# 连接数据库
# 开始连接数据库
CONN = sqlite3.connect("./database/data.db")
logging.info("连接数据库成功")

# 创建游标
CURSOR = CONN.cursor()
logging.info("游标创建成功")

# 创建 URL -> ID 映射表
CURSOR.execute(
    "CREATE TABLE IF NOT EXISTS URL_ID_MAP("
    "URL TEXT PRIMARY KEY,"
    "ID INTEGER NOT NULL"
    ");")
CONN.commit()

# 创建整合列表
CURSOR.execute(
    "CREATE TABLE IF NOT EXISTS MODPACK_LIST("
    "URL TEXT PRIMARY KEY"
    ");")
CONN.commit()

# 创建整合列表
CURSOR.execute(
    "CREATE TABLE IF NOT EXISTS MOD_INFO("
    "URL TEXT PRIMARY KEY,"
    "FILE_ID INTEGER NOT NULL"
    ");")
CONN.commit()

# 创建应当下载的模组列表
CURSOR.execute(
    "CREATE TABLE IF NOT EXISTS MOD_DOWNLOAD("
    "URL TEXT PRIMARY KEY,"
    "ID INTEGER NOT NULL,"
    "FILE_ID INTEGER NOT NULL,"
    "UPLOAD_DATE INTEGER NOT NULL"
    ");")
CONN.commit()
logging.info("找到或创建成功所需要的表")

# 加载 ASSET_MAP
# 没有使用 SQL ，使用外部的 JSON 存储，考虑到 ASSET_MAP 会在其他地方被使用
if os.path.exists(ASSET_MAP_FILE):
    with open(ASSET_MAP_FILE) as f:
        ASSET_MAP = json.load(f)

# 模组列表也用 JSON 吧
if os.path.exists(MOD_LIST_FILE):
    with open(MOD_LIST_FILE) as f:
        MOD_LIST = json.load(f)

# 创建临时文件夹
# 放置模组的临时文件夹
TMP_MODS_DIR = tempfile.TemporaryDirectory()
# 放置解压出来的资源包的临时文件夹
TMP_ASSETS_DIR = tempfile.TemporaryDirectory()


def sys_exit():
    # 退出数据库
    CONN.close()

    # 显示清除临时文件夹
    TMP_MODS_DIR.cleanup()
    TMP_ASSETS_DIR.cleanup()
