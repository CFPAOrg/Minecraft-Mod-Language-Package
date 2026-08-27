---
navigation:
  parent: lua-api/index.md
  title: InputItems
  icon: minecraft:cobblestone
categories:
  - api_types
description: the second argument passed to [network:handle callbacks](network.md#handle) a per-recipe bag of [`ItemsHandle`](items-handle.md) fields keyed by the recipe's input slot names
---

# InputItems

`InputItems` is the second argument your [`network:handle`](network.md#handle)
function receives. The network has already pulled the recipe's ingredients
out of storage for you, they're waiting on this table, one field per input
slot. Your job is to pump those items into the actual machine.

Each field is a full [ItemsHandle](items-handle.md), so you call `:insert`,
`:tryInsert`, `:count`, etc. on it just like any other handle.

## Field names

The field names are **camelCased from the input item ids**. So
`minecraft:raw_iron` becomes `items.rawIron`, `minecraft:copper_ingot`
becomes `items.copperIngot`. The script editor autocompletes the right names
for whichever recipe you're handling, no need to memorise them.

<LuaCode>
```lua
local furnace = network:get("furnace")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron) -- minecraft:raw_iron
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

### Duplicate ingredients

If the recipe has the same ingredient in more than one slot, the second
occurrence gets a `2` suffix, the third gets `3`, and so on. So a recipe
that takes two copper ingots and one gold ingot exposes them as
`items.copperIngot`, `items.goldIngot`, `items.copperIngot2`.

<LuaCode>
```lua
local press = network:get("press")
network:handle("...", function(job: Job, items: InputItems)
  press:face("top"):insert(items.copperIngot)
  press:face("top"):insert(items.copperIngot2)
  press:face("north"):insert(items.goldIngot)
  job:pull(press:face("bottom"))
end)
```
</LuaCode>

## You must use everything

The handler is expected to move every input into the machine. If anything's
left in `items.<slot>` when the handler returns, the network treats the
craft as incomplete and retries the recipe later. There's no "skip this
input" mode, the recipe says it needs N copper ingots and N copper ingots
have to land somewhere.

> **Note:** "Use it" means insert it somewhere reachable, network storage
> via `network:insert` counts. The check is just "did the script consume
> the items it was given?", not "did they end up in the right machine."
