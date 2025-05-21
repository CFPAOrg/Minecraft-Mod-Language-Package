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

脉冲样板供应器是经过特化的合成设备，它会在被红石信号触发时发送上一次使用的样板。

## 使用方法

1. **放置方块**：将脉冲样板供应器连接至ME网络，和普通的样板供应器一样即可。
2. **打开GUI**：右击方块打开其界面。
3. **放入样板**：向槽位内放入任意处理样板，无需特殊设置。
4. **触发合成**：向供应器发送一个红石信号脉冲。供应器会在每个上升沿到来时再次向机器发送上一次使用的样板。

如此就可自动化**概率产出**的配方。最基础的设施如下：机器产出失败时，应检测到该状态（比如可以使用[发信接口](signalling_interface.md)），并向供应器发送红石脉冲。供应器便会再次发送材料批次。