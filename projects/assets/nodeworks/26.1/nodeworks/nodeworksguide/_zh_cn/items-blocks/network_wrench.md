---
navigation:
  parent: items-blocks/index.md
  icon: network_wrench
  title: 网络扳手
description: 切换管道连接与否，链接焦准节点
item_ids:
- nodeworks:network_wrench
---

# 网络扳手

网络扳手是在不破坏方块时调整网络形状的工具。它能切换某段管道连接与否，也能远距链接<ItemLink id="focus_node" />。

<ItemImage scale="6" id="network_wrench" />

## 切换管道连接

Shift+右击两个网络方块相连的面可切换其中有无管道连通。方块本身没有变化，只是网络会将该处视作没有管道。

这是扳手最常用的功能。下面是常见的使用场景：

- 让<ItemLink id="node" />和<ItemLink id="pipe" />相邻但不合并
- 通过断开一条管道拆分网络
- 阻止<ItemLink id="terminal" />或设备与附近网络产生误连接

在同一处重复此操作可恢复连接。

## 链接焦准节点

<ItemLink id="focus_node" />是例外。扳手可将两个相距较远的焦准节点链接起来：

1. Shift+右击焦准节点未接触网络方块的一面，以将其设为预定来源。选中的方块会以边框高亮。
2. 右击另一个焦准节点以切换两者之间连接存在与否。

成功链接后对焦准节点的选择依然保留，可借此将多个焦准节点链接到一处，期间不需要重新选择。

### 规则

- 两焦准节点必须与选择位置位于**同一维度**。
- 两方必须属于同一个**网络控制器**。扳手不会连通两个网络。

扳手会通过聊天栏消息告知哪一条规则未满足。

## 配方

<RecipeFor id="network_wrench" />
