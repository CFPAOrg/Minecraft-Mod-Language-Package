# 贡献方针

贡献方针是参与本项目贡献的指导文件。

## 仓库结构

### 下方仓库目录结构树可暂时略过，可于稍后返回查看。
```text
Minecraft-Mod-Language-Package
  ├─.github ------------------------ // GitHub 相关配置文件
  ├─config ------------------------- // 配置文件
  │ └─packer ----------------------- // 打包器配置文件
  ├─projects ----------------------- // 翻译文件
  │ └─(Minecraft 版本) ------------- // 不带 fabric 字样的是用于 Forge 和 NeoForge 模组的
  │   └─assets
  │     ├─(CurseForge 项目名称) ---- // 见下
  │     │ └─(命名空间) ------------- // 见下
  │     │   └─lang ---------------- // 语言文件文件夹
  │     │     ├─en_us.json -------- // English (United States) 语言文件
  │     │     └─zh_cn.json -------- // 中文 (简体) 语言文件
  │     ├─(Modrinth 项目名称)------- // 见下
  │     │ └─(命名空间) ------------- // 见下
  │     │   └─lang ---------------- // 语言文件文件夹
  │     │     ├─en_us.json -------- // English (United States) 语言文件
  │     │     └─zh_cn.json -------- // 中文 (简体) 语言文件
  │     ├─minecraft
  │     │ └─minecraft ------------- // Minecraft 原版使用的命名空间
  │     │   ├─font
  │     │   │ └─glyph_sizes.bin --- // 全角标点修复文件
  │     │   └─textures
  │     │     └─font -------------- // 全角标点修复文件
  │     └─1UNKNOWN ---------------- // 存放不在 CurseForge 和 Modrinth 上发布的模组
  │         └─(命名空间)
  │           └─lang
  └─src --------------------------- // 各种自动化工具的源码
    ├─Formatter ------------------- // 格式化工具，曾用于统一翻译文件格式
    ├─Language.Core 
    ├─Packer ---------------------- // 打包器，用于自动生成资源包文件并发布 Release
    ├─Spider ---------------------- // 爬虫，曾用于爬取热门模组的语言文件供翻译
    └─Uploader -------------------- // 上传器，用于将资源包文件上传到文件分发服务器
```
### 翻译贡献简介
**贡献翻译需要遵守相关规定，也就是后文中的翻译贡献方针。**\
**本文及相关文件提供了，保障项目正常运作的工作流程，以及质量保证体系。**\
参与贡献，至少需要**知晓**以下内容：
 1. **Git/GitHub 相关操作流程**[^a]，如：Commit（提交）、Pull Request（PR）以下简称 PR
 2. **项目名称与命名空间**，对相关模组有了解能定位源码相关文件位置
 3. **版本优先级**，相对小众的我的世界版本将不提供或提供较少的支持
 4. **翻译用语共识**，同时还需要了解翻译相关原则及基础知识
 5. **本项目内工作流程**，包括但不限于提交、审查、搁置及贡献者许可协议（CLA）
 6. [**公示规则**](#公示规则)，一般不涉及，位于本文其他内容之后

除第一项（1.）外 Git/GitHub 相关操作流程，其余内容均在本文或本项目内有相关阐述。\
仍有不明？可前往 [QQ 群](https://jq.qq.com/?_wv=1027&k=5geO1T21)（630943368）。

### <ins>什么是 **CurseForge 项目名称**</ins>
以匠魂为例，CurseForge 页面地址：\
Curseforge.com/minecraft/mc-mods/**tinkers-construct** 
> [!IMPORTANT]
> **`tinkers-construct`** 是匠魂的 CurseForge 项目名称

### <ins>什么是 **Modrinth 项目名称**</ins>
以 Clean F3 为例（Modrinth **独占模组**），页面地址：\
Modrinth.com/mod/**clean-f3** 
`Modrinth 项目名称` 为 `modrinth-clean-f3`
 - 需要注意的是 `clean-f3` 仅为 `Modrinth 项目名称` 的**主体**部分
 - 为了与 Curseforge 上发布的模组作以区分，所有**仅**在 Modrinth 上发布的模组，在其之前需要添加 `modrinth-` 作为区分
> [!IMPORTANT]
> **`modrinth-clean-f3`** 是 Clean F3 的 Modrinth 项目名称

### <ins>什么是 **命名空间（Namespace）**</ins>
 - 一个模组可能有多个命名空间
   - 命名空间介绍见[Minecraft Wiki](https://zh.minecraft.wiki/w/%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4ID?variant=zh-cn#%E5%91%BD%E5%90%8D%E7%A9%BA%E9%97%B4)
 - 仓库中`命名空间`文件夹下的目录结构与[资源包](https://zh.minecraft.wiki/w/%E8%B5%84%E6%BA%90%E5%8C%85)的相应结构相同，其他可用资源包加载的本地化文件亦可接收

以匠魂为例，获取其发行文件，[根据其源码内容](https://github.com/SlimeKnights/TinkersConstruct)，它的 `en_us.json` 的路径为\
`assets/tconstruct/lang/en_us.json`\
则 `命名空间` 为 `assets/` 和 `/lang` 之间的内容\
> [!IMPORTANT]
> **`tconstruct`** 是匠魂的命名空间。


### <ins>**版本优先级**</ins>
`projects` 文件夹下只标出模组所属的大版本号，其中的模组翻译文件应满足以下优先级：
1. 模组**活跃**更新的 Minecraft 版本优先
2. 若所有小版本都活跃更新，则 Minecraft **高版本**者优先
* 例[^1]

## <ins>翻译用语共识</ins>

1. “材料 + 质/制 + 中心词”的翻译，如“铁质涡轮”或“铁制涡轮”，二者皆合理。只需单模组内统一。
2. 关于“木制品名称”的翻译，可参考 [#4525](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/issues/4525) 的解决方法。

## <ins>翻译贡献方针</ins>

以下内容只针对 [projects](./projects) 文件夹下的贡献。

### 总则

- 翻译**必须**符合 [Minecraft 模组简体中文翻译规范与指南](https://cfpa.site/TransRules/)的规定。
- **拒绝**接收机器翻译（含生成式 AI）、生硬翻译。
  - 若直接提交此类翻译，该 PR 将被打上“生硬翻译”标签。
  - 若作者不及时进行有效修改，PR 可能会依照本仓库的[搁置规则](#搁置规则)处理。
- 翻译必须在**审校后**才能进入仓库。

### <ins>Pull Request（PR）相关规定</ins>

#### PR 标题要求

- 提交时应当**及时签署**[贡献者许可协议](https://cla-assistant.io/CFPAOrg/Minecraft-Mod-Language-Package) 或可发送 PR 后尽快签署。
- PR 标题**应当**简洁明了，格式为 `{模组英文全名}{空格}{简述}`
  - ✔️
    - `Tinkers' Construct 翻译提交`
    - `Tinkers' Construct 和 Tinkers' Reforged 译名修正`
  - ❌
    - `TiC 翻译更新`（未使用全名）
    - `匠魂翻译更新`（未包含英文名）
    - `提交 Tinkers' Construct 翻译`（英文名前不应有文字）


#### PR 内容要求

- **必须**提交 PR 至`main`分支
- **必须**路径合规，详见[仓库结构](#仓库结构)
- **必须**包含简体中文、翻译源语言的语言文件[^2]
  - 若翻译源语言不是英语，且模组有英语语言文件，则**必须**包含英语语言文件[^2]
    
- <ins>建议每个 PR 仅含一个模组
- <ins>建议</ins>若多个模组的中文总行数不超过 200 则可合并为一个 PR
- <ins>建议</ins>用相关词语填写提交消息（Commit Message），如`提交`、`更新`、`修改`、`删除`

<!--
### Weblate

- **Weblate 自 2022 年 4 月起暂停新用户注册。**
- 普通用户不能直接点击“保存”按钮提交翻译，只能点击“建议”按钮。
- Weblate 中做出的更改在被审核通过后会被同步到本仓库。
- 善用 Weblate 的词汇表，可规范翻译及提高翻译效率。
-->

### <ins>翻译审查</ins>

#### 审查规则

- 审查的基本**依据**是[翻译贡献方针](#翻译贡献方针)
- 审查流程**必须**满足本文档[翻译审查](#翻译审查)内容所述
- 审查过程中各方**应当**遵守[礼仪](https://zh.wikipedia.org/wiki/Wikipedia:%E7%A4%BC%E4%BB%AA)（[备用](https://share.weiyun.com/LRvx1omf)）

#### 审查人

- **任何利用[相关功能](https://docs.github.com/zh/pull-requests/collaborating-with-pull-requests/reviewing-changes-in-pull-requests/commenting-on-a-pull-request)参与审查的用户是审查人**。
- [CFPA团队](https://github.com/CFPAOrg) 的成员（Member）和[仓库](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package) 的协作者（Collaborator）是具有**团队官方性质**的审查人[^3]。

#### PR 作者

- **及时**做出**合理回应**，或接受建议，或提出异议，否则 PR 可能会按[搁置规则](#搁置规则)[^4]关闭
  - ✔️ 在**接受**审查人[^3]的建议后，PR 作者应当**解决**（Revolve）对话（Conversation）
  - ❌ 若**拒绝**审查人的建议，或和审查人的观点有**异议**，PR 作者**不应急于解决**对话
- 如遇到 Git/GitHub 操作上的困难，应**先询问后操作**，避免造成混乱

### <ins>搁置规则（对 PR 作者）</ins>

搁置规则[^4]用于解决 PR 作者未及时响应审查要求，而导致的 PR 积压问题。
因此，请 PR 作者提交请求后**定期查阅**相关系统通知，特别是提交后 7 至 14 日内。
因搁置而关闭的 PR 作者若想继续更新，可重新打开 PR。

[^a]: PR 教程
      1. 可查看[视频教程](https://www.bilibili.com/video/BV1yqgge9EVK/)或[文字教程](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/wiki/%E4%BD%BF%E7%94%A8-GitHub-%E6%8F%90%E4%BA%A4%E7%BF%BB%E8%AF%91)来学习。
      2. 注意，视频或文字教程都只介绍了 Pull Request 的使用方法，**贡献方针仍需阅读**。

[^1]: 例
      1. Minecraft 版本 1.19.2 与 1.19.4 均属同一大版本号 1.19 下的子版本
         1. 若某一模组在两个版本上的开发均活跃，由于 1.19.4 的版本号更高，因此优先考虑该模组在 1.19.4 下的译名标准化情况与适配情况\
         2. 这一优先级不会影响到模组在其他大版本下（如 1.18、1.12 等）的分支

[^2]: 文件路径提示
      1. 如果文件路径不包含语言标记 `zh_cn`，一般需要**修改全局或局域的 Packer 配置**，否则它们会被打包器排除，不会进入用户使用的资源包
      2. 如果这些文件放置在 `font` 或 `textures` 中，无需修改配置，默认已经对这两处进行了特殊处理
      3. 具体操作参见[文档](Packer-Doc.md#添加无语言标识的文件)
      4. 不同版本的同一模组可通过[自定义文件检索策略](./Packer-Doc.md#检索策略)同步翻译

[^3]: 审查与审查人
      1. 至少一位具有**官方身份**的审查人对 PR 给出批准（Approval）审查后，PR 才能合并。
      2. 审查人在给出**批准**审查后应给 PR 加上“**即将合并**”标签，此后需至少等待 24 小时，若等待期间没有新动态则可以合并 PR。
      3. “动态”包括但不限于 PR 作者发送提交、审查人提出意见。
      
[^4]: 搁置规则
      1. 若 PR 中存在未作者未响应的审查超过 7 日，审查人有权提及（@）PR 作者，提醒其相应审查意见，然后加上“即将被搁置”标签。
      2. 若“即将被搁置”标签存在超过 7 日，PR 作者将被视为无法回应。此时
         1. 若存在要求 PR 作者参与的审查意见，PR 将被加上“即将拒收”标签，1 天后 PR 将被关闭。
         2. 若审查意见都无需 PR 作者参与，PR 将被加上“即将拒收”标签。
            1 天缓冲期内官方审查人**可以**直接采纳审查意见，并终止计时，转入合并流程。
      3. 在 1、2 所述过程中，若 PR 作者做出了回应，标签将被清除，计时重新从 1 开始。

## 联系我们

若有不明白的地方，可[前往 QQ 群](https://jq.qq.com/?_wv=1027&k=5geO1T21)（630943368）。

> [!TIP]
> *\
> *\
> *\
> 以下内容不涉及翻译贡献\
> *\
> *\
> *

## 公示规则

公示规则是为了传播 PR 中某个（些）模组译名或词条的重大更改而设立的，包括但不限于：远古译名的更改，错误译名的更正。

1. 该规则适用于与官方翻译或社区流传度较广的翻译存在**重大差异**，且存在译名或词条更改的 PR
2. 纯文档或代码贡献 PR **不应**进入公示流程（存在停止支持或重新支持某模组翻译的除外）（例：[#4327](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pull/4327)，[#4215](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pull/4215)）
3. 若 PR 在**审查通过后**符合上述规则，则视为该 PR 进入公示流程，同时加上“需要公示”标签，并择日通过如 Bilibili、QQ 群、MC 百科社群等平台发布公示，至发布之日 14 天止视为公示流程结束。此时清除标签并加上“即将合并”标签，转入合并流程。
   - 公示时，应当附带：PR 链接、原文、更改内容、更改缘由等，选择性附带图片。

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

路径：`./config/packer/[version].json`（如 1.12 的文件在 [1.12.2.json](./config/packer/1.12.2.json)）

该文件内放置了**所有**正在维护的版本的打包配置。
不要随意*删去*内容，除非你知道它为什么弃用。
加入内容相对而言宽松一些，但最好还是说明理由。

*下面没有提到的一般都不适合改动；如果需要，最好说明理由。*

主要的更改场景：

- 增加新翻译版本
  - 需要将所有项填写一遍，同时需要更新 `.github/workflows/packer.yml`、`.github/workflows/pr-packer.yml`、`.github\boring-cyborg.yml`，以及 [CFPABot](https://github.com/Cyl18/CFPABot) 等相关服务。没有规划最好不要乱动。
- 更改字符替换表
  - 修改`characterReplacement`，格式与已有文本一致。对于**基础多语种平面（BMP）**以外的字符，最好用 **UTF-16 代理对**书写。
  - 同时可能需要修改字体文件。
- 处理非文本文件
  - 参考 [Packer-Doc](Packer-Doc.md) 对其的描述。
- 停止对某模组的支持
  - 把该模组的 `CurseForge 项目名称`或`命名空间`中的加入相应的 `exclusionMods` 或 `exclusionDomains`（二者取其一）。


