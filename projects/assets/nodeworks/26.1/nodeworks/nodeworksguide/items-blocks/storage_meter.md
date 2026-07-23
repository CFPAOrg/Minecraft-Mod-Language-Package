---
navigation:
  parent: items-blocks/index.md
  icon: storage_meter
  title: Storage Meter
categories:
  - device
description: tracks the amount of items/fluids its configured to watch
item_ids:
- nodeworks:storage_meter
---

# Storage Meter

The Storage Meter watches an item in the network and emits a redstone
signal when its stock drops below your threshold. It can also start an autocraft
job to replenish the stock.

<GameScene interactive={true} zoom="5" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/stock_meter_door.snbt" />
  <DiamondAnnotation pos="3.5 0.5 1.5">
    <ItemImage id="minecraft:oak_planks" />
  </DiamondAnnotation>
  <DiamondAnnotation pos="0.5 0.5 0.5">
    <RecipeFor id="minecraft:oak_door" />
  </DiamondAnnotation>
  <BlockAnnotation x="1" color="#00f2ff">
    Has Autocraft enabled and replenishes the stock of doors in the network automatically
  </BlockAnnotation>
</GameScene>

## Using Storage Meters

Right-click it with the item you want it to watch. Right-click again with
an empty hand to open the GUI and set the threshold and channel.

It emits a redstone signal whenever the stock dips below the threshold.
With Autocraft on (the default), it'll also start a craft job to top up
the stock. Turn Autocraft off if you'd rather drive a
<ItemLink id="craft_requester" /> with the signal.

The status label at the bottom of the GUI tells you what it's doing. Hover
it for details.

## Subnet Example

<GameScene interactive={true} zoom="4" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/storage_meter_subnet.snbt" />
  <BlockAnnotation y="2" x="2">
    Cooks <ItemLink id="minecraft:raw_iron" /> to <ItemLink id="minecraft:iron_ingot" />
  </BlockAnnotation>
  <BlockAnnotation x="4" y="2" z="1">
    <ItemImage id="minecraft:raw_iron" />
  </BlockAnnotation>
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

This example shows a <Color id="green">subnet</Color> with a Storage Meter watching a chest for iron ingots. When it's below it sends a redstone signal to <Color id="blue">another network's</Color> <ItemLink id="craft_requester" /> which triggers an autocrafting job using a <ItemLink id="processing_handler" />.

## Channel

The Storage Meter uses a channel picker in its GUI to choose where the crafted item should go as well as the channel of the Network Storage being watched.

> **Note:** See [Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for more info.

## Recipe

<RecipeFor id="storage_meter" />
