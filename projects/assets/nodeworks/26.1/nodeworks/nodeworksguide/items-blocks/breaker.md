---
navigation:
  parent: items-blocks/index.md
  icon: breaker
  title: Breaker
categories:
  - device
description: mines and harvests blocks in front of it
item_ids:
- nodeworks:breaker
---

# Breaker Block

The Breaker destroys the block at the position in front of itself over time
and routes the drops back to
[Network Storage](../nodeworks-mechanics/network-storage.md) (or to a
script-supplied handler). Diamond-pickaxe tier, with break duration that uses
the wooden-pickaxe formula so harder blocks take noticeably longer to break.

<BlockImage scale="6" id="breaker" />

## Placing

The Breaker's front face points at whatever you were aiming at when you
placed it down (same shape as a piston or dispenser). The block in front of
that face is what `:mine()` will break.

## Target filter

The Breaker's GUI has a filter for which block it should break. Leave it
empty to break anything in front, or set a block to restrict the Breaker
to that target.

## Tree Felling

If you place a Breaker at the base of a tree it will fell the whole thing.

<GameScene zoom="4" paddingTop="30" paddingLeft="60" paddingRight="60" interactive={true} >
  <ImportStructure src="../assets/assemblies/breaker_tree_felling.snbt" />
  <BlockAnnotation x="2" y="1" z="2">
  Cutting the last log holding the tree up fells the whole thing
  </BlockAnnotation>
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

## Redstone

The GUI's redstone setting controls when the Breaker is allowed to fire:

- **High**: active while powered.
- **Low**: active while unpowered.
- **Ignored**: redstone does nothing. The Breaker only fires when a script
  calls `:mine()`.

## Channel

The Breaker has a name and channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how
channels scope which scripts can address this device.

## Scripting

See the [BreakerHandle](../lua-api/breaker-handle.md) page to see the scripting api.

## Recipe

<RecipeFor id="breaker" />
