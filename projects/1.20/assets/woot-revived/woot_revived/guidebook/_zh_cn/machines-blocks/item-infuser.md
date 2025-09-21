---
navigation:
    parent: machines-blocks/machines-blocks-index.md
    title: "物品灌注器"
    icon: "woot_revived:item_infuser"
---
# 物品灌注器

<BlockImage id="item_infuser" scale="5"/>

<ItemImage id="item_infuser" scale="0.5"/>物品灌注器通过将原料与注入流体结合，来产出新物品

## 合成

<RecipeFor id="item_infuser" />

## 棱镜

<ItemImage id="prism" scale="0.5"/>棱镜是合成<ItemImage id="fake_spawner" scale="0.5"/>伪刷怪笼的主要原料

<Recipe id="item_infuser/prism" />

## 染料板

在获得染料板之前，你需要先合成对应的染料框架

以下为如何合成一个<ItemImage id="white_dye_casing" scale="0.5"/>白色染料框架的示例，同样也适用于其他颜色。

<Row alignItems="center">
  <GameScene zoom="5">
    <ImportStructure src="../assets/anvil/dye_casing.snbt" />
    <IsometricCamera yaw="180" pitch="40" />
  </GameScene>
  <ItemImage id="white_dye_casing" scale="2"/>
  要合成该物品，你需要<ItemImage id="dye_casing_mold" scale="0.5"/>染料框架模具，以及一个<ItemImage id="minecraft:white_dye" scale="0.5"/>白色染料
</Row>

获得染料框架之后，可在物品灌注器中将其与<ItemImage id="pure_dye_fluid_bucket" scale="0.5"/>纯净染料流体结合获得一个染料板

<Recipe id="item_infuser/white_dye_plate" />

## 附魔板

要合成生命燃料单元，你需要对应的附魔板。

例如，要获得一个<ItemImage id="copper_cell" scale="0.5"/>铜生命单元，你需要<ItemImage id="copper_enchanted_plate" scale="0.5"/>铜附魔板

需要<ItemImage id="enchanted_fluid_bucket" scale="0.5"/>附魔流体和对应的碎片来获得这些附魔板

<Row>
  <Recipe id="item_infuser/copper_enchanted_plate" />
  <Recipe id="item_infuser/iron_enchanted_plate" />
  <Recipe id="item_infuser/gold_enchanted_plate" />
  <Recipe id="item_infuser/diamond_enchanted_plate" />
  <Recipe id="item_infuser/netherite_enchanted_plate" />
</Row>

## 杂项

也可使用该机器来获得一些原版物品

<Row>
    <Recipe id="item_infuser/magma_block" />
    <Recipe id="item_infuser/netherrack" />
    <Recipe id="item_infuser/fire_charge" />
    <Recipe id="item_infuser/crying_obsidian" />
    <Recipe id="item_infuser/soul_soil" />
</Row>