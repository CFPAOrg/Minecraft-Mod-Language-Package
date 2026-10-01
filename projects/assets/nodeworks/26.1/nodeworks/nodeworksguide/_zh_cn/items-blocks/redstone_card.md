---
navigation:
  parent: items-blocks/index.md
  icon: redstone_card
  title: 红石卡
categories:
  - card
description: 读写所安装节点面处的红石信号
item_ids:
- nodeworks:redstone_card
---

# 红石卡

在所安装的节点面处读写红石信号。

<ItemImage scale="6" id="redstone_card" />

## 安装与脚本

安装方式与<ItemLink id="io_card" />相同。详细步骤参见[IO卡安装](./io_card.md#安装)。红石卡会读写*所处面*的红石信号。

参见[红石卡脚本API](../lua-api/card-handle.md#红石卡)，它与其他卡片的API有所不同。

## 频道

红石卡的GUI中有一个频道选择器。有关频道限制脚本能否访问此卡片的详情，参见[选择频道](../lua-api/channel.md#选择频道)。

## 配方

<RecipeFor id="redstone_card" />