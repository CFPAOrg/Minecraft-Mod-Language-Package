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

这种加速的本质是对周围方块执行“随机刻”，自然产生的随机刻也依然保留。理论上来说，1台催生器就能使得事物的生长速度变为原本的大约90倍，多台催生器的效果加算。

<GameScene zoom="6" interactive={true}>
  <ImportStructure src="../assets/assemblies/growth_accelerator.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

需向其顶面或底面供能，AE2[线缆](cables.md)和其他模组的能量线缆均可。充能器能接受AE2能量（AE）和Forge能量（FE）。

在顶面或底面放置<ItemLink id="crank" />并右击手摇即可手工供能。

顶面和底面可通过粉红色的福鲁伊克斯珠分辨。

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/accelerator_connections.snbt" />
<IsometricCamera yaw="195" pitch="30" />
</GameScene>

## 配方

<RecipeFor id="growth_accelerator" />
