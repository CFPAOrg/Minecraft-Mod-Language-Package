---
navigation:
  parent: ae2-mechanics/ae2-mechanics-index.md
  title: 赛特斯石英的生长
  icon: quartz_cluster
---

# 赛特斯石英的生长

## 基本就是从开始与入门那里复制来的

<GameScene zoom="6" background="transparent">
<ImportStructure src="../assets/assemblies/budding_certus_1.snbt" />
</GameScene>

赛特斯石英芽会从[赛特斯石英母岩](../items-blocks-machines/budding_certus.md)中生长出来，与紫水晶类似。如果破坏未完全生长的石英芽，则会掉落一个<ItemLink id="certus_quartz_dust" />，不受时运影响。如果破坏长成的石英簇，则会掉落四个<ItemLink id="certus_quartz_crystal" />，且会受时运影响而增加掉落量。

共有4种等级的赛特斯石英母岩：无瑕、有瑕、开裂、破损。

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/budding_blocks.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

每次石英芽生长时，母岩都有可能降一级，并最终变为普通的赛特斯石英块。将赛特斯石英母岩或者赛特斯石英块以及若干个<ItemLink id="charged_certus_quartz_crystal" />一起投入水中，就能将其修复并产生新的母岩。

<RecipeFor id="damaged_budding_quartz" />

无瑕的赛特斯石英母岩不会降级，因而能无限产生赛特斯石英。但是它们无法合成也无法被镐完好地挖下搬运，就算有精准采集也不行。（不过它们*可以*被[空间存储](../ae2-mechanics/spatial-io.md)移动。）

赛特斯石英母岩自身的生长非常缓慢。幸运的是，在母岩旁放置<ItemLink id="growth_accelerator" />能大幅加速这一过程。你的第一要务便是制造一些此方块。

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/budding_certus_2.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

假如没有足够石英制造<ItemLink id="energy_acceptor" />或是<ItemLink id="vibration_chamber" />，可以制造一个<ItemLink id="crank" />并安到催生器上。

自动采集赛特斯石英的设计[见此](../example-setups/simple-certus-farm.md)。