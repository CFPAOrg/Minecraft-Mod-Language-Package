---
navigation:
  title: Crazy AE2 Addons
  position: 120
---

# Crazy AE2 Addons

Crazy AE2 Addons以多种方式拓展了应用能源2（Applied Energistics 2）的功能：模组引入了高级自动化设备、监测设备、红石控制功能、合成设备、网络工具，以及便携式空间存储设备。

大多数方块和部件都需在ME网络内运作。

---

## 需要帮助？

加入[Discord服务器](https://discord.com/invite/mWy8AVRtwz)

---

## 特性目录

---

### 监测、显示、警报设备

用于可视化ME网络数据、记录库存水平、在世界或HUD中显示警报的各种工具。

- [显示屏](crazyguide/display.md)  
  能显示文本、图像、AE2网络数据的线缆子部件，支持多种组件符和颜色，还有为大型屏幕准备的合并模式。

- [无线通知终端](crazyguide/notification_terminal.md)  
  最多能监测16种物品（可配置）的无线终端，可在对应物品库存量超出/跌过所配置阈值时发出HUD警报，警报颜色可调。

- [资源追踪终端](crazyguide/resource_tracking_terminal.md)  
  显示网络中当前正在消耗何种物品及其消耗速率的终端，能按去向分解显示详细信息，也配有能定位对应接口的高亮按钮。

---

### 发信器和红石控制

根据ME网络状态、物品库存水平、标签表达式、手动远程切换等触发源控制红石信号的部件和终端。

- [发信器终端](crazyguide/emitter_terminal.md)  
  能一站式管理网络中所有基础ME标准发信器的终端，集成了阈值和过滤项的编辑功能。

- [无线发信器终端](crazyguide/emitter_terminal.md)  
  发信器终端的无线版本。

- [复合标准发信器](crazyguide/multi_level_emitter.md)  
  库存标准发信器的一种，能同时监测最多16种资源（可配置），接受与/或逻辑运算，支持合成卡与模糊卡。

- [标签标准发信器](crazyguide/tag_level_emitter.md)  
  库存标准发信器的一种，使用布尔标签表达式进行过滤，而非直接过滤物品。

- [模拟信号卡](crazyguide/analog_card.md)  
  适用于ME标准发信器和标签标准发信器的升级卡，会输出正比于物品量的模拟红石信号，可选择采用线性映射或对数映射。

- [红石发信器](crazyguide/redstone_emitter.md)  
  简单的红石发信部件，可用红石终端远程控制。

- [红石终端](crazyguide/redstone_terminal.md)  
  能一站式开关网络中所有红石发信器的终端。

- [无线红石终端](crazyguide/redstone_terminal.md)  
  红石终端的无线版本。

---

### P2P、运输设备、网络通道

用于在不同位置乃至维度间传递物品、流体、交互、能力的高级通道工具。

- [虫洞](crazyguide/wormhole.md)  
  通用式P2P通道，能够传输方块能力和交互操作，甚至支持传送。可跨维度。

- [轮询物品P2P通道](crazyguide/rr_p2p.md)  
  能在各输出端间均分物品的P2P通道。

- [轮询流体P2P通道](crazyguide/rr_p2p.md)  
  能在各输出端间均分流体的P2P通道。

---

### 合成、样板、供应器

用于改进自动合成工作流、修改已编码样板、扩展样板仓储的实用设备。

- [CPU优先级调整器](crazyguide/cpu_priority_tuner.md)  
  用于设置合成CPU优先级，可用其控制哪些CPU会优先执行合成任务。

- [样板倍增器](crazyguide/pattern_multiplier.md)  
  能按所选倍数倍增已编码样板中输入输出的物品。可在容器内直接进行倍增。

- [疯狂样板供应器](crazyguide/crazy_pattern_provider.md)  
  可扩展的样板供应器，具有方块形态和部件形态。起始时有72个槽位，可使用升级进一步增加。

- [弹出器](crazyguide/ejector.md)  
  会自动合成所设定的物品，并向相邻容器弹出。

---

### 标签过滤

使用标签表达式过滤终端和自动化逻辑的工具，无需一一指定物品。

- [标签显示元件](crazyguide/tag_view_cell.md)  
  使用布尔标签表达式过滤ME终端的显示元件。

---

### 配装

定制的加工处理机器，专为不符合标准合成和处理样板的配方设计。

- [配方配装器](crazyguide/recipe_fabricator.md)  
  能按照专门定制的配装配方加工原料的方块，接受流体输入输出，也可让其自动弹出产物。

---