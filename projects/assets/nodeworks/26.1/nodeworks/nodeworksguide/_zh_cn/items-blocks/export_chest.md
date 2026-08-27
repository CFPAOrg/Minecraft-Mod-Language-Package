---
navigation:
  parent: items-blocks/index.md
  icon: export_chest
  title: 导出箱
categories:
  - infrastructure
description: 从网络存储中抽取物品保存于自身
item_ids:
- nodeworks:export_chest
---

# 导出箱

有9个槽位的箱子，能从[网络存储](../nodeworks-mechanics/network-storage.md)中自动抽取物品缓存于自身。

<GameScene zoom="6">
  <ImportStructure src="../assets/assemblies/export_chest.snbt" />
</GameScene>

## 筛选器

箱子的GUI接受一系列筛选规则，语法与<ItemLink id="storage_card" />所用的一致。所有匹配任意规则的物品都可被抽入箱中。筛选器为空时导出箱不会抽取，以免新放置的导出箱立即抽空网络。

## 输出面

在GUI中可挑选一个自动输出面，缓存的资源会被送入该面方向的容器。适合为漏斗、熔炉、机器供货而无需脚本。留空此设置相当于仅手动拿取。

## 频道

设置频道后，导出箱便只会抽取该频道下的存储卡。默认设置会从网络中的所有存储卡抽取。参见[选择频道](../lua-api/channel.md#选择频道)。

## 红石

GUI的红石设置限制了导出箱运作与否：

- **高**：有信号时运作。
- **低**：无信号时运作。
- **忽略**：与红石信号无关。

## 无线

在导出箱上方放置<ItemLink id="broadcast_antenna" />，并将其与其他网络的<ItemLink id="receiver_antenna" />配对。箱子抽出的物品会直接送至接收网络的网络存储。

## 配方

<RecipeFor id="export_chest" />
