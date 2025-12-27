---
navigation:
  title: 行星卡
  icon: spaceploitation:planet_card
  position: 2
item_ids:
  - spaceploitation:planet_card
  - spaceploitation:tinted_planet_card
---

# 行星卡

行星卡可将行星模拟器与维度相连，以便进行航天任务。

## 连接行星卡

1. 合成空白<ItemLink id="spaceploitation:planet_card" />
2. 前往目标维度
3. 右击以将行星卡与该维度的行星相连
4. 再次右击以激活

行星卡会在提示文本中显示其维度和激活状态。

## 可用的行星

### 地球（主世界）

<ItemImage id="spaceploitation:planet_card" components="spaceploitation:planet={planet_type:{texture:'minecraft:item/planet_card/planets/overworld',dimension:'minecraft:overworld'},activated:true}" />

使用常见的主世界材料产出基础资源。

### 火星（下界）

<ItemImage id="spaceploitation:planet_card" components="spaceploitation:planet={planet_type:{texture:'minecraft:item/planet_card/planets/the_nether',dimension:'minecraft:the_nether'},activated:true}" />

产出能量，兼有处理下界资源的功能。

### 金星（末地）

产出高级的末地资源，如潜影壳和鞘翅复制。

### 黑洞（深暗之域）

游戏末期内容，需在深暗之域生物群系中激活。

## 断开连接

单独合成已连接的行星卡，可将其回退为空白卡：

<Recipe id="spaceploitation:unlink_planet_card" />

## 提示

- 各行星的可用配方均可查阅JEI
- 不同行星需要不同的输入材料
- 可以保留多张已激活的行星卡，以便快速切换
