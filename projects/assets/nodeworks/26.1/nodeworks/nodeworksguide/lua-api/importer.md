---
navigation:
  parent: lua-api/index.md
  title: Importer
  icon: minecraft:hopper
categories:
  - api_types
  - api_preset
description: move items and fluids from A to B with a distribution strategy
---

# Importer

The `importer` global builds movers that pull items and fluids from one or
more sources and deposit them into one or more targets. Every importer is a
scheduled task under the hood, so it keeps running at its configured interval
until the script stops or you call `:stop()` on the handle.

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

A Storage Card target keeps its own rules. Only items its rule list,
stackability and data filters allow are moved into it, the same as
`network:insert`, so an armour-only card stays armour-only whatever the
importer's `:filter` says.

<LuaCode>
```lua
importer:from("farm"):to("storage1", "storage2"):start()
importer:from("mobFarm"):to(network):start()  -- deposit into the pool
```
</LuaCode>

## filter

What to move. Anything matching one of the rules moves. Leave it out to move everything. Filter syntax is the same as [Network:find](network.md#find).

You can use `:filter()` multiple times to apply multiple filters or call it with no parameter to reset the filter.

<LuaCode>
```lua
importer
  :from(network)
  :filter("$item:minecraft:cobblestone")
  :filter("$item:minecraft:stone")
  :to("io_*")
  :start()

local puller = importer
  :from("quarry")
  :filter("#c:ores")
  :to(network)

puller:filter() -- resets the filters
puller:start() -- starts the importer
```
</LuaCode>

## except

Allows you to specify any items you explicitly do **not** want to move.

<LuaCode>
```lua
-- All ores, except one the furnaces can't smelt
importer
  :from(network)
  :to("furnace_*")
  :filter("#c:ores")
  :except("mod:uranium")
  :roundrobin()
  :start()

-- Empty a machine, but leave its slag in it
importer:from("crusher"):to(network):except("mod:slag"):start()
```
</LuaCode>

## Fluids

Importers move fluids too. Any rule can name a fluid, and `$fluid:` picks the
fluid when an item shares the name. Amounts are in millibuckets, a bucket is `1000`. A target with no tank is simply skipped for fluids.

<LuaCode>
```lua
importer
  :from(network)
  :to("boiler")
  :filter("$fluid:minecraft:water")
  :start()
```
</LuaCode>

## Distribution

The importer has two ways of splitting what it moves across targets. The
default is fill, you opt into round robin explicitly.

### Fill (default)

Fills the first target first. Once it's full, overflow goes to the next target,
and so on. Good when you have a priority order and want one chest to stay topped
up before any excess lands elsewhere.

<LuaCode>
```lua
importer
  :from("furnaceOutput")
  :filter("$item:iron_ingot")
  :to("mainChest", "overflow")
  :start()
```
</LuaCode>

### roundrobin

Shares out evenly across every target. Provide a number to specify how much each target gets per turn, default 1.
For items that is items, for fluids it is millibuckets,
so give a fluid importer a step like 1000 for a bucket per turn.

<LuaCode>
```lua
importer
  :from("bufferChest")
  :to("furnace1", "furnace2", "furnace3")
  :roundrobin()
  :start()

importer
  :from(network)
  :to("boiler_*")
  :filter("$fluid:minecraft:water")
  :roundrobin(1000)
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

Ores and raw materials feed in round robin to every furnace, finished ingots
collect back into the network.

<LuaCode>
```lua
local furnaces = network:cards("furnace_*")

-- Feed the furnaces evenly
importer:from(network)
  :to(furnaces:face("top"))
  :filter("#c:ores", "#c:raw_materials")
  :except("mod:uranium")
  :roundrobin()
  :every(10)
  :start()

-- Collect whatever comes out
importer:from(furnaces:face("bottom"))
  :to(network)
  :start()
```
</LuaCode>

## See also

* [Shared preset methods](presets.md#shared-methods) (`:every`, `:start`,
  `:stop`, `:isRunning`).
* [Stocker](stocker.md) for the "maintain a level" pattern.
* [Network:find](network.md#find) for filter syntax details.
