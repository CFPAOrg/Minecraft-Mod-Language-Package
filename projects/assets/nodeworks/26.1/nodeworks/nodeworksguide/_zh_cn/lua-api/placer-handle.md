---
navigation:
  parent: lua-api/index.md
  title: PlacerHandle
  icon: placer
categories:
  - api_types
description: 用于在其前方放置方块的设备
---

# PlacerHandle

`PlacerHandle`（放置器句柄）是对网络中<ItemLink id="placer" />的引用，由[`network:get(name)`](network.md#get)返回。它会从[网络存储](../nodeworks-mechanics/network-storage.md)中抽取一个所选物品，并将其作为方块放置在自身前方的位置。

<BlockImage scale="6" id="placer" />

`:place(...)`为同步操作，它会在脚本调用的同一刻返回`true`/`false`。过程不会占用多个刻，不会返回builder对象，也不接受回调函数。只有`BlockItem`物品（有可放置的方块形态）能成功执行，对工具、食物，或任意无法放置的物品调用会立即失败。

## 属性

- **`.name`**
  - 放置器的别名（和终端侧边栏中的一致）

## place

从网络存储中抽出一个所选物品，将其放在放置器前方的位置。成功放置返回`true`。

参数可以是物品ID字符串或[ItemsHandle](./items-handle.md)。若传入handle，放置器会读取其`.id`，并从网络存储中抽取一个*该物品*，方式与直接传入字符串一致。此方法不会抽取handle本身的来源，而是会向网络中的存储卡抽取。

<LuaCode>
```lua
local placer = network:get("placer_1")
placer:place("minecraft:cobblestone")
```
</LuaCode>

以下情况会返回`false`（且不进行放置）：
- 网络中没有可用的匹配物品
- 目标位置不是空气
- 物品无法放置（如`minecraft:diamond`、`minecraft:stick`）

<LuaCode>
```lua
local placer = network:get("bridge_builder")
local ok = placer:place("minecraft:oak_planks")
if not ok then
  print("未放置，网络存储中没有木板或目标位置已被阻挡")
end
```
</LuaCode>

## block

返回放置器前方方块的ID，规格与[`ObserverCard:block`](./card-handle.md#侦测卡)一致。适合用在`:place`前面，对“位置是否为空/是否是预期中的方块”进行判断。

<LuaCode>
```lua
local placer = network:get("placer_1")
if placer:block() == "minecraft:air" then
  placer:place("minecraft:torch")
end
```
</LuaCode>

## isBlocked

若目标位置不可被替换（不是空气，也不是矮草丛、雪等可被替换的方块），返回`true`；否则返回`false`。若只需要知道该处是否被阻挡，使用此方法的开支要小于调用`:place`再检查返回值。

<LuaCode>
```lua
local placer = network:get("placer_1")
if not placer:isBlocked() then
  placer:place("minecraft:cobblestone")
end
```
</LuaCode>
