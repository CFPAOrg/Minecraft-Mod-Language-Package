---
navigation:
  title: 细菌分析机
  icon: nautec:bacterial_analyzer
  position: 4
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:bacterial_analyzer
  - nautec:advanced_bacterial_analyzer
---

# <Color id="light_purple">细菌分析机</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bacterial_analyzer" scale="2"/>
  细菌分析机可验明菌落的大小、活力、统计数据。
</Column>

向左侧槽位放入装有未分析菌落的<ItemLink id="petri_dish"/>。等待3秒，经过分析的培养皿即会出现在右侧槽位。进行下一次分析前需要清空右侧槽位。左侧槽位只接受其中菌落未经分析的培养皿，使用管道运输时不会被空培养皿或已分析的培养皿堵塞。

生物学机器也可以操作未经分析的菌落；分析只是能方便你读数，但它们也是你判断要选育、培养、燃烧哪些菌落的依据。[诱变机](mutator.md)输出的菌落会回到未分析状态。

***

## <Color id="gold">搭建</Color>

分析机有两格高，放置时需要上方方块为空。右击任意一处即可打开。

它需要下部底面接收至少5 AP。该功率只是阈值：少于5 AP停工，恰好在5 AP为正常速度，多于5 AP则加快运转速度（见下）。

分析耗时（60刻）和所需功率（5 AP）均可配置。

漏斗和管道可向下部方块输入培养皿，并从该处抽出经过分析的培养皿，默认所有面均可。[面配置](nautec:getting_started/utilities.md)可调整每一面的交互方式。

***

## <Color id="gold">读出已分析培养皿的数据</Color>

提示文本中会显示大小、活力，有产物的品系还会显示品系产量。同时按住Shift和Control还能查看下一次突变时菌落各统计数据的变动范围。Shift还会给出品系在反应机中的营养物质，在培养机中增长需要什么物品，以及突变的去向品系，同时给出各路线的诱变剂和概率。红色的统计数据代表已达上限。各统计数据的介绍参见[细菌统计数据](bacteria_stats.md)。

***

## <Color id="gold">配方</Color>

<Recipe id="nautec:bacterial_analyzer"/>

***

## <Color id="gold">高级细菌分析机</Color>

<Row>
  <ItemImage id="advanced_bacterial_analyzer" scale="2"/>
</Row>

能同时分析九个培养皿。它有九个输入槽和九个输出槽，输入槽中的各个培养皿可同时经历60刻的分析耗时，装满时的分析耗时和基础分析机中分析一次的耗时相同。分析进度显示为各槽位中从下往上横扫的色带。

* 功率：至少40 AP，纯度2.1及以上，向除前面外的任意面发射。功率或纯度不达标即停工并保留进度。[海晶水晶](nautec:getting_started/laser_power.md)光束（3.0）或满纯度的<ItemLink id="bacterial_fuel_cell"/>（2.5）均符合要求。
* 机器只接受未经分析的培养皿，也即不会被管道送来的已分析或空培养皿堵塞。
* 所有九个输出槽都满时，分析完毕的培养皿会在输入槽中等候，直至输出槽腾出空间。

鼠标悬停在箭头上可查看等待的原因，或也可透过<ItemLink id="prism_monocle"/>观察。默认情况下，漏斗和管道可在任意面上输入输出（[面配置](nautec:getting_started/utilities.md)）。耗时、功率、纯度均在`config/nautec-common.toml`中。

<Recipe id="nautec:advanced_bacterial_analyzer"/>

***

## <Color id="gold">更强大的光束</Color>

光束越强，分析机和高级分析机就运转得更快：速度乘数为(光束功率 ÷ 所需功率)的平方根。细菌分析机需要5 AP，提供20 AP可让分析速度翻倍。高级细菌分析机需要纯度2.1的40 AP，提供该纯度的160 AP可用两倍速分析所有九个培养皿。继续提高纯度不影响速度。

| 光束，以所需功率倍数计 | 速度       |
| ---------------------- | ---------- |
| 1×                     | ×1（正常） |
| 4×                     | ×2         |
| 9×                     | ×3         |
| 16×                    | ×4         |

3秒的单菌落分析耗时对应提供5 AP光束时的数据。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
