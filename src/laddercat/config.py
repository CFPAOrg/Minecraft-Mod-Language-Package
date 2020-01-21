# 某些英文键不是我们想要的，可以通过这一块书写删除它
del_key = [
    'msg.entity.rocket.seldst',
    'commands.reload.usage',
    'tile.freezer.name',
    'tile.mirror.name',
    'name.TRINKET',
    'tile.oreIron.name',
    # 下面四个是 Railcraft 对原版铁轨名字的修改
    'tile.activatorRail.name',
    'tile.detectorRail.name',
    'tile.goldenRail.name',
    'tile.rail.name',
]

delete_list = [
    "writing_guides",
    "chisel_guide", # 凿子 "mod" 的手册，无需翻译
    "pokecube_books", # "pokecube" 模组手册，乱码无法翻译
    "bloodmagicguide", # 血魔法手册，无需翻译
    "evilcraftcompat", # 附带在 "EvilCraft" 内的兼容性 "mod"，无语言文件
    "torohealthmod", # "ToroHealth" "Damage" "Indicators" 血量显示 "mod"，无语言文件
    "packmode", # 无语言文件
    "shulkerbox", # "Advanced" "Shulkerboxes"，一个可以在背包直接打开潜影盒的 "mod"，无语言文件
    "progressivebosses", # 错误编码
    "jaopca", # 会导致崩溃
    "tinkersdefense", # 新版本已经修改名称，这个名称属于旧版本残留，删去
    "simpleautorun", # 空语言文件
    "equipmenttooltips", # 空语言文件
    "defiled-lands", # 瞎编乱造词语
    "angermanagement"
    "kk", # 王国之心
    "xtones", # 不需要翻译
    "aoa3", # 其他人维护
    "mw", # 翻译会导致游戏无法游玩
    "skybonsais", # 空语言文件
]

namespace_domain_blacklist = [
    # 格式: "<模组的project name>::<domain name>"
]

update_setting = {
    "hours": 72
}

mod_blacklist_slug = [
    "dungeon-tactics", # 乱码
    "minecraft-comes-alive-mca", # 无意义人名翻译
    "mike-dongles", # 无意义粉丝向模组
    "magical-psi", # 仅仅改材质，但是作者忘记删语言文件了
    "the-twilight-forest", # 目前有他人对此翻译存在反对观点，暂时列为黑名单，规避冲突
    "charset-lib", # 3TUSK 指出不需要翻译
    "forestry", # 3T维护
    "metamorph", # horsewithnoname 的模组
    "aperture", # horsewithnoname 的模组
    "blockbuster", # horsewithnoname 的模组
    "imaginary", # horsewithnoname 的模组
    "greenscreen",
    "slashblade", # 翻译问题较多，目前上传了固定版本，不再变动
    "the-aether-ii",
    "extraplanets", # 岩浆水覆盖问题
    "shetiphiancore", # 染料颜色重名问题
    "skillable", # 原作者不在更新
    "smarthoppers-mod", # 太过抽象
    "thaumic-equivalence", # 缺失翻译最多的手册部分目前还未实装
    "embers", # 已经不再维护
    "ice-and-fire-dragons", # EEEEEET
    "projecte", #手册暂时有问题
    "lycanites-mobs",
    "craftpresence", # 汉化会导致崩溃，是的
    "anger-management",
    "twitch-chat-integration", # 有加载 Bug
    "chineseworkshop", # 自带中文
    "moarsigns", #自带
]

pages = 20

queue_num = 20
async_worker_number = 10