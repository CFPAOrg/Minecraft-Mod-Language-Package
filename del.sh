#! /bin/bash

# 记录操作的主目录，方便后面操作
PATH_MAIN=`pwd`

# 新建assets-tmp文件夹，放置临时从mod包中解压的语言文件
mkdir assets-tmp

# 这一块有一个奇怪的bug，如果在主目录下操作解压，整个解压会全部出错
# 考虑到1.12的特殊性，有的作者用小写，有的用大写
cd mods
for filename in `ls *.jar`
	do
		unzip -o $filename assets/*/lang/en_US.lang -d ${PATH_MAIN}/assets-tmp/
		unzip -o $filename assets/*/lang/en_us.lang -d ${PATH_MAIN}/assets-tmp/
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
done

cd $PATH_MAIN
mkdir -p release-fold/assets

# 遍历assets-tmp文件夹中所有子文件夹，对比assets文件夹中文件
# 对比中英文文件，只记录增加的部分
cd $PATH_MODS
for filename_mods in `ls`
 do
	 cd $PATH_ASSETS
	 for filename_assets in `ls`
		 do
			 # 很奇怪的问题，有些mod会莫名其妙存在minecraft文件夹
			 if [ "$filename_mods" == "$filename_assets" ] && [ "$filename_assets" != "minecraft" ]; then
				 sed -i 's/\r//g' "${PATH_MODS}/${filename_mods}/lang/en_us.lang"
				 sed -i 's/\r//g' "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang"
				 echo "CRLF > LF"

				 mkdir -p "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang"
				 diff -uwB "${PATH_MODS}/${filename_mods}/lang/en_us.lang" "${PATH_ASSETS}/${filename_assets}/lang/zh_cn.lang" | grep ^\+ > "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/diff.lang"
				 echo "Get Diff File"

				 sed -i 's/^[+]*//g' "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/diff.lang"

				 mv "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/diff.lang" "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/zh_cn.lang"

				 sed -i '/^\s*$/d' "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/zh_cn.lang"
				 tr -s '\n' < "${PATH_MAIN}/release-fold/assets/${filename_assets}/lang/zh_cn.lang"
				 break
			 fi
	 done
done

# 最后，删掉assets-tmp文件夹
cd ${PATH_MAIN}
rm -rf ./assets-tmp

# 删掉mods文件，方便操作
rm -rf ./mods
