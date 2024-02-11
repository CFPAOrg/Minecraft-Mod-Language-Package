---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 晶体催生器
  icon: growth_accelerator
  position: 310
categories:
- machines
item_ids:
- ae2:growth_accelerator
---

# 晶体催生器

<BlockImage id="growth_accelerator" p:powered="true" scale="8"/>

相邻放置于母岩时，晶体催生器会大幅加快赛特斯石英和紫水晶的[生长](../ae2-mechanics/certus-growth.md)。

奇怪的是，它*也能*加速各种植物的生长。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/growth_accelerator.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

在顶面或底面放置<ItemLink id="crank" />并右击手摇即可手工供能。

其只会从其粉红色的福鲁伊克斯珠所在面与线缆相连。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/accelerator_connections.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配方

<RecipeFor id="growth_accelerator" />
