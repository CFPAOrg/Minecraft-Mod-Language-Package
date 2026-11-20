---
navigation:
  parent: lua-api/index.md
  title: Breaker Handle
  icon: breaker
categories:
  - api_types
description: a device used to break blocks in front of it
---

# BreakerHandle

A `BreakerHandle` is a reference to a <ItemLink id="breaker" /> on the network,
returned by [`network:get(name)`](network.md#get). It starts a multi-tick break
of the block in front of the breaker and routes the drops back to the network
(or to a custom handler).

<BlockImage scale="6" id="breaker" />

The breaker mines at diamond-pickaxe tier and uses the wooden-pickaxe duration
formula, so harder blocks take noticeably longer to break than easier ones.
Only one break can be in progress at a time per breaker, calling `:mine()`
again while a break is running is a no-op.

## Properties

- **`.name`**
  - the breaker's alias (same label shown in the terminal sidebar)

## mine

Starts a multi-tick break of the block at the breaker's facing position.
Returns a [BreakBuilder](./breaker-handle.md#breakbuilder) so the script can
chain `:connect(fn)` to redirect the drops. If no chain follows, the drops
flow into [Network Storage](../nodeworks-mechanics/network-storage.md) using
the standard [Storage Card](../items-blocks/storage_card.md) priority rules.

<LuaCode>
```lua
local breaker = network:get("quarry_1")
breaker:mine() -- drops go to network storage
```
</LuaCode>

If the target is air, unbreakable, or above the breaker's tier, `:mine()`
returns a no-op builder so chained calls don't crash.

## cancel

Aborts the in-flight break, if any. Safe to call when idle. The block isn't
broken and no drops are produced.

<LuaCode>
```lua
local breaker = network:get("breaker_1")
breaker:mine()
if dangerous() then
  breaker:cancel() -- stop before completion
end
```
</LuaCode>

## block

Returns the block id at the breaker's facing position, the same shape as
[`ObserverCard:block`](./card-handle.md#observer-card). Useful for gating a
break on the block's identity.

<LuaCode>
```lua
local breaker = network:get("breaker_1")
if breaker:block() == "minecraft:stone" then
  breaker:mine()
end
```
</LuaCode>

## state

Returns a property table for the block at the breaker's facing position. Same
shape as [`ObserverCard:state`](./card-handle.md#observer-card), every
`BlockState` property the block has (growth `age`, `facing`, `lit`,
`waterlogged`, ...) becomes a field.

<LuaCode>
```lua
local breaker = network:get("crop_breaker")
local state = breaker:state()
if state.age == 7 then
  breaker:mine() -- only break fully-grown crops
end
```
</LuaCode>

## isMining

Returns `true` while a break is in progress, `false` when idle. Use it to
avoid issuing a second `:mine()` mid-break (the second call is a no-op anyway,
but `:isMining()` lets the script branch cleanly).

<LuaCode>
```lua
local breaker = network:get("breaker_1")
if not breaker:isMining() then
  breaker:mine()
end
```
</LuaCode>

## progress

Returns a fraction from `0` to `1` representing how far along the current
break is. `0` when idle. Useful for driving a progress display or pacing
follow-up actions.

<LuaCode>
```lua
local breaker = network:get("breaker_1")
print(string.format("%.0f%%", breaker:progress() * 100))
```
</LuaCode>

---

## BreakBuilder

Returned by [`Breaker:mine()`](./breaker-handle.md#mine). Configures how the
drops route once the break completes. With no chain, drops flow to network
storage automatically. Chain `:connect(fn)` to redirect them to a script
handler instead.

### connect

Redirects the drops from this break to a callback. The handler receives one
[ItemsHandle](./items-handle.md)-shaped value per dropped stack, so a single
break of a multi-drop block (e.g. a fortune-affected ore) calls the handler
multiple times.

The handler can read the drop's `.id`, `.name`, `.count`, and `.kind` to
decide what to do. Items the handler doesn't claim spill back into network
storage as the default routing.

<LuaCode>
```lua
local breaker = network:get("breaker_1")
local chest = network:get("ore_chest")
breaker:mine():connect(function(item: ItemsHandle)
  if item.id == "minecraft:diamond" then
    chest:insert(item) -- diamonds go to a dedicated chest
  end
  -- everything else falls through to network storage
end)
```
</LuaCode>

> **Note:** The breaker's `:connect` handler runs on break completion, not on
> every tick. Errors inside the handler are swallowed so a bad callback can't
> jam the breaker.
