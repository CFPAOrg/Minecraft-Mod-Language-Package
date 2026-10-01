---
navigation:
  parent: lua-api/index.md
  title: PlacerHandle
  icon: placer
categories:
  - api_types
description: a device to place blocks in front of it
---

# PlacerHandle

A `PlacerHandle` is a reference to a <ItemLink id="placer" /> on the network,
returned by [`network:get(name)`](network.md#get). It pulls one of a chosen
item from [Network Storage](../nodeworks-mechanics/network-storage.md) and
places it as a block at the placer's facing position.

<BlockImage scale="6" id="placer" />

`:place(...)` is synchronous, it returns `true` / `false` in the same tick the
script called it. No multi-tick progress, no builder, no callback. Only items
that are `BlockItem`s (have a placeable block form) succeed, the call fails
fast on tools, food, or anything non-placeable.

## Properties

- **`.name`**
  - the placer's alias (same label shown in the terminal sidebar)

## place

Pulls one of the chosen item from network storage and places it at the
placer's facing position. Returns `true` on success.

The argument can be either an item id string or an [ItemsHandle](./items-handle.md).
With a handle, the placer reads `.id` and pulls one of *that* item from the
network pool the same way it would for the bare-string form. The handle's own
source isn't drained, the network's storage cards are.

<LuaCode>
```lua
local placer = network:get("placer_1")
placer:place("minecraft:cobblestone")
```
</LuaCode>

Returns `false` (and places nothing) when:
- the network has no matching item available
- the target position is non-air
- the item isn't a placeable block (e.g. `minecraft:diamond`, `minecraft:stick`)

<LuaCode>
```lua
local placer = network:get("bridge_builder")
local ok = placer:place("minecraft:oak_planks")
if not ok then
  print("nothing placed, no planks in storage or target blocked")
end
```
</LuaCode>

## block

Returns the block id at the placer's facing position, the same shape as
[`ObserverCard:block`](./card-handle.md#observer-card). Useful for "is the
slot still empty / is it the block I expect" checks before calling `:place`.

<LuaCode>
```lua
local placer = network:get("placer_1")
if placer:block() == "minecraft:air" then
  placer:place("minecraft:torch")
end
```
</LuaCode>

## isBlocked

Returns `true` if the target position can't be replaced (non-air and not a
replaceable block like grass or snow), `false` if a place would land. Cheaper
than calling `:place` and checking the return value when you only want to
know whether the slot is free.

<LuaCode>
```lua
local placer = network:get("placer_1")
if not placer:isBlocked() then
  placer:place("minecraft:cobblestone")
end
```
</LuaCode>
