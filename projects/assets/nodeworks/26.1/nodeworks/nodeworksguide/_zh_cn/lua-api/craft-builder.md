---
navigation:
  parent: lua-api/index.md
  title: CraftBuilder
  icon: minecraft:crafting_table
categories:
  - api_types
description: 由[`network:craft`](network.md#craft)返回，用于配置产物的去向
---

# CraftBuilder

`CraftBuilder`（合成建造器）是[`network:craft`](network.md#craft)的返回值类型。它代表网络已经计划但还未收到产物的合成作业。默认情况下，合成完毕时产物会被送至[网络存储](../nodeworks-mechanics/network-storage.md)。若想要使用回调函数，可链式调用`:connect(fn)`。

合成作业本身可能同一刻内就结束（由网络存储供应原材料的原版配方），也可能需要许多刻（所有经由[`network:handle`](network.md#handle)、处理操作器、多阶段合成树的作业）。无论是哪一种，builder的API都完全一致。

> **注意：**&zwnj;`network:craft`必然返回一个builder，即便是无法计划合成作业（无配方、缺少原材料、没有合成CPU）也是如此。此类失效会作为`nil`进入`:connect`的回调函数。

## 默认：存储产物

若没有后续链式调用，产物会被自动送回网络存储，过程中使用常规的[存储卡](../items-blocks/storage_card.md)优先级和[`network:route`](network.md#route)规则。此后，可和网络存储中其他资源一样通过`network:find`进行查询。

<LuaCode>
```lua
-- 发起后即不管：合成16根火把，最后会进入网络存储
network:craft("minecraft:torch", 16)
```
</LuaCode>

## connect

将产物交由回调函数处理，**而不是**自动存储。调用`:connect`会禁用builder的默认行为：脚本运行时不会自动存储，产物归回调函数所有。

回调函数的参数为`ItemsHandle?`：成功合成时为[ItemsHandle](items-handle.md)，失败时为`nil`。使用前务必检查。

<LuaCode>
```lua
local oven = network:get("oven")
network:craft("minecraft:bread", 4):connect(function(items: ItemsHandle?)
  if not items then
    print("面包合成失败")
    return
  end
  oven:insert(items) -- 产物面包直接进入oven
end)
```
</LuaCode>

回调函数会在合成结束后立即触发。合成失效会变为`nil`：

- 合成计划失败：无配方、缺少原材料、网络中没有合成CPU。
- 异步超时：处理用handler未能发回输出。
- CPU离线：合成CPU在合成中途损坏或被移除。

无论是哪一种失效，脚本运行时都会将CPU缓存送回网络存储，以免物品滞留。

### 移动物品需要你来操作

回调函数收到的handle是**合成CPU缓存中剩余物品的实时引用**。调用`card:insert(items)`/`network:insert(items)`可抽空缓存，将物品送入目的地。

回调函数返回时残留在缓存中的物品会**掉落在CPU的位置**，终端会同时记录错误。操作约定是“handle归你，移动物品也归你”，未能完成移动的错误不会静默消失。

<LuaCode>
```lua
local chest = network:get("ore_chest")
network:craft("minecraft:iron_ingot", 8):connect(function(items: ItemsHandle?)
  if not items then return end
  if not chest:insert(items) then
    -- 箱子已满：送至网络存储，避免掉落
    network:insert(items)
  end
end)
```
</LuaCode>

此行为和自动存储——必然送至无论存储卡（且只会在所有存储卡均拒绝时掉落）——不一样，是刻意为之。回调函数通过`:connect`来控制物品去向，而脚本运行时会信任你。

> **注意：**&zwnj;回调函数内抛出的错误会在终端处记录，但不会截停脚本的其他部分。

## 同步的connect

原材料已备齐的原版配方作业会在发起的同一刻结束。回调函数依然会按同样路径在`:craft`调用的后一刻触发，以便`:connect`在解析前注册。无需为此设置特殊处理，API的表现在同步和异步合成作业中完全一致。

<LuaCode>
```lua
-- 无论是立即完成的合成，还是需要30s的烧炼，connect的表现都相同
network:craft("minecraft:iron_ingot", 8):connect(function(items: ItemsHandle?)
  if items then chest:insert(items) end
end)
```
</LuaCode>
