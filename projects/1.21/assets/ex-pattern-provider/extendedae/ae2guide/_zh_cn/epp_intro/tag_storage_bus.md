---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME标签存储总线
    icon: extendedae:tag_storage_bus
categories:
- extended devices
item_ids:
- extendedae:tag_storage_bus
---

# ME标签存储总线

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_tag_storage_bus.snbt"></ImportStructure>
</GameScene>

ME标签存储总线的性质与<ItemLink id="ae2:storage_bus" />相同，但可以按照物品和流体标签进行过滤，还支持一些基础的逻辑运算符。

示例见下：

- 只接受粗矿

c:raw_materials

- 接受所有铸锭和宝石

c:ingots/* | c:gems/*
