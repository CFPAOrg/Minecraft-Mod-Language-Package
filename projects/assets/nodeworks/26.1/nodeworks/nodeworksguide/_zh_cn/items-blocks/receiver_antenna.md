---
navigation:
  parent: items-blocks/index.md
  icon: receiver_antenna
  title: 接收天线
categories:
  - infrastructure
description: 连接至已广播的处理存储器和导出箱
item_ids:
- nodeworks:receiver_antenna
---

# 接收天线

用于将网络连接至其他[子网](../nodeworks-mechanics/subnets.md)。很适合用来把[处理集](./recipe_sets.md#处理集)配方拆分到多个网络中去，同时保留[自动合成](../nodeworks-mechanics/autocrafting.md)功能。

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/receiving_antenna_uses.snbt" />
  <BoxAnnotation min="2 0 0" max="3 1 1">
    从其他网络处接收处理集配方
  </BoxAnnotation>
  <BoxAnnotation min="0 0 0" max="1 2 1">
    从正在广播的导出箱处接收物品
  </BoxAnnotation>
</GameScene>

## 无线接收物品

在<ItemLink id="import_chest" />上方放置接收天线，再与其他网络中<ItemLink id="export_chest" />上方的<ItemLink id="broadcast_antenna" />配对。送入正广播的导出箱的物品会抵达天线所在的导入箱，也即，在两个网络间无线传递物品。

## 配方

<RecipeFor id="receiver_antenna" />