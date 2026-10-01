---
navigation:
  parent: items-blocks/index.md
  icon: instruction_set
  title: 配方集
categories:
  - autocrafting
description: 存储[自动合成](../nodeworks-mechanics/autocrafting.md)需要的合成配方
item_ids:
- nodeworks:instruction_set
- nodeworks:processing_set
---

# 配方集

配方集是用于存储[自动合成](../nodeworks-mechanics/autocrafting.md)所需配方的物品，分为两种。

配方集是模板物品，能存储单个配方供[自动合成](../nodeworks-mechanics/autocrafting.md)参考执行。配方集需在GUI中先行编写，再插入相应的[存储器](./storage_blocks.md)中去。

共有两种配方集，对应两类配方：

- **指令集：**&zwnj;原版的3x3合成配方（有序、无序）
- **处理集：**&zwnj;所有其他配方（烧炼、模组机器、多输出加工流程、所有会超时的流程）

---

## 指令集

<ItemImage scale="4" id="instruction_set" />

3x3的合成模板。所有可在原版工作台中执行的配方均可。

### 创建配方

右击打开。拿起物品点击虚槽位留下虚影（无需消耗物品），点击空槽位可清除。产物槽会在输入匹配已知合成配方时自动填充。**清除全部**会重置方格。

GUI中还有一个**标签替换**切换按钮。启用时（默认），配方会接受与虚影在同一标签下的任意物品，所有标记为橡木木板的箱子也会接受白桦木板、云杉木板，或者其他任意在`#minecraft:planks`下的物品。禁用可限制为精确匹配物品ID。

> **提示：**&zwnj;JEI的&zwnj;**(+)**&zwnj;配方转移按钮在此GUI中有效，可以先在JEI中挑选合成配方，再点击(+)一次性填充。

### 部署

将编写完毕的指令集放入<ItemLink id="instruction_storage" />。相邻的指令集会形成集群。只要集群中*有一个*方块在网络中，集群内的其他指令集便都对CPU可见。

---

## 处理集

<ItemImage scale="4" id="processing_set" />

形式自由的配方，最多可有9个输入和3个输出，以及可选的每次合成超时时限。所有3×3方格无法处理的都能用处理集（烧炼、高炉烧炼、模组机器、多输出加工流程，或任意&zwnj;*“输出前需等待N刻”*&zwnj;的配方）。

### 创建配方

右击打开。GUI中有：

- **输入方格**：（3×3）虚槽位，接受任意输出，位置随意。
- **输出列**：（3个槽位）虚槽位，接受输出。
- **超时字段**：0–999刻（0 = 无超时）。`+`可`-`按钮的调整步长为20，Shift点击的步长为100。
- **串行切换**：启用时，CPU不会在运行此配方时重复并行运行。
- **清除全部**：重置所有设置。

槽位内资源数量可用滚轮滚动调整（向上滚动+1，向下-1，在数量为1时向下滚动则清除）。

> **提示：**&zwnj;JEI的&zwnj;**(+)**&zwnj;也在此有效，且*普遍*有效。只要是JEI知晓的配方类别（烧炼/高炉烧炼/模组加工过程）均可。

### 部署

将编写完毕的处理集放入<ItemLink id="processing_storage" />。和指令存储器类似，相邻的处理存储器也会形成集群。CPU会对实际执行配方的外部机器进行调度。

## 配方

<Row>
    <RecipeFor id="instruction_set" />
    <RecipeFor id="processing_set" />
</Row>