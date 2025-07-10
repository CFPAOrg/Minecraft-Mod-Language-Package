---
navigation:
  parent: enderdrives_intro/enderdrives_intro-index.md
  title: 磁带盘物品存储元件
  icon: tape_disk
categories:
  - tapedrives
item_ids:
  - enderdrives:tape_disk
---

# 磁带盘驱动器

磁带盘驱动器是兼容AE2原生系统的强大存储元件，专门用于处理**包含大量NBT的物品**，如工具、盔甲、附魔装备，以及任意具有独特标签的物品——这些物品在使用传统ME存储元件时通常会大量占用物品类型空间。

磁带盘和普通的AE2元件不同，它们的字节占用量会随其中物品的**NBT大小**动态变化，可借此精细控制你的存储系统。磁带盘驱动器**不**具备优先级设置，请使用ME驱动器的优先级。

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:tape_disk" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:tape_disk" />
  </Column>
</Row>

---

## 工作原理

磁带盘只会接受具有非标准NBT的物品，如盔甲、工具、不可堆叠的物品等。

---

## 字节与类型的限制

磁带盘同时具有**类型限制**和**字节占用限制**：

- **类型限制** – 单种物品的存储量上限（如附魔书、自定义盔甲等）
- **字节占用限制** – 由各个物品的**NBT数据大小**决定；神化（Apotheosis）的装备等携带大量标签的物品会因此占用更多空间

磁带盘会**优先接受包含大量NBT的物品**，非常适合存储装备和独特的物品，也可阻止它们污染传统的存储空间。

---


## 磁带盘的使用时机

在下述情况中，应当优先使用磁带盘：

- 需存储**不可堆叠的物品**，如盔甲、工具、装备
- 需存储**包含大量NBT的模组物品**
- 需将特殊物品隔离在普通的ME元件之外

磁带驱动器在普通驱动器捉襟见肘的地方大放异彩——它们能避免大体量元件的类型被占用。

---

## IO端口传输

磁带盘会对涉及它自身，以及它使用任意IO端口的传输进行自动限流。这是为避免一次传输大量NBT过多的物品导致的游戏卡死。

---

## 里面能存储什么？

磁带盘专长于存储**包含大量NBT**、**不可堆叠**、或**自定义**的物品——它不是通用的批量存储设备。

---

### 接受的物品

| 物品                                            | 示例                   |
| ----------------------------------------------- | ---------------------- |
| <ItemImage id="minecraft:diamond_chestplate" /> | 带有魔咒的**钻石胸甲** |
| <ItemImage id="minecraft:enchanted_book" />     | 带有魔咒的**附魔书**   |
| <ItemImage id="minecraft:splash_potion" />      | 具有效果的**药水**     |
| <ItemImage id="minecraft:netherite_pickaxe" />  | 消耗过耐久度的**工具** |

---

### 不接受的物品

| 物品                                     | 理由              |
| ---------------------------------------- | ----------------- |
| <ItemImage id="minecraft:cobblestone" /> | 不包含NBT，可堆叠 |
| <ItemImage id="minecraft:wheat" />       | 不包含NBT，可堆叠 |
| <ItemImage id="minecraft:oak_log" />     | 不包含NBT，可堆叠 |
| <ItemImage id="minecraft:apple" />       | 不包含NBT，可堆叠 |
| <ItemImage id="minecraft:iron_ingot" />  | 不包含NBT，可堆叠 |

---

