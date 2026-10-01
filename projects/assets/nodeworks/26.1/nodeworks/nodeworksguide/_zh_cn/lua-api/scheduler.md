---
navigation:
  parent: lua-api/index.md
  title: Scheduler
  icon: minecraft:repeater
categories:
  - api_builtin
description: 每刻运行/每秒运行/延迟回调函数
---

# Scheduler

`scheduler`（规划器）模块会注册周期性和延时式回调函数，计时基准为服务端刻（20 TPS）。每次注册会返回一个任务ID，可将其传入`:cancel`以停止。

> **提示：**&zwnj;若想要脚本不断运行[`scheduler:tick`](scheduler.md#tick)或[`scheduler:second`](scheduler.md#second)，建议开启<ItemLink id="terminal" />的[“自动运行”](../items-blocks/scripting_terminal.md#自动运行)。

![](../assets/images/autorun.png)

## tick

每服务端刻运行一次所给回调函数

<LuaCode>
```lua
scheduler:tick(function()
  -- 每秒运行20次
end)
```
</LuaCode>

## second

每秒（20刻）运行一次所给回调函数

<LuaCode>
```lua
scheduler:second(function()
  -- 每秒运行1次
end)
```
</LuaCode>

## delay

将回调函数延迟所给刻数。

<LuaCode>
```lua
scheduler:delay(20, function()
  -- 经过1秒再运行
end)
```
</LuaCode>

## cancel

停止所给ID对应的任务。对已取消和已过期ID调用能保证安全。

<LuaCode>
```lua
local task = scheduler:tick(function()
  print("hello")
end)
-- 在1秒后取消scheduler:tick任务
scheduler:delay(20, function()
  scheduler:cancel(task)
end)
-- "hello"（x20）
```
</LuaCode>
