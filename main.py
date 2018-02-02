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

# 清除黑名单文件夹
import src.redundancy.black_dir_del

# 再次清除先前的零时文件
os.system('rm -rf /tmp/mods')
os.system('rm -rf /tmp/modpacks')
