![pack.png](https://i.loli.net/2018/02/18/5a8974407b453.png)

---

<div align="center">

[![Website](https://img.shields.io/badge/%E5%AE%98%E7%BD%91-cfpa.team-brightgreen)](https://cfpa.team/)
![Weblate](https://weblate-t.exz.me/widgets/langpack/-/svg-badge.svg)
![Packer](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/workflows/Packer/badge.svg?branch=main)
[![License](https://img.shields.io/badge/license-CC%20BY--NC--SA%204.0-blue)](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/main/LICENSE)

</div>

简体中文丨[**English**](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/main/README-en.md)

## 仓库说明

这里是 Minecraft 模组简体中文翻译项目的仓库。

该项目的目的是解决模组作者不接收翻译、翻译更新速度慢等诸多问题。

## 如何使用

### 1. 安装模组（推荐）

下载并安装 [I18nUpdateMod](https://www.curseforge.com/minecraft/mc-mods/i18nupdatemod) 模组，详情请查看此模组的 [MCMOD](https://www.mcmod.cn/class/1188.html) 页面。

|                        模组下载量                         |                             模组支持版本                              |
| :-------------------------------------------------------: | :-------------------------------------------------------------------: |
| ![CurseForgePage](https://cf.way2muchnoise.eu/297404.svg) | ![CurseForgeVersion](https://cf.way2muchnoise.eu/versions/297404.svg) |

### 2. 手动添加资源包

在 [GitHub Releases](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/releases) 下载并添加资源包（后缀对应支持的 MC 版本和 Modloader 类型）。

若资源包不生效，请检查资源包的优先级。

## 问题反馈

1. [GitHub Issue](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/issues)
2. [osTicket 工单系统][osTicket]

## 加入我们

若想提交翻译、贡献代码，请**仔细**阅读 [CONTRIBUTING](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/main/CONTRIBUTING.md)。

## 授权方式

本项目采用 [知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议](https://creativecommons.org/licenses/by-nc-sa/4.0/)（[简体中文](https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh)）进行许可，协议全文可在 [此处](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/main/LICENSE) 查看。

## 相关信息

- [MCBBS 推广宣传帖](https://www.mcbbs.net/thread-774087-1-1.html)
- [MC 百科上的自动汉化更新模组](https://www.mcmod.cn/class/1188.html)

## 翻译资源库

### 工具

- [Saladict 沙拉查词](https://saladict.crimx.com/)
- [Minecraft Mods Translator](https://github.com/Maz-T/Minecraft-Mods-Translator) - 简易 CAT 工具。
- [汉化小工具](https://tt.nptr.cc/) - LANG 转 JSON，JSON 更新，JSON 补全。
- [Octotree](https://www.octotree.io/) - 树型展示 GitHub 项目文件结构，懒加载，独立收藏系统。

### 词典

- [剑桥词典](https://dictionary.cambridge.org/zhs/%E8%AF%8D%E5%85%B8/%E8%8B%B1%E8%AF%AD-%E6%B1%89%E8%AF%AD-%E7%AE%80%E4%BD%93/)丨[谷歌词典](https://chrome.google.com/webstore/detail/google-dictionary-by-goog/mgijmajocgfcbeboacabfgobmjgjcoja?hl=zh-CN)
- [词源在线](https://www.etymonline.com/cn)

### MC 相关翻译资源

- [Minecraft Wiki:译名标准化](https://minecraft.fandom.com/zh/wiki/Minecraft_Wiki:%E8%AF%91%E5%90%8D%E6%A0%87%E5%87%86%E5%8C%96) - 原版词汇中英对照。
- [Minecraft Wiki:译名标准化/历史](https://minecraft.fandom.com/zh/wiki/Minecraft_Wiki:%E8%AF%91%E5%90%8D%E6%A0%87%E5%87%86%E5%8C%96/%E5%8E%86%E5%8F%B2) - 原版词汇变更历史。
- [Minecraft 模组翻译参考词典](https://dict.mcmod.cn/) - 以英文检索本仓库中的翻译条目。
- [MCBBS 的翻译讨论](https://www.mcbbs.net/forum.php?mod=forumdisplay&fid=1015&page=1&filter=typeid&typeid=2250) - 原版翻译讨论、投票、公告。
- [MC百科社群的翻译讨论](https://bbs.mcmod.cn/forum.php?mod=forumdisplay&fid=31&filter=typeid&typeid=116) - 模组翻译讨论，零散汉化发布。

### 其他

- [术语在线](https://www.termonline.cn/index) - 全国科学技术名词审定委员会审定的术语。
- [CNKI 翻译助手](https://dict.cnki.net/index) - 学科词典聚合和机器翻译。
- [WantWords 反向词典](https://wantwords.net/) - 寻找相似词，词穷拯救者。

<!-- **你们是怎么做到流水线式的翻译的？**

emmmm，原理其实很简单。

- 通过爬虫爬取 CurseForge 的热门模组；
- 脚本推送回 GitHub 仓库；
- Weblate 检测到仓库变动，自动抓取 GitHub 变动；
- 翻译人员在 Weblate 上翻译，Weblate 自动推回到 GitHub；
- GitHub Actions 检测到仓库变动，自动构建并打包；
- GitHub Actions 自动发布到 GitHub 的 Release 上，以供下载；

-->

## 鸣谢

感谢 `phi` 搭建了 Weblate 服务器；

感谢 `Summpot`，`Nullpinter` 制作了新版本的 C# 爬虫；

感谢 `PeakXing` 制作的 logo；

感谢 `Snownee`、`FledgeXu`、`asdflj` 等在内的诸多人的意见和建议；

感谢本项目的最初贡献者 `Aemande123`，`DYColdWind`，`Snownee`，`yuanjie000`，`forestbat`，`3TUSK`，`SihenZhang`，`MoXiaoFreak`，`gloomy_banana`，`yuanjie000`，`exia00125`，`luckyu19` 提供的汉化。（排名不分先后）

感谢玩家 `R_liu` 提供的拔刀剑本地化；

资源包镶嵌了 `3TUSK` 提供的全角标点修复文件；

最后感谢那些参与翻译，并致力于本地化推广的各位玩家，你们辛苦了。

本项目的所有贡献者可在 [Contributors](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/graphs/contributors) 页面查看。

[osTicket]: <https://ticket.cyllive.cn>

## 状态

![Alt](https://repobeats.axiom.co/api/embed/fab4d8d1692c23f3728abede45c9654f039b8813.svg "Repobeats analytics image")
