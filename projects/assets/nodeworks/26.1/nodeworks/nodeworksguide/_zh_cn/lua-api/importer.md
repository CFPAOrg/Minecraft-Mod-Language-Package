---
navigation:
  parent: lua-api/index.md
  title: Importer
  icon: minecraft:hopper
categories:
  - api_types
  - api_preset
description: 将物品从A移动到B，接受分配策略
---

# Importer

`importer`（导入器）全局变量能建造物品搬运器，从任意多个来源中抽取物品，再送到任意多个目标中去。在实现方式上，importer其实是scheduler任务，因此它会根据所配置的间隔运行，并在脚本停止或对handle调用`:stop()`时终止。

## from

<LuaCode>
```lua
Importer:from(...sources: string | CardHandle | network): ImporterBuilder
```
</LuaCode>

importer链的起点。来源可为卡片别名、CardHandle对象，或`network`全局变量（代表整个网络存储）三者混用。至少需要指定一个来源。

<LuaCode>
```lua
importer:from("farmChest")                        -- 名称来源
importer:from(network)                            -- 网络存储作为来源
importer:from("chestA", network, network:get("chestB"))  -- 混用
```
</LuaCode>

## to

<LuaCode>
```lua
ImporterBuilder:to(...targets: string | CardHandle | network): ImporterBuilder
```
</LuaCode>

设置目的地。多态行为和`:from`一致：卡片别名、CardHandle对象、指代网络存储的`network`。至少需要指定一个目标。

<LuaCode>
```lua
importer:from("farm"):to("storage1", "storage2"):start()
importer:from("mobFarm"):to(network):start()  -- 存入网络存储
```
</LuaCode>

## filter

<LuaCode>
```lua
ImporterBuilder:filter(pattern: string): ImporterBuilder
```
</LuaCode>

按照筛选器限制可移动的物品（或流体）种类。&zwnj;**可选。**&zwnj;默认值为`*`，对应移动所有物品。筛选器的语法与[Network:find](network.md#find)一致，即包括`$item:id`、`$fluid:id`、`#tag`、`modname:*`、正则表达式。

<LuaCode>
```lua
-- 仅移动圆石
importer:from(network)
  :filter("$item:minecraft:cobblestone")
  :to("io_*")
  :start()

-- 移动所有c:ores物品
importer:from("mobFarm"):filter("#c:ores"):to("storage"):start()
```
</LuaCode>

## 分配

importer有两种分配调度目标的方式。默认为填充，需要显式指定是否使用轮询。

### 填充（默认）

填充首个目标。填满后移出到下一个目标，以此类推。适合有优先级顺序且希望一个箱子积极补货、多余物品溢出到其他箱子的场景。

<LuaCode>
```lua
importer:from("furnaceOutput")
  :filter("$item:iron_ingot")
  :to("mainChest", "overflow")
  :start()
```
</LuaCode>

### roundrobin

<LuaCode>
```lua
ImporterBuilder:roundrobin(step: number?): ImporterBuilder
```
</LuaCode>

每刻在所有目标间均分资源。`step`是每刻送入每个目标的最大物品量（默认为1）。step=1时，来自来源的三个物品会在同一刻送入三个目标，每个目标各一个。如需大批量移动，可增加step或通过`:every(1)`增加计刻速度。

<LuaCode>
```lua
importer:from("bufferChest")
  :to("furnace1", "furnace2", "furnace3")
  :roundrobin()
  :every(10)
  :start()
```
</LuaCode>

轮询指针每刻前进一步；即便是来源货物不足、只有部分目标能拿到物品的情况下，也能维持分配的公平。

## 卡片别名的通配符

`:from`和`:to`都接受卡片名称中存在`*`通配符。`"io_*"`会扩展至importer解析快照时所有别名匹配该模式的卡片，并会在每次网络拓扑改变时重新进行扩展。

<LuaCode>
```lua
-- 将单个箱子的内容物均分到所有名为“io_...”的卡片
importer:from("input"):to("io_*"):roundrobin():start()

-- 从一系列来源箱子中抽出汇总到单个输出位置
importer:from("farm_*"):to("storage"):start()
```
</LuaCode>

## 示例：两阶段烧炼阵列

矿石按轮询送入三个熔炉，产物收集至中央存储箱。

<LuaCode>
```lua
-- 将矿石均分给三个熔炉
importer:from("oreBuffer")
  :filter("$item:iron_ore")
  :to("furnace1", "furnace2", "furnace3")
  :roundrobin()
  :every(10)
  :start()

-- 从所有三台熔炉中抽取锭，并存入输出箱
importer:from("furnace1", "furnace2", "furnace3")
  :filter("$item:iron_ingot")
  :to("outputChest")
  :start()
```
</LuaCode>

## 延伸阅读

* [通用预设方法](presets.md#通用方法)（`:every`、`:start`、`:stop`、`:isRunning`）。
* [Stocker](stocker.md)（补货器），“维持库存量”样板。
* [Network:find](network.md#find)，筛选器语法详情。
