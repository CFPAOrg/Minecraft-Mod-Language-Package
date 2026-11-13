---
navigation:
  title: 海蓝钢与铸铁
  icon: nautec:aquarine_steel_ingot
  position: 2
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:aquarine_steel_compound
  - nautec:aquarine_steel_ingot
  - nautec:aquarine_steel_block
  - nautec:cast_iron_compound
  - nautec:cast_iron_ingot
  - nautec:cast_iron_nugget
  - nautec:cast_iron_rod
  - nautec:cast_iron_block
  - nautec:laser_channeling_coil
  - nautec:whisk
  - nautec:broken_whisk
  - nautec:oil_barrel
---

# <Color id="light_purple">海蓝钢与铸铁</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_ingot" scale="2"/>
  制造大多数海蓝科技机器需用的金属和部件。
</Column>

## <Color id="gold">海蓝钢</Color>

<Row>
  <ItemImage id="aquarine_steel_compound"/>
  ### <Color id="aqua">海蓝钢混合物</Color>
</Row>

可以手工合成，也可在[搅拌机](mixer.md)与盐水混合。使用相同量的粗铁，后者的产量更多。JEI中给出了搅拌机的配方。

<Recipe id="nautec:aquarine_steel_compound"/>

<Row>
  <ItemImage id="aquarine_steel_ingot"/>
  ### <Color id="aqua">海蓝钢锭</Color>
</Row>

将混合物投入有功率的激光，等待5秒，它即会变成锭。光束的纯度不限，一台海蓝催化器就已足够。如使用纯度2.0及以上的光束，则只需等待4秒，且能给出2个锭。设施的搭建参见[物品转化](nautec:getting_started/item_transformation.md)。

<Row>
  <ItemImage id="aquarine_steel_block"/>
  ### <Color id="aqua">海蓝钢块</Color>
</Row>

相当于九个锭的储物方块。

<RecipeFor id="aquarine_steel_block"/>

***

## <Color id="gold">铸铁</Color>

<Row>
  <ItemImage id="cast_iron_compound"/>
  ### <Color id="aqua">铸铁混合物</Color>
</Row>

<Recipe id="nautec:cast_iron_compound"/>

<Row>
  <ItemImage id="cast_iron_ingot"/>
  ### <Color id="aqua">铸铁锭</Color>
</Row>

在熔炉中烧炼混合物，高炉烧炼可翻倍产量。

<Recipe id="nautec:cast_iron_ingot_blasting"/>

来自海床的老旧铁坨子也可以用高炉烧炼：锚相当于11个锭，油桶相当于5个锭。

<Recipe id="nautec:cast_iron_ingot_from_oil_barrel_blasting"/>

<Row>
  <ItemImage id="cast_iron_rod"/>
  ### <Color id="aqua">铸铁棒</Color>
</Row>

用于制造海蓝钢工具、钓鱼站、深海排水口壁、油桶和搅拌器。

<Recipe id="nautec:cast_iron_rod"/>

<Row>
  <ItemImage id="cast_iron_nugget"/>
  ### <Color id="aqua">铸铁粒</Color>
</Row>

九个粒可合成锭，也可反向拆解。铸铁粒可修复破损的搅拌器。

<Row>
  <ItemImage id="cast_iron_block"/>
  ### <Color id="aqua">铸铁块</Color>
</Row>

相当于九个锭的储物方块。

<Recipe id="nautec:cast_iron_block_from_ingots"/>

<Row>
  <ItemImage id="oil_barrel"/>
  ### <Color id="aqua">油桶</Color>
</Row>

能装下最多8,000 mB原油的铸铁油桶，接受海蓝科技和其他模组的原油（即所有`c:oil`标签下的流体）。右击可打开或关闭桶盖；只有在桶盖打开时管道才能访问内容物。用高炉烧炼它可得到铸铁锭。用镐挖掘可带走。

<Recipe id="nautec:oil_barrel"/>

***

## <Color id="gold">机器部件</Color>

<Row>
  <ItemImage id="laser_channeling_coil"/>
  ### <Color id="aqua">激光传导线圈</Color>
</Row>

由<ItemLink id="burnt_coil"/>通过物品转化制成：纯度1.5及以上，等待10秒。海蓝催化器的极限是1.2，因此需要让光束射入<ItemLink id="prismarine_crystal"/>再使用，或需要让光束通过<ItemLink id="focusing_lens"/>。

线圈是制造充能器、海晶电池、大多数海蓝钢工具以及许多后期机器的原材料。

<Row>
  <ItemImage id="broken_whisk"/>
  ### <Color id="aqua">破损的搅拌器</Color>
</Row>

溺尸偶尔会掉落一个，在幸运垂钓区内有可能作为宝藏钓到它，海底废墟和研究前哨站的箱子里也会出现。

<Row>
  <ItemImage id="whisk"/>
  ### <Color id="aqua">搅拌器</Color>
</Row>

[搅拌机](mixer.md)的搅拌头。需用四个铸铁粒修复破损的搅拌器，也可用铸铁棒、海晶水晶碎片和一个海蓝钢锭直接合成。

<Recipe id="nautec:whisk"/>
<Recipe id="nautec:whisk_from_cast_iron"/>
