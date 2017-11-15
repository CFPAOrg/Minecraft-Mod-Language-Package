#! /bin/bash
#! /usr/bin/lua5.2

# 记录操作的主目录，方便后面操作
PATH_MAIN=`pwd`

# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp

# 这一块有一个奇怪的bug，如果在主目录下操作解压，整个解压会全部出错
cd mods
for filename in `ls *.jar`
	do
		unzip $filename assets/*/lang/en_US.lang -d ${PATH_MAIN}/assets-tmp/
		unzip $filename assets/*/lang/zh_CN.lang -d ${PATH_MAIN}/assets-tmp/
	done
echo "完成语言文件解压"

# 记录操作的主目录下的资源包文件和提取出的语言文件地址，方便后面操作
cd ${PATH_MAIN}/assets-tmp/assets
PATH_MODS=`pwd`
cd ${PATH_MAIN}/assets
PATH_ASSETS=`pwd`

# 将解压缩出来的语言文件中英文文本和中文文本对比更新
# 如果中文文件不存在，复制一份英文文本，并且重命名为zh_CN-merged.lang
cd $PATH_MODS
for filename_mods in `ls`
	do
		if [ ! -f "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" ]; then
			echo "${filename_mods}"
			cp "${PATH_MODS}/${filename_mods}/lang/en_US.lang" "${PATH_MODS}/${filename_mods}/lang/zh_CN-merged.lang"
			cd $PATH_MODS
		else
			echo "${filename_mods}"
			cp "${PATH_MODS}/${filename_mods}/lang/en_US.lang" "${PATH_MAIN}/en_US.lang"
			cp "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang" "${PATH_MAIN}/zh_CN.lang"
			cd ${PATH_MAIN}
			lua Tool_Update.lua
			mv "${PATH_MAIN}/zh_CN-merged.lang" "${PATH_MODS}/${filename_mods}/lang/zh_CN-merged.lang"
			rm ${PATH_MAIN}/en_US.lang
			rm ${PATH_MAIN}/zh_CN.lang
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
					echo "替换汉化"
					mv "${PATH_MODS}/${filename_mods}/lang/zh_CN-merged.lang" "${PATH_MAIN}/en_US.lang"
					mv "${PATH_ASSETS}/${filename_assets}/lang/zh_CN.lang" "${PATH_MAIN}/zh_CN.lang"
					cd ${PATH_MAIN}
					lua Tool_Update.lua
					mv "${PATH_MAIN}/zh_CN-merged.lang" "${PATH_ASSETS}/${filename_mods}/lang/zh_CN.lang"
					rm ${PATH_MAIN}/en_US.lang
					rm ${PATH_MAIN}/zh_CN.lang
					break
				fi
		done
		if [ "$filename_mods" != "$filename_assets" ]; then
			echo "${filename_mods}"
			mkdir -p "${PATH_ASSETS}/${filename_mods}/lang"
			mv "${PATH_MODS}/${filename_mods}/lang/zh_CN-merged.lang" "${PATH_ASSETS}/${filename_mods}/lang/zh_CN.lang"
			cd $PATH_MODS
		fi
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 删掉mods文件，方便操作
rm -rf ./mods
