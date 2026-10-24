---
navigation:
  title: 新手入门
  position: 10
---

# 新手入门

## 所需材料

节点工程网络的驱动力来自于<ItemLink id="celestine_shard" />的反射性质。

## 培育天青石

可以像培育<ItemLink id="minecraft:amethyst_cluster" />一样培育天青石，此操作需要用到<ItemLink id="budding_celestine" />。

## 第一个节点工程网络

不涉及脚本的简单网络，只用于查看任意多个相连箱子中的物品，和使用容器终端类似。

<GameScene interactive={true} zoom="5">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="assets/assemblies/first_network.snbt" />
  <BoxAnnotation min="2.25 0.1 0.1" max="2 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />存储卡
  </BoxAnnotation>
</GameScene>

- 此网络包含：
  - 1x <ItemLink id="inventory_terminal" />
  - 若干<ItemLink id="pipe" />，用于连接所有设备
  - 若干<ItemLink id="node" />，用于将箱子等外部方块连接至网络
  - 1x <ItemLink id="storage_card" />，放置于节点朝向箱子的一面

### 扩展你的节点工程网络

- [移动物品](./nodeworks-mechanics/moving-items.md)
- [自动合成](./nodeworks-mechanics/autocrafting.md)
- [示例设施](./example-setups/index.md)
