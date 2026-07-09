---
navigation:
  parent: items-blocks/index.md
  icon: breaker
  title: 破坏器
categories:
  - device
description: 破坏并采集前方方块
item_ids:
- nodeworks:breaker
---

# 破坏器

破坏器能花费一定时间摧毁前方的方块，并将掉落物路由回[网络存储](../nodeworks-mechanics/network-storage.md)（或路由至脚本handler）。品质为钻石，破坏耗时使用木镐的计算公式，因此硬方块花费的时间显著更长。

<BlockImage scale="6" id="breaker" />

## 放置

破坏器的前部会朝向放置时的视线方向（和放置活塞与发射器一致）。该面前方的方块即是`:mine()`的挖掘目标。

## 目标筛选器

破坏器的GUI中有一个筛选器，用于限定应破坏哪种方块。留空为破坏前方一切事物，设置方块可限制为仅破坏该方块。

## 砍树

面朝树木基部的破坏器会砍倒整棵树。

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60" interactive={true} >
  <ImportStructure src="../assets/assemblies/breaker_tree_felling.snbt" />
  <BlockAnnotation x="2" y="1" z="2">
  砍伐最后一块支撑树木的原木会连带砍倒整棵树
  </BlockAnnotation>
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

## 红石

GUI的红石设定可控制破坏器的运作条件：

- **高**：有信号时运作。
- **低**：无信号时运作。
- **忽略**：与红石信号无关。只会在脚本调用`:mine()`时触发。

## 频道

破坏器GUI中有名称和频道的设定器。有关频道限制脚本能否访问设备的详情，参见[选择频道](../lua-api/channel.md#选择频道)。

## 脚本

脚本API参见[BreakerHandle](../lua-api/breaker-handle.md)页面。

## 配方

<RecipeFor id="breaker" />
