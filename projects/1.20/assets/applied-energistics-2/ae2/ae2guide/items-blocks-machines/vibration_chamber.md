---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 谐振仓
  icon: vibration_chamber
  position: 110
categories:
- network infrastructure
item_ids:
- ae2:vibration_chamber
---

# 谐振仓

<BlockImage id="vibration_chamber" p:active="true" scale="8" />

给网络供给[能量](../ae2-mechanics/energy.md)的基础方法是<ItemLink id="energy_acceptor" />，谐振仓则能直接生成少量到中量的AE。

默认状况下（无[升级](upgrade_cards.md)且处于默认配置），它会产出40AE/t。

网络的[能量](../ae2-mechanics/energy.md)存满时，谐振仓会减缓工作速度以减少燃料消耗，但它不会完全停止工作。

## 设置

*   谐振仓提供调整全局能量单位（AE、E/FE）的设置

## 升级

谐振仓支持如下[升级](upgrade_cards.md)：

*   每张<ItemLink id="energy_card" />会将谐振仓的效率+50%，最大+150%，也即基础效率的250%
*   每张<ItemLink id="speed_card" />会将谐振仓的燃烧速率+50%，最大+150%，也即基础能量输出的250%

## 配置

谐振仓各属性可在.minecraft/config/ae2/common.json中修改。

*   baseEnergyPerFuelTick设置谐振仓未经升级的基础效率。
*   minEnergyPerGameTick设置产能水平下限（即便网络不需要能量，谐振仓也会缓慢消耗燃料）。
*   maxEnergyPerGameTick设置谐振仓未经升级的输出上限（和速度）。

## 配方

<RecipeFor id="vibration_chamber" />
