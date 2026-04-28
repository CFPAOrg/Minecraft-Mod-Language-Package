---
navigation:
    parent: factory/factory-index.md
    title: "通用方块"
    icon: "woot_revived:factory_connect"
    position: 0
---
# 通用方块

每个工厂都使用这些方块构成通用结构。如需了解更多关于结构的详细信息，请前往相应的等级页面

## 工厂核心

<ItemImage id="heart" scale="0.5"/>[工厂核心](../machines-blocks/heart.md)是工厂的主控制器

<RecipeFor id="heart" />

## 升级插槽

<ItemImage id="factory_upgrade" scale="0.5"/>[升级插槽](../machines-blocks/upgrade-slot.md)可存放工厂的升级物品

<RecipeFor id="factory_upgrade" />

## 伪刷怪笼

<ItemImage id="fake_spawner" scale="0.5"/>[伪刷怪笼](../mob-shard.md)用于存放要进行模拟的生物

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="../assets/anvil/fake_spawner.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="fake_spawner" scale="2"/>
  要合成该方块，你需要一个完全编入的<ItemImage id="mob_shard" scale="0.5"/>生物碎片，一个<ItemImage id="prism" scale="0.5"/>棱镜，以及一个<ItemImage id="factory_base" scale="0.5"/>工厂基座
</Row>

## 主基座和副基座

<ItemImage id="factory_ctr_base_pri" scale="0.5"/>主基座和<ItemImage id="factory_ctr_base_sec" scale="0.5"/>副基座是<ItemImage id="fake_spawner" scale="0.5"/>伪刷怪笼的基座

注意：副基座上的伪刷怪笼为可选项

<Row>
  <RecipeFor id="factory_ctr_base_pri" />
  <RecipeFor id="factory_ctr_base_sec" />
</Row>

## 工厂连接器

<ItemImage id="factory_ctr_base_pri" scale="0.5"/>工厂连接器用于连接原料与工厂

<RecipeFor id="factory_connect" />

## 原料输入口

<ItemImage id="import" scale="0.5"/>[原料输入口](../machines-blocks/import.md)用于输入生成生物所需的物品或流体

<RecipeFor id="import" />

## 战利品输出口

<ItemImage id="export" scale="0.5"/>[战利品输出口](../machines-blocks/export.md)是生物产出物品/流体的输出端

<RecipeFor id="export" />

## 生命单元

注意：所有等级的生命单元均可用于所有等级的工厂！

可在使用[结构展示器](../machines-blocks/layout.md)时注意到这一点，可以看到生命单元预览方块会在各个生命单元之间切换