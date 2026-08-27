---
navigation:
  parent: items-blocks/index.md
  icon: craft_requester
  title: 合成请求器
categories:
  - device
description: 收到红石信号时发起自动合成作业
item_ids:
- nodeworks:craft_requester
---

# 合成请求器

合成请求器会在收到红石信号时发起自动合成作业。需为其指定所合成物品和单次数量。

<GameScene interactive={true} zoom="5" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/craft_requester_door.snbt" />
  <DiamondAnnotation pos="3.5 0.5 1.5">
    <ItemImage id="minecraft:oak_planks" />
  </DiamondAnnotation>
  <DiamondAnnotation pos="0.5 0.5 0.5">
    <RecipeFor id="minecraft:oak_door" />
  </DiamondAnnotation>
  <BoxAnnotation min="1.2 1 0.3" max="1.8 1.2 0.7" color="#00f2ff">
    红石信号激活合成请求器，合成所指定的物品
  </BoxAnnotation>
</GameScene>

## 使用合成请求器

以物品右击可设置合成目标。空手再次右击可打开GUI，其中可设置单次数量和[输出频道](./craft_requester.md#频道)。

有红石信号时，它会持续发起合成作业并排队，一次合成的量即为单次数量。撤走红石信号即会停止发起。

与按钮配合使用，可进行单次合成；与<ItemLink id="storage_meter" />配合，则可用于自动维持库存。量表会在库存量降低和回升时自行切换信号。

GUI底部的状态标签能反映请求器当前的行为。鼠标悬停以查看详情。

## 频道

合成请求器GUI中的频道选择器可用于选择产物去向的频道。

> **注意：**&zwnj;更多信息参见[选择频道](../lua-api/channel.md#选择频道)。

## 配方

<RecipeFor id="craft_requester" />
