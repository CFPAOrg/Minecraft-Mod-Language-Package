---
navigation:
  parent: items-blocks/index.md
  icon: storage_meter
  title: 库存量表
categories:
  - device
description: 追踪所配置物品/流体的量
item_ids:
- nodeworks:storage_meter
---

# 库存量表

库存量表会检测网络中的物品，并在其库存量低于所设阈值时发出红石信号。它还能发起自动合成作业以补货。

<GameScene interactive={true} zoom="5" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/stock_meter_door.snbt" />
  <DiamondAnnotation pos="3.5 0.5 1.5">
    <ItemImage id="minecraft:oak_planks" />
  </DiamondAnnotation>
  <DiamondAnnotation pos="0.5 0.5 0.5">
    <RecipeFor id="minecraft:oak_door" />
  </DiamondAnnotation>
  <BlockAnnotation x="1" color="#00f2ff">
    启用了自动合成，会自动为网络补充门
  </BlockAnnotation>
</GameScene>

## 使用库存量表

用物品右击可设定监测目标。空手再次右击打开GUI以设置阈值和频道。

库存量低于所设阈值时，量表会发出一个红石信号。启用自动合成（默认）时，量表还会发起一个合成作业以进行补货。若想让信号控制<ItemLink id="craft_requester" />发起合成，可关闭自动合成。

GUI底部的状态标签能反映量表当前的行为。鼠标悬停以查看详情。

## 子网示例

<GameScene interactive={true} zoom="4" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/storage_meter_subnet.snbt" />
  <BlockAnnotation y="2" x="2">
    将<ItemLink id="minecraft:raw_iron" />烧炼为<ItemLink id="minecraft:iron_ingot" />
  </BlockAnnotation>
  <BlockAnnotation x="4" y="2" z="1">
    <ItemImage id="minecraft:raw_iron" />
  </BlockAnnotation>
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

此例中，<Color id="green">子网</Color>中的库存量表正检测箱子中的铁锭。存量低于阈值时，量表会向<Color id="blue">另一个网络</Color>的<ItemLink id="craft_requester" />发送红石信号，并触发使用<ItemLink id="processing_handler" />的合成作业。

## 频道

库存量表的GUI中有一个频道选择器，可用于选择所合成物品的目的地，以及监测哪个频道下的网络存储。

> **注意：**&zwnj;更多信息参见[选择频道](../lua-api/channel.md#选择频道)。

## 配方

<RecipeFor id="storage_meter" />
