---
navigation:
  parent: lua-api/index.md
  title: Job
  icon: minecraft:paper
categories:
  - api_types
description: the first argument passed to a [network:handle callback](network.md#handle) and represents the in-flight processing job the handler is responsible for producing outputs for
---

# Job

A `Job` is the first argument your [`network:handle`](network.md#handle)
function receives. Each time the network needs to run a recipe on your
Processing Set, it calls your handler with a fresh `Job` and the
[items](input-items.md) it pulled from storage. Your handler puts those items
into the machine, then calls `job:pull(card)` to tell the network where the
finished items will come out.

## pull

Tells the network where the finished items will come out. Pass one or more
[CardHandle](card-handle.md)s and the network watches them until the full
output count has been collected.

If the outputs are already sitting in one of the cards (instant recipes,
shapeless crafts), the craft finishes on the same tick. Otherwise the network
keeps checking each tick and grabs whatever's in the card so far, so a
furnace that drips out one ingot at a time still works fine.

<LuaCode>
```lua
local furnace = network:get("furnace")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron)
  -- pull from the bottom face once the smelt completes
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

### Multiple source cards

Pass more than one card if the finished items could land in any of several
places. The network checks each card in order and grabs from whichever has
the items. Useful when you have downstream pipes or hoppers that route the
output into different chests depending on the item.

<LuaCode>
```lua
local furnace = network:get("furnace")
local outboxA = network:get("outbox_a")
local outboxB = network:get("outbox_b")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron)
  -- finished ingots get sorted into one of two chests, pull from either
  job:pull(outboxA, outboxB)
end)
```
</LuaCode>

### Put items in first

`:pull` only handles the output side. You still have to insert the
[InputItems](input-items.md) into the machine yourself. If anything's left
in `items.<slot>` when your handler returns, the craft is considered
incomplete and the network will try the recipe again.

### Timeout

If the outputs never show up, the craft eventually times out and the inputs
are returned to storage. Each Processing Set has its own timeout (in ticks)
that you can tune in its GUI, defaults to 15 seconds. Bump it up for slow
machines like large smelting batches or modded multi-second recipes.

> **Note:** An error inside your handler stops *that one craft* but doesn't
> take down the rest of your script. If a craft hangs unexpectedly, check the
> terminal log, the error will be there.
