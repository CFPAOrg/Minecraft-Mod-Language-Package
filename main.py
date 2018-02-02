#!/usr/bin/python3
import os
import yaml

# 清除先前的零时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')

# mod 信息抓取
import src.crawler.mod_info_get

# modpack 信息抓取、下载、解压
import src.crawler.modpack_info_get
import src.crawler.modpack_downloader
import src.unzip.modpack_unzip

# modpack 中的 mod 信息抓取
import src.crawler.modpack_mod_info_get

# 开始下载 mod
import src.crawler.mod_downloader
import src.crawler.modpack_mod_downloader

# 最后，解压语言文件
import src.unzip.mod_unzip

# 开始处理语言文件
import src.handle.handle

# 再次清除先前的零时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')


# 定义一个能够初始化的函数，检验 list 数据
# config_var：传入的配置文件参数
# top_var：配置文件上限
def list_config_init(config_var):
    # 判定是不是 list
    if str(type(config_var)) != '<class \'list\'>':
        config_var = ['baka943']
    # list 是不是为空
    elif len(config_var) == 0:
        config_var = ['baka943']
    # list 里面每个元素是不是都是 str
    else:
        for i in range(len(config_var)):
            if str(type(config_var[i])) != '<class \'str\'>':
                config_var[i] = 'baka943'
    return config_var


# 开始检索 del list 删除
# 读取配置文件
with open('config.yml', 'r') as f:
    config = yaml.load(f)
    DEL_LIST = list_config_init(config['del_list'])

# 开始强制删除对应文件夹
for i in DEL_LIST:
    os.system('rm -rf ./project/assets/' + i)
