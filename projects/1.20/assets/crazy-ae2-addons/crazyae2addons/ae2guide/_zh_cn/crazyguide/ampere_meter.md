---
navigation:
  parent: crazyae2addons_index.md
  title: 电流表
  icon: crazyae2addons:ampere_meter
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:ampere_meter
---

# 电流表

<BlockImage id="crazyae2addons:ampere_meter" scale="4"></BlockImage>

电流表的功能相对简单：能显示两端间能量的传输量。使用时，此设备需与两个使用能量的方块相邻。右击电流表可进行设置。

界面中央有一个箭头按钮，点击可切换能量输入和输出端。可以来回翻转箭头并观察数字的变化以进行测试。界面中的主要数据是在若干刻内统计出的平均传输率，测量Forge能量（FE）时显示格式为`10k FE/t`，测量格雷科技（GregTech）的能量时则类似`4A (LuV)`。它还可充当二极管，用于阻断相反方向的能量流动。

## 兼容性

- 对任意使用Forge能量的机器有效。
- 安装格雷科技时，还可测量EU电流和电压。