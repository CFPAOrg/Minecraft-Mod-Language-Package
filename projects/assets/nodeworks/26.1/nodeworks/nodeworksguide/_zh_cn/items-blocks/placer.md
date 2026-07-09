---
navigation:
  parent: items-blocks/index.md
  icon: placer
  title: 放置器
categories:
  - device
description: 网络范围内共享的放置器
item_ids:
- nodeworks:placer
---

# 放置器

放置器能在自身前方放置具有方块形态的物品。脚本通过物品ID选择所用物品；也可通过传入[ItemsHandle](../lua-api/items-handle.md)，匹配的物品会从[网络存储](../nodeworks-mechanics/network-storage.md)中抽出并放置。此操作是同步的，脚本会在请求的同一刻得到`true`/`false`的返回值。

<BlockImage scale="6" id="placer" />

## 放置

破坏器的前部会朝向放置时的视线方向（和放置活塞与发射器一致）。放置器会直接在该面前部放置方块。仅具有方块形态的物品有效，工具、食物、杂项物品均会导致放置调用失败。

## 方块筛选器

放置器的GUI中有一个筛选器，用于限定应放置哪种方块。匹配的物品会在每次放置器触发时从[网络存储](../nodeworks-mechanics/network-storage.md)中抽取。留空可让放置器停止在空闲状态，直至脚本请求。

## 红石

GUI的红石设定可控制放置器的运作条件：

- **高**：有信号时运作。
- **低**：无信号时运作。
- **忽略**：与红石信号无关。放置器只会在脚本调用时触发。

## 频道

放置器GUI中有名称和频道的设定器。有关频道限制脚本能否访问设备的详情，参见[选择频道](../lua-api/channel.md#选择频道)。

## 脚本

脚本API参见[PlacerHandle](../lua-api/placer-handle.md)页面。

## 配方

<RecipeFor id="placer" />
