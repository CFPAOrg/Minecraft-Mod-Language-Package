---
navigation:
  parent: crazyae2addons_index.md
  title: 独立式数据处理器
  icon: crazyae2addons:isolated_data_processor
categories:
  - Data Variables
item_ids:
  - crazyae2addons:isolated_data_processor
---

# 独立式数据处理器

<BlockImage id="crazyae2addons:isolated_data_processor" scale="4"></BlockImage>

独立式数据处理器是一类高速逻辑设备，其功能与标准的数据处理器类似，但它会在每一刻都持续执行其逻辑运算，不会等待外部触发信号。

## 使用方法

1. **放置方块**：将独立式数据处理器连接至ME网络。
2. **放入逻辑卡**：
    - 向处理器放入[逻辑卡](logic_cards.md)。
3. **配置运算符**：
    - 点击逻辑卡槽位下方的扳手按钮以打开详细配置。
    - 设置输入值（可以是常量、变量、寄存器），并指定结果的存储位置。
4. **寄存器**：
    - 可使用4个临时寄存器（`&&0`到`&&3`）暂存中间值。
5. **循环逻辑**：
    - 处理器会在每一刻到来时自动读取下一张卡，并执行相应的运算。
    - 条件跳转卡（真值跳转、假值跳转）可用于动态跳过槽位。
6. **多次写出**：此类处理器会一直向[ME数据控制器](me_data_controller.md)写出。

独立式数据处理器会独立常态运行，正因此，它是计数器、计时器等需常态启用的逻辑系统的不二之选。