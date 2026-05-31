---
navigation:
  title: 控制器
  icon: "synergy:quantum_reactor_controller"
  parent: nuclear.md
  position: 1
categories:
  - nuclear
item_ids:
  - synergy:quantum_reactor_controller
---

# 控制器

量子反应堆的核心。

在被红石激活时，它会根据燃料单元的情况产生热量和能量。

控制器有作用范围，范围中的方块均视作有效方块。

右击控制器会显示热量和FE的变化率。

## 模式：

- 等待
  -> 未提供红石信号

- 过热
  -> 受大量热

- 无燃料
  -> 配方输出槽已满/配方输入槽为空/没有有效燃料单元

- 生产
  -> 产能并推进配方的进度

<ItemImage id="synergy:quantum_reactor_controller" scale="4.0"/>

<RecipeFor id="synergy:quantum_reactor_controller" />
