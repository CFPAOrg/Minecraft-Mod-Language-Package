---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 充能器
  icon: charger
  position: 310
categories:
- machines
item_ids:
- ae2:charger
---

# 充能器

<BlockImage id="charger" scale="8" />

充能器能为其支持的工具和<ItemLink id="certus_quartz_crystal" />充能。

需向其顶面或底面供能，AE2[线缆](cables.md)和其他模组的能量线缆均可。充能器能接受AE2能量（AE）和Forge能量（FE）。其允许从各面输入输出物品。只有产物才会被抽出，因此不需要设置过滤。可用<ItemLink id="certus_quartz_wrench" />旋转以实现自动化。

可将<ItemLink id="certus_quartz_crystal" />充能为<ItemLink id="charged_certus_quartz_crystal" />，或是将<ItemLink id="minecraft:compass" />变为<ItemLink id="meteorite_compass" />。

在顶面或底面放置<ItemLink id="crank" />并右击手摇即可手工充能物品。

它也是[福鲁伊克斯研究员](fluix_researcher.md)的工作站点。

## 简单自动化

如下例，充能器的可旋转性使其能按下述方式半自动化：

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/charger_hopper.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配方

<RecipeFor id="charger" />
