# 打包机制文档

**跳转：[快速参考](#快速参考)** <!--应该没写错-->

## 注意事项

- 文件地址中，目录分隔符**一律使用正斜杠（`/`）**！
- 地址相关
  - 下述说明中，**完整地址**永远指从**仓库根目录**算起的地址，例如对根目录下的 `CONTRIBUTING.md`，应为 `CONTRIBUTING.md`；对1.12版本资源包的 `pack.png`，应为 `projects/1.12.2/pack.png`。
  - 下述说明中，**相对地址**永远指从**特定命名空间的文件夹**算起的地址，例如对仓库中的 `projects/1.18/assets/minecraft/minecraft/font/default.json`，应为 `font/default.json`。
  - 下述说明中，**目标地址**永远指**分发的资源包中**，该文件应当被放置的位置，例如对上一条中提及的文件，应为 `assets/minecraft/font/default.json`。
- 文件相关
  - 下述说明中，**语言文件**永远指可以被打包器解读为**映射表**的文件。这包括了所有 **`lang/` 下的 `.lang` 和 `.json` 文件**。
  - 下述说明中，**文本文件**永远指含有**文本内容**，但**不属于语言文件**的文件。这包括了非语言文件的 `.txt`、`.md`、`.json` 文件。
  - 下述说明中，**非文本文件**永远指**不属于以上两类**的文件，如图片或其他二进制文件。
- 本次打包器更新以后，对于**非文本文件**无需特殊处理：打包器会按照文件拓展名自动识别文件类型。

<!-- 下面的部分内容是从我的fork处，尚未完工（短期内也不会完工）的wiki摘录+修改而来的。有部分地方用XML注释格式去掉了部分内容，但是我没有完全删掉，因为还打算复制回去的。 --->

## 配置文件

配置文件分为两类：

- 放置在 `config/packer` 下的**全局**配置文件，用作整个打包流程的基础配置；
- 放置在各命名空间下的**局域**配置文件，用于对特定命名空间（以及模组）提供特殊的配置项。

### 文件格式

目前而言，所有配置文件都需要填写全部项——无关项可以填写空集合，但不能不填，更不能写 null。有计划在将来优化这一行为。

#### 全局配置文件

**全局**配置文件 `config/packer/<version>.json` 的格式如下：

- 根标签 object
  - `base` object  
  打包流程中的*不变配置*，不能被文件结构中的**局域配置文件**改写。包含的内容都是**不低于**命名空间层级的，因为局域配置文件就是放在命名空间一级中的。
    - `version` string  
    该配置文件指向的版本，以 `projects/` 中的文件夹名称为准。原则上*应当*与文件名中的 [version] 一致。
    - `targetLanguages` list  
    打包的目标语言，即最终在资源包中存在的语言。
      - string  
      目标语言，即该版本使用的语言标识符。  
      以在 `lang` 下的语言文件的文件名，以及其他文件的路径中，标明语言的部分为准。目前而言，使用的是 `zh_cn`，尽管有消息称将要改用 `zho_Hans-CN`。
    - `exclusionMods` list  
    被打包器排除的模组文件夹。  
    如果因为某些原因需要移除某个模组的翻译（如移交官方/其他团体等），但意图保留原有翻译，可能需要这一项。
      - string  
      排除的模组。<!--以[S部分](./S.-本仓库的结构向导)中定义的 **[mod-identifier]** | **(CurseForge 项目名称)**为准。-->
    - `exclusionNamespaces` list  
    被打包器排除的 **[namespace]** | **(命名空间)**。  
    暂时闲置，以待后续需求。
      - string  
      排除的命名空间。<!--以[S部分](./S.-本仓库的结构向导)中定义的 **[namespace]** | **(命名空间)**为准。-->
  - `floating` object  
  打包流程中的*可变配置*，可能被文件结构中的**局域配置文件**改写。包含的内容都是**低于**命名空间层级的，因为局域配置文件就是放在命名空间一级中的。
    - `inclusionDomains` list  
    强制包含的 **[domain]**。  
    一般而言，用于通常不会包含**语言标识符**的 `domain`。  
    一般而言会包含 `font` 与 `textures`，因为这两处往往不带语言标识符，且字体修复已经需要用到这两个domain；其他内容多半会出现在*局域配置*中。
      - string  
      强制包含的domain名称。<!--以[S部分](./S.-本仓库的结构向导)中定义的 **[domain]** 为准。-->
    - `exclusionDomains` list  
    强制排除的 **[domain]**。  
    暂时闲置，或可用于排除一些策略相关的零散文件。
      - string  
      强制排除的domain名称。<!--以[S部分](./S.-本仓库的结构向导)中定义的 **[domain]** 为准。-->
    - `exclusionPaths` list  
    强制排除的 **[相对地址]**。
      - string  
      强制排除的文件的**相对地址**。  
      一般而言，在主配置中只会放置通用的忽略对象，例如 `packer-policy.json` 和 `local-config.json`；其余条目最好放在*局域配置*中。
    - `inclusionPaths` list  
    强制包含的 **[相对地址]**。  
    暂时闲置，可以用于添加零散的无语言标记文件。
      - string  
      强制包含的文件的**相对地址**。
    - `characterReplacement` object  
    打包时采用的字符替换表。用于将部分字符替换至特殊位点，也可单纯用于简化输入。目前而言，包含了字体修复的有关内容。
      - `<查询语句>` string  
      用以替换**正则表达式**`<查询语句>`匹配对象的内容，可以是一个或多个字符，甚至可以在这里用**正则替换语句**。  
      主要用于*字体修复包*所需的**符号替换**，此时，查询语句通常是字面量，替换内容一般而言总是以四位 *Unicode 转义码*填写；对于**基础多语种平面（BMP）**以外的字符，最好用 **UTF-16 代理对**书写。
    - `destinationReplacement` object  
    打包时采用的目标地址替换。  
    可以用于移动文件，但暂时闲置；使用**检索策略**中的`singleton`也可以实现地址替换，但需要在每个模组下配置。
      - `<查询语句>` string  
      用以替换**正则表达式**`<查询语句>`匹配对象的内容，可以是一个或多个字符，甚至可以在这里用**正则替换语句**。

#### 局域配置文件

**局域**配置文件 `projects/<version>/assets/<mod-name>/<namespace>/local-config.json` 的格式与全局配置文件中，`floating` 标签下的内容（*可变配置*）一致。

### 文件容斥顺序

介于在配置文件中出现了多种包含/排除文件的配置项，有必要说明以下这些项生效的顺序：

1. `exclusionMods` 和 `exclusionNamespaces` 在进入命名空间前即会排除相应的文件夹——甚至不会加载其中的 `local-config.json`。  
当然，如果是通过*检索策略*访问的，则这一项不会生效。
2. 在剩下的命名空间中，检索文件。下面的配置项可能会被当地的*局域配置*修改，除了 `targetLanguages` 以外。
3. 在所有检索到的文件中，排除掉 `exclusionPaths` 指定的文件，即便是通过*检索策略*访问的。
4. 在剩下的文件中，直接包含 `inclusionPaths` 和 `inclusionDomains` 指定的文件。
5. 在剩下的文件中，排除掉 `exclusionDomains` 指定的文件。
6. 在剩下的文件中，仅包含由 `targetLanguages` 指定的，在路径中任意位置包含有*简体中文语言标记*的文件，其他文件不予包含。

### 局域配置文件的重写规则

- 如果在某个命名空间内检测到存在 `local-config.json`，打包器将会在全局配置的基础上，在其*可变配置*中**添加**该文件中的内容，并用这一修改后的配置执行**该命名空间下的**检索工作。
- 最好不要与全局配置中的内容重复。尽管理论上这样子可以运行，但是重复项保留哪一个或许不容易断定。
- 需要注意的是，如果通过*检索策略*来**引用其他命名空间**，打包器**只**会加载目标命名空间的局域配置，而**不会**加载原空间的局域配置；不过，在原位进行的检索工作不受影响。

## 检索策略

对于每个**命名空间文件夹**，打包器除了可以原位检索文件以外，还可以**使用不同的检索方式**。目前，可用的检索方式有四种：

1. **原位**检索文件。
2. **引用**给定的命名空间。
3. 从给定的**组合**文件，直接生成语言文件（或部分）。
4. 引用**单个**文件。

> 计划中，将对*非语言文件的文本文件*添加一个**修改包**策略，但是这个策略暂时还没实现，部分原因是在上一版打包器中，这个策略还没被用过。

单独看起来，这或许没什么用（打包器的上一版中，功能还要多些）；但有一点很重要：这些加载策略是可以**串联**、**递归**的！于是，通过这些策略，应该可以满足许多需求。

- **串联**：在一个策略文件中，可以放置**多条策略**。策略将会从前往后执行，**前者**优先——和*Minecraft资源包*顺序差不多。不过，在文件冲突时，也提供了一些特殊的冲突解决选项。
- **递归**：如果**引用**了其他命名空间文件夹，那里的策略文件**也会生效**。这意味着可以实现*连续引用*——尽管前提是不出现**循环引用**。

部分案例被放在了 `projects/packer-example/` 这一虚拟的“版本”下。很明显，我们**并不会**分发这一版本，但如果有条件，可以在本地构造打包器，并用这一版本做试验。

### 策略相关文件的格式

#### packer-policy.json

对于每个**命名空间文件夹**，策略文件为 `projects/<version>/assets/<mod-name>/<asset-domain>/packer-policy.json`。
若找不到该文件，默认策略内容为 `[{"type": "direct"}]`，也就是**原位**加载，没有特殊配置。

- 根标签 list  
打包器需要执行的策略，**从前往后执行**。如果有冲突内容，默认以**前者**优先——当然这是可以配置的。
  - object  
  单项策略。部分参数可变。
    - `modifyOnly` bool  
    默认为 `false`。  
    对于**语言文件**，若本项为 `true`，对于已有的键，若在该步中提供了新的值，则将会用新值替换旧值；**不会**包含本步中新出现的键。  
    对于其他文件，本项无效。
    - `append` bool  
    默认为 `false`。  
    对于**文本文件**，将会在已有的文本内容之后**换行**，然后连接本步的内容。  
    对于其他文件，本项无效。
    - `type` strin  
    策略的类型。

    **若 `type` 的值为 `direct`：** 不进行特殊处理，直接按照此处的文件结构打包。

    **若 `type` 的值为 `indirect`：** 引用给定的命名空间。对于这些文件，其*目标地址*中的*命名空间*将会自动替换为本策略所在的命名空间。（[示例](projects/1.20/assets/minecraft/minecraft/packer-policy.json)的第二条）
    - `source` string  
    引用命名空间所在文件夹的**完整地址**。

    **若 `type` 的值为 `composition`：** 从给定的*组合文件*，直接生成语言文件（或部分）。这些组合文件可能不会被自动排除；可以考虑使用*局域配置*处理。（[示例](projects/1.16/assets/macaws-bridges/mcwbridges/packer-policy.json)的第二条；[组合文件示例](projects/1.16/assets/macaws-bridges/mcwbridges/lang/zh_cn-composition.json)）
    - `source` string  
    引用组合文件的**完整地址**。
    - `destType` string  
    需要生成的语言文件的类型。可以为`json`或`lang`。

    **若 `type` 的值为 `singleton`：** 引用给定的单个文件。理论上该操作可以选取任何位置的文件，只要目标位置填写正确；不过，一般建议放在*合理的位置*。（[示例](projects/1.19/assets/isometric-renders/isometric-renders/packer-policy.json)的第一条）
    - `source` string  
    引用文件所在的**完整地址**。
    - `relativePath`  
    文件需要被放置的**相对地址**。考虑到连续引用，这里不宜使用**目标地址**。

#### [组合文件].json

<!--示例：macaws-->
- 根标签 object
  - `target` string  
  生成的语言文件的**目标地址**。
  - `entries` list  
  需要生成的组合项。这些项将会分别执行组合以后，连接起来。
  **如果存在键冲突，打包器会在此崩溃！** 有计划在后期更改这一行为；目前而言，可以使用多个组合文件绕过这个限制。
    - object  
    单项策略。
      - `templates` object  
      组合所用的模板。所有内容采用**C#格式化模式**填写。  
      粗略地说，其中的格式符有形式 `{0}, {1}, {2},...`，字面量花括号需要用 `{{` 和 `}}` 转义；完整的定义可见 *[.net文档/Composite Formatting](https://learn.microsoft.com/en-us/dotnet/standard/base-types/composite-formatting)*。
        - `<键模板>` string  
        `<键模板>`对应的值模板。
      - `parameters` list  
      组合所用的参数表。参数按照模板中的**索引**顺序排列。不支持嵌套，必须用字面量。
        - object  
        每个索引位置上可用的参数。
          - `<键参数>` string  
          `<键参数>`对应的值参数。

### 组合文件

组合文件用来生成“组合型”的**语言文件/语言文件片段**，也就是那些有大量重复文本、有明显的格式的语言文件片段。

组合文件的工作原理如下：

- 获取 `entries` 中的全部条目，每个条目代表一种组合模式。
- 每个条目中，由 `templates` 中的所有条目充当模板，`parameters` 中的所有条目充当参数，生成若干组合后的条目。
  - 在 `parameter` 中，有时会出现多于一组参数；这种情况下，每组参数都会自由组合。
  - 同样的，`templates` 也会和每一套参数自由组合。
- 将所有组合后的条目汇总，生成语言文件。
  - 在这一过程中，如果出现了**键冲突**，目前而言，**打包器会在此崩溃！** 不过，如果后续观察表明确实存在此种需要，也会考虑修改这一行为。

组合文件可以和其他打包策略混合使用，以修改组合中效果不好的部分，或者添加非组合的内容。

组合文件理论上可以放在任何位置，使用任何名称；因此，打包器的*基础配置*没有办法排除掉这些文件。不过，为了方便，最好将其汇总在一个位置，采用明确的名称，以便在*局域配置*中排除。

## 配置注解

上述配置全部采用 `json` 格式书写；这导致的一个问题就是，`json` 格式严格意义上是**不支持注释**的！为了解决这一问题，在使用这些内容时，最好在对应的命名空间内附上**注解文件**。当然，这不是必须的，但最好这么做。同时，也可以在此写下对该目录内容和功能的特殊注释。

原则上注解文件可以采用任何形式，但建议写到*命名空间目录下的 `README.md` 文件*中——打包的全局配置默认会排除这一文件。同样的，注解文件的形式也没有特殊限定，但尽量统一为佳。

一些注解文件的例子为[这个](projects/1.16/assets/minecraft/minecraft/README.md)、[这个](projects/1.18/assets/minecraft/minecraft/README.md)和[这个](projects/1.18/assets/macaws-furniture/mcwfurnitures/README.md)。

> 原则上，这些注解甚至可以自动生成。

## 快速参考

以下列出了一些与打包流程相关的常见文件配置。如果遇到以下情况，可以直接使用下面的方案。

### 版本增添

> 该项**需要**预先进行讨论，指定合适的版本支持计划！

- 制定版本支持计划。  
  这条一般是由管理层指定的。**有时**，支持计划会在 *Issues* 界面中展示——1.19 与 1.20 的支持计划即这么做了。
- 判定是否需要工具链更新。
  - 无需更新：  
    - 创建 `config/packer/[version].json`，并按照本文的指导填写，或参照相近版本的配置文件。
    - 在 `.github/workflows/pr-packer.json` 与 `.github/workflows/packer.json` 中，一处形如 `version: [ "1.12.2", ... ]` 的列表中（如[此处](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/blob/c1d6b114fba63e86b5df682ec01fc30b818ee5e0/.github/workflows/packer.yml#L102)），加入需增添的版本。
    - 创建 `projects/[version]`，并按照其他版本的格式填写 `pack.png`，`pack.mcmeta`，`LICENSE`，`README.txt` 等内容。
      - 注意 `pack.mcmeta` 需要把花括号转义；可以参照其他版本的文件。
      - 注意 `.../minecraft/minecraft` 下的**字体修复文件**，需要按该版本的字体支持情况考虑填写。通常可以引用旧版本的资源，以减少重复工作。
  - 需要更新：
    - 更新工具链。这可能需要很长的时间，取决于更新操作的复杂程度。例如，我们对 **1.20** 的支持稍晚，部分原因就是工作人员 ~我~ 全面更新了一次打包器。
    - 按照“无需更新”的内容执行。

### 复用语言文件

如果你在维护多版本的模组，有可能会遇到相近或相同的多份语言文件。此时，**复用**语言文件，可以减轻维护负担。

#### 完全复用

这适用于语言文件完全一致的情况，如不同平台的同一模组。

- 确定可用的文件来源。
- 在目标模组的**命名空间**文件夹下，创建 `packer-policy.json`，填写如下内容，其中 `source` 字段按照前一步找到的来源填写。（[示例](projects/1.18-fabric/assets/iron-furnaces/ironfurnaces/packer-policy.json)）

```json
[
    {
        "type": "indirect",
        "source": "projects/[version]/assets/[mod-identifier]/[namespace]"
    }
]
```

- 尽管理论上不会加载，但仍应删除已有的 `lang/zh_cn.json`，以免误会。`lang/en_us.json` 无需移除。
- （可选）创建**注解文件**。

#### 复用+修改

这适用于语言文件大部一致，小部有改动的情况。

- 确定可用的文件来源，以及需要做出的修改。多余的字段无需删去（也暂时无法删去；如有需要，会考虑增加此功能）；缺少或不同的字段则需要修改。
- **方案一**：适用于有多个文件需要修改的情况。（[示例](projects/1.20/assets/minecraft/minecraft/packer-policy.json)）
  - 在 `lang/zh_cn.json`（或其他需更改的文件）中，保留与来源文本不一致，需要修改的文本，其余内容删去。
  - 在目标模组的**命名空间**文件夹下，创建 `packer-policy.json`，填写如下内容，其中 `source` 字段按照前一步找到的来源填写。

```json
[
    {
        "type": "direct"
    },
    {
        "type": "indirect",
        "source": "projects/[version]/assets/[mod-identifier]/[namespace]"
    }
]
```

- **方案二**：（[示例](projects/1.19/assets/isometric-renders/isometric-renders/packer-policy.json)）
  - 以合适名称创造新文件（“修改文件”），仅包含与来源文本不一致，需要修改的文本，其余内容删去。
  - 在目标模组的**命名空间**文件夹下，创建 `packer-policy.json`，填写如下内容，其中两个 `source` 字段依次填写修改文件、来源命名空间的**完整地址**，`destination` 字段填写目标文件的**相对地址**。

```json
[
    {
        "type": "singleton",
        "source": "projects/[version]/assets/[mod-identifier]/[namespace]/[file-path]",
        "relativePath": "[file-path]"
    },
    {
        "type": "indirect",
        "source": "projects/[version]/assets/[mod-identifier]/[namespace]"
    }
]
```

- （可选）创建**注解文件**。

#### 选取单文件

若来源有多个文件，但只需要其中某个文件，可以将上述方案中，`indirect` 策略替换为以下文本：

```json
{
    "type": "singleton",
    "source": "projects/[version]/assets/[mod-identifier]/[namespace]/[file-path]",
    "relativePath": "[domain]/[file-path]"
}
```

其中 `source` 为**完整地址**，`relativePath` 为在最终资源包中，需要放置的**相对地址**。

### 添加无语言标识的文件

无其他配置时，打包器只会打包**含有简体中文语言标识**的文件，以及 **domain** 为 `font`、`textures` 的文件。如果需要添加不满足此要求的文件，需要适当修改配置文件。

#### 按domain集中添加文件

这适用于集中在一个或几个 **domain** 下的文件。

- 确定该模组需要加入的 **domain**。
- 在目标模组的**命名空间**文件夹下，创建 `local-config.json`，填写如下内容：（[示例](projects/1.20/assets/applied-energistics-2/ae2/local-config.json)）

```json
{
    "inclusionDomains": [],
    "exclusionDomains": [],
    "exclusionPaths": [],
    "inclusionPaths": [],
    "characterReplacement": {},
    "destinationReplacement": {}
}
```

- 在上述文件中，`inclusionDomains` 处，按照 `Json` 格式填写所需的 **domain**。

此外，若可以确定该**domain**在该版本普遍需要添加，可以转而在全局配置 `config/packer/[version].json` 中进行相应修改。

#### 添加零散文件

这适用于文件没有特殊集中位置的情况。

- 确定该模组需要加入的文件。
- 在目标模组的**命名空间**文件夹下，创建 `local-config.json`，填写如下内容：

```json
{
    "inclusionDomains": [],
    "exclusionDomains": [],
    "exclusionPaths": [],
    "inclusionPaths": [],
    "characterReplacement": {},
    "destinationReplacement": {}
}
```

- 在上述文件中，`inclusionPaths` 处，按照 `Json` 格式填写所需文件的**相对路径**。

通常不应将这种配置写入全局配置。

### 常用组合文件参数

原版 16 色

```json
{
    "black": "黑色",
    "blue": "蓝色",
    "brown": "棕色",
    "cyan": "青色",
    "gray": "灰色",
    "green": "绿色",
    "light_blue": "淡蓝色",
    "light_gray": "淡灰色",
    "lime": "黄绿色",
    "magenta": "品红色",
    "orange": "橙色",
    "pink": "粉红色",
    "purple": "紫色",
    "red": "红色",
    "white": "白色",
    "yellow": "黄色"
}
```

机械动力岩石

```json
{
    "andesite": "安山岩",
    "asurine": "皓蓝石",
    "calcite": "方解石",
    "crimsite": "绯红岩",
    "deepslate": "深板岩",
    "diorite": "闪长岩",
    "dripstone": "滴水石",
    "granite": "花岗岩",
    "limestone": "石灰岩",
    "ochrum": "赭金砂",
    "scorchia": "焦黑熔渣",
    "scoria": "熔渣",
    "tuff": "凝灰岩",
    "veridium": "辉绿岩"
}
```
