---
navigation:
  parent: lua-api/index.md
  title: Channel
  icon: io_card
categories:
  - api_types
description: 按染料颜色分割的网络视图
---

# Channel

`Channel`（频道）是按染料颜色分割的网络视图。使用[`network:channel(color)`](network.md#channel)可以得到频道。在Channel下的查询仅能看见该颜色频道下的卡片、变量、设备，这些网络成员的频道需在各自的GUI中选择。多个子系统可共用一个网络，不同子系统间同样的卡片别名不会相互冲突。

<LuaCode>
```lua
local red = network:channel("red")
local blue = network:channel("blue")
red:getAll("redstone"):set(true)   -- 仅触发红色频道的活塞
blue:getAll("redstone"):set(true)  -- 仅触发蓝色频道的活塞
```
</LuaCode>

颜色名必须为原版的16种染料颜色之一（`white`、`red`、`blue`、`light_blue`、`light_gray`……）。未知的颜色会出错。

## 选择频道

在所有[卡片](../nodeworks-mechanics/cards.md)和[设备](../nodeworks-mechanics/devices.md)的GUI中，都有用于选择频道的组件。默认情况下，所有设备和卡片的初始频道为`white`。点击频道选择器可打开一个颜色列表以供挑选。

![](../assets/images/choose_channel.png)

## get

仅作用于此频道的别名查询。返回[CardHandle](card-handle.md)、[VariableHandle](variable-handle.md)、Breaker或Placer，命名空间与[`network:get`](network.md#get)一致。频道中没有成员匹配别名时会出错。

<LuaCode>
```lua
local red = network:channel("red")
local counter = red:get("counter")  -- 红色频道下名为“counter”的变量
local door = red:get("door")     -- 红色频道下名为“door”的卡片
```
</LuaCode>

## getAll

返回一个[HandleList](handle-list.md)，内有频道下的所有给定类别的成员。接受适用于[`network:getAll`](network.md#getAll)的类别：`"io"`、`"storage"`、`"redstone"`、`"observer"`、`"variable"`、`"breaker"`、`"placer"`。不传入参数可返回所有成员，不论类别。

<LuaCode>
```lua
local red = network:channel("red")
red:getAll("observer"):onChange(function(block, state)
  print("红石频道侦测卡已触发：", block)
end)
```
</LuaCode>

## getFirst

返回频道下给定类别的首个成员，无成员匹配时返回`nil`。适合在频道内只有一个成员，且不想处理HandleList时使用。

<LuaCode>
```lua
local sensor = network:channel("blue"):getFirst("observer")
if sensor then
  print(sensor.name, "是蓝色频道的侦测卡")
end
```
</LuaCode>
