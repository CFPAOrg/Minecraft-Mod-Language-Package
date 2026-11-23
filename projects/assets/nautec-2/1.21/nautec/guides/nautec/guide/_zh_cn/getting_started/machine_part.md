---
navigation:
  title: 远古机器部件
  icon: nautec:ancient_valve
  position: 5
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:burnt_coil
  - nautec:rusty_gear
  - nautec:gear
  - nautec:ancient_valve
  - nautec:valve
  - nautec:damaged_aquatic_chip
  - nautec:aquatic_chip
---

# <Color id="light_purple">远古机器部件</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="ancient_valve" scale="2"/>
  来自海床的破损部件，在配方中使用前需要先修复。
</Column>

来自海床的齿轮、阀门、线圈、芯片、搅拌器都已受损，使用前需要修复，而每种部件的修复方式不一。[回收](salvage.md)中列出了它们的出现位置。在找到水晶晶洞之后，你就可以直接自行制造所有部件了，不必再为运气好坏发愁：参见本页底部的自行制造。

| 发现时                                | 修复后                        | 如何修复                                    |
| ------------------------------------- | ----------------------------- | ------------------------------------------- |
| <ItemLink id="rusty_gear"/>           | <ItemLink id="gear"/>         | [蚀刻](etching.md)                          |
| <ItemLink id="ancient_valve"/>        | <ItemLink id="valve"/>        | [蚀刻](etching.md)                          |
| <ItemLink id="burnt_coil"/>           | 激光传导线圈                  | 纯度1.5的[物品转化](item_transformation.md) |
| <ItemLink id="damaged_aquatic_chip"/> | <ItemLink id="aquatic_chip"/> | 合成                                        |
| 破损的搅拌器                          | 搅拌器                        | 合成                                        |

***

<Row>
  <ItemImage id="gear"/>
  ### <Color id="aqua">齿轮</Color>
</Row>

将生锈的齿轮投入蚀刻酸。齿轮是制造海蓝钢镐、海蓝钢斧、海蓝钢锹、搅拌机、钓鱼站、深海排水口和两种强化件的原材料。

***

<Row>
  <ItemImage id="valve"/>
  ### <Color id="aqua">阀门</Color>
</Row>

将远古阀门投入蚀刻酸。阀门是制造海蓝钢胸甲、海蓝钢护腿、深海排水口、喷口汇热器、氧气散布器、压力舱门、载货模块、聚变堆端口的原材料。

***

<Row>
  <ItemImage id="burnt_coil"/>
  ### <Color id="aqua">激光传导线圈</Color>
</Row>

用纯度1.5的光束照射烧坏的线圈10秒。可用海晶水晶、细菌燃料单元、聚焦透镜产生所需光束，详见[物品转化](item_transformation.md)。线圈是制造海蓝钢工具、充能器、海晶电池和许多其他机器的原材料。

***

<Row>
  <ItemImage id="aquatic_chip"/>
  ### <Color id="aqua">海蓝芯片</Color>
</Row>

将损坏的海蓝芯片与海晶碎片合成。海蓝芯片是制造培养机、生物反应机、细菌燃料单元、压力锻造机、共鸣室、大多数海洋斥候模块、大多数可合成强化件的原材料。偶能通过生物荧光林的幸运区宝藏获取已修复的芯片。

<Recipe id="nautec:aquatic_chip"/>

***

## <Color id="gold">搅拌器</Color>

将破损的搅拌器与铸铁粒合成。搅拌器是制造[搅拌机](nautec:laser_chemistry/mixer.md)的原材料。破损的搅拌器则可从溺尸身上、海底废墟箱子中，以及作为幸运区宝藏获取。

<Recipe id="nautec:whisk"/>

***

## <Color id="gold">自行制造</Color>

随着游戏流程的推进，所有部件最终都能稳定制造。各部件间有解锁顺序：

1. **齿轮**：将铸铁块投在纯度2.5及以上的光束下，持续8秒，它就会变成四个齿轮。只有<ItemLink id="prismarine_crystal"/>和<ItemLink id="bacterial_fuel_cell"/>能达到2.5的纯度，参见[物品转化](item_transformation.md)。
2. **阀门和搅拌器**：使用铸铁、齿轮、海蓝钢、海晶水晶碎片合成。
3. 使用阀门和搅拌器制造[深海排水口](nautec:laser_chemistry/drain.md)和[搅拌机](nautec:laser_chemistry/mixer.md)。
4. **烧坏的线圈**：向搅拌机放入4个铜锭、2份红石、1个海蓝钢锭、1个海晶水晶碎片，并灌入1,000 mB的盐水，可制成1个烧坏的线圈。需和上文所说的一样用纯度1.5的光束修复。
5. **海蓝芯片**：向搅拌机放入2个金锭、4份红石、2个海晶水晶碎片、1个激光传导线圈，并灌入1,000 mB的盐水，可制成2个完好的海蓝芯片。

JEI中会给出搅拌机和光束配方。

<Recipe id="nautec:valve_from_cast_iron"/>

<Recipe id="nautec:whisk_from_cast_iron"/>
