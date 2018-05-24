#!/usr/bin/python3
# 这一块属于独立的模块，并不记入主程序
# 给 Travis CI 用的，用来剔除重复文件
# 同时将文件上传到七牛云

import os
import src.redundancy.redundancy
import qiniu
import hashlib

# 这里打包的是剔除冗余的版本
os.system('mv ./project-tmp/assets ./')
os.system('mv ./project-tmp/pack.mcmeta ./')
os.system('mv ./project-tmp/pack.png ./')
os.system(
    'zip -r -9 "Minecraft-Mod-Language-Modpack-Lite.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"')
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

# 生成 md5 文件
os.system('md5sum ./Minecraft-Mod-Language-Modpack.zip | cut -c1-32 > ./Minecraft-Mod-Language-Modpack.MD5')


# 多加一步，上传到七牛云
# 从环境变量获取 Access Key 和 Secret Key
access_key = os.getenv('Access_Key')
secret_key = os.getenv('Secret_Key')
# 构建鉴权对象
q = qiniu.Auth(access_key, secret_key)
# 要上传的空间
bucket_name = 'langpack'

# 上传到七牛后保存的文件名
key_1 = 'Minecraft-Mod-Language-Modpack.zip'
key_2 = 'Minecraft-Mod-Language-Modpack.MD5'
# 生成上传 Token，可以指定过期时间等
token_1 = q.upload_token(bucket_name, key_1, 600)
token_2 = q.upload_token(bucket_name, key_2, 600)
# 要上传文件的本地路径
local_file_1 = './Minecraft-Mod-Language-Modpack.zip'
local_file_2 = './Minecraft-Mod-Language-Modpack.MD5'

# 上传第一个文件
ret_1, info_1 = qiniu.put_file(token_1, key_1, local_file_1)
print(info_1)
assert ret_1['key'] == key_1
assert ret_1['hash'] == qiniu.etag(local_file_1)

#上传 MD5 文件
ret_2, info_2 = qiniu.put_file(token_2, key_2, local_file_2)
print(info_2)
assert ret_2['key'] == key_2
assert ret_2['hash'] == qiniu.etag(local_file_2)
