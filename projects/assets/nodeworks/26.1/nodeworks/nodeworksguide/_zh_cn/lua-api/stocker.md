---
navigation:
  parent: lua-api/index.md
  title: Stocker
  icon: minecraft:observer
categories:
  - api_types
  - api_preset
description: 通过抽取、合成，或两者并用保证目标存量足够
---

# Stocker

`stocker`（补货器）全局变量能建造库存水平维持器。设置好目标容器、`:keep(n)`水位线、来源（抽取、合成、两者并用）后，stocker就会在容器库存量低于水位线时进行补货。库存量超出水位线时不会抽出多余量，若玩家往里多放了些，多出的部分也不会被取走。

## 三种来源模式

stocker链以三种工厂方法之一起始，可根据物品来源选择其中一种。

### from

<LuaCode>
```lua
Stocker:from(...sources: string | CardHandle | network): StockerBuilder
```
</LuaCode>

从卡片或网络存储中抽取。短缺时不会合成。适用于“只从这个缓存箱里抽取”和“从网络存储里抽取，缺少时等待”的场景。与[`:filter`](./stocker.md#filter)配合可匹配特定种类的物品，不指定筛选器时stocker会抽取任意物品直到达成`:keep(n)`的要求。

<LuaCode>
```lua
-- 从指定的两个箱子里抽取箭
stocker:from("chest1", "chest2"):filter("$item:arrow"):to("dispenser"):keep(64):start()

-- 从网络存储抽取，抽空则等待
stocker:from(network):filter("$item:arrow"):to("dispenser"):keep(64):start()
```
</LuaCode>

### ensure

<LuaCode>
```lua
Stocker:ensure(itemId: string): StockerBuilder
```
</LuaCode>

首先从网络存储中抽取，短缺时合成剩余部分。最常用的来源模式，适用于“确保有N个物品”的场景。需接受精确物品ID，因为合成计划本身需要有确切的产物。

<LuaCode>
```lua
stocker:ensure("minecraft:arrow"):to("dispenser"):keep(64):start()
stocker:ensure("minecraft:iron_ingot"):to(network):keep(256):start()
```
</LuaCode>

### craft

<LuaCode>
```lua
Stocker:craft(itemId: string): StockerBuilder
```
</LuaCode>

只通过合成补货，不从现有存储空间中抽取。如需保证产物为新合成状态，或资源稀缺以至于合成优于抽取，可选择此来源模式。

<LuaCode>
```lua
stocker:craft("minecraft:bread"):to("foodChest"):keep(16):start()
```
</LuaCode>

## 必选方法

### to

<LuaCode>
```lua
StockerBuilder:to(target: string | CardHandle | network): StockerBuilder
```
</LuaCode>

设置目标。接受卡片别名、CardHandle对象，以及代表“保证网络库存量”的`network`。stocker会统计目标中匹配物品的数量，使用`network`时，则统计所有存储卡。

### keep

<LuaCode>
```lua
StockerBuilder:keep(amount: number): StockerBuilder
```
</LuaCode>

目标的库存量水平。stocker会补货至达到此值为止。若当前数量超出此值（玩家额外放入、其他脚本输入等），stocker也不会抽出。stocker只会送入，永远不会抽出。

## 可选方法

### filter

<LuaCode>
```lua
StockerBuilder:filter(pattern: string): StockerBuilder
```
</LuaCode>

限制目标中`:keep(n)`统计的资源种类。默认为`*`（任意物品）。如需stocker在多种来源间仅统计特定种类的物品，可设置此值。**`:ensure`和`:craft`会自动设置此值**至相应的物品ID，因此仅有`:from`需要专门指定`:filter`。

<LuaCode>
```lua
stocker:from("buffer")
  :filter("$item:arrow")
  :to("dispenser")
  :keep(64)
  :start()
```
</LuaCode>

### batch

<LuaCode>
```lua
StockerBuilder:batch(size: number): StockerBuilder
```
</LuaCode>

将合成请求聚合至该单次数量。默认为0，代表“缺多少补多少”（缺少3个时就合成3个，无论配方的消耗有多小）。设为`:batch(64)`可让stocker一次性合成64个；此设置适合设施开支大（多输入、多步骤）的配方使用，这些配方若以多个小作业的数量发出会严重拖慢CPU。

<LuaCode>
```lua
stocker:craft("minecraft:iron_ingot"):to("chest"):keep(64):batch(32):start()
-- 短缺10个时合成32个，补货后目标可能能暂时性存有74个物品。
```
</LuaCode>

目标存量可能会因单次数量过大而超出`:keep(n)`，后续计刻时stocker便什么都不会做，直至库存量再次低于水位线为止。

## 示例：为发射器补充箭，缺少时合成

<LuaCode>
```lua
stocker:ensure("minecraft:arrow")
  :to("trapDispenser")
  :keep(64)
  :batch(16)
  :every(20)
  :start()
```
</LuaCode>

每秒：若发射器中箭的数量少于64，则首先从网络存储抽取；若仍短缺，合成16个。重复至发射器补充完毕。

## 延伸阅读

* [通用预设方法](presets.md#通用方法)（`:every`、`:start`、`:stop`、`:isRunning`）。
* [Importer](importer.md)（导入器），A到B的持续供货，与库存量无关。
* [Network:craft](network.md#craft)，合成原语详情。
