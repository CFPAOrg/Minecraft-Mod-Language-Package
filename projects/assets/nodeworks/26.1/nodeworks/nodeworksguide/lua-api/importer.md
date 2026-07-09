---
navigation:
  parent: lua-api/index.md
  title: Importer
  icon: minecraft:hopper
categories:
  - api_types
  - api_preset
description: move items from A to B with a distribution strategy
---

# Importer

The `importer` global builds movers that pull items from one or more sources
and deposit them into one or more targets. Every importer is a scheduled task
under the hood, so it keeps running at its configured interval until the
script stops or you call `:stop()` on the handle.

## from

<LuaCode>
```lua
Importer:from(...sources: string | CardHandle | network): ImporterBuilder
```
</LuaCode>

Starts an importer chain. Sources can be any mix of card aliases, CardHandle
objects, or the `network` global (meaning the whole Network Storage pool).
At least one source is required.

<LuaCode>
```lua
importer:from("farmChest")                        -- one named source
importer:from(network)                            -- network pool as source
importer:from("chestA", network, network:get("chestB"))  -- mixed
```
</LuaCode>

## to

<LuaCode>
```lua
ImporterBuilder:to(...targets: string | CardHandle | network): ImporterBuilder
```
</LuaCode>

Sets the destinations. Same polymorphism as `:from`: card aliases, CardHandle
objects, or `network` for the pool. At least one target is required.

<LuaCode>
```lua
importer:from("farm"):to("storage1", "storage2"):start()
importer:from("mobFarm"):to(network):start()  -- deposit into the pool
```
</LuaCode>

## filter

<LuaCode>
```lua
ImporterBuilder:filter(pattern: string): ImporterBuilder
```
</LuaCode>

Narrows the mover to items (or fluids) matching the filter. **Optional.** The
default is `*`, which moves every item. Use filter syntax from
[Network:find](network.md#find) including `$item:id`, `$fluid:id`, `#tag`,
`modname:*`, and regex.

<LuaCode>
```lua
-- Move only cobblestone
importer:from(network)
  :filter("$item:minecraft:cobblestone")
  :to("io_*")
  :start()

-- Move all c:ores items
importer:from("mobFarm"):filter("#c:ores"):to("storage"):start()
```
</LuaCode>

## Distribution

The importer has two ways of splitting items across targets. The default is
fill, you opt into round robin explicitly.

### Fill (default)

Fills the first target first. Once it's full, overflow goes to the next target,
and so on. Good when you have a priority order and want one chest to stay topped
up before any excess lands elsewhere.

<LuaCode>
```lua
importer:from("furnaceOutput")
  :filter("$item:iron_ingot")
  :to("mainChest", "overflow")
  :start()
```
</LuaCode>

### roundrobin

<LuaCode>
```lua
ImporterBuilder:roundrobin(step: number?): ImporterBuilder
```
</LuaCode>

Distributes evenly across every target on every tick. `step` is the max items
delivered to each target per tick (default 1). With step=1, three items in
the source land as one in each of three targets in a single tick. For bulk
flow, raise the step or speed up the tick rate with `:every(1)`.

<LuaCode>
```lua
importer:from("bufferChest")
  :to("furnace1", "furnace2", "furnace3")
  :roundrobin()
  :every(10)
  :start()
```
</LuaCode>

The round robin cursor rotates one position per tick so fairness holds even
when the source is running thin and only some targets get items that tick.

## Wildcards in card aliases

Both `:from` and `:to` accept `*` wildcards in card names. A single
`"io_*"` expands to every card whose alias matches the pattern at the
moment the importer resolves its snapshot, and re-expands any time the
network topology changes.

<LuaCode>
```lua
-- Fan out from one chest to every card named io_...
importer:from("input"):to("io_*"):roundrobin():start()

-- Pull from a whole group of source chests into a single output
importer:from("farm_*"):to("storage"):start()
```
</LuaCode>

## Example: two-stage smelter array

Ores feed in round robin to three furnaces, outputs collect into a central
chest.

<LuaCode>
```lua
-- Feed ore evenly to three furnaces
importer:from("oreBuffer")
  :filter("$item:iron_ore")
  :to("furnace1", "furnace2", "furnace3")
  :roundrobin()
  :every(10)
  :start()

-- Collect ingots from all three into the output chest
importer:from("furnace1", "furnace2", "furnace3")
  :filter("$item:iron_ingot")
  :to("outputChest")
  :start()
```
</LuaCode>

## See also

* [Shared preset methods](presets.md#shared-methods) (`:every`, `:start`,
  `:stop`, `:isRunning`).
* [Stocker](stocker.md) for the "maintain a level" pattern.
* [Network:find](network.md#find) for filter syntax details.
