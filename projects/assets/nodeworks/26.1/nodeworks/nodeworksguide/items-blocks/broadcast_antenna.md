---
navigation:
  parent: items-blocks/index.md
  icon: broadcast_antenna
  title: Broadcast Antenna
categories:
  - infrastructure
description: broadcasts access to Network Controllers, Processing Storage, and Export Chests
item_ids:
- nodeworks:broadcast_antenna
---

# Broadcast Antenna

A block with two purposes, depending on what it's placed on top of:

- On a <ItemLink id="network_controller" />: broadcasts wireless access to the
network. A <ItemLink id="portable_inventory_terminal" /> paired to this antenna
can read/write to the network anywhere in range
- On a <ItemLink id="processing_storage" />: broadcasts the block's (and any other
touching <ItemLink id="processing_storage" />) collection of <ItemLink id="processing_set" />s
which another network can use for [autocrafting](../nodeworks-mechanics/autocrafting.md)
- On an <ItemLink id="export_chest" />: broadcasts the chest as a wireless drop-off.
A paired <ItemLink id="receiver_antenna" /> on another network forwards anything
pushed into the chest straight into that network

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/broadcast_antenna_uses.snbt" />
  <BoxAnnotation min="2 0 0" max="4 1 1">
    Both Processing Storage blocks are being broadcasted
  </BoxAnnotation>
  <BoxAnnotation min="5 0 0" max="6 1 1">
    Being broadcasted for Portable Inventory Terminals
  </BoxAnnotation>
  <BoxAnnotation min="0 0 0" max="1 1 1">
    Pushes items to paired import chests
  </BoxAnnotation>
</GameScene>

## Pairing

1. Open the Broadcast antenna GUI
1. Place a <ItemLink id="link_crystal" /> into the top slot
1. Take the Crystal out, it's now paired

## Range

By default the range of a broadcasting antenna is 128 blocks. You can upgrade
the range with either a <ItemLink id="dimension_range_upgrade" /> or <ItemLink id="multi_dimension_range_upgrade" />

## Recipe

<RecipeFor id="broadcast_antenna" />