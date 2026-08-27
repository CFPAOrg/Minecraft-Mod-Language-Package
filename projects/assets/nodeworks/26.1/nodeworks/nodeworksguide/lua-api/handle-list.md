---
navigation:
  parent: lua-api/index.md
  title: HandleList
  icon: minecraft:red_bundle
categories:
  - api_types
description: a fan-out list of cards or variables returned by getAll
---

# HandleList

A `HandleList<T>` is a list of cards or variables that **broadcasts write
methods across every member**. You get one from
[`network:getAll(type)`](network.md#getAll) or
[`Channel:getAll(type)`](network.md#channel-getall).

Calling a write method on the list invokes that method on each member with
the same arguments, in order. Read methods aren't exposed on the list, their
return values are the whole point of calling them, and silently dropping
them across N members would be a footgun. To read per-member, call `:list()`
and iterate.

<LuaCode>
```lua
-- Toggle every red-channel piston on at once.
network:channel("red"):getAll("redstone"):set(true)
-- Register the same onChange handler on every observer in one line.
network:getAll("observer"):onChange(function(block, state)
    if block == "nodeworks:celestine_cluster" then
        -- ...
    end
end)
```
</LuaCode>

## Which methods broadcast

Only **write methods** fan out across the list, ones whose call site doesn't
depend on the return value. Reads like `:powered()`, `:count()`, `:get()`,
`:block()` are intentionally absent so a return value isn't silently dropped
across N members. To read per-member, call `:list()` and inspect each member
individually.

Each type's own page (e.g. [RedstoneCard](card-handle.md#redstone-card),
[VariableHandle](variable-handle.md)) is the source of truth for which of its
methods are reads versus writes.

## list

The escape hatch. Returns the underlying array so you can iterate per-member,
read individual values, or apply per-member logic that doesn't fit the
broadcast shape.

<LuaCode>
```lua
local pistons = network:channel("red"):getAll("redstone")
for _, p in pistons:list() do
    if p:powered() then
        print(p.name, "is currently powered")
    end
end
```
</LuaCode>

## count

How many members the list has. Cheaper than `#list:list()` because it doesn't
build the array.

<LuaCode>
```lua
local watchers = network:getAll("observer")
print(watchers:count(), "observer cards on the network")
```
</LuaCode>

## face

Returns a new HandleList whose card members have their access face overridden
to `name`. The original list isn't modified, the override applies only to the
returned copy. Members that aren't [CardHandle](card-handle.md)'s (variables,
breakers, placers) pass through unchanged, those handle types ignore face.

The override survives when the list is fed into a preset
([Importer](importer.md) / [Stocker](stocker.md)), so a wildcard fan-out can
read or write a non-default face on every matched card with one expression.

<LuaCode>
```lua
-- pull furnace outputs (bottom face) from every io_* card into the output chest
importer:from(network:cards("io_*"):face("bottom")):to("output"):start()
```
</LuaCode>

Same shape as [`CardHandle:face`](card-handle.md#face), but applied across the
whole list at once.
