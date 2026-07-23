---
navigation:
  parent: items-blocks/index.md
  icon: portable_inventory_terminal
  title: 便携式物品栏终端
categories:
  - tool
description: 所链接网络存储的便携式视窗
item_ids:
- nodeworks:portable_inventory_terminal
---

# 便携式物品栏终端

手持式的<ItemLink id="inventory_terminal" />。能通过配对于<ItemLink id="network_controller" />上方<ItemLink id="broadcast_antenna" />的<ItemLink id="link_crystal" />无线连接。

<ItemImage scale="6" id="portable_inventory_terminal" />

## 链接至网络

便携式物品栏终端与网络建立链接需要三样组件：

<GameScene zoom="3" interactive={true} paddingTop="20">
  <ImportStructure src="../assets/assemblies/broadcast_antenna_network_controller.snbt" />
</GameScene>

- 目标网络中的<ItemLink id="network_controller" />
- 该控制器上方的<ItemLink id="broadcast_antenna" />
- 与该天线配对的<ItemLink id="link_crystal" />*（不是和处理存储器配对）*

<br clear="all" /><br clear="all" /><br clear="all" /><br clear="all" />
<FloatingImage src="../assets/images/portable_inventory_terminal_link_slot.png" align="left" />

准备好经过配对的链接晶体，放入便携式物品栏终端右上方的槽位即可。

链接建立后，便携式终端的物品纹理会亮起网络的颜色。

<br clear="all" />

## 范围

更多有关广播范围的信息参见<ItemLink id="broadcast_antenna" />页面。

## 使用终端

GUI中的所有内容与<ItemLink id="inventory_terminal" />完全一致。

## 配方

<RecipeFor id="portable_inventory_terminal" />