import shutil

from src.baka_init import *


def main(del_list_tmp_assets, del_list_project_dict):
    logging.info("==================  删除列表程序开始  ==================")
    for i in DEL_LIST:
        if os.path.exists(del_list_tmp_assets + "/assets/" + i):
            shutil.rmtree(del_list_tmp_assets + "/assets/" + i)
        if os.path.exists(del_list_project_dict + "/assets/" + i):
            shutil.rmtree(del_list_project_dict + "/assets/" + i)
    logging.info("==================  删除列表程序结束  ==================")


if __name__ == '__main__':
    main(TMP_ASSETS_DIR.name, "../..")
