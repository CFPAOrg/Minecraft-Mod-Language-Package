---
navigation:
  parent: lua-api/index.md
  title: Network
  icon: node
categories:
  - api_builtin
description: 查询网络存储、路由物品、发起合成作业、注册handler
---

# Network

`network`（网络）模块是指向<ItemLink id="terminal" />所属节点工程网络的入口。它能查询存储空间，在多个handle之间路由物品，注册回调函数。

## get

按名称获取网络中任意成员的引用，如<ItemLink id="storage_card" />、<ItemLink id="io_card" />、<ItemLink id="redstone_card" />、<ItemLink id="observer_card" />、<ItemLink id="variable" />等，通常在脚本的开头使用。卡片与变量名称冲突时选择卡片。

点击脚本终端的侧栏可以自动插入get行。

![点击前](../assets/images/click-to-add-card-01.png) ![点击后](../assets/images/click-to-add-card-02.png)

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/chest_furnace_terminal.snbt" />
  <BoxAnnotation min="1 1.1 0.1" max="1.25 1.9 0.9" color="#AA83E0">
    重命名为&zwnj;**“chest”**&zwnj;<ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="1 0.1 0.1" max="1.25 0.9 0.9" color="#83E086">
    重命名为&zwnj;**“furnace”**&zwnj;<ItemImage id="nodeworks:io_card" />
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local chest = network:get("chest")        -- 获取存储卡
local furnace = network:get("furnace")    -- 获取IO卡
local count = network:get("count")        -- 获取名为“count”的变量
```
</LuaCode>

---

## getAll

返回一个[HandleList](handle-list.md)，内有所有匹配所给类型的卡片和变量。HandleList会对所有成员广播写方法（`:set`、`:onChange`……），用它激活多个活塞或为多个侦测卡注册handler均只需一行。如需按成员迭代，可调用`:list()`。

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/chest_connected_storage_card.snbt" />
  <BoxAnnotation min="2.25 1.1 0.1" max="2 1.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
  <BoxAnnotation min="2.25 0.1 0.1" max="2 0.9 0.9" color="#AA83E0">
    <ItemImage id="nodeworks:storage_card" />
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
-- 广播：一次性激活所有红石卡
network:getAll("redstone"):set(true)
-- 若需分别使用读方法的返回值，应按成员迭代
local storages = network:getAll("storage")
for _, storage in storages:list() do
    print(storage.name)
end
-- "storage_0"
-- "storage_1"
```
</LuaCode>

---

## cards

返回一个[HandleList](handle-list.md)，内有所有匹配所给名称的卡片。如需同时使用遵从同一命名惯例的所有卡片，可以使用此方法。

<LuaCode>
```lua
local allPistonCards = network:cards("piston_*")
allPistonCards:set(true) -- 激活所有活塞
```
</LuaCode>

---

## channel

将查询限制在单种染料颜色对应的频道。返回一个[`Channel`](./channel.md) handle，该对象的`:get`、`:getAll`、`:getFirst`只会返回相应频道中的卡片、变量、设备，频道筛选器的规则一致。遇到未知颜色名称时会出错。

<LuaCode>
```lua
local red = network:channel("red")
red:getAll("redstone"):set(true) -- 仅红色频道的活塞
local count = red:get("counter") -- 仅红色频道的变量
```
</LuaCode>

---

## channels

返回网络中所有染料颜色频道组成的列表，即所有至少包含一个卡片、变量、破坏器，或放置器的颜色。顺序按`DyeColor` ID升序，所以对此列表迭代是稳定的。它可在运行时返回各频道，无需硬编码。

> **注意：**&zwnj;新成员的默认频道是`white`，所以大多数非空网络里都会有这个频道。

<LuaCode>
```lua
for _, color in network:channels() do
  print("正在使用", color)
end
-- 正在使用 "white"
-- 正在使用 "red"
-- 正在使用 "blue"
```
</LuaCode>

常见用法：对所有活动频道使用同一个handler，无需考虑玩家选择了哪些频道。

<LuaCode>
```lua
for _, color in network:channels() do
  network:channel(color):getAll("redstone"):set(false)
end
```
</LuaCode>

---

## find

扫描整个[网络存储](../nodeworks-mechanics/network-storage.md)，搜索匹配筛选器的物品/流体。返回聚合式handle&zwnj;*（按整个网络存储统计）*；若无资源匹配，则返回`nil`。

<LuaCode>
```lua
local all = network:find("*") -- 返回所有物品和流体（若有）
local allItems = network:find("$item:*") -- 仅物品
local allFluids = network:find("$fluid:*") -- 仅流体
local allCoal = network:find("minecraft:coal") -- 物品ID
local allLogs = network:find("#minecraft:logs") -- 标签
local allRaw = network:find("/^Raw.*/") -- 正则表达式
```
</LuaCode>

使用`:find`的返回值时，应当先检查是否为空。

<LuaCode>
```lua
local allCoal = network:find("minecraft:coal")
if allCoal then
  print("有煤炭")
end
```
</LuaCode>

---

## findEach

和[find](./network.md#find)类似，此方法也会扫描[网络存储](../nodeworks-mechanics/network-storage.md)，搜索匹配筛选器的物品/流体。此方法会返回[ItemsHandle](./items-handle.md)列表，按物品ID和是否包含NBT数据去重。

<LuaCode>
```lua
for _, items in network:findEach("$item:*") do
  print(items.id, items.count, items.kind)
end
```
</LuaCode>

若网络中有钻石剑，一部分有魔咒一部分没有，则这两者会被分成两个元素。

<LuaCode>
```lua
for _, items in network:findEach("minecraft:diamond_sword") do
  print(items.id, items.hasData)
end
-- "minecraft:diamond_sword" true
-- "minecraft:diamond_sword" false
```
</LuaCode>

---

## count

返回[网络存储](../nodeworks-mechanics/network-storage.md)中匹配筛选器资源的总数。（流体以mB计。）

筛选器语法与[find](network.md#find)一致。

<LuaCode>
```lua
print("剑：", network:count("minecraft:diamond_sword"))
print("圆石：", network:count("minecraft:cobblestone"))
print("总计：", network:count("*"))
-- "剑：" 3
-- "圆石：" 256
-- "总计：" 259
```
</LuaCode>

---

## insert

参照标准的<ItemLink id="storage_card" />优先级规则，将一个[ItemsHandle](items-handle.md)插入[网络存储](../nodeworks-mechanics/network-storage.md)。需要网络能存下所有物品，否则便不会移动，并返回`false`。如希望尽力移动，可使用[tryInsert](./network.md#tryinsert)。

<LuaCode>
```lua
local ok = network:insert(items)
if ok then
  print("所有物品均已移动")
else
  print("未移动物品，空间不足")
end
```
</LuaCode>

---

## tryInsert

与[`insert`](network.md#insert)类似，但会移动所有匹配的物品，而不是要么全部移动，要么不移动。返回实际移动的数量（0至所请求的量）。所有未能移动的物品将停留在来源中。若仅移动一部分不会产生影响，可使用此方法。

<LuaCode>
```lua
local moved = network:tryInsert(items)
print("移动了" .. moved .. "个物品") -- 可为0到items.count
```
</LuaCode>

---

## craft

（参见[Auto-Crafting](../nodeworks-mechanics/autocrafting.md)）

为所给物品发起合成作业，并为其排队，返回一个[CraftBuilder](./craft-builder.md)。默认情况下，合成得到的物品会在合成完毕后自动进入[网络存储](../nodeworks-mechanics/network-storage.md)，无需链式调用：

<LuaCode>
```lua
-- 发起后即不管：面包会在合成完毕后进入网络存储
network:craft("minecraft:bread", 4)
```
</LuaCode>

在后方链式调用`:connect(fn)`可改变此行为。回调函数会收到一个[ItemsHandle?](items-handle.md)，成功时不为`nil`，不成功（合成计划失败、异步超时、无CPU）时为`nil`。调用`:connect`会覆盖自动存储行为。

<LuaCode>
```lua
local furnace = network:get("furnace")
network:craft("minecraft:charcoal"):connect(function(item: ItemsHandle?)
  if item then
    furnace:insert(item)
  end
end)
```
</LuaCode>

---

## shapeless

立即使用[网络存储](../nodeworks-mechanics/network-storage.md)中的原材料进行无序合成。若配方无效或缺少原材料，则不会进行合成，且方法会返回`nil`。

<LuaCode>
```lua
-- 合成一个打火石，产物自动进入网络存储。
network:shapeless("minecraft:flint", 1, "minecraft:iron_ingot", 1)
```
</LuaCode>

---

## handle

（参见[自动合成](../nodeworks-mechanics/autocrafting.md)）

为网络内的<ItemLink id="processing_set" />注册一个处理handler。该handler会随输入唤起，并且必须使用传入的[Job](job.md)以`pull`产物。所有来自[InputItems](input-items.md)的物品**必须**被handler接收。

<GameScene zoom="5" interactive={true} paddingTop="40" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/processing_storage_single_entry.snbt" />
  <BoxAnnotation min="1.9 0.1 0.75" max="1.1 0.9 1" color="#83E086">
    重命名为&zwnj;**“furnace”**&zwnj;<ItemImage id="nodeworks:io_card" />
  </BoxAnnotation>
  <BlockAnnotation x="0" y="0" z="0">
    <Row>
      <ItemImage id="minecraft:raw_iron" />
      **➜**
      <ItemImage id="minecraft:iron_ingot" />
    </Row>
  </BlockAnnotation>
</GameScene>

<LuaCode>
```lua
local furnace = network:get("furnace")
-- 粗铁 -> 铁锭的handler
network:handle("…", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron)
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

---

## route

批量编辑所有名称匹配的<ItemLink id="storage_card" />的[筛选器设置](../items-blocks/storage_card.md#筛选器)。返回一个builder，它的方法能链式调用，可在一行内写完整个规则集。各方法会在执行后立即生效于相应的卡片，和手动右击打开其GUI编辑的效果一样。

匹配模式为名称，接受`*`作为通配符。`cobblestone_*`可匹配`cobblestone_0`、`cobblestone_1`等。单独使用`*`则匹配网络中的所有存储卡。

<LuaCode>
```lua
network:route("cobblestone_*")
  :reset()
  :rule("#c:cobblestones")
  :noNbt()
  :allow()
```
</LuaCode>

### Builder方法

| 方法                                                   | 效果                               |
| ------------------------------------------------------ | ---------------------------------- |
| `:rule(filter)`                                        | 附加一条规则（语法与GUI内的一致）  |
| `:clearRules()`                                        | 清空规则，模式不变                 |
| `:allow()` / `:deny()`                                 | 设置规则列表模式                   |
| `:stackable()` / `:nonStackable()` / `:anyStackable()` | 设置可堆叠性筛选器                 |
| `:hasNbt()` / `:noNbt()` / `:anyNbt()`                 | 设置NBT筛选器                      |
| `:reset()`                                             | 清空规则，设置为白名单、任意、任意 |

调用时会返回同一个builder，也因此这些方法可以链式调用。设置的更改立即生效，且能在保存/加载间保持。

---

## debug

打印网络拓扑的总概。

<LuaCode>
```lua
network:debug()
-- === Network Debug ===
-- Controller: BlockPos{x=-25, y=70, z=10}
-- Nodes: 1
--   Node BlockPos{x=-25, y=70, z=9}: 1 cards
--     NORTH: cobblestone_storage (storage)
-- Terminals: 1
--   BlockPos{x=-26, y=70, z=9}
-- CPUs: 0
-- Crafters (Instruction Sets): 0
-- Processing APIs: 0
-- Variables: 0
```
</LuaCode>