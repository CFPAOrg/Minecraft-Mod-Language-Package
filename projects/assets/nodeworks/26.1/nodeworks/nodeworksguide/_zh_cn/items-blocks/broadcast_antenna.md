---
navigation:
  parent: items-blocks/index.md
  icon: broadcast_antenna
  title: 广播天线
categories:
  - infrastructure
description: 广播网络控制器、处理存储器、导出箱的访问端口
item_ids:
- nodeworks:broadcast_antenna
---

# 广播天线

有两种功能的方块，具体表现随放置位置而定：

- 在<ItemLink id="network_controller" />上：广播网络的无线访问入口。与该天线配对的<ItemLink id="portable_inventory_terminal" />可在范围内读写网络。
- 在<ItemLink id="processing_storage" />上：广播该方块（和其他相接的<ItemLink id="processing_storage" />）包含的<ItemLink id="processing_set" />，以供其他网络[自动合成](../nodeworks-mechanics/autocrafting.md)使用。
- 在<ItemLink id="export_chest" />上：将该箱广播为无线出货口。另一网络中与之配对的<ItemLink id="receiver_antenna" />会将箱中资源直接拉至该网络。

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/broadcast_antenna_uses.snbt" />
  <BoxAnnotation min="2 0 0" max="4 1 1">
    两个处理存储器都被广播
  </BoxAnnotation>
  <BoxAnnotation min="5 0 0" max="6 1 1">
    向便携式物品栏终端广播
  </BoxAnnotation>
  <BoxAnnotation min="0 0 0" max="1 1 1">
    向配对的导入箱发送物品
  </BoxAnnotation>
</GameScene>

## 配对

1. 打开广播天线的GUI。
2. 向顶部槽位放入<ItemLink id="link_crystal" />。
3. 拿出晶体，该晶体便已被配对。

## 范围

默认情况下，广播天线的范围为128格。可用<ItemLink id="dimension_range_upgrade" />或<ItemLink id="multi_dimension_range_upgrade" />升级。

## 配方

<RecipeFor id="broadcast_antenna" />