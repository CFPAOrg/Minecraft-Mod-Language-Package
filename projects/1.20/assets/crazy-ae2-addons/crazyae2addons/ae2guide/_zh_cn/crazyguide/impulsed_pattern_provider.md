---
navigation:
  parent: crazyae2addons_index.md
  title: 脉冲样板供应器
  icon: crazyae2addons:impulsed_pattern_provider
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:impulsed_pattern_provider
---

# 用AE2的手段处理概率产出配方

# 脉冲样板供应器

<BlockImage id="crazyae2addons:impulsed_pattern_provider" scale="4"></BlockImage>

脉冲样板供应器是经过特化的合成设备，当被红石信号触发时，会发送上一次使用的样板。

## 使用方法

1. **放置方块**：与普通样板供应器一样，将脉冲样板供应器连接至ME网络即可。
2. **打开GUI**：右击方块打开其界面。
3. **放入样板**：向槽位内放入任意处理样板，无需特殊设置。
4. **触发合成**：向该方块发送红石信号脉冲。每检测到一次上升沿，供应器会按上一次使用的样板再次向机器发配原料。

如此就可自动化**概率产出**的配方。最基础的设施如下：当机器未能成功产出目标物品时，检测该情形（例如使用[发信接口](signalling_interface.md)检测），并向供应器发送红石脉冲。供应器便会再次发配样板材料。