# Contributing for Minecraft-Mod-Language-Package

名词解释：

- 模组翻译文件（下文亦称“翻译”），指本项目 `projects/{version}/assets` 中的用于提供 **Minecraft** 模组及本体中文本地化支持的文件（包括且**不限于**模组本体所提供的 `lang`，`json` 文件、手册翻译文件）。
- 代码文件（下文亦称“代码”），指本项目 `src` 目录下所有代码文件。
- 配置文件（下文亦称“配置”），指本项目 `config` 目录下所有代码文件。
- 本地化修复文件（下文亦称“修复文件”），包括由 3TUSK 提供的全角标点修复文件，酒石酸菌所制作的生僻字兼容文件。
- Weblate 翻译平台（下文亦称“Weblate”），是一个高度集成了版本控制功能的 web-based 翻译工具。本项目的 Weblate 由 Phi 部署搭建。
- osTicket 工单系统（下文亦称“工单系统”）。
- Pull Requests（下文亦称“PR”）。

> 请在贡献前**仔细阅读**此文档（**特别是加粗部分**）

**目录：**

1. [翻译贡献指南](#翻译贡献指南)
2. [代码贡献指南](#代码贡献指南)
3. [配置更改指南](#配置更改指南)
4. [最后需要注意的](#最后需要注意的)

## 翻译贡献指南

在提交翻译之前，我们**默认**以下几点：

1. **你已阅读并同意 [知识共享署名-非商业性使用-相同方式共享 4.0 国际许可协议](https://creativecommons.org/licenses/by-nc-sa/4.0/)（[简体中文](https://creativecommons.org/licenses/by-nc-sa/4.0/deed.zh)）**
2. **你已阅读翻译相关注意事项：[Minecraft 模组简体中文翻译规范与指南](https://rules.cfpa.team/)（十分重要）**

有关**翻译**的说明：

- 不要望文生义，有些看起来十分离谱的东西可能是正确的。
- 尽量做到边开游戏边翻译。
- **本项目对机翻、生硬翻译并不友好，还请在提交具有这些特征的文件时深思熟虑。**

有关**提交**的说明：

- 请确保提交的语言文件名称大小写正确，一般情况下语言文件名称应为**小写**。
- 提交翻译文件时，请一并提交/更新英文原文。
- 若只提交英文原文，请一并提交空白翻译文件。
  - 1.12 的文件为无内容的文件
  - 1.16 的文件为只包含左右花括号的文件，[例子](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/50b4d47d320ac9b78192e9adec19bff0a4948d57/projects/1.16.1/assets/pams-harvestcraft-2-food-extended/pamhc2foodextended/zh_cn.json)

有关**审查**的说明：

- 无论是哪种提交方式，都需要在**审查通过**后才会推送至本项目。
- 愿意等待**长时间**的审查（部分可能长达一个月）。
- 你能够**接受**因翻译质量问题而提出的批评，并在收到建议后**愿意**进行修改。

为本项目贡献翻译有以下三种方法：

- [工单系统](#工单系统)
- [Weblate](#weblate)
- [GitHub PR](#github-pr)

### 工单系统

- 使用前需先在 [工单系统][osTicket] 注册工单账号。
- 完成注册后，请使用**注册邮箱**（而不是用户名）登录工单系统。
- 请在工单系统中选择**请求添加模组翻译**工单，并根据提示进行后续操作。
- 提交工单后，后续跟进消息会以邮件的方式通知，请**留意**注册邮箱（有可能会被处理为垃圾邮件）。

### Weblate

- 使用前需先在 [工单系统][osTicket] 中提交**账户申请**工单（**注意**：工单账号和 Weblate 账号并不是同一个账号）。
- 普通用户不能直接点击“保存”按钮提交翻译，只能点击“建议”按钮。
- 善用 Weblate 的词汇表，可规范翻译及提高翻译效率。

### GitHub PR

- 默认你对 Git、GitHub 已经有了**一定**的了解，并且懂得使用 PR。
- 请提交 PR 至 **main** 分支。
- 若要提交多个模组的翻译，请尽量分多个 PR 提交。
- 请**务必**使用以下标记命名 PR 标题。
  - `[R]`（需要审查）
  - `[M]`（直接合并）
  - `[P]`（难度较大）
  - `[WIP]`（未完成）
  - 多个标记的例子：`[R][P][WIP]`
- 请确保提交文件的路径是**正确**的（[例子](#提交文件路径的例子)）。
  - 如果是 1.12 翻译，应该是：`projects/1.12.2/assets/{CurseForge 项目名称}/{ModID}/lang/zh_cn.lang`
  - 如果是 1.16 翻译，应该是：`projects/1.16/assets/{CurseForge 项目名称}/{ModID}/lang/zh_cn.json`
- 未完工的翻译仍可提交 PR，可以先设置为 Draft。
- 善用相关词语填写 PR 信息或 Commit 信息，如提交、更新/修改、删除等词语。
- 提交 PR 后，后续跟进消息会以邮件的方式通知，请**留意**注册邮箱（有可能会被处理为垃圾邮件）。
- 请勿对本地化修复文件做出任何改动。
- **请勿在提交翻译的 Commit 中同时更改配置以及代码，除非你明白且愿意承担所造成的相关后果。**

#### 提交文件路径的例子

Tinkers Construct 的 CruseForge 页面地址为 <https://www.curseforge.com/minecraft/mc-mods/tinkers-construct>，则 {CurseForge 项目名称} 为 **tinkers-construct**。

Tinkers Construct 英文原文的路径为 `assets/tconstruct/lang/en_us.json`，则 {ModId} 为 **tconstruct**。

最终你要提交翻译文件的路径为 `projects/1.16/assets/tinkers-construct/tconstruct/lang/zh_cn.json`

## 代码贡献指南

- **我们默认你已了解 C#、GitHub Actions 以及相关计算机的基本知识。**
- **贡献代码有着更加严格的审查，请不要发无意义的、影响本项目运作的 PR（例：[SPAM](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/pull/840)）。**
- 在提交前，你已测试过你的代码能够**正常**的运行。
- 请简要描述提交的代码的**作用**。

## 配置更改指南

**建议更改的配置仅为 `config/spider/config.json`，故其他文件不做说明**

- `"version"`：游戏版本，**请勿修改**
- `"spider_conf"`：爬虫相关设置
- `"base_mod_count"`：默认爬取模组的数量
- `"black_list"`：模组黑名单，元素为 `String` 类型，内容为 CurseForge 的项目 Id
- `"white_list"`：同上，为模组白名单

注意事项：

- 请不要随意删除黑名单模组，这些模组在这里是有原因的。
- 请不要在**未经同意**的情况下修改默认爬取数量。

## 最后需要注意的

若有不明白的地方，可前往 QQ 群（630943368，**较为活跃**）或 [Discord](https://discord.com/invite/SGve5Fn) 提问。

**本项目的每个贡献者都是理应感谢的人。**

[osTicket]: <https://ticket.cyllive.cn>
