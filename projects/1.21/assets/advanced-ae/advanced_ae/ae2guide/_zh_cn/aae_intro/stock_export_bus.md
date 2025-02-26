---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: 库存输出总线
  icon: advanced_ae:stock_export_bus_part
categories:
  - advanced items
item_ids:
  - advanced_ae:stock_export_bus_part
---

# 库存输出总线

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_stock_export_bus.snbt"></ImportStructure>
</GameScene>

库存输出总线可配置为输出特定数目的过滤物品组。它会记录目标存储空间中已有的量，且不会让该数目超出设定的数目。打开界面，将需过滤的物品拖入过滤槽，再按下中键即可配置数量。注意，它不会调控输出；也即，若是目标存储空间中物品或流体的量超出了设定值，此总线也不会取走多余部分。