---
navigation:
  parent: items-blocks/index.md
  icon: terminal
  title: 脚本终端
categories:
  - terminal
  - requires_controller
description: 编写和运行控制网络所用Lua脚本的地方
item_ids:
- nodeworks:terminal
---

# 脚本终端

脚本终端是编写和运行控制网络所用Lua脚本的地方。

> 需要<ItemLink id="network_controller" />才可使用

<BlockImage scale="6" id="terminal" />

## 打开编辑器

右击终端可打开。编辑器界面分为三个面板：

- **侧边栏**，列出网络中的所有卡片和变量。点击可在光标处插入一行`network:get("…")`。
- **脚本标签页**，`main`和所有你创建的模块。`main`会在点击开始时运行，其他标签页需通过[`require(name)`](../lua-api/index.md)加载。
- **输出面板**，来自`print(…)`和脚本错误的输出。
  - 也可点击左侧的箭头以收起/展开该面板，或拖动分隔栏以调整面板尺寸。

![](../assets/images/terminal_gui.png)

## 运行脚本

（网络查询、合成、scheduler回调函数、变量等各种脚本功能参见[脚本API](../lua-api/index.md)参考。）

点击开始可加载并运行当前的`main`标签页。除非通过注册回调函数持续运行，否则脚本会在`main`完成后退出。点击停止可终止脚本。

### 自动运行

启用编辑器中的自动运行可在终端加载时自动启动脚本。终端只会在所处区块被加载时加载，可见自动运行**并非**“服务器在线时不断运行”。只有玩家身在区块范围内才能保证加载；若要在附近无人时保持加载，应启用网络的<ItemLink id="network_controller" />区块加载功能。

![](../assets/images/autorun.png)

### 红石

向终端发送红石脉冲可切换脚本运行与否。若脚本已停止，脉冲到来时即会启动；若已在运行中，脉冲到来时即会停止。所有上升沿都有效——可以是按下按钮，踩下压力板，或放置火把。

> 若脚本因为超出最大运行时限而被终止，那么它就无法通过红石重新激活，直到你打开编辑器并编辑脚本为止。此特例是为防止红石钟周期性触发有错误的脚本。

## 配方

<RecipeFor id="terminal" />