---
navigation:
  title: 反应机升级
  icon: nautec:reactor_speed_upgrade
  position: 11
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:reactor_speed_upgrade
  - nautec:reactor_yield_upgrade
  - nautec:reactor_efficiency_upgrade
  - nautec:reactor_fusion_upgrade
---

# <Color id="light_purple">反应机升级</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="reactor_speed_upgrade" scale="2"/>
  升级可增加反应机的产量，降低反应机的消耗，但需以能耗增加为代价。
</Column>

[生物反应机](bio_reactor.md)有2个升级槽，[工业生物反应机](industrial_bio_reactor.md)有4个。每个槽都能容纳一个升级，类型不限，同时安装两个同种升级时效力也会变为两倍。升级会影响反应机中的所有菌落。也可用漏斗和管道放入升级；升级只会进入升级槽。

各升级的提示文本会显示当前配置中给定的升级效果数据和能耗乘数。

***

## <Color id="gold">升级</Color>

<Row>
  <ItemImage id="reactor_speed_upgrade"/>
  ### <Color id="aqua">反应机速度升级</Color>
</Row>

每个升级追加50%产量：一个升级变为1.5倍速，两个2倍速，四个3倍速。能耗乘数为1.6。

<Row>
  <ItemImage id="reactor_yield_upgrade"/>
  ### <Color id="aqua">反应机产量升级</Color>
</Row>

每周期结束后额外产出一个物品：一个升级每周期产出2个物品，两个升级产出3个物品，四个升级5个物品。能耗乘数为1.8。只有对应输出槽能够容纳一批次的所有产物，才会实际完成当前生产周期。

<Row>
  <ItemImage id="reactor_efficiency_upgrade"/>
  ### <Color id="aqua">反应机效率升级</Color>
</Row>

每个升级额外让各菌落每刻少消耗25%的[营养物质缓存](colony_feeding.md)，效应乘算：一个升级消耗75%，两个消耗56%，三个42%，四个32%。相当于1,200刻的营养物质在有一个升级时可续航80秒，两个时107秒，四个时190秒。消耗量不会降至25%（可配置）的下限之下，默认情况下即便是四个升级也无法达到。能耗乘数为1.2。该升级不会改动物品的输出速率。

速度和产量升级都能降低每份产物需消耗的营养物质量，这是因为营养物质按刻而不是按产物份数消耗。在每份输出AP消耗量的层面上讲，产量升级（两倍产物，1.8倍能耗）优于速度升级（1.5倍产物，1.6倍能耗）。

<Row>
  <ItemImage id="reactor_fusion_upgrade"/>
  ### <Color id="aqua">反应机合并升级</Color>
</Row>

由其他三种升级各一个合成。一个合并升级的效力相当于同时安装速度、产量、效率升级各一个，而且能和其他合并升级堆叠。能耗乘数为2.5，比分开安装三者的3.46要小。

可在升级槽紧俏的反应机中使用。工业生物反应机中安装四个合并升级，速度为3倍，产物每周期5个，营养物质消耗量为32%，能耗则为基值的约39倍。

***

## <Color id="gold">能耗计算</Color>

所需AP = (基值 + 每菌落能耗 x 有菌落槽位数) x 1.6 ^ 速度升级数 x 1.8 ^ 产量升级数 x 1.2 ^ 效率升级数 x 2.5 ^ 合并升级数，向上取整

各升级的乘数之间也是乘算，因此能耗会快速上涨。基值和每菌落能耗参见[生产率](production_rates.md)。

有3个菌落的生物反应机：

| 升级           | 所需AP |
| -------------- | ------ |
| 无             | 50     |
| 1 速度         | 80     |
| 2 速度         | 128    |
| 1 产量         | 90     |
| 2 产量         | 162    |
| 1 速度，1 产量 | 144    |
| 1 产量，1 效率 | 108    |
| 2 效率         | 72     |
| 1 合并         | 125    |
| 1 合并，1 产量 | 225    |
| 2 合并         | 313    |

有9个菌落的工业生物反应机：

| 升级           | 所需AP |
| -------------- | ------ |
| 无             | 550    |
| 4 效率         | 1,141  |
| 2 产量，2 效率 | 2,567  |
| 4 速度         | 3,605  |
| 2 速度，2 产量 | 4,562  |
| 4 产量         | 5,774  |
| 1 合并         | 1,375  |
| 2 合并         | 3,438  |
| 2 合并，2 产量 | 11,138 |
| 4 合并         | 21,485 |

本页中的所有增益和乘数均可配置。

***

## <Color id="gold">配方</Color>

原材料的来源参见[深海材料](nautec:deep_engineering/materials.md)。

***

## <Color id="gold">更强大的光束</Color>

强激光的速度乘数作用于速度升级之后，两者效果相乘。会提高能耗的升级也会抬高强激光效应的起始点，也即光束加速的方方面面都会以反应机升级后的数值为基准计算。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。

<RecipeFor id="reactor_speed_upgrade"/>

<RecipeFor id="reactor_yield_upgrade"/>

<RecipeFor id="reactor_efficiency_upgrade"/>

<RecipeFor id="reactor_fusion_upgrade"/>
