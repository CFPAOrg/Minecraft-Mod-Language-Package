---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: ME输出总线
  icon: export_bus
  position: 220
categories:
- devices
item_ids:
- ae2:export_bus
---

# 输出总线

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/blocks/export_bus.snbt" />
</GameScene>

输出总线会从[网络存储](../ae2-mechanics/import-export-storage.md)中抽出物品和流体（以及附属添加的其他类型），并存入其所连接的容器。

为减少卡顿，输出总线会在近期未输出的情况下进入某种“睡眠模式”，此时其工作速度较慢，并会在其输出物品时被唤醒并逐渐进入正常状态（每秒传输4次）。

输出总线是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

## 过滤

默认情况下，输出总线不会输出任何东西。放入其过滤槽的物品会加入白名单，也即只会输出其中指明的事物。

如果没有所需物品或流体，可从JEI/REI中拖拽以放入过滤槽。

用流体容器（如铁桶或流体储罐）右击即可将流体设为过滤，而非铁桶和储罐物品。

## 升级

输出总线支持以下[升级](upgrade_cards.md)：

*   <ItemLink id="capacity_card" />增加过滤槽位数，并给予设置输出顺序的功能
*   <ItemLink id="speed_card" />增加每次传输时移动的物品数
*   <ItemLink id="fuzzy_card" />使得总线能按耐久度或忽略物品NBT过滤
*   <ItemLink id="crafting_card" />使总线能向[自动合成](../ae2-mechanics/autocrafting.md)系统发送所需物品的请求；可设置为使用或不使用已存储物品
*   <ItemLink id="redstone_card" />加入红石控制功能，使其会在高信号、低信号、遇脉冲时启动

## 速度

| 加速卡数 | 每次传输移动的物品数 |
|:---------|:---------------------|
| 0        | 1                    |
| 1        | 8                    |
| 2        | 32                   |
| 3        | 64                   |
| 4        | 96                   |

## 配方

<RecipeFor id="export_bus" />
