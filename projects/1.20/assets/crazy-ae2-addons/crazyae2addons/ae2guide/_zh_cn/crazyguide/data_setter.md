---
navigation:
  parent: crazyae2addons_index.md
  title: 数据设置器
  icon: crazyae2addons:data_setter
categories:
  - Data Variables
item_ids:
  - crazyae2addons:data_setter
---

# 数据设置器

<BlockImage id="crazyae2addons:data_setter" scale="4"></BlockImage>

**数据设置器**是一件简单的红石驱动设备，在接收到红石脉冲时会将给定**数据变量**设置为给定值。

## 如何使用

1. **放置方块**，连接至包含数据控制器的ME网络。
2. **右击**打开GUI。
3. 输入：
    - 需设置的**变量**的名称。
    - 用于设置的**值**（必须为整数）。
4. 向方块发送**红石脉冲**。
    - 脉冲上升沿到来时，变量即会以给定值存入控制器。

## 使用场景示例

- 使用按钮或者拉杆触发逻辑链。
- 向显示监视器或处理器发送"armed" = 1等代表状态的变量。
- 使用红石钟或计数器定时触发逻辑。

只有当网络中存在有效的ME数据控制器时起效。