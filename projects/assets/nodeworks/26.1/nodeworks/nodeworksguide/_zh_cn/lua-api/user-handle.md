---
navigation:
  parent: lua-api/index.md
  title: UserHandle
  icon: user
categories:
  - api_types
description: 能使用物品右击其前方方块的设备
---

# UserHandle

`UserHandle`（使用器句柄）是对网络中<ItemLink id="user" />的引用，由[`network:get(name)`](network.md#get)返回。它会从[网络存储](../nodeworks-mechanics/network-storage.md)中抽取一个物品，并用其右击前方方块。

<BlockImage scale="6" id="user" />

使用器有两种模式。**瞬时**模式下，每次调用`:use()`会发起单次右击。**保持**模式下，则会按住鼠标右键，直至`:stop()`运行（或物品完成了操作，或超出了30秒时限）。筛选器语法与<ItemLink id="storage_card" />一致。

## 属性

- **`.name`**
  - 使用器的别名（和终端侧边栏中的一致）
- **`.kind`**
  - 必定是`"user"`

## use

触发使用器。**瞬时**模式下仅右击一次，并返回操作的执行地点。**保持**模式下则按住鼠标右键，返回是否进入按住右键状态。

若使用器正在使用、在冷却中、被筛选器阻止，或网络存储中没有匹配物品，或网络中没有控制器，则返回`false`（且不会触发）。

<LuaCode>
```lua
local farmer = network:get("crop_farmer")
farmer:use()
```
</LuaCode>

如需完全重启按住右键操作，可先调用`:stop()`。

## stop

取消计划中的瞬时点击，或释放按住操作。空闲时调用能保证安全，即不会报错，且返回`false`。将物品送回网络存储的收缩动画无法取消。

<LuaCode>
```lua
local user = network:get("user_1")
local watcher = network:get("observ_1")
user:setMode("hold")
user:use() -- 对可疑的方块使用刷子
-- 方块变为普通的沙子和沙砾时，停止使用器
watcher:onChange(function(block: BlockId, state: any)
    if block == "minecraft:gravel" or block == "minecraft:sand" then
        user:stop()
    end
end)
```
</LuaCode>

## isUsing

正按住右键时返回`true`，否则返回`false`。

<LuaCode>
```lua
local user = network:get("user_1")
if not user:isUsing() then
  user:use()
end
```
</LuaCode>

## mode

以字符串形式返回当前模式，必定为`"instant"`或`"hold"`。

<LuaCode>
```lua
local user = network:get("user_1")
print(user:mode()) -- "instant"
```
</LuaCode>

## setMode

设置使用器的模式。接受`"instant"`和`"hold"`（忽略大小写）。

<LuaCode>
```lua
local user = network:get("crop_farmer")
user:setMode("hold")
```
</LuaCode>

## filter

以字符串形式返回当前筛选器规则，未设置时返回空值。

<LuaCode>
```lua
local user = network:get("user_1")
print(user:filter()) -- "minecraft:bone_meal"
```
</LuaCode>

## setFilter

设置使用器是筛选器规则。筛选器语法与<ItemLink id="storage_card" />一致，也即物品ID、`#namespace:tag`、`minecraft:*`、`/正则表达式/`、`$item:`/`$fluid:`前缀均可用。

<LuaCode>
```lua
local user = network:get("crop_farmer")
user:setFilter("minecraft:bone_meal")
```
</LuaCode>

## facing

以全小写字符串形式（`"north"`、`"south"`、`"east"`、`"west"`、`"up"`、`"down"`）返回使用器的朝向.

<LuaCode>
```lua
local user = network:get("user_1")
print(user:facing()) -- "north"
```
</LuaCode>
