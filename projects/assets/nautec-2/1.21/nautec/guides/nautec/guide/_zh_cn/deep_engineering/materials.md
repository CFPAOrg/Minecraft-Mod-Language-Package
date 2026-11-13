---
navigation:
  title: 深海材料
  icon: nautec:flawless_prismarine_crystal
  position: 4
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonant_shard
  - nautec:flawless_prismarine_crystal
  - nautec:deep_steel_plating
---

# <Color id="light_purple">深海材料</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="flawless_prismarine_crystal" scale="2"/>
  共鸣室和深渊压力锻造机制造的三种合成原材料。
</Column>

所有材料均只有一个机器配方。JEI会显示相应的纯度和深度需求。

***

<Row>
  <ItemImage id="resonant_shard"/>
  ### <Color id="aqua">共鸣碎片</Color>
</Row>

由<ItemLink id="prismarine_crystal_shard"/>在[共鸣室](resonance_chamber.md)中制成，需要纯度3.0及以上的光束。一片水晶碎片制造一片共鸣碎片。

它是用于制造[门径](gateway.md)、[深渊压力锻造机](pressure_forge.md)、[海王三叉戟](neptunes_trident.md)、[聚变反应堆](fusion_plant.md)的激光注入器、惰性水晶种子，以及[共鸣网络](resonance_network.md)方块的原材料，还可锻压为无瑕的海晶水晶。

***

<Row>
  <ItemImage id="flawless_prismarine_crystal"/>
  ### <Color id="aqua">无瑕的海晶水晶</Color>
</Row>

由共鸣碎片在[深渊压力锻造机](pressure_forge.md)中制成。需要纯度2.0，锻造机位于Y轴-20及以下，每枚水晶需加工10秒。

用于制造[海洋步枪](atlantean_rifle.md)、[海王三叉戟](neptunes_trident.md)、[门径](gateway.md)、聚变堆控制器、育晶仪、惰性水晶种子、压力模拟器。

***

<Row>
  <ItemImage id="deep_steel_plating"/>
  ### <Color id="aqua">深海钢衬板</Color>
</Row>

由海蓝钢锭在[深渊压力锻造机](pressure_forge.md)中制成。需要纯度2.5，锻造机位于Y -40及以下，每片衬板需加工15秒。

用于制造[海洋步枪](atlantean_rifle.md)、[海王三叉戟](neptunes_trident.md)、[门径](gateway.md)、大多数[聚变反应堆](fusion_plant.md)部件和育晶仪。

它也可在铁砧中修复<ItemLink id="submarine"/>。在左侧槽位放置物品形态的海洋斥候，右侧槽位放置衬板。每片衬板可修复20%的船壳，一次消耗2级经验。修复用物品和每物品修复量可通过`config/nautec-common.toml`中的`submarineRepairItem`和`submarineRepairPercent`调整。
