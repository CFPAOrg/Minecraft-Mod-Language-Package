#!/bin/bash
#!/usr/bin/python3
# @Author TartaricAcid
# @Title 自动更新脚本主程序
######################################

# 记录操作的主目录，方便后面操作
PATH_MAIN="/root/943_Python/autocurse/"
cd "${PATH_MAIN}"

# 进行github pull
git pull

# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp

# 新建mods文件夹，放置爬虫爬下来的mod
mkdir mods

# 爬虫下载mod
python3 download.py

# 再pull一次，我总担心爬虫的时候又发生变动，毕竟爬虫速度目前还是比较慢的
git pull

# 这一块有一个奇怪的bug，如果在主目录下操作解压，整个解压会全部出错
# 考虑到1.12的特殊性，有的作者用小写，有的用大写
cd mods
for filename in `ls`
do
  unzip -o $filename assets/*/lang/en_US.lang -d ${PATH_MAIN}/assets-tmp/
  unzip -o $filename assets/*/lang/en_us.lang -d ${PATH_MAIN}/assets-tmp/
  unzip -o $filename assets/*/lang/zh_CN.lang -d ${PATH_MAIN}/assets-tmp/
  unzip -o $filename assets/*/lang/zh_cn.lang -d ${PATH_MAIN}/assets-tmp/
done
echo "完成语言文件解压"

# 记录操作的主目录下的资源包文件和提取出的语言文件地址，方便后面操作
PATH_MODS=${PATH_MAIN}/assets-tmp/assets
PATH_ASSETS=${PATH_MAIN}/assets

# 我管你大写还是小写，统统给我小写
# 中文？统统改成zh_cn_old.lang，用作冗余剔除的参考
# 鉴于mv命令的特殊性，改名和移动还是分两步走
# 下面先是改名
cd $PATH_MODS
for filename_mods in `ls`
do
  if [ -f "${PATH_MODS}/${filename_mods}/lang/en_US.lang" ];
  then
    echo "${filename_mods}模组的英文文件改写成小写"
    mv "${PATH_MODS}/${filename_mods}/lang/en_US.lang" "${PATH_MODS}/${filename_mods}/lang/en_us.lang"
    cd $PATH_MODS
  fi
  if [ -f "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" ];
  then
      echo "${filename_mods}模组的中文文件改写成小写并转换"
      mv "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn_old.lang"
      cd $PATH_MODS
      continue
  fi
  if [ -f "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" ];
  then
    echo "${filename_mods}模组的中文文件转换"
    mv "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn_old.lang"
    cd $PATH_MODS
    continue
  fi
  # 如果中文文件没有，就创建一个空文件
  # 这一块方便之后操作，毕竟比先用if判断文件是否存在要好用
  touch "${PATH_MODS}/${filename_mods}/lang/zh_cn_old.lang"
done

# 接下来是移动
# 遍历assets-tmp文件夹中所有子文件夹，对比assets文件夹中文件
# 如果有相同的，就强制cp覆盖过去
# 如果没有相同的，得新建文件夹，然后移动过去
cd $PATH_MODS
  for filename_mods in `ls`
  do
      cd $PATH_ASSETS
      for filename_assets in `ls`
      do
        if [ "$filename_mods" == "$filename_assets" ];
        then
          cp -f "${PATH_MODS}/${filename_mods}/lang/en_us.lang" "${PATH_ASSETS}/${filename_assets}/lang/en_us.lang"
          cp -f "${PATH_MODS}/${filename_mods}/lang/zh_cn_old.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang"
          break
        fi
      done
      if [ "$filename_mods" != "$filename_assets" ];
      then
        echo "${filename_mods}"
        mkdir -p "${PATH_ASSETS}/${filename_mods}/lang"
        cp -f "${PATH_MODS}/${filename_assets}/lang/en_us.lang" "${PATH_ASSETS}/${filename_mods}/lang/en_us.lang"
        cp -f "${PATH_MODS}/${filename_mods}/lang/zh_cn_old.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang"
        cd $PATH_MODS
      fi
done

# 我们现在有了给weblate用的en_us, zh_cn，还有剔除冗余用的zh_cn_old
# 接下来，需要将en_us, zh_cn_old混编（混编后命名为en_zh）
# 然后en_zh和zh_cn对比更新
cd $PATH_ASSETS
for filename_assets in `ls`
do
  if [ ! -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" ];
  then
    touch "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
  fi
  if [ -f "${PATH_ASSETS}/${filename_assets}/lang/en_us.lang" ];
  then
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/en_us.lang" "${PATH_MAIN}/en_us.lang"
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn.lang"
    cp -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn_old.lang" "${PATH_MAIN}/zh_cn_old.lang"
    cd $PATH_MAIN
    python3 all_update_1.py   # 第一步：en_us和zh_cn_old混编得到en_zh
    python3 all_update_2.py   # 第二步：en_zh和zh_cn对比更新得到zh_cn_out
    python3 all_update_3.py   # 第三步：zh_cn_out和en_us对比更新得到zh_cn_del
    cp -f "${PATH_MAIN}/zh_cn_del.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
  fi
  # 删错不必要的残留文件
  cd $PATH_MAIN
  rm *.lang
done

# 接下来，按照雪尼的提醒，剔除不需要放入weblate的mod
# 读取black.list文件
# 然后删除文件夹
for del_file in `cat black.list`
do
  cd $PATH_ASSETS
  for filename_assets in `ls`
  do
    if [ ${del_file} = ${filename_assets} ]
    then
      rm -rf "${del_file}"
    fi
  done
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 删掉mods文件，方便操作
rm -rf ./mods

# 生成统计数据
python3 info.py

cd "${PATH_MAIN}"

# 最后，进行 github 推送
git add .
commit_date=`date +%F`
git commit -m "Auto Update By Shell Script, Update Time: ${commit_date}"
git push
