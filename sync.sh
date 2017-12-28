#!/bin/bash
#!/usr/bin/python3
# @Author TartaricAcid
# @Title 自动同步脚本
# 是的，我要同步weblate上翻译的汉化项目
# 是的，我就要用shell套python
######################################

# 记录操作的主目录，方便后面操作
PATH_MAIN=`pwd`
PATH_ASSETS=${PATH_MAIN}/assets
PATH_WEBLATE=${PATH_MAIN}/weblate/assets

# python脚本下载
python3 sync.py

# 强制覆盖
cp -r -f ./weblate/* ./

# 我们现在有了给weblate用的en_us, zh_cn，还有剔除冗余用的zh_cn_old
# 接下来，需要将en_us, zh_cn_old混编（混编后命名为en_zh）
# 然后en_zh和zh_cn对比更新
cd $PATH_WEBLATE
for filename_assets in `ls`
do
  if [ ! -d "${PATH_ASSETS}/${filename_assets}/lang" ];
  then
    mkdir -p "${PATH_ASSETS}/${filename_assets}/lang"
  fi
  if [ ! -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" ];
  then
    touch "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
  fi
  if [ ! -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang" ];
  then
    touch "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang"
  fi
  if [ -f "${PATH_ASSETS}/${filename_assets}/lang/en_us.lang" ];
  then
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/en_us.lang" "${PATH_MAIN}/en_us.lang"
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn.lang"
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang" "${PATH_MAIN}/zh_cn_old.lang"
    cd $PATH_MAIN
    python3 all_update_1.py
    python3 all_update_2.py
    cp -f "${PATH_MAIN}/zh_cn_out.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
  fi
  # 删错不必要的残留文件
  cd $PATH_MAIN
  rm *.lang
done

# 删掉所有的英文文本
cd $PATH_MAIN
python3 delete_english.py

rm -rf ./weblate
