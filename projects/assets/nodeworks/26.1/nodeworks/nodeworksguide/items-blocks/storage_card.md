---
navigation:
  parent: items-blocks/index.md
  icon: storage_card
  title: Storage Card
categories:
  - card
description: marks the adjacent block as part of network storage
item_ids:
- nodeworks:storage_card
---

# Storage Card

A Storage Card marks the adjacent block as part of [Network Storage](../nodeworks-mechanics/network-storage.md). The
shared pool the network queries, routes into, and lists in the Inventory
Terminal.

<ItemImage scale="6" id="storage_card" />

## 配置

When you right-click with a **Storage Card** you can set the priority, channel,
and filters.

![](../assets/images/storage-card-gui.png)

> **Tip:** Use a <ItemLink id="card_programmer" /> to copy the card's settings
> (optionally name and channel as well) which lets you bulk set Card settings
> using a template.
> 
> You can also use [`network:route()`](../lua-api/network.md#route) to bulk set card
> settings without even touching them.

## Target face

You can pick which face of the adjacent block the card talks to. By
default the card uses the face the node is pointed at, which is usually
what you want. Override it for blocks with side-specific slots like
furnaces, where the top accepts input, the side accepts fuel, and the
bottom yields output.

## Channel

The Storage Card's GUI also has a channel picker. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how channels
scope which scripts, routing rules, and presets see this card.

## Filters

Each Storage Card can be configured to accept only specific items so a network
with multiple cards routes incoming items to the right place. A fresh card has
no filters and accepts everything.

### Mode

The **Mode** toggle in the Storage Card GUI flips the rule list between

- **Allow**: only items matching at least one rule are accepted
- **Deny**: items matching at least one rule are rejected, everything else passes through

With no rules in the list, Mode has no effect, but the **Stackability** and
**NBT** filters below still apply on top. A card only accepts everything when
all three filters are at their defaults (no rules, Any Stackability, Any NBT).

### Rules

Each rule is a single line of filter syntax, evaluated against the item trying to
enter the card:

| Syntax                  | Matches                                        |
| ----------------------- | ---------------------------------------------- |
| `minecraft:cobblestone` | exact item id                                  |
| `#minecraft:logs`       | every item in this tag                         |
| `minecraft:*`           | every item from this mod / namespace           |
| `/^.*_ore$/`            | items whose id matches this regular expression |
| `*`                     | every item/fluid                               |

You can add rules three different ways:

1. Click **[+ Add Rule]** at the bottom of the list and type into the new row.
Autocomplete suggests item ids and tags as you type
2. Drag any item from JEI onto the rule list. The item's id becomes a new rule
3. From a Scripting Terminal, use [`network:route()`](../lua-api/network.md#route)
to set rules across many cards at once

### Stackability and NBT

Two extra toggles narrow what the card accepts beyond the rule list:

- **Stackability**: cycles through **Any** / **Stackable Only** / **Non-stackable only**.
Useful for separating tools and armor from bulk resources without listing every item id
- **NBT**: cycles through **Any** / **Has data** / **No data**.
Items with NBT (damaged tools, named items, enchanted books) can be split from their
pristine versions.

All three settings combine. An item only enters the card if it passes
Stackability, passes NBT, and matches the rule list. A card with
`Mode: Allow`, `Stackability: Stackable only`, `NBT: No data`, and rule
`#minecraft:swords` accepts nothing in practice. Swords aren't stackable,
so the Stackability check rejects everything before the rule list is even
consulted. Pick settings that make sense together.

### Examples

**Bulk cobblestone storage**

> **Mode:** Allow
> 
> **Stackability:** Any
> 
> **NBT:** Any
> 
> **Rules:** #c:cobblestone

Accepts any cobblestone in the `#c:cobblestones` tag

**Non-stackable only**

> **Mode:** Allow
> 
> **Stackability:** Non-stackable only
> 
> **NBT:** Any
> 
> **Rules:** *Empty*

A storage card that just accepts any non-stackable items doesn't require any rules

## Installation and scripting

Installed the same way an <ItemLink id="io_card" /> is. Slot into a face of
a node that's touching the block. The scripting API is identical to an IO
Card (see [CardHandle](../lua-api/card-handle.md#inventory-cards) for the full set of methods)

## The difference from IO

<ItemLink id="io_card" />'s blocks are script-controlled inventories.
Scripts must explicitly move items to/from them. A Storage Card puts its
block *into* the network's shared pool: `network:find` sees it, the
<ItemLink id="inventory_terminal" /> and <ItemLink id="portable_inventory_terminal" /> list it, and crafting recipes pull ingredients from it
automatically.

## Recipe

<RecipeFor id="storage_card" />