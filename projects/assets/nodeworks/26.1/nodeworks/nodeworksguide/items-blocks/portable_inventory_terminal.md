---
navigation:
  parent: items-blocks/index.md
  icon: portable_inventory_terminal
  title: Portable Inventory Terminal
categories:
  - tool
description: a portable viewport into any linked network's storage
item_ids:
- nodeworks:portable_inventory_terminal
---

# Portable Inventory Terminal

A portable

A hanheld version of the <ItemLink id="inventory_terminal" />. Connects wirelessly
via a <ItemLink id="link_crystal" /> paired to a <ItemLink id="broadcast_antenna" />
on top of a <ItemLink id="network_controller" />.

<ItemImage scale="6" id="portable_inventory_terminal" />

## Linking it to a network

The Portable Inventory Terminal reaches a network through three components you
need in place first:

<GameScene zoom="3" interactive={true} paddingTop="20">
  <ImportStructure src="../assets/assemblies/broadcast_antenna_network_controller.snbt" />
</GameScene>

- A <ItemLink id="network_controller" /> on the target network
- A <ItemLink id="broadcast_antenna" /> placed on top of that Controller
- A <ItemLink id="link_crystal" /> paired to that antenna *(not to a Processing Storage)*

<br clear="all" /><br clear="all" /><br clear="all" /><br clear="all" />
<FloatingImage src="../assets/images/portable_inventory_terminal_link_slot.png" align="left" />

Then with the paired Link Crystal, you place it in the top-right slot of the Portable Inventory Terminal

The Portable's item texture lights up with the network's color when the link
is live.

<br clear="all" />

## Range

See the <ItemLink id="broadcast_antenna" /> page for more info on broadcasting range

## Using the terminal

Everything inside the GUI works identically to the <ItemLink id="inventory_terminal" />.

## Recipe

<RecipeFor id="portable_inventory_terminal" />