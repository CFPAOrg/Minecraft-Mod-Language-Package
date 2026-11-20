---
navigation:
  parent: lua-api/index.md
  title: Channel
  icon: io_card
categories:
  - api_types
description: a dye-color-scoped view of the network
---

# Channel

A `Channel` is a dye-color-scoped view of the network. You get one from
[`network:channel(color)`](network.md#channel). Lookups through a Channel only
see cards, variables, and devices whose channel matches that color, the channel
is picked in each card or device's own GUI. Multiple subsystems can share one
network without their card aliases stepping on each other.

<LuaCode>
```lua
local red = network:channel("red")
local blue = network:channel("blue")
red:getAll("redstone"):set(true)   -- only the red-channel pistons fire
blue:getAll("redstone"):set(true)  -- only the blue-channel pistons fire
```
</LuaCode>

The color name must be one of the 16 vanilla dye colors (`white`, `red`,
`blue`, `light_blue`, `light_gray`, …). An unknown color raises an error.

## Choosing a Channel

In all [Cards](../nodeworks-mechanics/cards.md) and [Devices](../nodeworks-mechanics/devices.md), there will be a way to pick a Channel. By default all
devices and Cards start on `white`. You can click to expand a list of colors to
pick one

![](../assets/images/choose_channel.png)

## get

Alias lookup scoped to this channel. Returns a [CardHandle](card-handle.md),
[VariableHandle](variable-handle.md), Breaker, or Placer, the same name
namespace as [`network:get`](network.md#get). Errors when no member on the
channel matches the alias.

<LuaCode>
```lua
local red = network:channel("red")
local counter = red:get("counter")  -- variable named "counter" on the red channel
local door = red:get("door")     -- card named "door" on the red channel
```
</LuaCode>

## getAll

Returns a [HandleList](handle-list.md) of every member on this channel
matching the given type. Same type strings as
[`network:getAll`](network.md#getAll), `"io"`, `"storage"`, `"redstone"`,
`"observer"`, `"variable"`, `"breaker"`, `"placer"`. Pass nothing to get
every member on the channel regardless of type.

<LuaCode>
```lua
local red = network:channel("red")
red:getAll("observer"):onChange(function(block, state)
  print("red-channel observer fired:", block)
end)
```
</LuaCode>

## getFirst

The first member on this channel of the given type, or `nil` when none match.
Useful when there's only ever one of something per channel and you don't want
to index into a HandleList.

<LuaCode>
```lua
local sensor = network:channel("blue"):getFirst("observer")
if sensor then
  print(sensor.name, "is the blue-channel observer")
end
```
</LuaCode>
