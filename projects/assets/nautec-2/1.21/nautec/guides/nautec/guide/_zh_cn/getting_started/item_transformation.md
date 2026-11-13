---
navigation:
  title: 物品转化
  icon: nautec:aquarine_steel_ingot
  position: 2
  parent: getting_started/getting_started-index.md
---

# <Color id="light_purple">物品转化</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_ingot" scale="2"/>
  有一定功率的激光能转化掉落的物品。
</Column>

将物品丢到有一定功率的激光内即可，可在发送端到接收端间任选位置。有转化配方与物品匹配、且激光纯度足够时，物品即会在经过配方耗时后发生转化。整个过程中不需要点鼠标，且整个物品堆叠会一起转化，每个物品都会变成相应的产物：投入3个海晶砂粒会产出6个海晶水晶碎片。

物品需要在光束中停留足够的时间。若是物品被推走，或是激光功率不足（哪怕只不足了一瞬），转化进度便会归零。

***

## <Color id="gold">配方</Color>

| 输入                             | 输出                                         | 所需纯度 | 时间 |
| -------------------------------- | -------------------------------------------- | -------- | ---- |
| 海蓝钢混合物                     | 海蓝钢锭                                     | 任意     | 5 s  |
| 海蓝钢混合物                     | 2个海蓝钢锭                                  | 2.0      | 4 s  |
| <ItemLink id="burnt_coil"/>      | 激光传导线圈                                 | 1.5      | 10 s |
| 海晶砂粒                         | 2个<ItemLink id="prismarine_crystal_shard"/> | 2.0      | 8 s  |
| <ItemLink id="cast_iron_block"/> | 4个<ItemLink id="gear"/>                     | 2.5      | 8 s  |

有多个配方匹配时，光束会尽可能使用高纯度的配方，纯度2.0及以上的光束可将1份混合物变为2个锭。

JEI在物品转化分类下列出了所有转化配方，也包括其他模组或数据包添加的。

如需自动化，可以用[激光合成矩阵](laser_crafting_matrix.md)来以机器的形式执行本页提及的所有转化，原材料由管道提供。

***

## <Color id="gold">海蓝钢</Color>

海蓝钢是要制造的第一样东西。转化所需混合物没有纯度要求，无论什么样的<ItemLink id="aquatic_catalyst"/>光束都可以：让催化器指向<ItemLink id="prismarine_laser_relay"/>等接收端，再将混合物丢到光束中即可。

<Recipe id="nautec:aquarine_steel_compound"/>

后续可用[搅拌机](nautec:laser_chemistry/mixer.md)批量制造混合物。

***

## <Color id="gold">更高的纯度</Color>

激光传导线圈和海晶水晶碎片需要的纯度比催化器的上限1.2还要高。可以用下方之一：

* <ItemLink id="prismarine_crystal"/>，纯度3.0。相应设施见下。
* <ItemLink id="bacterial_fuel_cell"/>，根据菌落最高可达2.5。
* 在光束中放置<ItemLink id="focusing_lens"/>，可将光束的纯度提高0.5，最高可至2.0（`lensPurityBonus`）。
* 接触催化器的<ItemLink id="budding_prismarine"/>，每方块追加0.1，最高可至2.0。参见[激光功率](laser_power.md)。

转化会按物品所处光束的纯度进行判断。若投入透镜发出的光束，那么用的就是透镜提高过的纯度。在催化器中使用海晶水晶碎片，再让光束通过一个透镜，所得纯度即为1.7，足够修复线圈了。

***

## <Color id="gold">海晶水晶之下</Color>

所有水晶晶洞（参见[结构](structures.md)）中都有一个海晶水晶，且其与底部之间已留有空隙（石头晶洞间距一格，深板岩晶洞间距两格），恰好是纯化所需要的。

* 在与海晶水晶齐平的任意位置放置催化器，相距最多16格，让它指向水晶侧面。两者之间不得有东西阻挡。
* 向催化器放入任意燃料。水晶最下方的方块即会向下射出纯度3.0的光束。
* 将物品丢到空隙中，让它们被光束击中。

确保催化器燃料充足。只要燃料耗尽，水晶的光束即会消失，转化进度重置。

<Color id="gold">提示</Color>：光束会灼烧它经过的一切事物。进行转化时建议从旁边投入物品，不要站在光束下方。
