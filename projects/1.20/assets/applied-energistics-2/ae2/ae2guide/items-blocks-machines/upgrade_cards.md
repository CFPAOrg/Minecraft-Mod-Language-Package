---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 升级卡
  icon: speed_card
  position: 410
categories:
- tools
item_ids:
- ae2:basic_card
- ae2:advanced_card
- ae2:redstone_card
- ae2:capacity_card
- ae2:void_card
- ae2:fuzzy_card
- ae2:speed_card
- ae2:inverter_card
- ae2:crafting_card
- ae2:equal_distribution_card
- ae2:energy_card
---

# 升级卡

<Row>
  <ItemImage id="redstone_card" scale="2" />

  <ItemImage id="capacity_card" scale="2" />

  <ItemImage id="void_card" scale="2" />

  <ItemImage id="fuzzy_card" scale="2" />

  <ItemImage id="speed_card" scale="2" />

  <ItemImage id="inverter_card" scale="2" />

  <ItemImage id="crafting_card" scale="2" />

  <ItemImage id="equal_distribution_card" scale="2" />

  <ItemImage id="energy_card" scale="2" />
</Row>

升级卡能改变AE2[设备](../ae2-mechanics/devices.md)和机械的行为，增加速度，加强过滤功能，启用红石控制，如此种种。

## 升级卡组件

<Row>
  <ItemImage id="basic_card" scale="2" />

  <ItemImage id="advanced_card" scale="2" />
</Row>

升级卡需用基础卡或高级卡合成。

<Row>
  <RecipeFor id="basic_card" />

  <RecipeFor id="advanced_card" />
</Row>

## 红石卡

<ItemImage id="redstone_card" scale="2" />

红石卡给予红石控制功能，并会向装置的GUI中加入对应多种红石信号状况的切换按钮。

<RecipeFor id="redstone_card" />

## 容量卡

<ItemImage id="capacity_card" scale="2" />

容量卡能增加输入总线、输出总线、存储总线、成型面板的过滤槽数。

<RecipeFor id="capacity_card" />

## 溢出销毁卡

<ItemImage id="void_card" scale="2" />

溢出销毁卡可在<ItemLink id="cell_workbench" />中装入[存储元件](storage_cells.md)，其会在元件已满时销毁输入物品。（一定要给元件[分区](cell_workbench.md)！）若同时装有均分卡，则会在特定物品的扇区已满时销毁多余的该物品，而无视其他物品的装满情况。

<RecipeFor id="void_card" />

## 模糊卡

<ItemImage id="fuzzy_card" scale="2" />

模糊卡允许可过滤的装置和工具按耐久度或忽略NBT过滤，从而允许无视耐久度和魔咒输出铁斧，或是只输出耐久度不满的钻石剑。

以下是模糊耐久度的比较方式示例，表格左侧为总线配置，顶部为被比较物品。

| 25%          | 耐久度剩余10%的镐 | 耐久度剩余30%的镐 | 耐久度剩余80%的镐 | 完好无损的镐 |
| ------------ | ------------------- | ------------------- | ------------------- | ------------ |
| 接近破损的镐 | ✅                   | \*\*\*\*            | \*\*\*\*            | \*\*\*\*     |
| 完好无损的镐 | \*\*\*\*            | ✅                   | ✅                   | ✅            |

| 50%          | 耐久度剩余10%的镐 | 耐久度剩余30%的镐 | 耐久度剩余80%的镐 | 完好无损的镐 |
| ------------ | ------------------- | ------------------- | ------------------- | ------------ |
| 接近破损的镐 | ✅                   | ✅                   | \*\*\*\*            | \*\*\*\*     |
| 完好无损的镐 | \*\*\*\*            | \*\*\*\*            | ✅                   | ✅            |

| 75%          | 耐久度剩余10%的镐 | 耐久度剩余30%的镐 | 耐久度剩余80%的镐 | 完好无损的镐 |
| ------------ | ------------------- | ------------------- | ------------------- | ------------ |
| 接近破损的镐 | ✅                   | ✅                   | \*\*\*\*            | \*\*\*\*     |
| 完好无损的镐 | \*\*\*\*            |                     | ✅                   | ✅            |

| 99%          | 耐久度剩余10%的镐 | 耐久度剩余30%的镐 | 耐久度剩余80%的镐 | 完好无损的镐 |
| ------------ | ------------------- | ------------------- | ------------------- | ------------ |
| 接近破损的镐 | ✅                   | ✅                   | ✅                   | \*\*\*\*     |
| 完好无损的镐 | \*\*\*\*            | \*\*\*\*            | \*\*\*\*            | ✅            |

| 忽略         | 耐久度剩余10%的镐 | 耐久度剩余30%的镐 | 耐久度剩余80%的镐 | 完好无损的镐 |
| ------------ | ------------------- | ------------------- | ------------------- | ------------ |
| 接近破损的镐 | ✅                   | ✅                   | ✅                   | **✅**        |
| 完好无损的镐 | **✅**               | **✅**               | **✅**               | ✅            |

<RecipeFor id="fuzzy_card" />

## 加速卡

<ItemImage id="speed_card" scale="2" />

加速卡使得事物运作得更快，输入总线和输出总线每次操作能移动更多物品，也可让压印器和装配室工作加速。

<RecipeFor id="speed_card" />

## 反相卡

<ItemImage id="inverter_card" scale="2" />

反相卡将设备和工具的过滤从白名单变为黑名单。

<RecipeFor id="inverter_card" />

## 合成卡

<ItemImage id="crafting_card" scale="2" />

合成卡给予设备向[自动合成](../ae2-mechanics/autocrafting.md)系统发送相关物品合成请求的能力。

<RecipeFor id="crafting_card" />

## 均分卡

<ItemImage id="equal_distribution_card" scale="2" />

均分卡可在<ItemLink id="cell_workbench" />中装入[存储元件](storage_cells.md)，其会根据自身[分区](cell_workbench.md)将元件分为均等大小的扇区。如此即可避免某种物品将元件填满。

<RecipeFor id="equal_distribution_card" />

## 能源卡

<ItemImage id="energy_card" scale="2" />

能源卡会为便携终端等工具增加能量容量，也可增加<ItemLink id="vibration_chamber" />的效率。

<RecipeFor id="energy_card" />
