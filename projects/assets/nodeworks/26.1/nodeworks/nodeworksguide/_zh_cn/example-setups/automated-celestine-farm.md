---
navigation:
  parent: example-setups/index.md
  icon: celestine_shard
  title: 天青石农场
categories:
  - example
---

# 天青石农场

<ItemLink id="budding_celestine" />可使用<ItemLink id="breaker" />与<ItemLink id="terminal" />自动化。

<GameScene zoom="4" interactive={true} paddingLeft="30" paddingRight="30">
  <ImportStructure src="../assets/assemblies/celestine_farm.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
</GameScene>

也可以用焦准节点连接各部分：

<GameScene zoom="4" interactive={true} paddingLeft="30" paddingRight="30">
  <ImportStructure src="../assets/assemblies/celestine_farm_focus_node.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
</GameScene>

在破坏器的GUI中，将它们设为低红石模式，即无红石信号时运作。再将它们设为破坏<ItemLink id="celestine_cluster" />。

它们会破坏长出的天青石簇，并将产物送入[网络存储](../nodeworks-mechanics/network-storage.md)。