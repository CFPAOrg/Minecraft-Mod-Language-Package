---
navigation:
  parent: lua-api/index.md
  title: HandleList
  icon: minecraft:red_bundle
categories:
  - api_types
description: getAll返回的卡片/变量列表，支持一次性广播
---

# HandleList

`HandleList<T>`（句柄列表）是卡片与变量组成的列表，**会在所有成员间广播写方法**。[`network:getAll(type)`](network.md#getAll)和[`Channel:getAll(type)`](network.md#channel-getall)的返回值为此类型。

对列表调用写方法，相当于按顺序使用相同的参数对所有成员调用该方法。读方法均未公开，因为读方法的返回值才是最重要的，进行静默跳过只会给脚本埋下隐患。如需按成员读取，可调用`:list()`并遍历。

<LuaCode>
```lua
-- 一次性触发所有红色频道下的活塞。
network:channel("red"):getAll("redstone"):set(true)
-- 在一行内为所有侦测卡注册同一个onChange handler。
network:getAll("observer"):onChange(function(block, state)
    if block == "nodeworks:celestine_cluster" then
        -- ...
    end
end)
```
</LuaCode>

## 哪些方法会被广播

只有**写方法**会对列表广播，也即只有调用位置不会在意其返回值的方法。`:powered()`、`:count()`、`:get()`、`:block()`等读方法均为刻意留空，以避免静默跳过某个成员的返回值。如需按成员读取，可调用`:list()`并依次操作。

每种类型的页面（如[RedstoneCard](card-handle.md#红石卡)、[VariableHandle](variable-handle.md)）是判断方法是读还是写的标准来源。

## list

类型逃生舱。返回内部的数组，以供按成员迭代、读取各成员，或应用不符合广播形式成员独有逻辑设置。

<LuaCode>
```lua
local pistons = network:channel("red"):getAll("redstone")
for _, p in pistons:list() do
    if p:powered() then
        print(p.name, "当前已充能")
    end
end
```
</LuaCode>

## count

列表中成员的数量。比`#list:list()`的开支小，因为它不需要建立数组。

<LuaCode>
```lua
local watchers = network:getAll("observer")
print("网络中有", watchers:count(), "张侦测卡")
```
</LuaCode>

## face

返回一个新HandleList，其中卡片成员的访问面强制改为`name`。原本的列表不会受影响，强制修改仅作用于返回的副本。不是[CardHandle](card-handle.md)的成员（变量、破坏器、放置器等）不会受影响，这些handle类型会忽略face。

列表的强制修改会在传入预设（[Importer](importer.md)/[Stocker](stocker.md)）时保留。仅需一个表达式，通配符广播即可读写所有匹配卡片的非默认面。

<LuaCode>
```lua
-- 从所有io_*卡片中抽取熔炉产物（底面）并送入输出箱
importer:from(network:cards("io_*"):face("bottom")):to("output"):start()
```
</LuaCode>

参数规格与[`CardHandle:face`](card-handle.md#face)一致，但会一次性作用于整个列表。
