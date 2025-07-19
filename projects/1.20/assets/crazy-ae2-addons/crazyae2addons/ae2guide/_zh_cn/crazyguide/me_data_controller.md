---
navigation:
  parent: crazyae2addons_index.md
  title: ME数据控制器
  icon: crazyae2addons:me_data_controller
categories:
  - Data Variables
item_ids:
  - crazyae2addons:me_data_controller
---

# ME数据控制器

<BlockImage id="crazyae2addons:me_data_controller" scale="4"></BlockImage>

ME数据控制器是Crazy AE2 Addons数据系统的核心。它用于存储[数据提取器](data_extractor.md)提取到的数据，以供[显示监视器](display.md)、[数据追踪器](data_tracker.md)、[数据处理器](data_processor.md)等其他方块使用。

## 使用方法

1. **放置方块**：将ME数据控制器连接至ME网络。
2. **扩充存储容量**：
    - 将存储组件放入控制器的槽位。
    - 组件每有1k字节的空间，即可多存储1个变量。16k就能存储16个变量，以此类推。
3. **自动化管理**：
    - 网络中的某些设备能向控制器发送变量。
    - 变量的值改变时，所有监视该变量的设备均会立即更新。

为使用Crazy AE2 Addons中的数据变量功能，网络中必须有且仅有1个ME数据控制器。