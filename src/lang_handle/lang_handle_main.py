from distutils import dir_util

import javaproperties

from src.baka_init import *


# 读取普通语言文件，处理成 dict
def normal_language_file_to_dict(nlftd_file_path):
    nlftd_dict = {}
    with open(nlftd_file_path, "r", encoding="utf-8", errors="replace") as nlftd_f:
        for nlftd_line in nlftd_f.readlines():
            if nlftd_line is not None and not nlftd_line.startswith("#") and "=" in nlftd_line:
                nlftd_list = nlftd_line.split("=", 1)
                nlftd_dict[nlftd_list[0]] = nlftd_list[1]
    return nlftd_dict


# 普通语言文件的书写
def normal_language_file_write(nlfw_file_path, nlfw_dict):
    # 获取 key
    nlfw_key = list(nlfw_dict.keys())
    # key 进行排序
    nlfw_key.sort()

    # 写成语言文件
    with open(nlfw_file_path, "w", encoding="utf-8", errors="replace") as nlfw_f:
        for nlfw_i in nlfw_key:
            nlfw_f.writelines(nlfw_i + "=" + nlfw_dict[nlfw_i])


# 读取带有 #PARSE_ESCAPES 的语言文件，处理成 dict
def properties_language_file_to_dict(plftd_file_path):
    with open(plftd_file_path, "r", encoding="utf-8", errors="replace") as plftd_f:
        plftd_dict = javaproperties.load(plftd_f)
    return plftd_dict


# 带有 #PARSE_ESCAPES 的语言文件的书写
def properties_language_file_write(plfw_file_path, plfw_dict):
    # 获取 key
    plfw_key = list(plfw_dict.keys())
    # key 进行排序
    plfw_key.sort()

    # 写成语言文件
    with open(plfw_file_path, "w", encoding="utf-8", errors="replace") as plfw_f:
        # 先写标识符 #PARSE_ESCAPES
        plfw_f.writelines("#PARSE_ESCAPES\n")

        # 而后逐个写入
        for nlfw_i in plfw_key:
            # 需要对 key 内的特殊字符转义
            nlfw_i_replace = nlfw_i.replace(":", "\\:").replace("=", "\\=")
            nlfw_v_replace = plfw_dict[nlfw_i].replace("\n", "\\n")
            # 而后才写入
            plfw_f.writelines(nlfw_i_replace + "=" + nlfw_v_replace + "\n")


# 判定一个文件是否包含 #PARSE_ESCAPES
def is_properties_language_file(iplf_file_path):
    with open(iplf_file_path, "r", encoding="utf-8", errors="replace") as iplf_f:
        # 逐行读取文本
        for iplf_i in iplf_f.readlines():
            # 如果存在此关键词，直接结束函数，返回 True
            if "#PARSE_ESCAPES" in iplf_i:
                return True
        # 逐行遍历完毕仍未发现此关键词，说明不存在，返回 False
        return False


# 判定语言文件类型，然后将其转换成 dict 的函数
def check_language_file_type_and_to_dict(clftatd_file_path):
    if is_properties_language_file(clftatd_file_path):
        return properties_language_file_to_dict(clftatd_file_path)
    else:
        return normal_language_file_to_dict(clftatd_file_path)


# 判定语言文件类型，然后将其写成语言文件
def check_language_file_type_and_write(clftaw_file_path, clftaw_dict):
    if is_properties_language_file(clftaw_file_path):
        properties_language_file_write(clftaw_file_path, clftaw_dict)
    else:
        normal_language_file_write(clftaw_file_path, clftaw_dict)


# 将输入的四个 dict 处理成我们想要的东西
def four_dict_handle(fdh_dict_en, fdh_dict_en_old, fdh_dict_zh, fdh_dict_zh_old):
    # 变量初始化
    fdh_dict_return_dict = {}

    # 一个排查了半天的 bug，需要 copy 备用 dict
    # 因为替换的 key 还有可能在后面再次被使用
    zh_index = fdh_dict_zh.copy()
    zh_old_index = fdh_dict_zh_old.copy()

    # 开始遍历 en_us，以其作为蓝本
    for fdh_ek, fdh_ev in fdh_dict_en.items():
        # 如果 key 不同，value 却相同，重写 key
        for fdh_eok, fdh_eov in fdh_dict_en_old.items():
            if fdh_ek != fdh_eok and fdh_ev.lower().replace("\u0020", "").replace("\n", "") \
                    == fdh_eov.lower().replace("\u0020", "").replace("\n", ""):
                # 对应中文替换
                if fdh_eok in fdh_dict_zh.keys() and fdh_eok in zh_index.keys():
                    fdh_dict_zh[fdh_ek] = zh_index[fdh_eok]
                    # 别忘记删除旧的 key-value 对
                    del fdh_dict_zh[fdh_eok]
                if fdh_eok in fdh_dict_zh_old.keys() and fdh_eok in zh_old_index.keys():
                    fdh_dict_zh_old[fdh_ek] = zh_old_index[fdh_eok]
                    # 别忘记删除旧的 key-value 对
                    del fdh_dict_zh_old[fdh_eok]

        # 依据最新版 en_us 处理成可用的 dict
        # zh_cn 优先级高于 zh_cn_old，所以 zh_cn 在后面
        if fdh_ek in fdh_dict_zh_old.keys():
            fdh_dict_return_dict[fdh_ek] = fdh_dict_zh_old[fdh_ek]
        if fdh_ek in fdh_dict_zh.keys():
            fdh_dict_return_dict[fdh_ek] = fdh_dict_zh[fdh_ek]

    return fdh_dict_return_dict


def main(handle_assets_path, handle_project_path):
    logging.info("==================  主体处理程序开始  ==================")
    for i in os.listdir(handle_assets_path + "/assets"):
        logging.info("正在处理 " + i + " 文件夹……")

        # 构建各个需要处理的文件路径
        en_us_path = handle_assets_path + "/assets/" + i + "/lang/en_us.lang"
        en_us_old_path = handle_assets_path + "/assets/" + i + "/lang/en_us_old.lang"
        zh_cn_path = handle_assets_path + "/assets/" + i + "/lang/zh_cn.lang"
        zh_cn_old_path = handle_assets_path + "/assets/" + i + "/lang/zh_cn_old.lang"

        # 开始获取处理成 dict
        en_us_dict = check_language_file_type_and_to_dict(en_us_path)
        en_us_old_dict = check_language_file_type_and_to_dict(en_us_old_path)
        zh_cn_dict = check_language_file_type_and_to_dict(zh_cn_path)
        zh_cn_old_dict = check_language_file_type_and_to_dict(zh_cn_old_path)

        # 处理得到我们想要的数据
        zh_cn_out_dict = four_dict_handle(en_us_dict, en_us_old_dict, zh_cn_dict, zh_cn_old_dict)
        check_language_file_type_and_write(zh_cn_path, zh_cn_out_dict)

        # 记得销毁 dict，否则可能存在冲突
        en_us_dict.clear()
        en_us_old_dict.clear()
        zh_cn_dict.clear()
        zh_cn_old_dict.clear()

    dir_util.copy_tree(handle_assets_path + "/assets", handle_project_path + "/assets")
    logging.info("==================  主体处理程序结束  ==================")


if __name__ == '__main__':
    main("../../tmp_assets", "../../project")
