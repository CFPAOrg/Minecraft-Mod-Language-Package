# 第一章 了解语言文件

## 1. 语言文件发展历史

语言文件（这里特指模组相关语言文件）的发展是一个极为曲折的过程。

### ① Minecraft 1.6.1 之前

在 Minecraft 1.6.1 之前官方还没有指定相关规范，模组本身缺乏对多语言的支持。诸如工业、建筑这样的模组，可能还给提供语言文件，但其他大部分模组直接都是硬编码语言文件。

> 硬编码：将可变变量用一个固定数值表示。由于可变变量是固定不变的，一旦编译后很难修改。
>
> 软编码：和硬编码相对，将可变变量用特殊标记来表示。这样在编译后，只需要修改这个特殊标记即可。

为了能够翻译相关模组，当时的翻译者往往需要 jd-gui 这样的反编译工具来反编译模组，而后修改模组的常量池来参与翻译。这样翻译不但效率低下，一旦翻译错误，整个模组文件就报废了。

> 关于早期模组翻译，可以参见：<http://www.mcbbs.net/thread-81953-1-40.html>

### ② Minecraft 1.6.1 ~ Minecraft 1.10.2 之间

1.6.1 之后官方相关规范的出现，大大简化了翻译的难度。官方采用了简单的语言文件格式来加载本地化，语言文件甚至可以被资源包所替换。大致规则如下：

- 语言文件都位于 `assets/modid/lang/` 下，其中 modid 是随意的，依据具体的模组不同，名字可能不同。比如林业模组的语言文件都位于 `assets/forestry/lang` 文件夹下。
- 可以通过资源包覆盖语言文件，覆盖机理和材质一致。


- 语言文件命名参照了 [ISO639](https://www.iso.org/iso-639-language-codes.html) 标准：英文（美国）就是 `en_US.lang`，中文（中国大陆）就是 `zh_CN.lang`

- 语言文件格式是简单的 `key=value` 方式书写：

  ```properties
  item.apple.name=苹果
  tile.stone.name=石头
  ```


  > 在上述案例中 `item.apple.name` 就是 `key`，而 `苹果` 就是 `value`。

- 以 `#` 开头的段落识别为注释：

  ```properties
  # 注释
  # 注释中可以随便书写文字，均不会加载
  item.apple.name=苹果
  tile.stone.name=石头
  ```

- 语言文件编码为 `utf-8 无 BOM 编码`

  > [BOM](https://en.wikipedia.org/wiki/Byte_order_mark)
  >
  > **字节顺序标记**（byte-order mark，**BOM**），即放置在文件开头的字符 `\uFEFF`，它常被用来当做标示文件是以 UTF-8、UTF-16 或 UTF-32 编码的记号。

### ③ Minecraft 1.11 以后

1.11 版本更新后，官方对部分文件大小写做了严格规范，资源相关的文件名需要通过资源包的 `pack.mcmeta` 中的 `pack_format` 参数来决定。

> 一个只包含 `pack_format` 和 `description` 参数的 `pack.mcmeta` 文件，可以看到书写格式和 JSON 一致。
>
> ```json
> {
>   "pack": {
>     "pack_format": 3,
>     "description": "模组资源文件"
>   }
> }
> ```

- 当设定为 `2` 时，语言文件名采用旧版本书写方式，英文（美国）就是 `en_US.lang`，中文（中国大陆）就是 `zh_CN.lang`。


- 当设定为 `3` 时，语言文件名需要全小写。比如英文（美国）就是 `en_us.lang`，中文（中国大陆）就是`zh_cn.lang`。

除此之外其他规则一致。


## 2. 模组语言文件加载机理

### ① 普通语言文件加载

> 这一块参考 Minecraft 1.12.x 版本的 Forge 代码。
> 源代码：[【1】](https://github.com/MinecraftForge/MinecraftForge/blob/1.12.x/src/main/java/net/minecraftforge/fml/common/FMLCommonHandler.java#L707-L747) [【2】](https://github.com/MinecraftForge/MinecraftForge/blob/1.12.x/patches/minecraft/net/minecraft/util/text/translation/LanguageMap.java.patch)

Minecraft 加载语言文件的机理很简单：

1. 游戏读取所有模组的 `assets/modid/lang/` 下的语言文件；

2. 将语言文件处理成映射表；

  我们刚刚在[第一章](https://github.com/CFPAOrg/Minecraft-Mod-Language-Package/wiki/%E5%86%85%E5%AE%B9#%E7%AC%AC%E4%B8%80%E7%AB%A0-%E4%BA%86%E8%A7%A3%E8%AF%AD%E8%A8%80%E6%96%87%E4%BB%B6)中有简单说过 Minecraft 的语言文件，游戏将会按照条目中的**第一个等号**来拆分成映射表。

  > 比如 `a=b=c` 在游戏中会拆分成 `a` 和 `b=c` 两个条目，形成一对映射；

4. 游戏中依据映射表、具体选择的语言来加载翻译条目；

4. 如果指定语言找不到映射，则开始在 `en_us.lang` 中寻找映射；

5. 如果在 `en_us.lang` 中还是找不到对应的映射，直接显示`key`；

   > **映射**
   >
   > 两个非空集合 A 与 B 间存在着对应关系，而且对于 A 中的每一个元素，B 中总有有唯一的一个元素与它对应，就这种对应称为从 A 到 B 的映射。

### ② 带有 `#PARSE_ESCAPE` 注释语言文件加载

Forge 新增了一个特殊读取：如果注释中存在 `#PARSE_ESCAPE` 注释，那么处理将会严格按照 Java Properties 格式来读取，并处理成映射表；

Properties 格式很像 Minecraft 语言文件格式，但是要更加灵活强大：

- Properties 采用 `:` 或 `=` 来书写映射，也是按照第一个 `:` 或 `=` 来拆分成映射表。下面两种书写方式均是正确的：

  ```properties
  #PARSE_ESCAPE
  item.apple.name:苹果
  item.apple.name=苹果
  ```

- Properties 可以采用转义字符来转义 `:` 或者 `=`，转义过的字符不会被识别。

  ```properties
  #PARSE_ESCAPE
  item.apple\:name:苹果
  item.apple\=name=苹果
  ```

- Properties 可以写成多行的，通过每行行尾的 `\` 符号来识别：

  ```properties
  #PARSE_ESCAPE
  item.apple.name:苹果\
  	挺好吃的
  item.apple.name=苹果\
  	不咋好吃\
  	真的\
  	确实不好吃
  ```

- Properties 采用 `#` 或者 `!` 来书写注释：

  ```properties
  #PARSE_ESCAPE
  ! 这是一条注释
  item.apple.name:苹果
  # 这也是一条注释
  item.apple.name=苹果
  ```

### ③ 映射重名问题

由于游戏是将所有模组的语言文件放在一起处理，一些粗心大意的模组作者在书写语言文件方面如果考虑不周，就会罕见的存在映射重名问题。

比如经典的 [ShetiPhianCore](https://minecraft.curseforge.com/projects/shetiphiancore) 译名冲突，在 ShetiPhianCore 模组中存在着这几个翻译条目：

```properties
item.dyePowder.green.name=绿色染料
item.dyePowder.red.name=红色染料
item.dyePowder.yellow.name=黄色染料
```

而类似的条目在 Minecraft 原版中恰好也存在，它们的 key 完全相同：

```properties
item.dyePowder.green.name=仙人掌绿
item.dyePowder.red.name=玫瑰红
item.dyePowder.yellow.name=蒲公英黄
```

结果导致  [ShetiPhianCore](https://minecraft.curseforge.com/projects/shetiphiancore) 模组的这几个条目直接覆盖了原版的语言文件，导致玩家在游戏中获取了错误的翻译。

除此之外诸如更多武器模组的 `武士刀 `与 PlusTiC 模组的 `李奥纳多的武士刀` 名称相互冲突的等等问题，不一而具。

所幸的是这些问题很少见，而且出现后仅仅是对游戏内翻译有所影响，不会带来任何其他方面的崩溃或者冲突。如果你在翻译过程中发现了这些问题，请及时向模组的原作者反馈。

# 第二章 基础知识

## 1. 字符编码

计算机只能识别二进制代码，如果想要让计算机存储或者识别字符，就需要将字符转变为二进制代码。随着时代、用途等诸多因素的影响，字符编码的标准也各不相同。

这部分东西会非常多而乱，初学者可能会各种懵逼。没办法……谁让这是计算机呢……

### ① ASCII 码

1967 年美国国家标准学会制定了第一个字符编码规范，这就是赫赫有名的 ASCII 码。

ASCII 码使用 7 位二进制数（剩下的1位二进制为0）来表示所有的大写和小写字母、数字 0 到 9、标点符号， 以及在美式英语中使用的特殊控制字符。

然而 ASCII 码支持的字符太少，而后世界各国又独自演化出了适应本国使用的各种编码。诸如中国大陆的 GB2312 编码，日本的 Shift-JIS 编码。

![USASCII_code_chart.png](https://i.loli.net/2018/03/25/5ab795ee2c1af.png)

### ② ISO-8859-1 编码

也常被称为 `Latin-1` 编码，在 ASCII 的基础上额外加入 96 个字母及符号，使其能够广泛支持西欧各国语言。

特意提一下这个编码，部分欧美作者在书写语言文件时会偶然忘记改变文件编码，系统便自动使用 ISO-8859-1 编码书写语言文件。如果不慎语言文件中出现了非 ASCII 字符，那么这部分字符就会乱码。更有甚者强制使用 ISO-8859-1 编码中文文件，导致翻译者提交的正确翻译，在编译后乱码。

典型代表：

- [Dungeon Tactics](https://minecraft.curseforge.com/projects/dungeon-tactics) 模组，`en_US.lang` 采用 ISO-8859-1 编码。读取其 1.12.2 版本模组 `en_US.lang` 第 245 行字符 `ü`，存在乱码：

  ```properties
  item.dungeontactics:terrible_feather.name=Hühnerfeder
  ```
  
- [SuperMiner](https://minecraft.curseforge.com/projects/superminer-unified) 模组，`en_US.lang` 采用 ISO-8859-1 编码。读取其 1.12.2 版本模组 `en_US.lang` 第 46 行字符 `§`，存在乱码：


  ```properties
  superminer.excavator.goditems=§aCONGRATULATIONS: §7You've Unlocked the §6God Items§7!
  ```

### ③ GB 编码

- 中国国家标准总局 1980 发布的适合中文的编码，第一版为 GB2312 编码，共收入 6763个汉字、682 个非汉字图形字符。由于中文字符的庞杂性，所以采用了两个字节来表示，向下兼容 ASCII 编码。

  值得特殊说明的是，在 ASCII 里本来就有的数字、标点、字母，在 GB 编码中又重编了两个字节长的编码，这就是全角字符。

  ```properties
  # 半角数字、标点、字母
  1234567890,.abcdefg

  # 全角数字、标点、字母
  １２３４５６７８９０，．ａｂｃｄｅｆｇ
  ```

- 1995 年又制定了 GBK 编码，GBK 共收入 21886 个汉字和图形符号，兼容 GB2312 编码。

- 2000 年又制定了 GB18030 编码，这次收录了 70244 个中文字符，兼容 GBK 编码。GB18030 编采用一二四字节的变长编码。

值得一提的是，Windows 操作系统默认的文件编码方式是 ANSI 编码，在简体中文系统就指的 GB 编码。在日文系统上就指的是 Shift-JIS 编码。至于你问为什么非要用这个名字……去问微软爸爸啊。

### ④ Unicode 编码

世界各国的编码太多太乱了，我们来指定一个全新的通用标准吧，于是 Unicode 编码应运而生。Unicode 编码支持全世界各国文字，采用统一的编码，兼容 ISO 8859-1 编码。~~Unicode 编码依据不同的长度，具体实现方面又分为 UTF-8、UTF-16、UTF-32。（不考）~~最常用的就是 UTF-8 编码。

MacOS 和 Linux 都还不错，操作系统默认都是 UTF-8 无 BOM 编码；

Windows 系统则不然，采用 ANSI 编码，依据不同国家采用不同国家的国标码。但对 UTF-8 编码也有支持，我们在存储文件的时候还是可以将编码选择为 UTF-8 编码。

![weiruanbaba.png](https://i.loli.net/2018/03/25/5ab7b1d01cd64.png)

**但是！**Windows 下存储的 UTF-8 编码文件，其开头加入了字节顺序标记（byte-order mark，简称 BOM，即放置在文件开头的字符 `\uFEFF`），用来当做标示文件是以 UTF-8、UTF-16 或 UTF-32 编码的记号。部分程序并不支持 BOM，导致处理该字符时候会报错。

我们日常使用的 Java 7/8 以及 Python 3 这些计算机语言，内部实现默认都使用无 BOM 的 UTF-8 编码。但是在没有指定语言编码的情况下读取系统文件，仍旧是沿用系统编码。这在下一章的存储格式中会有详细的说明，这也是很多令人头疼问题的导火索。

## 2. 文件格式

这一章我们将介绍模组翻译中会遇见的各种文件格式，以及各种形形色色的问题。

### ① 原版语言文件

幸运的是，原版语言文件制定了较为严格的规定，同时也提供了方便易用的 I18n 方法。除了极少数模组，大部分模组都较好的遵循了原版语言文件。对几个特立独行的模组简单介绍下：

- 工业模组：至今仍然采用 `Java Properties ` 格式书写语言文件。
- 格雷科技：采用程序生成的配置文件来书写语言文件，启动时需要将语言文件放置在游戏主文件夹下。
- McJty：一个模组作者，写过很多知名的模组，比如 RFTools 三件套，The One Probe 等。除了官方强制要求添加本地化的部分（方块、物品、成就、标签页），其他部分全部采用硬编码。不过所幸他认识到了这个问题，在比较新的 [MeeCreeps](https://minecraft.curseforge.com/projects/meecreeps) 模组中已经开始书写较为全面的语言文件了。本人也表示会在之后逐步在其他模组中添加更多语言文件。
- [Extreme Reactors](https://minecraft.curseforge.com/projects/extreme-reactors)：属于旧版本遗留问题，所有的 GUI 目前仍旧采用硬编码。

原版语言文件的书写与格式在第一章中都详细叙述了，此处不再过多介绍。

### ② JSON 语言文件

#### （1）JSON 基本介绍

全称 JavaScript 对象表示法（JavaScript Object Notation），是一种轻量级的数据交换格式，完全独立于编程语言的文本格式来存储和表示数据。**JSON 不允许写入注释**，整体规则很简单，总结如下：

- 数据由逗号分隔；
- 花括号保存映射；
- 方括号保存数组；

下面我们先书写一个最简单的 JSON 文件，包含一对映射，一个存有两个数据的数组：

```json
{
    "item.apple.name": "苹果",
    "item.list.name": [
        "苹果",
        "香蕉"
    ]
}
```

JSON 有很多在线的格式化工具，能够检查我们书写的语法是否有错误，以及对数据进行重新排版。

- [JSON.cn](http://www.json.cn/)
- [BeJSON](https://www.bejson.com/)

#### （2）编码问题

按照标准，JSON 文件应当使用 UTF-8 无 BOM 编码，但是部分作者未强制指定编码，导致游戏中中文翻译乱码，或者更甚者无法启动游戏。

经典代表就是 [FTB Achievements](https://minecraft.curseforge.com/projects/ftb-achievements) 模组，它在很多 FTB 整合包中均有使用。在 [FTB Skyfactory Challenges](https://www.feed-the-beast.com/projects/ftb-skyfactory-challenges) 整合包中，其所有的挑战任务均使用  [FTB Achievements](https://minecraft.curseforge.com/projects/ftb-achievements) 书写，任务文件在游戏主目录下的 config 文件夹中，采用 JSON 格式书写。其所有的任务描述由配置中的 `tagCompound` 标签书写，但是作者似乎并没有限定编码，导致其强制以 ASCII 编码进行解析，如果不慎写入中文字符，启动过程中游戏会直接崩溃。

所幸还是有办法解决，通过转义字符书写 Unicode 编码，即可正常加载。但是转义字符书写的 Unicode 编码毕竟不适合阅读，在翻译过程中检查排错都很困难，如果出现了这些编码问题，请及时向原作者反馈问题。

> **转义书写的 Unicode 编码字符**
>
> 采用四位 16 进制，开头辅以 `\u` 字符来转义；比如正常的 `中文` 二字，Unicode 编码为 `\u4e2d\u6587` 。当程序读取到这些转义字符时，便会以 Unicode 编码来进行解析，从而在其他编码环境的文件中愉快的插入 Unicode 字符。
>
> 网络上有很多相关工具可以将普通字符转换为 Unicode 转义字符，比如[站长工具](http://tool.chinaz.com/tools/unicode.aspx)。

#### （3）传参崩溃问题

一般 JSON 书写的文件除了语言文件之后，还有许多功能性参数。如果我们在错误的地方进行了翻译，而作者代码又不够健壮，就会导致游戏崩溃。这种崩溃可能是启动中崩溃，也可能是游戏中触发某个事件后崩溃。

举个例子，匠魂模组 2.5 版本手册中曾经存在一个翻译错误，翻译者~酒石酸~错误的翻译了 `shulking.json` 文件的`modifier` 字段，此处字段应当为工具强化的 id，不能够翻译。该错误导致匠魂手册在长达半年的时间，中文玩家一打开就会游戏崩溃。

![捕获.PNG](https://i.loli.net/2018/03/27/5aba1a06e4372.png)

> :arrow_up: 上图中 `modifier` 字段不应当翻译。

如何判定当前字段是否应当被翻译，需要翻译者查看具体源码，或者多次试错才能够发现，难度较大。

### ③ XML 语言文件

可扩展标记语言（**EXtensible Markup Language**，简称 XML）是一种标记语言，很像 HTML 语言，不过所有的标签均可自定义。XML 可读性较 JSON 稍差，除了早期模组，现在极少有模组使用这种语言。

XML 语言大致结构如下，整个文件主体部分必须要被标签所囊括，可以添加注释：

```xml
<note>
    <!--注释部分，注释可以书写在标签的外面-->
	<to>George</to>
	<from>John</from>
	<heading>Reminder</heading>
		<body>Don't forget the meeting!</body>
</note>
```

关于更多 XML 知识，可以查看 [W3school 中文教程](http://www.w3school.com.cn/xml/index.asp)。

目前所知还在使用 XML 语言的模组仅有 [InGame Info XML](https://minecraft.curseforge.com/projects/ingame-info-xml) 模组。如同 JSON 语言一样，XML 也可能包含很多功能性参数，如果书写位置错误，也可能会导致游戏崩溃。好在  [InGame Info XML](https://minecraft.curseforge.com/projects/ingame-info-xml) 作者代码健壮性还不错，只会导致无法加载，游戏并不会崩溃。

这里截取了部分 [InGame Info XML 配置文件源码](https://github.com/Lunatrius/InGame-Info-XML/blob/master/src/main/resources/assets/ingameinfo/ingameinfo.xml)。

```xml
<line>
	<str>Day {day}, {mctime} (</str>
	<if>
		<var>daytime</var>
		<str>$eDay</str>
		<str>$8Night</str>
	</if>
	<str> time$f)</str>
</line>
```

图中只有 `<str>` 便签围起来的部分可以被翻译。

### ④ YAML 语言文件

YAML 英文原名为 YAML Ain't Markup Language，YAML 可以方便的表达映射、数组之类的数据，而且采用缩进表示层级关系，阅读性极高。

YAML 格式一般如下：

```yaml
house:
  family:
    name: Doe
    parents:
      - John
      - Jane  # 可以随意插入注释
  address:
    number: 34
    street: Main Street
    "city": "Nowheretown"
    zipcode: 12345
```

- 缩进并没有强制要求，只需要保证同级数据缩进相等即可，不过不可以使用 tab 缩进；
- 数据可以依据个人习惯选择是否用引号圈住；
- `#` 后插入注释；
- 数组内元素采用 `-` 符号，相同缩进来表示；

采用 YAML 书写配置或者语言文件的模组极为罕见，但在插件的配置、语言文件中几乎全部采用此语言书写。

### ⑤ 其他格式

然而总是会有模组作者另辟蹊径，选择自定义的格式来书写语言文件或者配置，典型代表就是格雷科技和 [Simple Achievements](https://minecraft.curseforge.com/projects/simple-achievements) 模组。

格雷科技采用了原版配置文件格式来加载语言文件，且加载位置放置在游戏主目录下。下图为部分语言文件截取：

```
languagefile {
    S:"Dirty Water.name"=脏水
    S:bc.trigger.gregapi.energy.air.capacity.empty=空的 (ENERGY.AIR)
    S:bc.trigger.gregapi.energy.air.capacity.full=满的 (ENERGY.AIR)
}
```

其次是  [Simple Achievements](https://minecraft.curseforge.com/projects/simple-achievements) 模组书写的任务书，这部分配置同样没有限定编码，需要转换成 Unicode 字符，或者采用 GB 编码书写才可以正常使用。

下图为其部分截取，作者并未为此添加 `try catch` 结构，如果书写错误，游戏会启动崩溃。

```
--== 神秘农业 ==--| |资源始终是有限的，作物才能满足你的需求::1
合成一个铁种子::0
合成一个钻石种子::0
使用离魂块获得一个怪物灵魂碎片::0
使用生长水晶和生长加速器::0
合成一个大师级的注魔水晶::0
合成一个终极苹果::0
合成一个终极防具::0
::1
::1
::1
```

## 3. Git 与 GitHub

### ① Git 基本介绍

小明在写一个程序，万恶的产品经理不停地在改需求，小明只好把写好的代码改了删，删了改。一来二去，小明电脑上的文件越来越乱，小明急切的需要一套特殊的工具，能够完美的管控文件，快捷的撤销、重复之前的步骤。我们把这种工具叫版本控制系统（**Version Control System**，简称 VCS）。

而 Git 就是其中出色的一款系统，由 Linux 的创始人林纳斯·本纳第克特·托瓦兹创建，Git 监控文件变化的机理很简单——只记录文件的改变。

现在有个文件，内容如下：

```
Hello World！
```

我么对其进行修改：

```
Hello MC！
你好世界！
```

对于 Git 来说，就记录了这样的变化：

```diff
- Hello World！
+ Hello MC！
+ 你好世界！
```

这样的方式给多人协作带来了极大的方便，因为只记录变化的部分，只要两个人修改的不是同一处文件，简单的把两人的变化记录在一起，即可完美实现协作功能。

### ② GitHub 是什么？

我们书写了代码，如果想要给其他人观看，就必然要把代码放置在网络上。好在如今有很多网站提供了免费的代码托管。国外的有 GitHub，Gitlab，Bitbucket，国内的有 Coding，而 GitHub 则是其中用户量最大的一家。GitHub 上面的代码全部采用 Git 进行管理，同时支持多人协作，对于公开项目完全免费。

**网址：<https://github.com/>**

![QQ截图20180328120221.png](https://i.loli.net/2018/03/28/5abb13dba03a9.png)

### ③ Git 与 GitHub 的使用

GitHub 虽然能够支持网页上直接进行操作，但是功能非常少，使用起来也不方便。更多的时候是直接通过 Git 的命令行或者图形化程序来进行代码的下载、本地修改、上传等操作。

如果是 Windows 系统，用户需要去 [Git 官网](https://git-scm.com/)下载安装包，安装后即提供了命令行工具。

![QQ截图20180328120716.png](https://i.loli.net/2018/03/28/5abb14fa2e8b1.png)

## 4. 文本编辑器 Atom 的介绍

## 5. 正则表达式

# 第三章 翻译规范

## 1. 翻译指南

## 2. 词库

# 第四章 自动化翻译

## 1. 爬虫系统

## 2. Weblate 翻译平台

## 3. 持续化集成系统

