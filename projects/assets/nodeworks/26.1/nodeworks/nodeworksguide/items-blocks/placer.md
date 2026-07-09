---
navigation:
  parent: items-blocks/index.md
  icon: placer
  title: Placer
categories:
  - device
description: a shared network placer
item_ids:
- nodeworks:placer
---

# Placer Block

The Placer places block-form items at the position in front of itself. The
script picks what to place by item id or by passing an
[ItemsHandle](../lua-api/items-handle.md), the matching item is then pulled
from [Network Storage](../nodeworks-mechanics/network-storage.md) and placed.
Synchronous, the script gets `true` / `false` in the same tick it asked.

<BlockImage scale="6" id="placer" />

## Placing

The Placer's front face points at whatever you were aiming at when you placed
it down (same shape as a piston or dispenser). Whatever block the Placer
spawns lands directly in front of that face. Only block-form items work,
tools, food, and miscellaneous items will fail the place call.

## Block filter

The Placer's GUI has a slot for the block it should place. The matching
item is pulled from
[Network Storage](../nodeworks-mechanics/network-storage.md) each time the
Placer fires. Leave it empty to idle until a script asks for something
specific.

## Redstone

The GUI's redstone setting controls when the Placer is allowed to fire:

- **High**: active while powered.
- **Low**: active while unpowered.
- **Ignored**: redstone does nothing. The Placer only fires when a script
  calls into it.

## Channel

The Placer has a name and channel picker in its GUI. See
[Choosing a Channel](../lua-api/channel.md#choosing-a-channel) for how
channels scope which scripts can address this device.

## Scripting

See the [PlacerHandle](../lua-api/placer-handle.md) page to see the scripting api.

## Recipe

<RecipeFor id="placer" />
