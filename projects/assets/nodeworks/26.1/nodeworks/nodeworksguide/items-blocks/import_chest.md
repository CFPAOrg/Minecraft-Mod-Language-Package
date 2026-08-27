---
navigation:
  parent: items-blocks/index.md
  icon: import_chest
  title: Import Chest
categories:
  - infrastructure
description: pushes items into network storage from its inventory
item_ids:
- nodeworks:import_chest
---

# Import Chest

A 9-slot chest that automatically pushes anything placed inside it into
[Network Storage](../nodeworks-mechanics/network-storage.md). Drop items
in by hand, with a hopper, or from another mod's pipes and the chest
clears itself into the network.

<GameScene zoom="6">
  <ImportStructure src="../assets/assemblies/import_chest.snbt" />
</GameScene>

Items that can't be accepted (filters, no space, etc.) stay in the chest
so you can see exactly what's stuck.

## Channel

Set a channel in the GUI to restrict the push to storage cards on that
channel. The default pushes to every storage card on the network. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel).

## Round robin

Toggle round robin in the GUI to spread inserts across destination
storage cards instead of always filling the first one. Handy when you
want incoming items to load-balance across multiple storage targets.

## Tick interval

The GUI exposes how often the chest tries to insert, defaulting to once
per second. Lower for snappier intake at the cost of more network work,
higher for idle setups.

## Redstone

The GUI's redstone setting gates whether the chest runs:

- **High**: active while powered.
- **Low**: active while unpowered.
- **Ignored**: redstone does nothing.

## Wireless

Place a <ItemLink id="receiver_antenna" /> on top of the chest and pair
it with a <ItemLink id="broadcast_antenna" /> sitting on an
<ItemLink id="export_chest" /> on another network. Items pushed into the
broadcasting Export Chest land in this chest, then route into the local
network's storage like any other intake.

## Recipe

<RecipeFor id="import_chest" />
