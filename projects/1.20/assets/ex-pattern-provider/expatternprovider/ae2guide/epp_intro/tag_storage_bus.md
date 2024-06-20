---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME 标签存储总线
    icon: expatternprovider:tag_storage_bus
categories:
- extended devices
item_ids:
- expatternprovider:tag_storage_bus
---

# ME 标签存储总线

<GameScene zoom="8" background="transparent">
  <ImportStructure src="../structure/cable_tag_storage_bus.snbt"></ImportStructure>
</GameScene>

ME 标签存储总线的性质与<ItemLink id="ae2:storage_bus" />相同，但你可以通过物品/流体的标签进行过滤，并且支持一些基本的运算符。

## 支持的运算符：

|   运算符   |   含义    |
|:---------:|:---------:|
|     &     |   逻辑与   |
|    \|     |   逻辑或   |
|     ^     |   逻辑异或 |
|     ()    |    优先    |
|     *     |   通配符   |

下面是一些例子：

- 只接受原矿

forge:raw_materials/*

- 接受所有的锭与宝石

forge:ingots/* | forge:gems/*

