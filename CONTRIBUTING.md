# 贡献方针

> 请在贡献前**仔细阅读**此文档（**特别是加粗部分**）

定义：

- 模组翻译文件（下文亦称“翻译”），指本项目 `projects/{版本}/assets` 中的用于提供 **Minecraft 模组**及本体中文本地化支持的文件（包括且**不限于**模组本体所提供的 `lang`，`json` 文件、手册翻译文件）。
- 代码文件（下文亦称“代码”），指本项目 `src` 目录下所有代码文件。
- 配置文件（下文亦称“配置”），指本项目 `config` 目录下所有代码文件。
- 本地化修复文件（下文亦称“修复文件”），包括由 3TUSK 提供的全角标点修复文件，酒石酸菌所制作的生僻字兼容文件。
- Pull Requests（下文亦称“PR”）：指在[本页面](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pulls)提交的请求。
<!--- Weblate 翻译平台（下文亦称“Weblate”），是一个高度集成了版本控制功能的 web-based 翻译工具。本项目的 Weblate 由 Phi 部署搭建。-->

**目录：**

- [贡献方针](#贡献方针)
  - [仓库结构](#仓库结构)
  - [翻译用语共识](#翻译用语共识)
  - [翻译贡献方针](#翻译贡献方针)
    - [Pull Request 相关规定](#pull-request-相关规定)
    - [翻译质量控制](#翻译质量控制)
  - [代码贡献指南](#代码贡献指南)
  - [配置更改指南](#配置更改指南)
    - [Packer](#packer)
  - [联系我们](#联系我们)

## 仓库结构

```text
Minecraft-Mod-Language-Package
  ├─.github --------------- // GitHub 相关配置文件
  ├─config ---------------- // 配置文件
  ├─projects -------------- // 翻译文件
  │ └─(Minecraft 版本) ---- // 不带 fabric 字样的是用于 Forge 的
  │   └─assets
  │     ├─(CurseForge 项目名称) ---- // 见下
  │     │ └─(命名空间) ------------- // 见下
  │     │   └─lang ----------------- // 语言文件文件夹，若模
  │     │     ├─en_us.json --------- // 英文（US）语言文件
  │     │     └─zh_cn.json --------- // 简体中文（中国）语言文件
  │     ├─minecraft
  │     │ └─minecraft -------------- // Minecraft 原版使用的命名空间
  │     │   ├─font
  │     │   │ └─glyph_sizes.bin ---- // 全角标点修复文件
  │     │   └─textures
  │     │     └─font
  │     │       ├─unicode_page_20.png ---- // 生僻字兼容文件
  │     │       ├─unicode_page_9f.png ---- // 生僻字兼容文件
  │     │       └─unicode_page_e9.png ---- // 生僻字兼容文件
  │     └─1UNKNOWN ----------------- // 存放不在 CurseForge 上发布的模组
  │       └─(命名空间)
  │         └─lang
  └─src --------------- // 各种自动化工具的源码
    ├─Formatter ------- // 格式化工具，用于统一翻译文件格式
    ├─Language.Core 
    ├─Packer ---------- // 打包器，用于自动生成资源包文件并发布 Release
    ├─Spider ---------- // 爬虫，曾用于爬取热门模组的语言文件供翻译
    └─Uploader -------- // 上传器，用于将资源包文件上传到文件分发服务器
```

**CurseForge 项目名称**：以匠魂为例，它的 CurseForge 页面地址是 `https://www.curseforge.com/minecraft/mc-mods/tinkers-construct`，则 `CurseForge 项目名称` 为 `tinkers-construct`。因为它是唯一的，被用来追溯模组来源。

**命名空间（Namespace）**：以匠魂为例，它的 en_us.json 的路径为 `assets/tconstruct/lang/en_us.json`，则 `{命名空间}` 为 `assets/` 和 `/lang` 之间的内容，即 `tconstruct`。一个模组可能有多个命名空间。命名空间介绍见 [Minecraft Wiki](https://minecraft.fandom.com/zh/wiki/%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4ID#%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4)。

## 翻译用语共识

1. “材料+质/制+中心词”的翻译，如“铁质涡轮”“铁制涡轮”，二者皆合理。只需单模组内统一。

## 翻译贡献方针

以下内容只针对对 [projects](./projects) 文件夹下的贡献。

发布 PR 即代表：

1. **你已阅读并同意按 [CC BY-NC-SA 4.0](https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh) 协议发布你的作品**。
2. **你已阅读 [Minecraft 模组简体中文翻译规范与指南](https://cfpa.site/TransRules/)**。
3. 你能够**接受**因翻译质量问题而提出的批评，并在收到建议后**愿意**与批评者讨论是否接受更改。

### Pull Request 相关规定

可查看[视频教程](https://www.bilibili.com/video/BV1Xi4y1r7S2/)或[文字教程](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/wiki/%E4%BD%BF%E7%94%A8-GitHub-%E6%8F%90%E4%BA%A4%E7%BF%BB%E8%AF%91)来学习。注意，视频或文字教程都只介绍了 Pull Request 的使用方法，贡献方针仍需阅读。

视频或文字教程中与翻译贡献方针不同的地方，以本方针为准。

- 提交 PR 至`main`分支。
- 若要提交多个模组的翻译，尽量按一个 PR 仅含一个模组的原则来提交。
  - 若多个模组包含的中文总行数不超过 200，允许合并为一个 PR（#1770）。
- PR 标题需简洁明了，格式应为 `{模组英文全名} {简述}`。
  - ✔️`Tinkers Construct 翻译提交`
  - ✔️`Tinkers Construct 和 Tinkers' Reforged 译名修正`
  - ❌`TiC3 翻译更新`（未使用全名）
  - ❌`匠魂翻译更新`（未包含英文名）
- 确保提交文件的路径是正确的：`projects/{版本}/assets/{CurseForge 项目名称}/{命名空间}/lang`
- 未完工的翻译仍可提交 PR，可以将其设置为 draft。
- 尽量用相关词语填写 commit massage，如`提交`、`更新`、`修改`、`删除`。
- 必须包含简体中文及翻译源语言的语言文件。
  - 若翻译源语言不是英文，请附上英文语言文件（如有）以供参考。
  - 禁止提交除上述三种语言以外的语言文件。
- 若只提交英文原文，请一并提交空白中文文件。
  - 1.12 空白翻译文件为无内容的文件。
  - 1.16 及以上空白翻译文件为只包含左右花括号即`{}`的文件，[例子](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/50b4d47d320ac9b78192e9adec19bff0a4948d57/projects/1.16.1/assets/pams-harvestcraft-2-food-extended/pamhc2foodextended/zh_cn.json)。
- 如果上传的文件中包含**非文本文件**（如`.ttf`，`.jpg`等），**有可能需要修改 [Packer 配置](config/packer.json)**，否则它们会被打包器排除，不会进入用户使用的资源包。
  - 如果这些文件放置在`font`或`textures`中，一般不用修改配置；默认已经对这两处进行了特殊处理。
- 不同版本的同一模组可通过[自定义文件检索策略](./Packer-Index-Doc.md)同步翻译。

### 翻译质量控制

- **本项目对机翻、生硬翻译并不友好，还请在提交具有这些特征的文件时深思熟虑。**
- 无论是哪种提交方式，都需要在**审查（review）通过**后才会推送至本项目。
- 审查时间可能极长，极端情况下可能长达数月。
- CFPABot 的报错需要二次确认。
<!--
### Weblate

- **Weblate 自 2022 年 4 月起暂停新用户注册。**
- 普通用户不能直接点击“保存”按钮提交翻译，只能点击“建议”按钮。
- Weblate 中做出的更改在被审核通过后会被同步到本仓库。
- 善用 Weblate 的词汇表，可规范翻译及提高翻译效率。
-->
## 代码贡献指南

以下内容只针对对 [src](./src) 文件夹下的贡献。

- **我们默认你已了解 C#、GitHub Actions 以及相关计算机的基本知识。**
- **贡献代码有着更加严格的审查，请不要发无意义的、影响本项目运作的 PR（例：[SPAM](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pull/840)）。**
- 在提交前，你已测试过你的代码能够**正常**的运行。
- 请简要描述提交的代码的**作用**。

## 配置更改指南

以下内容只针对对 [config](./config) 文件夹下的贡献。这里里只列出了部分修改可能较大的文件。

<!--### config/spider/config.json

> Spider目前暂时停用，以下事项仅作参考。

- `"version"`：游戏版本，**请勿修改**
- `"spider_conf"`：爬虫相关设置
- `"base_mod_count"`：默认爬取模组的数量
- `"black_list"`：模组黑名单，元素为 `String` 类型，内容为 CurseForge 的 Project ID
- `"white_list"`：同上，为模组白名单

注意事项：

- 请不要随意删除黑名单模组，这些模组在这里是有原因的。
- 请不要在**未经同意**的情况下修改默认爬取数量。
-->

### Packer

路径：[./config/packer.json](./config/packer.json)

该文件内放置了**所有**正在维护的版本的打包配置。
最好不要随意*删去*内容，除非你知道它曾经是干什么的，现在为什么不需要了。
加入内容相对而言宽松一些，但最好还是说明理由。

*下面没有提到的一般都不适合改动；如果需要，最好说明理由。*

主要的更改场景：

- 增加新翻译版本
  - 需要将所有项填写一遍，同时需要更新`.github/workflows/packer.yml`、`.github/workflows/pr-packer.yml`、`.github\boring-cyborg.yml`，以及 [CFPABot](https://github.com/Cyl18/CFPABot) 等相关服务。没有规划最好不要乱动。
- 处理非文本文件
  1. 如果该文件所在的文件夹与`lang`文件夹同级，且对**任何模组都**不会有文本文件（如font\），将该文件夹加入对应版本的`noProcessNamespace`中。
  2. 否则，将该模组的`CurseForge 项目名称`或`命名空间`中的一个（具体选哪一个看具体情况）加入`modNameBlackList`或`domainBlackList`，并将**所有**受影响的文件的相对位置加入`additionalContents`。
- 添加非标准位置（在`assets/`以外）的文件
  - 直接加入`additionalContents`
- 停止对某模组的支持
  - 把该模组的`CurseForge 项目名称`或`命名空间`中的加入相应的`modNameBlackList`或`domainBlackList`（二者取其一）。

## 联系我们

若有不明白的地方，可[前往 QQ 群](https://jq.qq.com/?_wv=1027&k=5geO1T21)（630943368，**较为活跃**）或 [Discord](https://discord.com/invite/SGve5Fn) 提问。
