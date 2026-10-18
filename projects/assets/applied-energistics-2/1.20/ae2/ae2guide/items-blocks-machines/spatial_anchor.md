---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 空间锚
  icon: spatial_anchor
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:spatial_anchor
---

# 空间锚

<BlockImage id="spatial_anchor" p:powered="true" scale="8"/>

AE2网络需要所有[设备](../ae2-mechanics/devices.md)均被区块加载才可工作，只有一部分被加载可能导致运行失常。空间锚则解决了这个问题。它会强制加载其所处网络占用的区块。仅是跨过区块边界的单个线缆就足以加载该新区块了。

其“加载范围”会穿过[量子桥](quantum_bridge.md)，但不会跨维度加载，因此如果有连接至下界的量子桥，则需要在基地和下界都有一个空间锚。

默认情况下，它也会启用加载区块的随机刻，这一特性可被AE2配置关闭。

空间锚可用<ItemLink id="certus_quartz_wrench" />旋转，如果真有需要的话。

## 设置

*   空间锚提供调整全局能量单位（AE、E/FE）的设置。
*   可在世界内显示被加载区块的全息图。

## 能量

空间锚的[能量](../ae2-mechanics/energy.md)消耗遵从如下等式：

e = 80 + (x\*(x+1))/2

x为被加载区块的数量

## 配方

<RecipeFor id="spatial_anchor" />
