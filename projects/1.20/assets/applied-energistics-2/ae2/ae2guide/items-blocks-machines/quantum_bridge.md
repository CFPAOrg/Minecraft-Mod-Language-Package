---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 量子桥
  icon: quantum_ring
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:quantum_link
- ae2:quantum_ring
---

# 量子网桥

![已搭建完成的量子网桥](../assets/diagrams/quantum_bridge_demonstration.png)

量子网桥能将[网络](../ae2-mechanics/me-network-connections.md)无限延伸，甚至能跨维度连接。它们能传输共32个频道（无论线缆连接方式如何），可视作无线的[致密线缆](cables.md#dense-cable)。

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/quantum_bridge_internal_structure_1.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/quantum_bridge_internal_structure_2.snbt" />

  <BoxAnnotation color="#33dd33" min="1 1 1" max="6 2 3">
        两端之间的虚线缆
  </BoxAnnotation>

  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

需要注意，**量子网桥的两端点均需区块加载**，假如两端距离很远，则必须使用<ItemLink id="spatial_anchor" />或再加区块加载器。

# 量子环

<BlockImage id="quantum_ring" scale="8" />

在<ItemLink id="quantum_link" />周围放下8个此方块即可创建一个量子网桥。只有与<ItemLink id="quantum_ring" />相邻的4个量子桥才会接受网络连接，角上的4格无法与线缆相连。

## 配方

<RecipeFor id="quantum_ring" />

# 量子链接仓

<BlockImage id="quantum_link" scale="8" />

在<ItemLink id="quantum_ring" />的中心放下1个此方块即可创建一个量子网桥。此方块不会与线缆相连，且只会在量子网桥搭建完毕后算作网络组件。

此方块的存储空间可装下一个<ItemLink id="quantum_entangled_singularity" />，且此存储空间可被自动化设施访问。

## 配方

<RecipeFor id="quantum_link" />
