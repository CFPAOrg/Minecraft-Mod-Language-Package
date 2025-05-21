---
navigation:
  parent: crazyae2addons_index.md
  title: 逻辑卡
  icon: crazyae2addons:add_card
categories:
  - Data Variables
---

## 逻辑卡概览

<ItemImage id="crazyae2addons:add_card" scale="4"></ItemImage>
<ItemImage id="crazyae2addons:sub_card" scale="4"></ItemImage>

配置数据处理器和独立式数据处理器时，需要用的逻辑卡来定义各类运算：

- **加法卡**：取两数和。
- **减法卡**：取第一个数减去第二个数的差。
- **乘法卡**：取两数积。
- **除法卡**：取第一个数除以第二个数的商（需第二个数不为零）。
- **最小值卡**：返回两数中的较小者。
- **最大值卡**：返回两数中的较大者。
- **右移卡**：向右移位（将第一个数右移第二个数位）。
- **左移卡**：向左移位（将第一个数左移第二个数位）。
- **真值跳转卡**：条件跳转。如果第一个数大于0，则跳转至第二个数对应的槽位。
- **假值跳转卡**：条件跳转。如果第一个数小于等于0，则跳转至第二个数对应的槽位。

逻辑卡可用于进行复杂的数学运算、进行条件检查、制造循环和分支。