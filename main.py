import src.file_download.mod_download
import src.info_get.mod_info_get
import src.info_get.mod_list_get
import src.lang_handle.lang_handle_copy
import src.lang_handle.lang_handle_del_list
import src.lang_handle.lang_handle_main
import src.lang_handle.lang_handle_preprocess
import src.lang_handle.lang_handle_unzip
import src.weblate.weblate_operation
from src.baka_init import *

if __name__ == '__main__':
    # 先进行 weblate 的 pull，commit，push 操作
    src.weblate.weblate_operation.main()

    # 然后依据配置文件，获取 curseforge 模组列表，部分整合模组列表等
    src.info_get.mod_list_get.main()

    # 在列表基础上获取模组相关文件信息
    src.info_get.mod_info_get.main()

    # 调用多线程下载工具，将需要更新的模组文件夹下载至临时文件夹
    src.file_download.mod_download.main(TMP_MODS_DIR.name)

    # 将模组中语言文件解压出来
    src.lang_handle.lang_handle_unzip.main(TMP_MODS_DIR.name, TMP_ASSETS_DIR.name)

    # 进行复制、重命名，文件补全操作
    src.lang_handle.lang_handle_copy.main("./project", TMP_ASSETS_DIR.name)

    # 进行预处理操作。旨在剔除空行，修正不规范注释，剔除黑名单 key
    src.lang_handle.lang_handle_preprocess.main(TMP_ASSETS_DIR.name)

    # 进行删除操作。旨在删除不需要放置进 weblate 的语言文件
    src.lang_handle.lang_handle_del_list.main(TMP_ASSETS_DIR.name, "./project")

    # 处理主程序，将语言文件更新，并返复制回 weblate
    src.lang_handle.lang_handle_main.main(TMP_ASSETS_DIR.name, "./project")
