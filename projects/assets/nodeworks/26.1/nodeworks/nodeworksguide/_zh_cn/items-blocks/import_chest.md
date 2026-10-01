---
navigation:
  parent: items-blocks/index.md
  icon: import_chest
  title: 导入箱
categories:
  - infrastructure
description: 将自身内容物送入网络存储
item_ids:
- nodeworks:import_chest
---

# 导入箱

有9个槽位的箱子，会自动将自身内容物送入[网络存储](../nodeworks-mechanics/network-storage.md)。可以手动放入、漏斗送入、用其他模组的管道运入，无论如何，导入箱都会将内容物清空到网络中。

<GameScene zoom="6">
  <ImportStructure src="../assets/assemblies/import_chest.snbt" />
</GameScene>

不被接受的物品（筛选限制、空间不足等）会留在箱中，方便查看为何会堵塞。

## 频道

在GUI中设置频道后，导入箱便只会向该频道下的存储卡发送。默认设置会向网络中的所有存储卡发送。参见[选择频道](../lua-api/channel.md#选择频道)。

## 轮询

在GUI中启用轮询后，导入箱会在多个目的存储卡间均分资源，而不会首先填充第一个。想要输入在多个存储目标间保持负载均衡时很好用。

## 刻间隔

GUI还会显示箱子尝试输入的间隔，默认为每秒一次。缩短可让输入更迅速，代价是网络负载上升；延长后网络空闲时间会增多。

## 红石

GUI的红石设置限制了导入箱运作与否：

- **高**：有信号时运作。
- **低**：无信号时运作。
- **忽略**：与红石信号无关。

## 无线

在导入箱上放置<ItemLink id="receiver_antenna" />，并将其与其他网络<ItemLink id="export_chest" />上方的<ItemLink id="broadcast_antenna" />配对。送入广播导出箱的物品会抵达本网络的导入箱，并随后和其他输入一样进入本地网络存储。

## 配方

<RecipeFor id="import_chest" />
