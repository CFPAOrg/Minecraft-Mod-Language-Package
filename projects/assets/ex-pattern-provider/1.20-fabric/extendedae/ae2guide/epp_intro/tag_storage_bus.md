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

ME标签存储总线的性质与<ItemLink id="ae2:storage_bus" />相同，但你可以通过物品/流体的标签进行过滤。它也支持一些基本的逻辑运算符。

下面是一些例子：

- 只接受粗矿

使用Forge加载器时：forge:raw_materials/*

使用Fabric加载器时：c:raw_materials

- 接受所有的锭与宝石

使用Forge加载器时：forge:ingots/* | forge:gems/*

使用Fabric加载器时：c:ingots/* | c:gems/*
