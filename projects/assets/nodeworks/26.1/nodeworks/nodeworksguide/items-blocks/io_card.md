---
navigation:
  parent: items-blocks/index.md
  icon: io_card
  title: IO Card
categories:
  - card
description: used for reading and writing an inventory/tank from scripts
item_ids:
- nodeworks:io_card
---

# IO Card

The IO Card lets a network read from and write to the inventory of an adjacent
block on demand. With an IO Card installed, scripts can query what's in the
block and move items or fluids to/from it.

<ItemImage scale="6" id="io_card" />

## Installing

IO Cards go in the face slots of a <ItemLink id="node" />. Right-click the
face of the node that's touching the block you want to control and drop an
IO Card into any of the 9 slots. The card's behavior applies to *that face*,
so the same node can have IO Cards on different faces controlling different
neighbors.

![](../assets/images/node_gui.png)

## What it does

A block with an IO Card attached shows up on the network as a script-reachable
inventory:

- `card:find(filter)` returns an [ItemsHandle](../lua-api/items-handle.md) for
  matching contents.
- `card:insert(items)` / `card:tryInsert(items)` move items into it.
- `card:count(filter)` totals matching items (and fluids, in mB).

Unlike a <ItemLink id="storage_card" />, an IO card's block is **not** part of
[Network Storage](../nodeworks-mechanics/network-storage.md). Scripts have to explicitly move items to or from it,
`network:find` across the whole network won't see its contents, and the
<ItemLink id="inventory_terminal" /> or <ItemLink id="portable_inventory_terminal" /> won't list them.

## Channel

The IO Card has a channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how channels
scope which scripts and presets can address this card.

## Scripting

See the [CardHandle reference](../lua-api/card-handle.md#inventory-cards) for the full set of
methods available on an IO Card's handle.

## Recipe

<RecipeFor id="io_card" />