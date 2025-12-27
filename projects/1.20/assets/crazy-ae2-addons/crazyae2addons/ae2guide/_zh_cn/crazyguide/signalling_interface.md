---
navigation:
  parent: crazyae2addons_index.md
  title: 发信接口
  icon: crazyae2addons:signalling_interface
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:signalling_interface
---

# 发信接口

<BlockImage id="crazyae2addons:signalling_interface" scale="4"></BlockImage>

[脉冲样板供应器](impulsed_pattern_provider.md)的最佳拍档。

发信接口是一种智能设备，能在指定物品的数量出现变动时发出红石脉冲。它非常适合用于创建自动警报装置、门控系统，也能在事物抵达或离开存储网络时触发其他由红石信号控制的机器。

## 使用方法

1. **放置方块**：将发信接口接至ME线缆。
2. **打开GUI**：右击打开配置界面。
3. **配置监测物品**：
    - 上排槽位是*配置槽*。可在此放入需要监测的物品。
    - 槽位旁的扳手标志可用于设定具体的阈值（比如说，可以设为在收到64个某物品时触发）。其功能与普通的接口类似，因此它也会从ME网络中取出物品放入这些槽位。
4. **接入红石**：向设备的任意面接入红石粉或红石导线。每次追踪的物品数量超过所设阈值（或变化量达到阈值）时，发信接口即会发出短时红石脉冲。

## 升级

- **红石卡**：使得接口在监测量超阈值时发出脉冲。
- **反相卡**：反转触发条件；也即在数量低于阈值时，或移除至少同等量时发出脉冲，而非在超过或收到时。
- **模糊卡**：允许通配物品NBT，很适合监测带有魔咒或自定义标签的物品。
