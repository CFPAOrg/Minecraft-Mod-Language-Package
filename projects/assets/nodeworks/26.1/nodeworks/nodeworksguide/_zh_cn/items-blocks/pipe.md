---
navigation:
  parent: items-blocks/index.md
  icon: pipe
  title: 真空管道
categories:
  - infrastructure
description: 所有网络都需要的建筑方块
item_ids:
- nodeworks:pipe
- nodeworks:covered_pipe
---

# 真空管道

节点工程网络的导线。管道能传输物品、信号，也能在网络的所有方块间进行路由。

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/vacuum_pipe.snbt" />
</GameScene>

将管道相邻放置（或相邻任意网络方块放置）后，两者会自动连接。

## 隐藏管道

### 覆层管道

在工作台中央放一个方块，再在周围放入8根真空管道，即可制成覆层管道，将管道本身隐藏起来。

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/covered_pipe.snbt" />
</GameScene>

### 焦准节点

可以借助<ItemLink id="focus_node" />穿过玻璃，也相当于能穿透墙壁。

<GameScene interactive={true} zoom="5" paddingLeft="20" paddingTop="20" paddingBottom="20">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/focus_node_glass.snbt" />
</GameScene>

## 配方

<RecipeFor id="pipe" />
