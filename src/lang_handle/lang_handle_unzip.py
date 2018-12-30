import os
import re
import zipfile

from src.baka_init import *


# 解压获取语言文件的解压函数
def unzip(unzip_file_name, unzip_path_mods, unzip_path_assets):
    with zipfile.ZipFile(unzip_path_mods + "/" + unzip_file_name, "r") as z:
        logging.info("开始解压 " + z.filename + " 文件")
        # 遍历文件列表
        for i in z.filelist:
            # 找出所有的中英文语言文件
            if re.match(r'assets/.*?/lang/(en_us|en_US|zh_cn|zh_CN)\.lang', i.filename):
                # 因为统一需要小写文件名，同时有复杂需求：
                # en_us.lang -> 保持不变
                # zh_cn.lang -> zh_cn_old.lang
                # 所以此次需要尝试替换下字符串
                zip_tmp_file_path = unzip_path_assets + "/" + i.filename.lower().replace("zh_cn.lang", "zh_cn_old.lang")
                # 剔除最后 11 字符，这样正好获取得到了文件夹路径
                zip_tmp_dir_path = unzip_path_assets + "/" + i.filename[:-11]

                # 先判定文件夹在不在，不在的话创建文件夹
                # exist_ok 用来跳过文件夹存在错误
                if not os.path.exists(zip_tmp_dir_path):
                    os.makedirs(zip_tmp_dir_path, exist_ok=True)

                # 开始将文件解压，提取出来
                with z.open(i.filename) as f:
                    # 同时增加 errors 参数，如果有那种瞎编码的作者，错误编码字符会被问号替换
                    with open(zip_tmp_file_path, "wb") as tmp:
                        # 强制重写编码，防止某些作者另辟蹊径
                        tmp.write(f.read())


def main(path_mods, path_assets):
    logging.info("==================  解压部分开始  ==================")
    # 开始遍历模组临时文件夹，解压得到内部的语言文件
    for zf in os.listdir(path_mods):
        # 如果是 zip 文件，进行解压
        if zipfile.is_zipfile(path_mods + "/" + zf):
            unzip(zf, path_mods, path_assets)
    logging.info("==================  解压部分结束  ==================")


if __name__ == '__main__':
    main("../../tmp_mods", "../../tmp_assets")
