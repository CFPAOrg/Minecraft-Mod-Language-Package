---
navigation:
  parent: items-blocks/index.md
  icon: user
  title: User
categories:
  - device
description: right-clicks with an item on the block in front of it
item_ids:
- nodeworks:user
---

# User Block

The User pulls an item from
[Network Storage](../nodeworks-mechanics/network-storage.md) and
right-clicks with it on whatever's in front of the block. Use it for
bone-mealing crops, brushing suspicious blocks, lighting tnt with flint
and steel, filling buckets, or anything else a player would normally do
by hand.

<BlockImage scale="6" id="user" />

## Placing

The User's front face points at whatever you were aiming at when you
placed it down (same shape as a piston or dispenser). It targets the
first non-air block up to two positions in front of itself, so a User
above an empty space above a crop still reaches the crop.

## Item filter

The User's GUI has a slot for the item it should use. The matching item
is pulled from Network Storage when the User fires and returned once the
action finishes. Filter syntax is the same as the
<ItemLink id="storage_card" />, so bare ids, tags, and wildcards all
work.

## Mode

The User runs in one of two modes:

- **Instant**: a single right-click per fire. Good for one-shot actions
  like applying bone meal or flint and steel.
- **Hold**: keeps the right-click held down across ticks until released.
  Good for tools that need to be held to do their thing, like a brush. A hold auto-releases after 30 seconds.

## Redstone

The GUI's redstone setting controls when the User is allowed to fire:

- **High**: active while powered.
- **Low**: active while unpowered.
- **Ignored**: redstone does nothing. The User only fires when a script
  calls into it.

## Channel

The User has a name and channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how
channels scope which scripts can address this device.

## Scripting

See the [UserHandle](../lua-api/user-handle.md) page for the scripting api.

## Recipe

<RecipeFor id="user" />
