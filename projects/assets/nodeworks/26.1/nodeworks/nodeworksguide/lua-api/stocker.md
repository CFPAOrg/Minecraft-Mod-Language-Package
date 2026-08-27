---
navigation:
  parent: lua-api/index.md
  title: Stocker
  icon: minecraft:observer
categories:
  - api_types
  - api_preset
description: keep a target topped up by pulling, crafting, or both
---

# Stocker

The `stocker` global builds level maintainers. You set a target container, a
`:keep(n)` watermark, and a source (pull, craft, or both), and the stocker
tops the target up whenever it dips below the watermark. It never extracts
once the watermark is reached, if the player dumps extras in, they stay.

## Three source modes

A stocker chain starts with one of three factory methods, depending on where
you want items to come from.

### from

<LuaCode>
```lua
Stocker:from(...sources: string | CardHandle | network): StockerBuilder
```
</LuaCode>

Pull from specific cards or the network pool. Never crafts if short. Good for
"pull from this specific buffer chest" or "pull from the pool, wait if empty."
Pair with [`:filter`](./stocker.md#filter) to match only a specific item type, without a
filter the stocker tops up the target to `:keep(n)` worth of any items.

<LuaCode>
```lua
-- Pull arrows from two specific chests
stocker:from("chest1", "chest2"):filter("$item:arrow"):to("dispenser"):keep(64):start()

-- Pull from the network pool, wait if the pool runs dry
stocker:from(network):filter("$item:arrow"):to("dispenser"):keep(64):start()
```
</LuaCode>

### ensure

<LuaCode>
```lua
Stocker:ensure(itemId: string): StockerBuilder
```
</LuaCode>

Pull from the network pool first, craft the rest if the pool is short. The
most common form, covers the "always have N of this" pattern. Takes an exact
item id because crafting needs a concrete output to plan against.

<LuaCode>
```lua
stocker:ensure("minecraft:arrow"):to("dispenser"):keep(64):start()
stocker:ensure("minecraft:iron_ingot"):to(network):keep(256):start()
```
</LuaCode>

### craft

<LuaCode>
```lua
Stocker:craft(itemId: string): StockerBuilder
```
</LuaCode>

Always craft to maintain the level. Never pulls from existing storage. Useful
when you want to guarantee fresh output or when an ingredient is scarce and
you'd rather top up by crafting than by pulling from a shared chest.

<LuaCode>
```lua
stocker:craft("minecraft:bread"):to("foodChest"):keep(16):start()
```
</LuaCode>

## Required methods

### to

<LuaCode>
```lua
StockerBuilder:to(target: string | CardHandle | network): StockerBuilder
```
</LuaCode>

Sets the destination. Accepts a card alias, CardHandle object, or `network`
for "keep the level in the pool itself." The stocker counts matching items in
the target, when you use `network`, it counts across every storage card.

### keep

<LuaCode>
```lua
StockerBuilder:keep(amount: number): StockerBuilder
```
</LuaCode>

Target stock level. The stocker tops up to this count and stops. If the
current count ever exceeds this (player dumped extras in, another script
inserted, etc.), the stocker does nothing. It only ever fills, never drains.

## Optional methods

### filter

<LuaCode>
```lua
StockerBuilder:filter(pattern: string): StockerBuilder
```
</LuaCode>

Narrows what the stocker counts toward `:keep(n)` in the target. Defaults to
`*` (any item). Set it when you want the stocker to only care about a specific
type of item pulled from a heterogeneous source. **`:ensure` and `:craft` set
this automatically** to their item id, so you only need `:filter` with
`:from`.

<LuaCode>
```lua
stocker:from("buffer")
  :filter("$item:arrow")
  :to("dispenser")
  :keep(64)
  :start()
```
</LuaCode>

### batch

<LuaCode>
```lua
StockerBuilder:batch(size: number): StockerBuilder
```
</LuaCode>

Coalesces craft requests into this batch size. Default 0 means "craft exactly
what's missing" (so a shortfall of 3 crafts 3, even if the recipe is cheap).
Setting `:batch(64)` makes the stocker craft 64 at a time, which is useful
for recipes with large setup cost (multi-input, multi-step) where many tiny
crafts would thrash the CPU.

<LuaCode>
```lua
stocker:craft("minecraft:iron_ingot"):to("chest"):keep(64):batch(32):start()
-- Shortfall of 10 crafts a full 32, target may temporarily hold 74 after delivery.
```
</LuaCode>

The target can temporarily exceed `:keep(n)` by the batch leftover, subsequent
ticks do nothing until the stock drops below the watermark again.

## Example: arrow dispenser with fallback crafting

<LuaCode>
```lua
stocker:ensure("minecraft:arrow")
  :to("trapDispenser")
  :keep(64)
  :batch(16)
  :every(20)
  :start()
```
</LuaCode>

Every second: if the dispenser has fewer than 64 arrows, pull from the pool
first, if still short, craft 16 more. Repeats until the dispenser is full.

## See also

* [Shared preset methods](presets.md#shared-methods) (`:every`, `:start`,
  `:stop`, `:isRunning`).
* [Importer](importer.md) for continuous A-to-B movement without a level goal.
* [Network:craft](network.md#craft) for the underlying craft primitive.
