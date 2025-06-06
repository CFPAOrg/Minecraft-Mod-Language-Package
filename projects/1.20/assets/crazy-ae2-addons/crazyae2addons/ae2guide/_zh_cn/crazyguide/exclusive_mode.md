---
navigation:
  parent: crazyae2addons_index.md
  title: 独占模式
  icon: crazyae2addons:crafting_guard
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:crafting_guard
---

# 独占模式

<BlockImage id="crazyae2addons:crafting_guard" scale="4"></BlockImage>

合成守护器是一类特殊方块，能阻止多个样板供应器在同一刻内向同一机器发送多个请求。可借此避免合成任务重叠，也可防止格雷科技（GregTech）的机器在编程电路的设置上出现不一致行为。

## 使用方法

1. **放置合成守护器**
    - 将其放置在ME网络中任意一处。每个网络中只允许存在一个合成守护器——多余的会在放置时自动掉落。

2. **启用样板供应器的独占模式**
    - 打开样板供应器的GUI。
    - 启用**阻挡模式**。
    - 启用新增的**独占模式（Exclusive Mode）**。
    - 该供应器即会跳过在同一刻内收到过原材料的机器。

---

## 工作原理

- 样板供应器送出物品时，合成守护器会记录用到的机器。
- 服务端的同一刻内，其他处于**独占模式**的样板供应器会跳过所记录的机器。
- 这样即可避免多个任务试图在同一时刻给同一台格雷科技机器设置电路。

---

## 注意事项

- 同一网络中只允许存在**一个合成守护器**。
- 样板供应器需要同时处于阻挡模式和独占模式。
