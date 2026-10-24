---
navigation:
  parent: items-blocks/index.md
  icon: receiver_antenna
  title: Receiver Antenna
categories:
  - infrastructure
description: connects to broadcasted processing storages and export chests
item_ids:
- nodeworks:receiver_antenna
---

# Receiver Antenna

Used to connect one network to another [subnet](../nodeworks-mechanics/subnets.md).
This ends up being useful for splitting up [Processing Set](./recipe_sets.md#processing-set) recipes across different
networks for [autocrafting](../nodeworks-mechanics/autocrafting.md)

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60">
  <IsometricCamera yaw="180" roll="0" pitch="0" />
  <ImportStructure src="../assets/assemblies/receiving_antenna_uses.snbt" />
  <BoxAnnotation min="2 0 0" max="3 1 1">
    Receiving processing set recipes from another network
  </BoxAnnotation>
  <BoxAnnotation min="0 0 0" max="1 2 1">
    Receives items from broadcasting export chests
  </BoxAnnotation>
</GameScene>

## Wireless item intake

Place the Receiver Antenna on top of an <ItemLink id="import_chest" /> and
pair it with a <ItemLink id="broadcast_antenna" /> sitting on an
<ItemLink id="export_chest" /> in another network. Items pushed into the
broadcasting Export Chest land in this Import Chest, giving you a wireless
conveyor between two networks.

## Recipe

<RecipeFor id="receiver_antenna" />