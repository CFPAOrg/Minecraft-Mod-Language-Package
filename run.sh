#! /bin/bash
#! /usr/bin/python3

# 进行github pull
git pull

# 记录操作的主目录，方便后面操作
PATH_MAIN=`pwd`

# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp
mkdir mods

# 爬虫下载mod
python3 download.py

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
cd $PATH_MODS
for filename_mods in `ls`
	do
		if [ -f "${PATH_MODS}/${filename_mods}/lang/en_US.lang" ]; then
			echo "${filename_mods}模组的英文文件改写成小写"
			mv "${PATH_MODS}/${filename_mods}/lang/en_US.lang" "${PATH_MODS}/${filename_mods}/lang/en_us.lang"
			cd $PATH_MODS
		fi
		if [ -f "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" ]; then
			echo "${filename_mods}模组的中文文件改写成小写"
			mv "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang"
			cd $PATH_MODS
		fi
done

# 将解压缩出来的语言文件中英文文本和中文文本对比更新
# 如果中文文件不存在，复制一份英文文本，并且重命名为zh_cn_out.lang
cd $PATH_MODS
for filename_mods in `ls`
	do
		if [ ! -f "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" ]; then
			echo "${filename_mods}"
			cp "${PATH_MODS}/${filename_mods}/lang/en_us.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn_out.lang"
			cd $PATH_MODS
		else
			echo "${filename_mods}"
			cp "${PATH_MODS}/${filename_mods}/lang/en_us.lang" "${PATH_MAIN}/en_us.lang"
			cp "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn.lang"
			cd ${PATH_MAIN}
			python3 all_update.py
			mv "${PATH_MAIN}/zh_cn_out.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn_out.lang"
			rm ${PATH_MAIN}/en_us.lang
			rm ${PATH_MAIN}/zh_cn.lang
			cd $PATH_MODS
		fi
done

# 遍历assets-tmp文件夹中所有子文件夹，对比assets文件夹中文件
# 如果有相同的，就对比更新语言文件
# 如果没有相同的，就将直接移动过去
cd $PATH_MODS
for filename_mods in `ls`
	do
		cd $PATH_ASSETS
		for filename_assets in `ls`
			do
				if [ "$filename_mods" == "$filename_assets" ]; then
					mv "${PATH_MODS}/${filename_mods}/lang/zh_cn_out.lang" "${PATH_MAIN}/en_us.lang"
					mv "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn.lang"
					cd ${PATH_MAIN}
					python3 all_update.py
					mv "${PATH_MAIN}/zh_cn_out.lang" "${PATH_ASSETS}/${filename_mods}/lang/zh_cn.lang"
					rm ${PATH_MAIN}/en_us.lang
					rm ${PATH_MAIN}/zh_cn.lang
					break
				fi
		done
		if [ "$filename_mods" != "$filename_assets" ]; then
			echo "${filename_mods}"
			mkdir -p "${PATH_ASSETS}/${filename_mods}/lang"
			mv "${PATH_MODS}/${filename_mods}/lang/zh_cn_out.lang" "${PATH_ASSETS}/${filename_mods}/lang/zh_cn.lang"
			cd $PATH_MODS
		fi
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp
mkdir assets-tmp

# 二次解压中文语言文件，进行冗余剔除
cd mods
for filename in `ls`
	do
		unzip -o $filename assets/*/lang/zh_CN.lang -d ${PATH_MAIN}/assets-tmp/
		unzip -o $filename assets/*/lang/zh_cn.lang -d ${PATH_MAIN}/assets-tmp/
	done
echo "完成中文语言文件解压"

# 我管你大写还是小写，统统给我小写
cd $PATH_MODS
for filename_mods in `ls`
	do
		if [ -f "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" ]; then
			echo "${filename_mods}模组的中文文件改写成小写"
			mv "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang"
			cd $PATH_MODS
		fi
done

# 遍历assets-tmp文件夹中所有子文件夹，对比assets文件夹中文件
# 如果有相同的，就对比更新语言文件
cd $PATH_MODS
for filename_mods in `ls`
	do
		cd $PATH_ASSETS
		for filename_assets in `ls`
			do
				if [ "$filename_mods" == "$filename_assets" ]; then
					mv "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn_old.lang"
					mv "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn_new.lang"
					cd ${PATH_MAIN}
					python3 delete_update.py
					mv "${PATH_MAIN}/zh_cn.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
					rm ${PATH_MAIN}/zh_cn_old.lang
					rm ${PATH_MAIN}/zh_cn_new.lang
					break
				fi
		done
done

# 判断文件是否存在且为空
# 不存在，或者大小为 0 就删掉
cd $PATH_ASSETS
for filename_assets in `ls`
	do
		if [ [! -s "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"] ]; then
			rm -rf "${PATH_ASSETS}/${filename_assets}"
		fi
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 删掉mods文件，方便操作
rm -rf ./mods

# 生成统计数据
python3 info.py

# 最后，进行 github 推送
git add .
commit_date=`date +%F`
git commit -m "Auto Update By Shell Script, Update Time: ${commit_date}"
git push
