#!/usr/bin/python3
# 这一块属于独立的模块，并不记入主程序
# 给 Travis CI 用的，用来剔除重复文件
# 同时将文件上传到七牛云

import logging
import os

import qiniu

if __name__ == '__main__':
    # 日志初始化
    logging.basicConfig(
        level=logging.DEBUG,
        format="[%(asctime)s] [%(threadName)s/%(levelname)s] [%(filename)s]: %(message)s",
        datefmt="%H:%M:%S"
    )

    # 打包处理主程序
    for modid in os.listdir('project/assets'):
        # 各个语言文件路径构建
        zh_cn_path = 'project/assets/{}/lang/zh_cn.lang'.format(modid)
        zh_cn_old_path = 'project/assets/{}/lang/zh_cn_old.lang'.format(modid)
        en_us_path = 'project/assets/{}/lang/en_us.lang'.format(modid)
        en_us_old_path = 'project/assets/{}/lang/en_us_old.lang'.format(modid)

        # 剔除 en_us
        os.system('rm -rf {}'.format(en_us_path))
        # 剔除 en_us_old
        os.system('rm -rf {}'.format(en_us_old_path))
        # 剔除 zh_cn_old
        os.system('rm -rf {}'.format(zh_cn_old_path))

        # zh_cn 存在，且文件为空
        if os.path.isfile(zh_cn_path) and os.path.getsize(zh_cn_path) == 0:
            os.system('rm -rf {}'.format(zh_cn_path))

    os.system('mv ./project/assets ./out')  # 移动资源包文件夹到主目录下
    os.system('mv ./project/pack.mcmeta ./out')  # 移动 pack.mcmeta 文件到主目录下
    os.system('mv ./project/pack.png ./out')  # 移动 pack.png 到主目录下
    os.system('cp ./database/asset_map.json ./out/assets/i18nmod/asset_map') # 将 asset_map 作为资源文件放入资源包

    # 打包“资源包，资源包 meta 文件，资源包图标，说明，许可证”
    #os.system('zip -r -9 "Minecraft-Mod-Language-Modpack.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"')

    # 上传到七牛云
    # 从环境变量获取 Access Key 和 Secret Key
    access_key = os.getenv('Access_Key')
    secret_key = os.getenv('Secret_Key')
    
    if access_key and secret_key:
        # 构建鉴权对象
        q = qiniu.Auth(access_key, secret_key)

        # 要上传的空间
        bucket_name = 'langpack'
        # 上传到七牛后保存的文件名
        key = 'Minecraft-Mod-Language-Modpack.zip'
        # 生成上传 Token，可以指定过期时间等
        token = q.upload_token(bucket_name, key, 120)
        # 要上传文件的本地路径
        localfile = './Minecraft-Mod-Language-Modpack.zip'
        # 将文件放入对象，进行上传
        ret, info = qiniu.put_file(token, key, localfile)

        logging.info(info)

        # 断言这两个返回值，确保上传的文件名和哈希值与本地一致
        assert ret['key'] == key
        assert ret['hash'] == qiniu.etag(localfile)

        # 刷新七牛云文件缓存
        cdn_manager = qiniu.CdnManager(q)
        # 需要刷新的文件链接
        urls = [
            'http://downloader.meitangdehulu.com/Minecraft-Mod-Language-Modpack.zip'
        ]
        # 刷新链接
        refresh_url_result = cdn_manager.refresh_urls(urls)
        logging.info(refresh_url_result)
