---
navigation:
  parent: items-blocks/index.md
  icon: redstone_card
  title: Redstone Card
categories:
  - card
description: reads and writes redstone signals at the installed node face
item_ids:
- nodeworks:redstone_card
---

# Redstone Card

Reads and writes redstone signals at the installed face.

<ItemImage scale="6" id="redstone_card" />

## Installing and Scripting

Installs in a Node face the same way an <ItemLink id="io_card" /> does.
See [IO Card installation](./io_card.md#installing) for the walkthrough.
The card reads and writes the redstone signal on *that face*.

See the [RedstoneCard Scripting API](../lua-api/card-handle.md#redstone-card)
is different from the other cards.

## Channel

The Redstone Card has a channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how channels
scope which scripts can address this card.

## Recipe

<RecipeFor id="redstone_card" />