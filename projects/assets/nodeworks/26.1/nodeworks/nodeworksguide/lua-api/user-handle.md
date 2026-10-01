---
navigation:
  parent: lua-api/index.md
  title: UserHandle
  icon: user
categories:
  - api_types
description: a device that right-clicks with an item in front of it
---

# UserHandle

A `UserHandle` is a reference to a <ItemLink id="user" /> on the network,
returned by [`network:get(name)`](network.md#get). It pulls one item from
[Network Storage](../nodeworks-mechanics/network-storage.md) and
right-clicks with it on whatever's in front of the block.

<BlockImage scale="6" id="user" />

The User has two modes. **Instant** fires a single right-click per
`:use()` call. **Hold** keeps the right-click held down across multiple
ticks until `:stop()` runs (or the held item finishes its action, or the
30-second timeout elapses). Filters use the same syntax as
<ItemLink id="storage_card" /> rules.

## Properties

- **`.name`**
  - the user's alias (same label shown in the terminal sidebar)
- **`.kind`**
  - always `"user"`

## use

Fires the User. In **instant** mode it right-clicks once and returns
whether the action landed. In **hold** mode it starts a hold and returns
whether the hold entered the held state.

Returns `false` (without firing) when the User is already using, on
cooldown, blocked by its filter, has nothing matching in storage, or
has no controller on the network.

<LuaCode>
```lua
local farmer = network:get("crop_farmer")
farmer:use()
```
</LuaCode>

To restart a hold cleanly, call `:stop()` first.

## stop

Cancels a pending instant fire or releases an in-progress hold. Safe to
call when idle, returns `false` without erroring. The retract animation
that returns the reserved item to network storage is non-cancellable.

<LuaCode>
```lua
local user = network:get("user_1")
local watcher = network:get("observ_1")
user:setMode("hold")
user:use() -- start using a brush on a sus block
-- when the block changes to normal sand or gravel, stop the user
watcher:onChange(function(block: BlockId, state: any)
    if block == "minecraft:gravel" or block == "minecraft:sand" then
        user:stop()
    end
end)
```
</LuaCode>

## isUsing

Returns `true` while a hold is active, `false` otherwise.

<LuaCode>
```lua
local user = network:get("user_1")
if not user:isUsing() then
  user:use()
end
```
</LuaCode>

## mode

Returns the current mode as a string, either `"instant"` or `"hold"`.

<LuaCode>
```lua
local user = network:get("user_1")
print(user:mode()) -- "instant"
```
</LuaCode>

## setMode

Sets the User's mode. Accepts `"instant"` or `"hold"` (case-insensitive).

<LuaCode>
```lua
local user = network:get("crop_farmer")
user:setMode("hold")
```
</LuaCode>

## filter

Returns the current filter rule as a string, empty when nothing is set.

<LuaCode>
```lua
local user = network:get("user_1")
print(user:filter()) -- "minecraft:bone_meal"
```
</LuaCode>

## setFilter

Sets the User's filter rule. Uses the same syntax as
<ItemLink id="storage_card" /> filters, so bare item ids,
`#namespace:tag`, `minecraft:*`, `/regex/`, and the `$item:` / `$fluid:`
prefixes all work.

<LuaCode>
```lua
local user = network:get("crop_farmer")
user:setFilter("minecraft:bone_meal")
```
</LuaCode>

## facing

Returns the direction the User is facing as a lowercase string
(`"north"`, `"south"`, `"east"`, `"west"`, `"up"`, `"down"`).

<LuaCode>
```lua
local user = network:get("user_1")
print(user:facing()) -- "north"
```
</LuaCode>
