---
navigation:
  parent: crazyae2addons_index.md
  title: 数据追踪器
  icon: crazyae2addons:data_tracker
categories:
  - Data Variables
item_ids:
  - crazyae2addons:data_tracker
---

# 数据追踪器

<BlockImage id="crazyae2addons:data_tracker" scale="4"></BlockImage>

数据追踪器是一类简单设备，用于监测ME网络中某变量的值，并根据其状态发出红石信号。变量的值大于0时，追踪器会发出满格红石信号；否则就不会发出信号。

## 使用方法

1. **放置方块**：将数据追踪器连接至ME网络。
2. **设置追踪变量**：右击方块打开其界面。输入需追踪的变量的名称，如`&ABC`。
3. **保存并应用**：按下“保存”/“Save”。
4. **红石输出**：当追踪变量的值大于0时，数据追踪器即会发出红石信号。否则便不会输出信号。

可借助数据追踪器检测熔炉烧炼进程等数据，并据此触发外部系统。