---
navigation:
  title: 船壳及其修复
  icon: nautec:submarine
  position: 3
  parent: submarine/submarine-index.md
---

# <Color id="light_purple">船壳及其修复</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="submarine" scale="2"/>
  损坏度、破损与修复。
</Column>

潜水器有自己的生命值和护甲值，乘坐潜水器时它会优先受到攻击，而不会直接让你受到伤害。

***

## <Color id="gold">船壳强度</Color>

|          | 默认                 |
| -------- | -------------------- |
| 船壳点数 | 80（40颗红心）       |
| 护甲值   | 20，相当于整套钻石套 |
| 盔甲韧性 | 8，相当于整套钻石套  |

所有三个数据均可配置。[护甲模块](armor_module.md)可提升盔甲韧性并抵御击退，[盾御模块](shield_module.md)可消耗储能承受伤害。

上船时，32格内正在攻击你的生物会转而攻击潜水器；上船后，所有本来要攻击你的生物会以潜水器为目标。可用[隐匿模块](stealth_module.md)摆脱它们。

潜水器免疫溺水、冰冻、方块窒息、生物挤压、摔落等伤害，乘员无法伤害潜水器。药水和其他治疗手段对潜水器无效。

***

## <Color id="gold">自我修复</Color>

潜水器每10秒恢复1%的船壳点数，无论有无人乘坐。轻微受损的潜水器静置一段时间后就会完全修复。间隔时间和修复量均可配置，整合包也可关闭自我修复功能。

读数面板的HULL行显示的是船壳完整度（参见[潜航](submarine_controls.md)）。

***

## <Color id="gold">破损</Color>

船壳耗尽点数后，潜水器会弹出乘员（不造成伤害），自身掉落为物品，保留充能和所有模块。掉落的物品为破损状态：尝试下水会给出“外壳破损，下水前需在铁砧处修复”消息，提示文本中也会显示同一句。

<Color id="gold">提示</Color>：潜水器会在破损时弹出乘员，地点通常是在海底深处。使用受损的潜水器时要备好[潜水套装](nautec:getting_started/diving_gear.md)。

***

## <Color id="gold">在铁砧处修复</Color>

<ItemImage id="deep_steel_plating" scale="1"/>

向铁砧左侧槽位放入潜水器，右侧放入<ItemLink id="deep_steel_plating"/>。每块衬板恢复20%的船壳完整度，消耗2级经验，铁砧最多只会消耗修复所需量，因此5块衬板即可完全修好破损的船壳。

所有受损的潜水器都可以修复，不是只能等到破损才可以。深海钢衬板锻压于[深渊压力锻造机](nautec:deep_engineering/pressure_forge.md)。修复用物品和每物品修复量都可配置，整合包甚至有可能将修复用物品换为钻石。
