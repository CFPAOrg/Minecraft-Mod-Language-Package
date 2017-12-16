#! /bin/bash
#! /usr/bin/lua5.2

# 记录操作的主目录，方便后面操作
PATH_MAIN=`pwd`

# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp

# 这一块有一个奇怪的bug，如果在主目录下操作解压，整个解压会全部出错
# 考虑到1.12的特殊性，有的作者用小写，有的用大写
cd mods
for filename in `ls *.jar`
	do
		unzip $filename assets/*/lang/en_US.lang -d ${PATH_MAIN}/assets-tmp/
		unzip $filename assets/*/lang/en_us.lang -d ${PATH_MAIN}/assets-tmp/
		unzip $filename assets/*/lang/zh_CN.lang -d ${PATH_MAIN}/assets-tmp/
		unzip $filename assets/*/lang/zh_cn.lang -d ${PATH_MAIN}/assets-tmp/
	done
echo "完成语言文件解压"

# 记录操作的主目录下的资源包文件和提取出的语言文件地址，方便后面操作
PATH_MODS=${PATH_MAIN}/assets-tmp/assets
PATH_ASSETS=${PATH_MAIN}/assets

# 我管你大写还是小写，统统给我大写
cd $PATH_MODS
for filename_mods in `ls`
	do
		if [ -f "${PATH_MODS}/${filename_mods}/lang/en_us.lang" ]; then
			echo "${filename_mods}模组的英文文件改写成大写"
			mv "${PATH_MODS}/${filename_mods}/lang/en_us.lang" "${PATH_MODS}/${filename_mods}/lang/en_US.lang"
			cd $PATH_MODS
		fi
		if [ -f "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" ]; then
			echo "${filename_mods}模组的中文文件改写成大写"
			mv "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" "${PATH_MODS}/${filename_mods}/lang/zh_CN.lang"
			cd $PATH_MODS
		fi
done

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

# 我管你大写还是小写，统统给我大写
cd $PATH_ASSETS
for filename_assets in `ls`
	do
		if [ -f "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" ]; then
			echo "${filename_assets}模组的中文文件改写成大写"
			mv "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_CN.lang"
			cd $PATH_ASSETS
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

# 最后，统统变回小写
cd $PATH_ASSETS
for filename_assets in `ls`
	do
		if [ -f "${PATH_ASSETS}/${filename_assets}/lang/zh_CN.lang" ]; then
			echo "${filename_assets}模组的中文文件改写成小写"
			mv "${PATH_ASSETS}/${filename_assets}/lang/zh_CN.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
			cd $PATH_ASSETS
		fi
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 我想应该没有比我还傻的了，懒得改动以前的代码，重新再来一遍吧
# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp

# 这一块有一个奇怪的bug，如果在主目录下操作解压，整个解压会全部出错
# 考虑到1.12的特殊性，有的作者用小写，有的用大写
cd mods
for filename in `ls *.jar`
	do
		unzip $filename assets/*/lang/zh_CN.lang -d ${PATH_MAIN}/assets-tmp/
		unzip $filename assets/*/lang/zh_cn.lang -d ${PATH_MAIN}/assets-tmp/
	done
echo "完成语言文件解压"


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
# 对比中文文件，只记录增加的部分
cd $PATH_MODS
for filename_mods in `ls`
 do
	 cd $PATH_ASSETS
	 for filename_assets in `ls`
		 do
			 # 很奇怪的问题，有些mod会莫名其妙存在minecraft文件夹
			 if [ "$filename_mods" == "$filename_assets" ] && [ "$filename_assets" != "minecraft" ]; then
				 sed -i 's/\r//g' "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang"
				 diff -u -B "${PATH_MODS}/${filename_mods}/lang/zh_cn.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" | grep ^\+ > "${PATH_ASSETS}/${filename_assets}/lang/diff.lang"
				 sed -i 's/^[+]*//g' "${PATH_ASSETS}/${filename_assets}/lang/diff.lang"
				 rm "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
				 mv "${PATH_ASSETS}/${filename_assets}/lang/diff.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
				 break
			 fi
	 done
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 删掉mods文件，方便操作
rm -rf ./mods
