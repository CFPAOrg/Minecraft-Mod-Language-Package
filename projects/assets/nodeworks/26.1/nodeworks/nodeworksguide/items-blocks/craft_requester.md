---
navigation:
  parent: items-blocks/index.md
  icon: craft_requester
  title: Craft Requester
categories:
  - device
description: starts an autocrafting job given a redstone signal
item_ids:
- nodeworks:craft_requester
---

# Craft Requester

The Craft Requester starts an autocrafting job when it receives a redstone
signal. Configure it with the item to craft and the batch size.

<GameScene interactive={true} zoom="5" paddingLeft="40" paddingRight="40">
  <ImportStructure src="../assets/assemblies/craft_requester_door.snbt" />
  <DiamondAnnotation pos="3.5 0.5 1.5">
    <ItemImage id="minecraft:oak_planks" />
  </DiamondAnnotation>
  <DiamondAnnotation pos="0.5 0.5 0.5">
    <RecipeFor id="minecraft:oak_door" />
  </DiamondAnnotation>
  <BoxAnnotation min="1.2 1 0.3" max="1.8 1.2 0.7" color="#00f2ff">
    Redstone signal activates Craft Requester and crafts its configured item
  </BoxAnnotation>
</GameScene>

## Using the Craft Requester

Right-click it with an item to set what it crafts. Right-click again with
an empty hand to open the GUI and pick the batch size and [output channel](./craft_requester.md#channel).

Apply redstone and it'll keep queueing crafts while the signal stays on,
one batch at a time. Drop the signal and it stops.

Pair it with a button for one-shot crafts or a <ItemLink id="storage_meter" />
for autostock. The meter cycles its signal on its own as stock dips and
recovers.

The status label at the bottom of the GUI tells you what it's doing. Hover it for
details.

## Channel

The Craft Requester uses a channel picker in its GUI to choose where the crafted item should go.

> **Note:** See [Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for more info.

## Recipe

<RecipeFor id="craft_requester" />
