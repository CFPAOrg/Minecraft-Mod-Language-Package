---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 存储元件
  icon: item_storage_cell_1k
  position: 410
categories:
- tools
item_ids:
- ae2:item_cell_housing
- ae2:fluid_cell_housing
- ae2:cell_component_1k
- ae2:cell_component_4k
- ae2:cell_component_16k
- ae2:cell_component_64k
- ae2:cell_component_256k
- ae2:item_storage_cell_1k
- ae2:item_storage_cell_4k
- ae2:item_storage_cell_16k
- ae2:item_storage_cell_64k
- ae2:item_storage_cell_256k
- ae2:fluid_storage_cell_1k
- ae2:fluid_storage_cell_4k
- ae2:fluid_storage_cell_16k
- ae2:fluid_storage_cell_64k
- ae2:fluid_storage_cell_256k
---

# 存储元件

<Column>
  <Row>
    <ItemImage id="item_storage_cell_1k" scale="4" />

    <ItemImage id="item_storage_cell_4k" scale="4" />

    <ItemImage id="item_storage_cell_16k" scale="4" />

    <ItemImage id="item_storage_cell_64k" scale="4" />

    <ItemImage id="item_storage_cell_256k" scale="4" />
  </Row>

  <Row>
    <ItemImage id="fluid_storage_cell_1k" scale="4" />

    <ItemImage id="fluid_storage_cell_4k" scale="4" />

    <ItemImage id="fluid_storage_cell_16k" scale="4" />

    <ItemImage id="fluid_storage_cell_64k" scale="4" />

    <ItemImage id="fluid_storage_cell_256k" scale="4" />
  </Row>
</Column>

存储元件是应用能源中存储的基础方式之一。需将其装入<ItemLink id="drive" />或<ItemLink id="chest" />中。

有关其字节和类型容量的介绍参见[字节与类型](../ae2-mechanics/bytes-and-types.md)。

若存储元件为空，则可手持Shift右击以将存储组件从元件外壳中取出。

## 存储容量与类型数变化关系

[每类型预先占用量](../ae2-mechanics/bytes-and-types.md)设计为：存有1个类型的元件的容量是存满63个元件的容量的两倍。

| 元件                                     |                       使用1个类型时总容量 |                        使用63个类型时总容量 |
| ---------------------------------------- | ----------------------------------------: | ------------------------------------------: |
| <ItemLink id="item_storage_cell_1k" />   |                                     8,128 |                                       4,160 |
| <ItemLink id="item_storage_cell_4k" />   |                                    32,512 |                                      16,640 |
| <ItemLink id="item_storage_cell_16k" />  |                                   130,048 |                                      66,560 |
| <ItemLink id="item_storage_cell_64k" />  |                                   520,192 |                                     266,240 |
| <ItemLink id="item_storage_cell_256k" /> |                                 2,080,768 |                                   1,064,960 |


## 分区

与过滤<ItemLink id="storage_bus" />类似，元件可过滤为只接受特定物品。此操作需在<ItemLink id="cell_workbench" />中完成。

如果没有所需物品，可从JEI/REI中拖拽以放入过滤槽。

## 升级

存储元件支持如下[升级](upgrade_cards.md)，需用<ItemLink id="cell_workbench" />装入：

*   <ItemLink id="fuzzy_card" />（流体元件不可用）使得元件可按耐久度或忽略NBT分区
*   <ItemLink id="inverter_card" />将白名单变为黑名单
*   <ItemLink id="equal_distribution_card" />会为每个类型分配同等大小的扇区，也即单个类型无法填满元件
*   <ItemLink id="void_card" />会在元件已满（或在装有均分卡时某类型已满）时销毁输入的物品，可避免农场产物堆积。设置分区的时候要小心！
*   便携元件也接受<ItemLink id="energy_card" />，可增加其能量容量

## 染色

便携物品和流体元件可像皮革盔甲一样染色，与染料合成即可。

# 外壳

元件可由存储组件和外壳合成，也可在外壳配方中央放入存储组件：

<Row>
  <Recipe id="network/cells/item_storage_cell_1k" />

  <Recipe id="network/cells/item_storage_cell_1k_storage" />
</Row>

外壳自身的配方如下：

<Row>
  <RecipeFor id="item_cell_housing" />

  <RecipeFor id="fluid_cell_housing" />
</Row>

# 存储组件

存储组件是所有AE2元件的核心，决定了元件的容量。每级组件的容量是前一级的4倍，消耗则为3倍。

<Column>
  <Row>
    <RecipeFor id="cell_component_1k" />

    <RecipeFor id="cell_component_4k" />

    <RecipeFor id="cell_component_16k" />
  </Row>

  <Row>
    <RecipeFor id="cell_component_64k" />

    <RecipeFor id="cell_component_256k" />
  </Row>
</Column>

# 物品存储元件

物品存储元件可存储最多63种物品，且覆盖所有标准容量。

<Column>
  <Row>
    <Recipe id="network/cells/item_storage_cell_1k_storage" />

    <Recipe id="network/cells/item_storage_cell_4k_storage" />

    <Recipe id="network/cells/item_storage_cell_16k_storage" />
  </Row>

  <Row>
    <Recipe id="network/cells/item_storage_cell_64k_storage" />

    <Recipe id="network/cells/item_storage_cell_256k_storage" />
  </Row>
</Column>

## 便携物体元件

它们是口袋版（或者背包版）的<ItemLink id="chest" />。可在<ItemLink id="charger" />中为其充能。

和标准的存储元件不同，随着字节容量上升，它们的类型容量会*下降*，且字节容量为标准的一半。

除其他元件能接受的升级卡外，便携元件也接受<ItemLink id="energy_card" />以增加能量容量。

<Column>
  <Row>
    <RecipeFor id="portable_item_cell_1k" />

    <RecipeFor id="portable_item_cell_4k" />

    <RecipeFor id="portable_item_cell_16k" />
  </Row>

  <Row>
    <RecipeFor id="portable_item_cell_64k" />

    <RecipeFor id="portable_item_cell_256k" />
  </Row>
</Column>

# 流体存储元件

流体存储元件可存储最多5种流体，且覆盖所有标准容量。

<Column>
  <Row>
    <Recipe id="network/cells/fluid_storage_cell_1k_storage" />

    <Recipe id="network/cells/fluid_storage_cell_4k_storage" />

    <Recipe id="network/cells/fluid_storage_cell_16k_storage" />
  </Row>

  <Row>
    <Recipe id="network/cells/fluid_storage_cell_64k_storage" />

    <Recipe id="network/cells/fluid_storage_cell_256k_storage" />
  </Row>
</Column>

## 便携流体元件

它们是口袋版（或者背包版）的<ItemLink id="chest" />。可在<ItemLink id="charger" />中为其充能。

和标准的存储元件不同，随着字节容量上升，它们的类型容量会*下降*，且字节容量为标准的一半。

除其他元件能接受的升级卡外，便携元件也接受<ItemLink id="energy_card" />以增加能量容量。

<Column>
  <Row>
    <RecipeFor id="portable_fluid_cell_1k" />

    <RecipeFor id="portable_fluid_cell_4k" />

    <RecipeFor id="portable_fluid_cell_16k" />
  </Row>

  <Row>
    <RecipeFor id="portable_fluid_cell_64k" />

    <RecipeFor id="portable_fluid_cell_256k" />
  </Row>
</Column>

# 创造物品元件与创作流体元件

<Row>
  <ItemImage id="creative_item_cell" scale="2" />

  <ItemImage id="creative_fluid_cell" scale="2" />
</Row>

创造物品元件与创作流体元件**并不能提供无限存储空间**。它们是所[分区](cell_workbench.md)物品或流体的无限供应源和销毁池。
