---
navigation:
  parent: lua-api/index.md
  title: Presets
  icon: terminal
categories:
  - api_builtin
description: declarative builders (importer, stocker) for common item movement and stocking patterns
---

# Presets

Presets are declarative builders for the two scripting patterns that show up most
often: **moving items from A to B** and **keeping a stock level topped up**. Each
preset is a chain of method calls that reads left to right like a sentence, and
ends in `:start()` to start it.

Presets sit on top of the existing scripting API. They're still Lua, still use
cards and filters the same way, and they're still torn down when the script
stops. The difference is one line of preset replaces roughly 15 lines of a
scheduler loop with manual state tracking.

<LuaCode>
```lua
-- move cobblestone from a farm chest into Network Storage, once per second.
importer:from("mobFarm"):filter("$item:cobblestone"):to(network):start()
-- keep 64 arrows stocked in a dispenser, crafting more when short.
stocker:ensure("minecraft:arrow"):to("dispenser"):keep(64):start()
```
</LuaCode>

## Current Presets

* [Importer](importer.md) moves items from one or more sources to one or more
  targets. Default is fill (exhaust each target before moving on). Call
  `:roundrobin()` to cycle through targets instead.
* [Stocker](stocker.md) maintains a target's stock at a `:keep(n)` watermark by
  pulling from storage, crafting, or both. Never extracts once the level is
  reached.

## Source and target references

Everywhere a preset takes a source or target, it accepts three shapes:

1. A **string** card alias: `"bufferChest"`.
2. A **CardHandle** from `network:get(...)`.
3. The **`network`** global itself, meaning "the whole Network Storage pool."

<LuaCode>
```lua
-- All three forms are valid and can be mixed.
importer:from("farm", network:get("secondary"), network)
  :to("output")
  :start()
```
</LuaCode>

Card resolution happens by name every time the network topology changes, so a
card that gets broken and replaced under the same name keeps working without
restarting the preset. Missing cards are skipped silently until they return.

## Shared methods

Every `ImporterBuilder` and `StockerBuilder` understands the same lifecycle and
control methods.

### every

<LuaCode>
```lua
ImporterBuilder:every(ticks: number): ImporterBuilder
StockerBuilder:every(ticks: number): StockerBuilder
```
</LuaCode>

Sets how often the preset re-evaluates. Default is 20 ticks (once per second).
Changing the rate mid-run cancels the current scheduler task and re-registers
at the new interval, so `imp:every(5)` takes effect immediately.

### start / stop / isRunning

<LuaCode>
```lua
ImporterBuilder:start()
ImporterBuilder:stop()
ImporterBuilder:isRunning(): boolean
```
</LuaCode>

`:start()` validates the chain and begins ticking. It's a no op if the builder
is already running, so calling it repeatedly is safe. `:stop()` stops ticking
but keeps all configuration, so a later `:start()` resumes the same chain
including any round robin cursor position.

<LuaCode>
```lua
local imp = importer:from("src"):to("dst")
scheduler:second(function()
  if someCondition() and not imp:isRunning() then
    imp:start()
  elseif imp:isRunning() and not someCondition() then
    imp:stop()
  end
end)
```
</LuaCode>

## Cleanup on script stop

When the Scripting Terminal stops (manually or from a network disconnect),
every preset registered during that script's lifetime is stopped automatically.
Dangling builders that were created but never `:start()` are also cleaned up.
Starting the script again rebuilds every preset from scratch, so you can
freely edit chain code between runs without worrying about leftover tasks.
