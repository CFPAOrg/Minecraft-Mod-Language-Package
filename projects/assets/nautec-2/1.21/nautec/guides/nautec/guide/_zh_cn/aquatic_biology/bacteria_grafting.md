---
navigation:
  title: 细菌移植
  icon: nautec:grafting_tool
  position: 3
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:grafting_tool
  - nautec:grafting_station
  - nautec:grafting_anchor
  - nautec:advanced_grafting_anchor
---

# <Color id="light_purple">细菌移植</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="grafting_tool" scale="2"/>
  移植工具能帮你从方块上刮下你的第一个菌落，再存放到培养皿中。
</Column>

主手持移植工具，副手持空<ItemLink id="petri_dish"/>，再右击相应生物群系中的可移植方块。每次尝试都有概率向培养皿放入一个新菌落，无论成功与否都消耗1点耐久度。点击到获得菌落即可。

<Color id="gold">提示</Color>：只可移植至空培养皿。若副手中的培养皿内有菌落，工具会显示“培养皿中已有菌落”，并且不会移植也不消耗耐久度。

***

## <Color id="gold">移植工具</Color>

<RecipeFor id="grafting_tool"/>

该工具有80点耐久度。

***

## <Color id="gold">可移植的地点</Color>

| 方块                                | 生物群系                                             | 品系     | 概率 |
| ----------------------------------- | ---------------------------------------------------- | -------- | ---- |
| 石头                                | 任意海洋                                             | 蓝细菌   | 40%  |
| 沙子                                | 任意沙滩                                             | 盐细菌   | 40%  |
| 灰化土                              | 任意森林                                             | 甲烷菌   | 40%  |
| 下界岩                              | 下界                                                 | 嗜热菌   | 40%  |
| 发光珊瑚虫                          | 生物荧光林                                           | 蓝细菌   | 50%  |
| 深海海带                            | 生物荧光林                                           | 盐养菌   | 30%  |
| 荧光海藻                            | 生物荧光林                                           | 成藻菌   | 30%  |
| 海晶长叶                            | 海晶珊瑚礁                                           | 光养菌   | 35%  |
| <ItemLink id="budding_prismarine"/> | 海晶珊瑚礁、生物荧光林、深渊海沟、暖水海洋、温水深海 | 嗜岩石菌 | 30%  |
| 深渊珊瑚                            | 深渊海沟                                             | 嗜钙菌   | 30%  |
| 喷口管虫                            | 热液喷口区                                           | 嗜硫菌   | 25%  |

整合包可能会改动此列表。JEI的细菌移植分类会显示当前的配方，生物群系显示在“仅在”之后。

***

## <Color id="gold">移植站</Color>

<Row>
  <ItemImage id="grafting_station" scale="2"/>
</Row>

移植站可不借助工具移植，也不要求生物群系符合。放入空<ItemLink id="petri_dish"/>和上表中的一个可移植方块，再注入盐水，机器即会每周期向培养皿放入全新的菌落。这里的移植操作不进行概率抽选，也即必定成功。

* 供能：至少100 AP、纯度2.8及以上的光束，向除前面外的任意面发射。<ItemLink id="prismarine_crystal"/>光束（3.0）可以直接射入，也可通过中继器和转接器送入。
* 盐水：每个菌落4,000 mB。储罐容量为16,000 mB。可以管道通入或用铁桶右击。
* 耗时：每个菌落一分钟。光束过弱只会暂停进度，不会损失。
* 每个菌落都需占用一个培养皿，并消耗一个方块，除非机器中安装有移植锚或高级移植锚。

右击打开。鼠标悬停在箭头上可查看等待的原因，或也可透过<ItemLink id="prism_monocle"/>观察。漏斗和管道可以送入培养皿和抽出有菌落的培养皿，默认可对任意面输入输出（[面配置](nautec:getting_started/utilities.md)）。运作时机器前部的视窗会亮起。

所有数据均在`config/nautec-common.toml`中。

<RecipeFor id="grafting_station"/>

<Row>
  <ItemImage id="grafting_anchor"/>
  ### <Color id="aqua">移植锚</Color>
</Row>

移植站的升级。放在移植站界面左下角的槽位中，每次移植后即不会消耗样本方块，只要培养皿和盐水供应充足便能持续移植出菌落。在物品栏中Shift点击移植锚可直接放入相应槽位。管道无法访问该槽位，自动化设施不会误抽移植锚。

<RecipeFor id="grafting_anchor"/>

<Row>
  <ItemImage id="advanced_grafting_anchor"/>
  ### <Color id="aqua">高级移植锚</Color>
</Row>

高级版移植锚，由四个[生物反应机](bio_reactor.md)的反应机速度升级制成。它也需放在左下角的槽位，同样可以避免消耗可移植方块，不过它能让移植速度加快200%，产出一个菌落从1分钟变为20秒。其缺点在于能耗：安装后移植站改为需要500 AP的光束，即常规100 AP的五倍，但纯度需求仍是2.8及以上。将鼠标悬停在移植站界面中的箭头上可查看当前移植锚的需求。

<RecipeFor id="advanced_grafting_anchor"/>

***

## <Color id="gold">更强大的光束</Color>

提供的光束越强，移植站的移植速度越快：速度乘数为(光束功率 ÷ 所需功率)的平方根。机器需要100 AP，或在有高级移植锚时需要500 AP；纯度需求则一直为2.8及以上。

| 光束，以所需功率倍数计 | 速度       |
| ---------------------- | ---------- |
| 1×                     | ×1（正常） |
| 4×                     | ×2         |
| 9×                     | ×3         |
| 16×                    | ×4         |

光束和移植锚的效果会叠加。高级移植锚在500 AP时已在用三倍速移植，改为提供2,000 AP可在三倍速基础上翻倍，也即一个菌落只需消耗10秒而非60秒。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

***

## <Color id="gold">开始时选哪些菌落</Color>

蓝细菌、盐细菌、甲烷菌、嗜热菌没有产物，也无法培养。它们是突变的起始点：直接把它们放到[诱变机](mutator.md)里，将其突变成有产物的品系。

深海生物群系品系则可在移植后直接投产。盐养菌产出海带，成藻菌产出海草，光养菌产出甘蔗，嗜岩石菌产出石头，嗜钙菌产出骨粉，嗜硫菌产出火药。嗜岩石菌也是其他许多品系的突变亲本，直接从海晶母岩上移植它可跳过一步15%概率的嗜热菌突变；到[海洋深处](nautec:getting_started/deep_oceans.md)转一圈能剩下很多突变的麻烦。

全新菌落均为未分析状态。用[细菌分析机](bacterial_analyzer.md)处理以查看所得菌落的详细信息。
