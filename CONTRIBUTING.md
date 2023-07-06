# 贡献方针

> 请在贡献前**仔细阅读**此文档（**特别是加粗部分**）

定义：

- 语言文件，指 Minecraft 中为显示文本提供支持的文件，包括所有语言，包括但不限于模组本体所提供的 LANG 文件、JSON文件、手册语言文件。
  - 翻译文件（下文亦称“翻译”），专指中文语言文件。本项目的翻译文件存放在 `projects/{版本}/assets` 中。
- 代码文件（下文亦称“代码”），指本项目 `src` 目录下所有代码文件。
- 配置文件（下文亦称“配置”），指本项目 `config` 目录下所有代码文件。
- Pull Requests（下文亦称“PR”）：指在[本页面](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pulls)提交的请求。
<!--- Weblate 翻译平台（下文亦称“Weblate”），是一个高度集成了版本控制功能的 web-based 翻译工具。本项目的 Weblate 由 Phi 部署搭建。-->

**目录：**

- [贡献方针](#贡献方针)
  - [仓库结构](#仓库结构)
  - [翻译用语共识](#翻译用语共识)
  - [翻译贡献方针](#翻译贡献方针)
    - [总则](#总则)
    - [Pull Request 相关规定](#pull-request-相关规定)
      - [标题与文字内容](#标题与文字内容)
      - [PR 内容](#pr-内容)
    - [翻译审查](#翻译审查)
      - [审查规则](#审查规则)
      - [审查人](#审查人)
      - [PR 作者](#pr-作者)
    - [搁置规则](#搁置规则)
    - [提示](#提示)
  - [代码贡献指南](#代码贡献指南)
  - [配置更改指南](#配置更改指南)
    - [Packer](#packer)
  - [联系我们](#联系我们)

## 仓库结构

```text
Minecraft-Mod-Language-Package
  ├─.github --------------- // GitHub 相关配置文件
  ├─config ---------------- // 配置文件
  │ └─packer -------------- // 打包器配置文件
  ├─projects -------------- // 翻译文件
  │ └─(Minecraft 版本) ---- // 不带 fabric 字样的是用于 Forge 的
  │   └─assets
  │     ├─(CurseForge 项目名称) ---- // 见下
  │     │ └─(命名空间) ------------- // 见下
  │     │   └─lang ----------------- // 语言文件文件夹
  │     │     ├─en_us.json --------- // English (United States) 语言文件
  │     │     └─zh_cn.json --------- // 中文 (简体) 语言文件
  │     ├─minecraft
  │     │ └─minecraft -------------- // Minecraft 原版使用的命名空间
  │     │   ├─font
  │     │   │ └─glyph_sizes.bin ---- // 全角标点修复文件
  │     │   └─textures
  │     │     └─font --------------- // 全角标点修复文件
  │     ├─1UNKNOWN ----------------- // 存放不在 CurseForge 和 Modrinth 上发布的模组
  │     │   └─(命名空间)
  │     │     └─lang
  │     └─0-modrinth-mod ----------- // 存放仅发布在 Modrinth 上的模组
  │         └─(命名空间)
  │           └─lang
  └─src --------------- // 各种自动化工具的源码
    ├─Formatter ------- // 格式化工具，曾用于统一翻译文件格式
    ├─Language.Core 
    ├─Packer ---------- // 打包器，用于自动生成资源包文件并发布 Release
    ├─Spider ---------- // 爬虫，曾用于爬取热门模组的语言文件供翻译
    └─Uploader -------- // 上传器，用于将资源包文件上传到文件分发服务器
```

**CurseForge 项目名称**：以匠魂为例，它的 CurseForge 页面地址是 `https://www.curseforge.com/minecraft/mc-mods/tinkers-construct`，则 `CurseForge 项目名称` 为 `tinkers-construct`。因为它是唯一的，被用来追溯模组来源。

**命名空间（Namespace）**：以匠魂为例，用压缩软件打开模组文件（JAR 格式），它的 en_us.json 的路径为 `assets/tconstruct/lang/en_us.json`，则 `{命名空间}` 为 `assets/` 和 `/lang` 之间的内容，即 `tconstruct`。一个模组可能有多个命名空间。命名空间介绍见 [Minecraft Wiki](https://minecraft.fandom.com/zh/wiki/%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4ID#%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4)。

仓库中“命名空间”文件夹下的目录结构与[资源包](https://minecraft.fandom.com/zh/wiki/%E8%B5%84%E6%BA%90%E5%8C%85)的相应结构相同。

## 翻译用语共识

1. “材料+质/制+中心词”的翻译，如“铁质涡轮”“铁制涡轮”，二者皆合理。只需单模组内统一。
2. 关于“木制品名称”的翻译，可参考 <https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pull/2715#discussion_r1056901664> 中的解决方法。

## 翻译贡献方针

以下内容只针对对 [projects](./projects) 文件夹下的贡献。

### 总则

- 翻译**必须**符合 [Minecraft 模组简体中文翻译规范与指南](https://cfpa.site/TransRules/)的规定。

- **拒绝**接收机器翻译、生硬翻译。

- 翻译**必须**在审查后才能进入仓库。

### Pull Request 相关规定

可查看[视频教程1](https://www.bilibili.com/video/BV1Xi4y1r7S2/)（已过时）、[视频教程2](https://www.bilibili.com/video/BV1Ph4y1R7M8/)或[文字教程](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/wiki/%E4%BD%BF%E7%94%A8-GitHub-%E6%8F%90%E4%BA%A4%E7%BF%BB%E8%AF%91)来学习。注意，视频或文字教程都只介绍了 Pull Request 的使用方法，贡献方针仍需阅读。

视频或文字教程中与翻译贡献方针不同的地方，以本方针为准。

#### 标题与文字内容

- PR 标题**应该**简洁明了，格式为 `{模组英文全名}{空格}{简述}`。
  - ✔️`Tinkers' Construct 翻译提交`
  - ✔️`Tinkers' Construct 和 Tinkers' Reforged 译名修正`
  - ❌`TiC3 翻译更新`（未使用全名）
  - ❌`匠魂翻译更新`（未包含英文名）
  - ❌`提交 Tinkers' Construct 翻译`（英文名前不应有文字）
- PR 模板中的检查单**必须**照做并完成勾选，详见[“检查单”使用说明](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/issues/2539)。

#### PR 内容

- **必须**提交 PR 至`main`分支。
- **必须**路径合规，详见[仓库结构](#仓库结构)。
- **必须**包含简体中文、翻译源语言的语言文件。
  - 若翻译源语言不是英语，且模组有英语语言文件，则**必须**包含英语语言文件。
- **建议**每个 PR 仅含一个模组。
  - 若多个模组的中文总行数不超过 200，**建议**合并为一个 PR（<https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/discussions/1770>）。
- **建议**用相关词语填写提交消息（Commit Message），如`提交`、`更新`、`修改`、`删除`。

<!--
### Weblate

- **Weblate 自 2022 年 4 月起暂停新用户注册。**
- 普通用户不能直接点击“保存”按钮提交翻译，只能点击“建议”按钮。
- Weblate 中做出的更改在被审核通过后会被同步到本仓库。
- 善用 Weblate 的词汇表，可规范翻译及提高翻译效率。
-->

### 翻译审查

#### 审查规则

- 审查的基本依据**是**[翻译贡献方针](#翻译贡献方针)。
- 审查流程**必须**满足本文档[翻译审查](#翻译审查)内容所述。
- 审查过程中各方**应**遵守[礼仪](https://zh.wikipedia.org/wiki/Wikipedia:%E7%A4%BC%E4%BB%AA)（[备用](https://share.weiyun.com/LRvx1omf)）。

#### 审查人

- 任何人都能利用 GitHub 提供的[相关功能](https://docs.github.com/zh/pull-requests/collaborating-with-pull-requests/reviewing-changes-in-pull-requests/commenting-on-a-pull-request)来审查 PR 中翻译。所有参与审查的用户即为审查人。
- [CFPA团队](https://github.com/CFPAOrg)的成员（Member）和[仓库](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package)的协作者（Collaborator）是具有团队官方性质的审查人。
- 至少一位具有官方身份的审查人对 PR 给出批准（Approval）审查后，PR 才能合并。
- 审查人在给出批准审查后**应**给 PR 加上“即将合并”标签，24 小时内没有新动态则可合并 PR。

#### PR 作者

- PR 作者**应**对审查作出合理回应，或接受建议，或提出异议。
- PR 作者**应**及时做出回应，否则 PR 可能会按[搁置规则](#搁置规则)关闭。

### 搁置规则

搁置规则的目的是解决由于 PR 作者迟迟不出面响应审查要求而导致的 PR 积压问题。

1. 若 PR 中存在未作者未响应的审查超过 7 天，审查人有权提及（@）PR 作者，提醒其相应审查意见，然后加上“即将被搁置”标签。
2. 若“即将被搁置”标签存在超过 7 天，PR 将被关闭。
3. 在 1、2 所述过程中，若 PR 作者有实质性回应，审查人**应**去除“即将被搁置”标签，计时重新从 1 开始。

### 提示

- 如果上传的文件中包含**非文本文件**（如`.ttf`，`.jpg`等），**有可能需要修改 [Packer 配置](config/packer.json)**，否则它们会被打包器排除，不会进入用户使用的资源包。
  - 如果这些文件放置在`font`或`textures`中，一般不用修改配置；默认已经对这两处进行了特殊处理。
- 不同版本的同一模组可通过[自定义文件检索策略](./Packer-Index-Doc.md)同步翻译。

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
不要随意*删去*内容，除非你知道它为什么弃用。
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
