---
navigation:
  parent: example-setups/index.md
  icon: minecraft:hopper
  title: 移动物品
categories:
  - example
---

# 移动物品

节点工程网络最简单的功能，就是从容器中抽出物品送至网络存储。本页面会介绍两种方式，首先是基础方式，随后是经过筛选的同一设施。

---

## 使用导入/导出箱

### 将物品送入网络

放置在<ItemLink id="import_chest"/>中的物品会被送入[网络存储](../nodeworks-mechanics/network-storage.md)。

<GameScene zoom="5" interactive={true}>
  <ImportStructure src="../assets/assemblies/moving_items_import_chest.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="1 0.1 0.1" max="1.25 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BlockAnnotation x="4">
    导入箱的内容物品会被自动送入网络
  </BlockAnnotation>
</GameScene>

### 从网络中抽取物品

<ItemLink id="export_chest"/>可将网络存储中的物品抽到自身物品栏中。

<GameScene zoom="5" interactive={true}>
  <ImportStructure src="../assets/assemblies/moving_items_export_chest.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="1 0.1 0.1" max="1.25 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BlockAnnotation x="4">
    导入箱的内容物品会被自动送入网络
  </BlockAnnotation>
</GameScene>

---

## 使用脚本终端

### 抽取所有物品

将潜影盒中所有物品抽入网络，不进行筛选。

<GameScene zoom="5" interactive={true}>
  <ImportStructure src="../assets/assemblies/moving_items.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="1 0.1 0.1" max="1.25 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="4.75 0.1 0.1" max="5 0.9 0.9" color="#83E086">
    重命名为&zwnj;**“shulkerBox”**&zwnj;的<ItemImage id="nodeworks:io_card" />
  </BoxAnnotation>
</GameScene>

脚本：

<LuaCode>
```lua
importer
    :from(shulkerBox)
    :to(network)
    :start()
```
</LuaCode>

> **注意：**&zwnj;如需反转方向，可将`:from(shulkerBox)`和`:to(network)`改为`:from(network)`和`:to(shulkerBox)`。

运行此脚本时，所有抵达潜影盒的物品都会被送入网络存储（即未进行筛选的任意存储卡）。

## 筛选：按物品种类路由

同样的网络，其中一张存储卡设为原木，另一张设为圆石，还有一张接受所有其他资源。

<GameScene zoom="5" interactive={true}>
  <ImportStructure src="../assets/assemblies/item_filtering.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="2 0.1 1.1" max="2.25 0.9 1.9" color="#AA83E0">
    **规则**：`#c:cobblestones`
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="2 1.1 1.1" max="2.25 1.9 1.9" color="#AA83E0">
    **规则**：`#c:logs`
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="2 2.1 1.1" max="2.25 2.9 1.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="5.75 0.1 1.1" max="6 0.9 1.9" color="#83E086">
    重命名为&zwnj;**“shulkerBox”**&zwnj;的<ItemImage id="nodeworks:io_card" />
  </BoxAnnotation>
</GameScene>

重用前一示例的脚本即可，区别仅在于存储卡各自有了[筛选器设置](../items-blocks/storage_card.md#筛选器)。
