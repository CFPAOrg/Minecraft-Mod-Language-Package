#!/usr/bin/python3
# 这一块属于独立的模块，并不记入主程序
# 给 Travis CI 用的，用来剔除重复文件

import os
import src.redundancy.redundancy

# 这里打包的是剔除冗余的版本
os.system('mv ./project-tmp/assets ./')
os.system('mv ./project-tmp/pack.mcmeta ./')
os.system('mv ./project-tmp/pack.png ./')
os.system('zip -r -9 "Minecraft-Mod-Language-Modpack-Lite.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"')
# 只需要剔除 assets 文件夹即可
os.system('rm -rf ./assets')

# 接下来是不剔除冗余保留版本的打包
# 处理主程序
for modid in os.listdir('project/assets'):
    # 先判断 zh_cn 存在不存在
    if not os.path.exists('project/assets/{}/lang/zh_cn.lang'.format(modid)):
        continue
    # 剔除 en_us
    os.system('rm -f project/assets/{}/lang/en_us.lang'.format(modid))
    # 再剔除 zh_cn_old
    os.system('rm -f project/assets/{}/lang/zh_cn_old.lang'.format(modid))
    # 最后判断文件是否为空
    if os.path.getsize('project/assets/{}/lang/zh_cn.lang'.format(modid)) == 0:
        os.system('rm -rf project/assets/{}'.format(modid))

# 最后打包
os.system('mv ./project/assets ./')
os.system('zip -r -9 "Minecraft-Mod-Language-Modpack.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"')
