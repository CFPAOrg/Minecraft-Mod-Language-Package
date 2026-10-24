---
navigation:
  parent: lua-api/index.md
  title: Scheduler
  icon: minecraft:repeater
categories:
  - api_builtin
description: tick/second/delay callbacks
---

# Scheduler

The `scheduler` module registers periodic and delayed callbacks that run on
the server tick (20 TPS). Every registration returns a task id you can pass
to `:cancel` to stop it.

> **Tip:** It's also recommended to turn on the ["Autorun"](../items-blocks/scripting_terminal.md#autorun) of the <ItemLink id="terminal" /> if you want this to always run [`scheduler:tick`](scheduler.md#tick) or [`scheduler:second`](scheduler.md#second)

![](../assets/images/autorun.png)

## tick

Runs a provided callback every server tick

<LuaCode>
```lua
scheduler:tick(function()
  -- runs 20 times/second
end)
```
</LuaCode>

## second

Runs a provided callback every second (20 ticks)

<LuaCode>
```lua
scheduler:second(function()
  -- runs once per second
end)
```
</LuaCode>

## delay

Delays a callback function by the provided number of ticks.

<LuaCode>
```lua
scheduler:delay(20, function()
  -- runs after one second has passed
end)
```
</LuaCode>

## cancel

Stops a given task's ID. This is safe to call on already-cancelled or expired IDs.

<LuaCode>
```lua
local task = scheduler:tick(function()
  print("hello")
end)
-- cancel the scheduler:tick task after one second
scheduler:delay(20, function()
  scheduler:cancel(task)
end)
-- "hello" (x20)
```
</LuaCode>
