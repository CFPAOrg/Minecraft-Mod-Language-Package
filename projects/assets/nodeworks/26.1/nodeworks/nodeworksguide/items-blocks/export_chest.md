---
navigation:
  parent: items-blocks/index.md
  icon: export_chest
  title: Export Chest
categories:
  - infrastructure
description: pulls items from network storage into its inventory
item_ids:
- nodeworks:export_chest
---

# Export Chest

A 9-slot chest that automatically pulls items out of
[Network Storage](../nodeworks-mechanics/network-storage.md) and into its
own buffer.

<GameScene zoom="6">
  <ImportStructure src="../assets/assemblies/export_chest.snbt" />
</GameScene>

## Filter

The chest's GUI takes a list of filter rules using the same pattern syntax
as the <ItemLink id="storage_card" />. Any item matching a rule is fair
game for export. An empty filter idles the chest so a fresh placement
doesn't immediately drain the network.

## Push face

Pick a face in the GUI to auto-drain the buffer into the inventory on
that side. Useful for feeding a hopper, furnace, or machine without
needing a script. Leave it unset to keep the buffer as a manual pickup
spot.

## Channel

Set a channel to restrict the pull to storage cards on that channel. The
default pulls from every storage card on the network. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel).

## Redstone

The GUI's redstone setting gates whether the chest runs:

- **High**: active while powered.
- **Low**: active while unpowered.
- **Ignored**: redstone does nothing.

## Wireless

Place a <ItemLink id="broadcast_antenna" /> on top of the chest and pair
it with a <ItemLink id="receiver_antenna" /> on another network. Items
pushed into the chest get forwarded straight into the receiving
network's storage.

## Recipe

<RecipeFor id="export_chest" />
