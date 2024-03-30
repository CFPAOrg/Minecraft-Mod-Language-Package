---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 赛特斯石英母岩
  icon: flawless_budding_quartz
  position: 010
categories:
- misc ingredients blocks
item_ids:
- ae2:flawless_budding_quartz
- ae2:flawed_budding_quartz
- ae2:chipped_budding_quartz
- ae2:damaged_budding_quartz
- ae2:small_quartz_bud
- ae2:medium_quartz_bud
- ae2:large_quartz_bud
- ae2:quartz_cluster
---

# 赛特斯石英母岩

（见[赛特斯石英的生长](../ae2-mechanics/certus-growth.md)）

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/budding_blocks.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

赛特斯石英芽会从赛特斯石英母岩中生长出来，与紫水晶类似。母岩可在[陨石](../ae2-mechanics/meteorites.md)中找到。共有4种等级的赛特斯石英母岩：无瑕、有瑕、开裂、破损。可由HWYLA、Jade、The One Probe等模组轻松辨别。（F3界面也可。）

对于有瑕、开裂、破损的母岩而言，每次石英芽生长时，母岩都有可能降一级，并最终变为普通的<ItemLink id="quartz_block" />。

无瑕的赛特斯石英母岩不会因石英芽的生长而降级，可用作无限生产源。

若用普通镐破坏，赛特斯石英母岩会降一级。若用精准采集镐破坏，则除无瑕母岩外不会降级。**这也意味着无瑕的赛特斯石英母岩无法用镐完好破坏或搬运**。不过可以用[空间存储](../ae2-mechanics/spatial-io.md)以剪切粘贴无瑕母岩。

## 配方

有瑕、开裂、破损的赛特斯石英母岩可通过将上一级母岩（或<ItemLink id="quartz_block" />）和若干个<ItemLink id="charged_certus_quartz_crystal" />投入水中合成。

无瑕的赛特斯石英母岩无法合成，只能在世界中搜寻而得。

<Row>
  <RecipeFor id="damaged_budding_quartz" />

  <RecipeFor id="chipped_budding_quartz" />

  <RecipeFor id="flawed_budding_quartz" />
</Row>
