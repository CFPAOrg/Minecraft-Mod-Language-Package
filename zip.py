#!/usr/bin/python3
# 这一块属于独立的模块，并不记入主程序
# 给 Travis CI 用的，用来剔除重复文件

import os
import src.redundancy.redundancy

os.system('mv ./project-tmp/assets ./')
os.system('mv ./project-tmp/pack.mcmeta ./')
os.system('mv ./project-tmp/pack.png ./')
os.system('zip -r -9 "Minecraft-Mod-Language-Modpack.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"')
os.system('rm -rf ./assets')
os.system('rm -rf ./pack.mcmeta')
os.system('rm -rf ./pack.png')

os.system('rm -rf ./project-tmp')
