---
navigation:
  parent: lua-api/index.md
  title: CraftBuilder
  icon: minecraft:crafting_table
categories:
  - api_types
description: returned by [`network:craft`](network.md#craft) and configures how the craft result is delivered once it completes
---

# CraftBuilder

A `CraftBuilder` is what [`network:craft`](network.md#craft) hands back. It
represents a craft the network has planned but not yet delivered. By default
the result lands in [Network Storage](../nodeworks-mechanics/network-storage.md)
when the craft finishes. If you want a callback instead, chain `:connect(fn)`.

The craft might finish on the same tick (vanilla recipes pulled together out
of storage) or take many ticks (anything routed through a
[`network:handle`](network.md#handle) processing handler, or a multi-stage
crafting tree). Either way, the builder's API is the same.

> **Note:** `network:craft` always returns a builder, even when the craft
> can't be planned (no recipe, missing ingredients, no Crafting CPU). The
> failure surfaces through `:connect`'s callback as `nil`.

## Default: stores the result

If you don't chain anything, the finished items are pushed into Network
Storage automatically using the normal [Storage Card](../items-blocks/storage_card.md)
priority and [`network:route`](network.md#route) rules. After that you can
query them through `network:find` like anything else in the pool.

<LuaCode>
```lua
-- fire-and-forget: craft 16 torches, they land in storage
network:craft("minecraft:torch", 16)
```
</LuaCode>

## connect

Hands the finished items off to a callback **instead** of auto-storing.
Calling `:connect` flips the builder out of the default behavior, the
runtime won't auto-store, the callback owns the result.

The callback's argument is `ItemsHandle?`, an [ItemsHandle](items-handle.md)
on success or `nil` on failure. Always check before using.

<LuaCode>
```lua
local oven = network:get("oven")
network:craft("minecraft:bread", 4):connect(function(items: ItemsHandle?)
  if not items then
    print("bread craft failed")
    return
  end
  oven:insert(items) -- finished bread goes straight into the oven
end)
```
</LuaCode>

The callback fires once when the craft resolves. Failure modes that surface
as `nil`:

- Plan failure: no recipe, missing ingredients, no Crafting CPU on the network.
- Async timeout: a processing handler never delivered the outputs.
- CPU offline: the Crafting CPU was broken or removed mid-craft.

In every failure case the runtime also releases any partial CPU buffer back
into Network Storage so items aren't stranded.

### You're responsible for moving the items

The handle the callback receives is a **live reference to the items still
sitting in the Crafting CPU's buffer**. Calling `card:insert(items)` /
`network:insert(items)` drains them out of the buffer into the destination.

Anything still in the buffer when the callback returns is **dropped at the
CPU's position** and a terminal error is logged. The contract is "you took
the handle, you're responsible for moving the items," failing to drain it
isn't silent.

<LuaCode>
```lua
local chest = network:get("ore_chest")
network:craft("minecraft:iron_ingot", 8):connect(function(items: ItemsHandle?)
  if not items then return end
  if not chest:insert(items) then
    -- chest full: fall back to network storage instead of dropping
    network:insert(items)
  end
end)
```
</LuaCode>

This is intentionally different from auto-store, which always routes through
the network's storage cards (and only drops in-world if every storage card
refuses). With `:connect`, the callback decides where the items go, and the
runtime trusts you to actually move them.

> **Note:** Errors thrown inside the callback are logged to the terminal but
> don't take down the rest of your script.

## When connect runs synchronously

Vanilla recipes whose ingredients are already in storage finish on the same
tick. The callback still fires through the same path, just one tick later
than the `:craft` call so that `:connect` has a chance to register before
resolution. You don't need to special-case this, the API behaves identically
for sync and async crafts.

<LuaCode>
```lua
-- works the same whether the craft is instant or takes 30s of smelting
network:craft("minecraft:iron_ingot", 8):connect(function(items: ItemsHandle?)
  if items then chest:insert(items) end
end)
```
</LuaCode>
