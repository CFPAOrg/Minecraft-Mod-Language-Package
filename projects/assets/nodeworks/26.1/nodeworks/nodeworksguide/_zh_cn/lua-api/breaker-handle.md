---
navigation:
  parent: lua-api/index.md
  title: BreakerHandle
  icon: breaker
categories:
  - api_types
description: 用于破坏其前方方块的设备
---

# BreakerHandle

`BreakerHandle`（破坏器句柄）是对网络中<ItemLink id="breaker" />的引用，由[`network:get(name)`](network.md#get)返回。它能对破坏器前方的方块启动消耗多个刻的破坏操作，并能将掉落物送回网络（或至自定义的handler）。

<BlockImage scale="6" id="breaker" />

破坏器的挖掘等级为钻石镐，破坏耗时使用木镐的计算公式，因此硬方块花费的时间显著更长。同一个破坏器在同一时刻仅能运行一个破坏操作，试图重叠调用`:mine()`相当于无操作。

## 属性

- **`.name`**
  - 破坏器的别名（和终端侧边栏中的一致）

## mine

对破坏器前方的方块启动消耗多个刻的破坏操作。返回一个[BreakBuilder](./breaker-handle.md#breakbuilder)，脚本可链式调用`:connect(fn)`以重定向掉落物。若不进行链式调用，掉落物会返回[网络存储](../nodeworks-mechanics/network-storage.md)，使用标准的[存储卡](../items-blocks/storage_card.md)优先级规则。

<LuaCode>
```lua
local breaker = network:get("quarry_1")
breaker:mine() -- 掉落物前往网络存储
```
</LuaCode>

若目标为空气、不可破坏，或破坏需要的品质高于破坏器，则`:mine()`会返回一个无操作builder，以免链式调用崩溃。

## cancel

若有运行中的破坏操作，终止其运行。空闲时调用能保证安全。方块不会被破坏，也不会产出掉落物。

<LuaCode>
```lua
local breaker = network:get("breaker_1")
breaker:mine()
if dangerous() then
  breaker:cancel() -- 在完成前停止
end
```
</LuaCode>

## block

返回破坏器前方方块的ID，规格与[`ObserverCard:block`](./card-handle.md#侦测卡)一致。适合用于破坏特定种类的方块。

<LuaCode>
```lua
local breaker = network:get("breaker_1")
if breaker:block() == "minecraft:stone" then
  breaker:mine()
end
```
</LuaCode>

## state

返回破坏器前方方块的属性表。规格与[`ObserverCard:state`](./card-handle.md#侦测卡)一致，方块的每一个`BlockState`属性（`age`、`facing`、`lit`、`waterlogged`……）都会变成单独的字段。

<LuaCode>
```lua
local breaker = network:get("crop_breaker")
local state = breaker:state()
if state.age == 7 then
  breaker:mine() -- 仅破坏长成的农作物
end
```
</LuaCode>

## isMining

若当前正在进行破坏，返回`true`；空闲则返回`false`。可用于避免在破坏中途发起`:mine()`（虽然此时调用本来也相当于无操作，但`:isMining()`可让脚本的分支更明确）。

<LuaCode>
```lua
local breaker = network:get("breaker_1")
if not breaker:isMining() then
  breaker:mine()
end
```
</LuaCode>

## progress

返回`0`到`1`之间的数，代表当前破坏操作的进度。空闲则返回`0`。适合用于显示进度条，或用于管理后续操作的时序。

<LuaCode>
```lua
local breaker = network:get("breaker_1")
print(string.format("%.0f%%", breaker:progress() * 100))
```
</LuaCode>

---

## BreakBuilder

由[`Breaker:mine()`](./breaker-handle.md#mine)返回。可用于配置破坏完成后掉落物的去向。若不进行链式调用，掉落物会自动进入网络存储。链式调用`:connect(fn)`可将其导入脚本handler。

### connect

将破坏的掉落物导入回调函数。每一个掉落的物品堆叠都会作为[ItemsHandle](./items-handle.md)传入handler，因此即便是只破坏一次会产生多项掉落的方块，也会多次调用handler。

handler可读取掉落物的`.id`、`.name`、`.count`、`.kind`，以此决定其去向。handler未路由的物品仍会使用默认路由，进入网络存储。

<LuaCode>
```lua
local breaker = network:get("breaker_1")
local chest = network:get("ore_chest")
breaker:mine():connect(function(item: ItemsHandle)
  if item.id == "minecraft:diamond" then
    chest:insert(item) -- 钻石进入专用的箱子
  end
  -- 所有其他产物进入网络存储
end)
```
</LuaCode>

> **注意：**&zwnj;破坏器的`:connect` handler会在破坏完成时运行，不是每刻都触发。handler内部的错误不会影响外部，出错的回调函数不会卡死破坏器。
