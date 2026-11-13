---
navigation:
  title: 激光功率
  icon: nautec:aquatic_catalyst
  position: 1
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:aquatic_catalyst
  - nautec:advanced_aquatic_catalyst
  - nautec:prismarine_crystal
---

# <Color id="light_purple">激光功率</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquatic_catalyst" scale="2"/>
  海蓝催化器能燃烧海晶石来发射激光束。
</Column>

海蓝科技机器的运作依赖于激光功率，单位为AP每刻（AP/t）。光束会携带两个值：它的功率和它的纯度。机器的运作需要功率，纯度在配方开始处理前检查。

光束只会在两个激光方块间形成。发送端需要最远16格内（`config/nautec-common.toml`中的`laserDistance`）存在能接受光束的面（机器、中继器、转接器、透镜）；光束由中继器发出时，判断范围为64格。两种情况均不允许中间存在固体方块。光束能穿透水和玻璃，搭建设施时可用玻璃封埋光束。

***

<Row>
  <ItemImage id="aquatic_catalyst"/>
  ### <Color id="aqua">海蓝催化器</Color>
</Row>

你的第一个激光功率源。它会一一燃烧海晶物品，并从特定面发出光束。

<Recipe id="nautec:aquatic_catalyst"/>

用物品堆叠右击催化器可装入燃料，也可用漏斗供应。空手右击可取出还未开始燃烧的燃料。

| 燃料                                      | 纯度 | 功率    | 燃烧时间 |
| ----------------------------------------- | ---- | ------- | -------- |
| 海晶碎片                                  | 0.4  | 12 AP/t | 30 s     |
| 海晶砂粒                                  | 0.8  | 6 AP/t  | 30 s     |
| <ItemLink id="prismarine_crystal_shard"/> | 1.2  | 20 AP/t | 75 s     |

放置时面向你的面呈淡色，可在该面装入燃料。光束会从对侧面、即有青色透镜的深色面射出。放置时向下看，可让催化器向下发射光束；向上看可向上发射。<ItemLink id="aquarine_steel_wrench"/>可旋转已放置的催化器。

催化器只会在发射面有目标时燃烧燃料，没有目标便保留燃料等待，不会浪费。两份燃料的交接没有空隙，只要还有燃料，光束就不会间断。一组64个碎片足够燃烧32分钟。

红石信号可暂停燃烧。催化器暂停时不会发射光束，并保留其燃料和燃烧进度，撤去信号后即恢复到暂停时的状态。

<ItemLink id="budding_prismarine"/>若与催化器除透镜面外的任意一面接触，即可增强发射的光束。每个方块增加25%的功率和0.1的纯度，纯度最高可达2.0（`catalystBuddingOutputBonus`、`catalystBuddingPurityBonus`、`catalystBuddingMaxPurity`）。起增强作用的海晶母岩不会长出晶芽：催化器每秒都会破坏母岩上的晶簇，且不产生掉落物。

侧面上靠近透镜的两盏小灯指示了催化器有没有找到接收端。绿色代表范围内有方块接受激光。红色代表没有：可能是透镜方向没有方块、有固体方块挡路、或所对的方块面不接受光束（通常由中继器朝向错误引起）。空手Shift右击催化器可向聊天栏发送燃料读数、光束方向、光束击中的目标，以及排除问题的建议。

<Color id="gold">提示</Color>：光束会灼烧它经过的所有东西，也包括你。光束越强，灼烧力度越大（参见[传输激光功率](nautec:laser_chemistry/laser_manipulation.md)）。注意避让光束，或也可用玻璃封起光束。

***

<Row>
  <ItemImage id="advanced_aquatic_catalyst"/>
  ### <Color id="aqua">高级海蓝催化器</Color>
</Row>

镶有金框的海蓝催化器，能同时燃烧8个燃料物品。每次燃烧的持续时间和海蓝催化器中燃烧一个物品的相同，光束的功率变为8倍，也即一组碎片可产生160 AP/t而非20，但消耗速度也变为8倍。每个物品的能量产出不变，只是加快产速而已。

<Recipe id="nautec:advanced_aquatic_catalyst"/>

| 燃料                                      | 纯度 | 功率     | 燃烧时间 |
| ----------------------------------------- | ---- | -------- | -------- |
| 海晶碎片                                  | 0.44 | 96 AP/t  | 30 s     |
| 海晶砂粒                                  | 0.88 | 48 AP/t  | 30 s     |
| <ItemLink id="prismarine_crystal_shard"/> | 1.32 | 160 AP/t | 75 s     |

使用相同的燃料，它发射的光束纯度比海蓝催化器发射的高出10%，此增益生效于海晶母岩增强之前。若燃料物品少于八个，它也会全部燃烧，并按数量计算功率。放置、指示灯、海晶母岩、Shift右击读数等所有其他方面都和海蓝催化器一样。`advancedCatalystFuelMultiplier`和`advancedCatalystPurityMultiplier`分别对应8和10%。

***

## <Color id="gold">纯度</Color>

光束在发射时就确定了纯度。催化器光束的纯度由燃料的纯度决定，可为0.4到1.2，再加海晶母岩增益。有两条及以上光束射向同一个方块时，最终功率是所有光束功率的和，最终纯度则接近于其中纯度最高者。详细计算方法为：最高纯度减去其与平均纯度差值的四分之一（`beamMergePurityDrop`），纯度3.0的光束和纯度0的光束汇合，最终纯度会是2.6左右。

高纯度需要使用<ItemLink id="prismarine_crystal"/>（天然为3.0，培育所得为3.00-6.00，最高可富集至12）或<ItemLink id="bacterial_fuel_cell"/>（最高2.5），也可用<ItemLink id="focusing_lens"/>提高现有光束的纯度。[激光光学](nautec:deep_engineering/beam_optics.md)中介绍了激光的转向、分叉和聚焦。

***

<Row>
  <ItemImage id="prismarine_crystal"/>
  ### <Color id="aqua">海晶水晶</Color>
</Row>

出现于海床下方水晶晶洞（参见[结构](structures.md)）内的六格高水晶。它能将所有光束变为纯度3.0的光束。天然的水晶无法搬走，但你可以自行培育出能被搬走的水晶，其光束纯度会在水晶长成时于3.00-6.00间抽选：参见[水晶培育](nautec:deep_engineering/crystal_cultivation.md)。[细菌富集催化机](nautec:deep_engineering/bacterial_enrichment_catalyst.md)可将纯度进一步提高到12。

可向水晶的侧面发射光束。水晶所有六个方块的四个侧面都接受光束，且会汇总各光束。这之后，顶部方块会向上发射光束，底部方块会向下发射，两光束的纯度均与水晶的相同：天然水晶为3.0，培育所得的水晶则会在长成时随机抽选一个固定值。只有其中一条抵达接收端时，该光束会携带所有输入功率；若两条都能抵达，则会在两者间均分。水晶的AP输出量不会超过输入量。光束直到抵达接收端或固体方块才会停止，在天花板和地板出留出空间就可让光束穿过。

天然水晶无法被搬离生成位置，需要就地搭建设施。启用能力的海蓝钢镐可从水晶上凿取[海晶水晶碎片](nautec:laser_chemistry/crystal_shards.md)，但每次都有概率摧毁整个水晶。

***

## <Color id="gold">传输功率</Color>

* [激光操控](nautec:laser_chemistry/laser_manipulation.md)：用于传递光束的海晶石激光中继器，用于合并和分叉光束的激光转接器。
* [激光光学](nautec:deep_engineering/beam_optics.md)：用于提高纯度的聚焦透镜。
* [充能器](nautec:laser_chemistry/charger.md)和[海晶电池](nautec:laser_chemistry/prismatic_battery.md)：将功率储存于物品。

佩戴<ItemLink id="prism_monocle"/>可读出激光方块收到的功率和纯度。

***

## <Color id="gold">更强大的光束</Color>

机器的AP指标是它的运作需求，不是消耗量。发射更强的光束不会产生浪费：大多数机器都会因此加快运作速度，乘数为光束功率与需求功率比值的平方根，也即四倍功率可让机器以两倍速运转。[更强大的光束](nautec:getting_started/stronger_beams.md)中给出了详细的规则和适用的各机器。
