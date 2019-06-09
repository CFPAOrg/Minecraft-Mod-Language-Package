from src.baka_init import *
from src.lang_handle.lang_handle_main import is_properties_language_file


# 返回剔除 \n，\r 和空格的字符串
def process_string(ps_str_in):
    return ps_str_in.replace('\n', '').replace('\r', '').replace('\u0020', '')


# 删除空格、删除指定 key、强制修正注释的函数
def language_file_delete_and_fix(lfdaf_file_path):
    # 暂存语言文件的 list
    lfdaf_list = []

    # 读取主程序，只读取符合要求的行
    with open(lfdaf_file_path, "r", encoding="utf-8", errors="replace") as lfdaf_f:
        for lfdaf_i in lfdaf_f.readlines():
            # 如果是正常的语言文件部分
            if lfdaf_i is not None and not lfdaf_i.startswith('#') and '=' in lfdaf_i:
                lfdaf_il = lfdaf_i.split('=', 1)
                # 如果键部分在 DEL_KEY 中，不存入后面的 lfdaf_list 中即可；
                # 如果值部分为空，不存入后面的 lfdaf_list 中，这样就剔除了空值语言文件；
                if lfdaf_il[0] in DEL_KEY or process_string(lfdaf_il[1]) == '':
                    logging.debug("删除了不符合的空行或黑名单键：" + lfdaf_il[0])
                    continue
            # 在上一个基础上，现在获得的肯定就是注释了，为了搞掉哪些不符合标准 Minecraft 格式注释
            # 我们进一步判定其首字符是否以 # 开头，不为 # 开头的是不符合规范的注释
            # 接下来在判定其是否为空行，很明显不是的，强制手动为其首段加上 #
            elif lfdaf_i is not None and not lfdaf_i.startswith('#') and process_string(lfdaf_i) != '':
                lfdaf_i = '# ' + lfdaf_i
                logging.debug("处理了不规范注释：" + lfdaf_i)

            # 最后将规范格式存入 list 中
            lfdaf_list.append(lfdaf_i)

    # 然后将其书写成文件
    with open(lfdaf_file_path, "w", encoding="utf-8", errors="replace") as lfdaf_f:
        for lfdaf_i in lfdaf_list:
            lfdaf_f.writelines(lfdaf_i)


def main(pre_tmp_assets_dir):
    logging.info("==================  预处理程序开始  ==================")
    for pre_file in os.listdir(pre_tmp_assets_dir + "/assets/"):
        pre_en_us = pre_tmp_assets_dir + "/assets/" + pre_file + "/lang/en_us.lang"
        if os.path.isfile(pre_en_us):
            # properties 语言文件实在是太过难以处理，暂且搁置
            if not is_properties_language_file(pre_en_us):
                language_file_delete_and_fix(pre_en_us)
    logging.info("==================  预处理程序结束  ==================")


if __name__ == '__main__':
    main("../..")
