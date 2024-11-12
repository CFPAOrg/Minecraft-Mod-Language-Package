---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: ME输入总线
  icon: import_bus
  position: 220
categories:
- devices
item_ids:
- ae2:import_bus
---

# 输入总线

<GameScene zoom="8" background="transparent">
<ImportStructure src="../assets/blocks/import_bus.snbt" />
</GameScene>

输入总线会从其所连接的容器中抽出物品和流体（以及附属添加的其他类型），并存入[网络存储](../ae2-mechanics/import-export-storage.md)。

为减少卡顿，输入总线会在近期未输入的情况下进入某种“睡眠模式”，此时其工作速度较慢，并会在其输入物品时被唤醒并逐渐进入正常状态（每秒传输4次）。

输入总线是[线缆子部件](../ae2-mechanics/cable-subparts.md)。

## 过滤

默认情况下，输入总线会输入所有其能访问的事物。放入其过滤槽的物品会加入白名单，也即只会输入其中指明的事物。

如果没有所需物品或流体，可从JEI/REI中拖拽以放入过滤槽。

用流体容器（如铁桶或流体储罐）右击即可将流体设为过滤，而非铁桶和储罐物品。

## 升级

输入总线支持以下[升级](upgrade_cards.md)：

*   <ItemLink id="capacity_card" />增加过滤槽位数
*   <ItemLink id="speed_card" />增加每次传输时移动的物品数
*   <ItemLink id="fuzzy_card" />使得总线能按耐久度或忽略物品NBT过滤
*   <ItemLink id="inverter_card" />将白名单变为黑名单
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

<RecipeFor id="import_bus" />
