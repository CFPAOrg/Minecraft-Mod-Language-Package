---
navigation:
  title: 总线
  icon: spaceploitation:energy_input_bus
  position: 4
item_ids:
  - spaceploitation:energy_input_bus
  - spaceploitation:energy_output_bus
  - spaceploitation:item_input_bus
  - spaceploitation:item_output_bus
  - spaceploitation:fluid_input_bus
  - spaceploitation:fluid_output_bus
---

# 总线

总线是行星模拟器输入输出资源的接口。使用时，需将多方块结构中的框架方块换成总线。

## 能量总线

<Row>
  <ItemImage id="spaceploitation:energy_input_bus" />
  <ItemImage id="spaceploitation:energy_output_bus" />
</Row>

传输FE能量。输入总线用于接收能量，输出总线则用于抽出产生的能量。

## 物品总线

<Row>
  <ItemImage id="spaceploitation:item_input_bus" />
  <ItemImage id="spaceploitation:item_output_bus" />
</Row>

传输物品。会连接至漏斗和相邻的容器。

## 流体总线

<Row>
  <ItemImage id="spaceploitation:fluid_input_bus" />
  <ItemImage id="spaceploitation:fluid_output_bus" />
</Row>

传输流体（为将来的配方预留）。

## 配置

可在总线GUI内配置各槽位激活与否。每个总线都有最多6个可配置的槽位，以供满足复杂的自动化需求。
