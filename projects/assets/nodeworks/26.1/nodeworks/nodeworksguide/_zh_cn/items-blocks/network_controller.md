---
navigation:
  parent: items-blocks/index.md
  icon: network_controller
  title: 网络控制器
categories:
  - infrastructure
description: 网络的心脏，每个网络都要有一个
item_ids:
- nodeworks:network_controller
---

# 网络控制器

每一个节点工程网络都仅需要一个控制器。若没有控制器，网络中的[管道](pipe.md)和[节点](node.md)便都不会运作。

<GameScene interactive={true} zoom="5">
  <IsometricCamera yaw="200" pitch="10" />
  <ImportStructure src="../assets/assemblies/controller_node_terminal.snbt" />
</GameScene>

放下控制器，从它所在位置延出管道，与管道相连的方块均会加入网络。

## 身份

在GUI中可为控制器命名和选色。名称仅作装饰，网络中的节点会和控制器保持同色，以便分辨距离较近的多个网络。

## 区块加载

GUI中可以切换区块加载与否，即是否强制加载网络占据的所有区块。适合给出远门时还要维持运作的自动合成设施使用。

## 每网络一个

连接到同一条管道的两个控制器会互相冲突，导致网络停机，直至去除其中一台才能恢复。

## 配方

<RecipeFor id="network_controller" />
