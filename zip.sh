#! /bin/bash
#! /usr/bin/python3
# @Author TartaricAcid
# @Title 自动打包工具
######################################

# 创建空文件夹，放置材质包
mkdir release

# 记录地址，方便操作
PATH_MAIN=`pwd`
PATH_RELE=${PATH_MAIN}/release

# 复制材质包必须的几样东西
# 材质包本体、识别文件、图标、说明、许可证
cp -fr "${PATH_MAIN}/assets" "${PATH_MAIN}/release"
cp -f "${PATH_MAIN}/pack.mcmeta" "${PATH_MAIN}/release/pack.mcmeta"
cp -f "${PATH_MAIN}/pack.png" "${PATH_MAIN}/release/pack.png"
cp -f "${PATH_MAIN}/README.md" "${PATH_MAIN}/release/README.md"
cp -f "${PATH_MAIN}/LICENSE" "${PATH_MAIN}/release/LICENSE"

# 首先对比zh_cn_old，剔除重复字符串
cd ${PATH_MAIN}/release/assets
for modid in `ls`
do
  if [ -f ${PATH_MAIN}/release/assets/${modid}/lang/en_us.lang ];
  then
    rm "${PATH_MAIN}/release/assets/${modid}/lang/en_us.lang"
    mv "${PATH_MAIN}/release/assets/${modid}/lang/zh_cn.lang" "${PATH_MAIN}/zh_cn.lang"
    mv "${PATH_MAIN}/release/assets/${modid}/lang/zh_cn_old.lang" "${PATH_MAIN}/zh_cn_old.lang"
    cd ${PATH_MAIN}
    python3 delete_update.py
    mv "${PATH_MAIN}/zh_cn_out.lang" "${PATH_MAIN}/release/assets/${modid}/lang/zh_cn.lang"
    cd ${PATH_MAIN}
    rm *.lang
  fi
done

# 然后打包
cd "${PATH_MAIN}/release"
zip -r "${PATH_MAIN}/Minecraft-Mod-Language-Modpack.zip" "assets" "pack.mcmeta"  "pack.png" "README.md" "LICENSE"

# 删除临时文件夹
rm -rf "${PATH_MAIN}/release"
