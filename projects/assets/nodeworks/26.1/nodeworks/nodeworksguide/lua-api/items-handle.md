---
navigation:
  parent: lua-api/index.md
  title: ItemsHandle
  icon: minecraft:bundle
categories:
  - api_types
description: a specific resource (items or fluid) with count, source, and transfer ops.
---

# ItemsHandle

An `ItemsHandle` is a **single resource type with a count attached**. It's
the value most network and card methods hand back when you ask "what's in
storage?" and the value those same methods accept when you say "move this
somewhere."

> **Note:** A handle is a **snapshot** taken when the call returned. The
> `.count` doesn't update as items move in or out of storage afterwards.
> If you need a fresh count, call `:find` again.

---

## What a handle represents (and doesn't)

A handle is an **aggregate of every matching resource at the queried
location**, not a single inventory stack. Two important consequences:

**The same handle covers both items and fluids.** The `.kind` field tells
you which one you're looking at. Counts are stack units for items and
millibuckets (mB) for fluids. Covered in detail under [count](./items-handle.md#count) and
[kind](./items-handle.md#kind).

**The count can exceed `maxStackSize`.** `network:find("minecraft:coal")`
might return a handle with `count = 192` even though a single inventory
slot only holds 64. The handle is "every coal anywhere in the network",
which can be spread across many slots, many storage cards, or many tanks.
The same is true for [card:find](card-handle.md#find), which aggregates
across the card's slots and tanks.

If you need each distinct stack separately (e.g. an enchanted sword
versus an un-enchanted one of the same id), use
[`findEach`](network.md#findEach) instead. It splits by id **and**
NBT data so each unique combination becomes its own handle.

<LuaCode>
```lua
local allCoal = network:find("minecraft:coal")
print(allCoal.count) -- 192, total across the whole network

for _, h in network:findEach("minecraft:diamond_sword") do
  print(h.name, h.hasData) -- enchanted vs plain swords as separate entries
end
```
</LuaCode>

---

## Properties

### id

The resource id of what this handle points at. Same shape for both kinds:
`"minecraft:diamond"` for an item, `"minecraft:water"` for a fluid.

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.id) -- "minecraft:coal"
```
</LuaCode>

### name

The display name as the player sees it in tooltips. Translated, formatted,
and respects custom names (anvil-renamed items show the renamed string).

<LuaCode>
```lua
local sword = network:find("minecraft:diamond_sword")
print(sword.name) -- "Diamond Sword" (or "Excalibur" if renamed)
```
</LuaCode>

### count

How much of the resource the handle represents. **Items are in stack units**
(individual items, not stacks of 64). **Fluids are in mB** (millibuckets,
1000 mB = 1 bucket).

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.count) -- 192 (192 individual coal pieces)
-- or for fluids
local water = network:find("minecraft:water")
print(water.count) -- 4000 (4 buckets in mB)
```
</LuaCode>

### kind

`"item"` or `"fluid"`. Branch on this when a script handles both.

<LuaCode>
```lua
for _, h in network:findEach("*") do
  if h.kind == "fluid" then
    print(h.count, "mB of", h.name)
  else
    print(h.count, "x", h.name)
  end
end
```
</LuaCode>

### stackable

`true` for items with a max stack size greater than 1 (cobblestone,
ingots, planks, ...), `false` for tools, armour, and anything unique
(potions with custom NBT, written books). Fluids are always `false` here,
they're tracked by volume not stacks.

<LuaCode>
```lua
for _, item in inputChest:findEach("*") do
  if not item.stackable then
    nonStackables:insert(item)
  else
    network:insert(item)
  end
end
```
</LuaCode>

Example of moving non-stacking items in another chest outside of your network

### maxStackSize

The largest stack the resource can occupy in a single inventory slot.
`64` for most items, `16` for snowballs and ender pearls, `1` for tools
and armour. Fluids report `1`, not meaningful.

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.maxStackSize) -- 64
```
</LuaCode>

### hasData

`true` if the stack carries non-default NBT, enchantments, custom names,
written-book content, dyed armour, suspicious-stew effects, etc. Useful for
sorting "interesting" items away from plain bulk.

<LuaCode>
```lua
for _, item in inputChest:findEach("*") do
  if item.hasData then
    enchantedItems:insert(item)
  else
    network:insert(item)
  end
end
```
</LuaCode>

---

## Methods

### hasTag

Returns `true` if the resource is a member of the given tag. Accepts the tag
id with or without the leading `#`, both `"minecraft:logs"` and
`"#minecraft:logs"` work.

<LuaCode>
```lua
for _, h in network:findEach("*") do
  if h:hasTag("minecraft:logs") then
    print(h.name, "is a log type")
  end
end
```
</LuaCode>

Tag membership is the same set Minecraft uses for crafting recipes and
biome decisions, so anything that works in a vanilla "any log" recipe will
match here.

### matches

Returns `true` if the resource matches the given filter, using the same
filter syntax as [`network:find`](network.md#find). Useful for routing
predicates and per-item branching without needing a full `:find` round-trip.

<LuaCode>
```lua
function smelt(item: ItemsHandle)
  if item:matches("/_ore$/") then
    machine:insert(item)
    return
  end
  furnace:insert(item)
end
```
</LuaCode>

---

## Passing a handle into transfer methods

A handle isn't just a read-only value, it's also the **source for moving
those items**. Most transfer methods take a handle as their argument and
move from wherever it came from into the new destination.

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  -- move all of it into the chest
  chest:insert(coal)
end
```
</LuaCode>

The methods that consume a handle this way:

- [`card:insert`](card-handle.md#insert) / [`card:tryInsert`](card-handle.md#tryinsert), into the card's adjacent inventory
- [`network:insert`](network.md#insert) / [`network:tryInsert`](network.md#tryinsert), into network storage with routing rules
- [`placer:place`](placer-handle.md#place), uses the handle's `.id` to pick what to place

The handle's `.count` is the maximum these methods will move. Pass an
optional second argument to cap the move at fewer, useful for small
destinations like a furnace's fuel slot:

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
furnace:insert(coal, 8) -- top up the fuel slot with 8 coal
```
</LuaCode>

> **Note:** `:insert` is all-or-nothing. If the destination can't fit the
> full amount you're trying to move, nothing moves and the call returns
> `false`. Use `:tryInsert` when a partial transfer is fine, or pass the
> second-arg cap so the move stays within the destination's capacity.

---

## nil when nothing matches

`:find` and `findEach`'s entries return `nil` when the filter has no match.
A handle with `count = 0` doesn't exist, the absence of a result is
expressed by absence. Always check before chaining:

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  print(coal.count, "coal available")
else
  print("no coal in storage")
end
```
</LuaCode>

The editor's type system tracks this, hovering `coal` shows
`ItemsHandle?` (the `?` is the "or nil" marker) so it'll prompt you when
you forget the check.
