---
navigation:
  parent: lua-api/index.md
  title: ItemsHandle
  icon: minecraft:bundle
categories:
  - api_types
description: 附带数量、来源、传输操作的特定资源（物品或流体）
---

# ItemsHandle

`ItemsHandle`（物品句柄）是**附带数量的资源种类**。问出“存储空间里有什么？”的时候，大多数网络和卡片方法的返回值都是这个类型；让同样的方法“把这个搬到其他地方去”的时候，它们也需要接受此类型的参数。

> **注意：**&zwnj;handle是在调用返回时拍摄的**快照**。`.count`不会因为后续物品出入而更新。如果需要新数值，可再次调用`:find`。

---

## handle代表了什么（以及没在代表什么）

handle是**所查询位置所有匹配资源的聚合**，不是单一的物品栏堆叠。此性质有两个重要的影响：

**同一类handle能处理物品和流体。**&zwnj;`.kind`字段存储了资源的类型。物品的数量为“个数”，流体的为毫桶（mB）。详情参见下文的[count](./items-handle.md#count)和[kind](./items-handle.md#kind)。

**count可以大于`maxStackSize`。**&zwnj;即便单个槽位内最多只能存下64个，`network:find("minecraft:coal")`也有可能会返回`count = 192`的handle。这个handle代表着“网络中任意位置的所有煤炭”，可以由多个槽位、多张存储卡、多个储罐汇总而来。[card:find](card-handle.md#find)也遵从这一点，即也会聚合卡片对应的槽位和储罐。

若需要各堆叠单独处理（如附魔的剑分离于未附魔的同ID剑），可换用[`findEach`](network.md#findEach)。它会按ID**和**NBT数据分割，每一种独特组合都会变成不同的handle。

<LuaCode>
```lua
local allCoal = network:find("minecraft:coal")
print(allCoal.count) -- 192，网络内的总量

for _, h in network:findEach("minecraft:diamond_sword") do
  print(h.name, h.hasData) -- 附魔的剑和未附魔的剑分属不同条目
end
```
</LuaCode>

---

## 属性

### id

handle所指向资源的ID。两种资源类型的表现一致：物品可为`"minecraft:diamond"`，流体可为`"minecraft:water"`。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.id) -- "minecraft:coal"
```
</LuaCode>

### name

玩家在提示文本中看见的显示名称。经翻译、有格式，且可自定义（经过铁砧重命名的物品会显示重命名的字符串）。

<LuaCode>
```lua
local sword = network:find("minecraft:diamond_sword")
print(sword.name) -- "钻石剑"（或者重命名过的话，"ex咖喱棒"）
```
</LuaCode>

### count

handle所代表资源的数量。**物品的单位为“个数”**（按单独物品，不按组数），**流体的为mB**（毫桶，1000 mB = 1 桶）。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.count) -- 192（192个煤炭）
-- or for fluids
local water = network:find("minecraft:water")
print(water.count) -- 4000（4桶，合4000mB）
```
</LuaCode>

### kind

`"item"`或`"fluid"`。可在处理两类资源的脚本中用它作分支判断。

<LuaCode>
```lua
for _, h in network:findEach("*") do
  if h.kind == "fluid" then
    print(h.count, "mB的", h.name)
  else
    print(h.count, "x", h.name)
  end
end
```
</LuaCode>

### stackable

最大堆叠数大于1的物品（圆石、锭、木板……）返回`true`，工具、盔甲、各类独特物品（有自定义NBT的药水、成书）返回`false`。流体必然返回`false`，它们按体积计量，不按堆叠。

<LuaCode>
```lua
for _, item in inputChest:findEach("*") do
  if not item.stackable then
    nonStackables:insert(item)
  else
    network:insert(item)
  end
end
```
</LuaCode>

此示例可将不可堆叠的物品移到网络外的某箱子。

### maxStackSize

资源在单个物品栏槽位中能存放的最大数量。大多数物品都是`64`，雪球和末影珍珠是`16`，工具和盔甲是`1`。流体必然返回`1`，不具备实际意义。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
print(coal.maxStackSize) -- 64
```
</LuaCode>

### hasData

若堆叠的NBT不为默认值（魔咒、自定义名称、成书内容、盔甲染色、谜之炖菜效果等），则返回`true`。可用它将“特别”的物品从普通物品中分拣出去。

<LuaCode>
```lua
for _, item in inputChest:findEach("*") do
  if item.hasData then
    enchantedItems:insert(item)
  else
    network:insert(item)
  end
end
```
</LuaCode>

---

## 方法

### hasTag

若资源是所给标签的成员，返回`true`。标签ID开头有无`#`均可，即`"minecraft:logs"`和`"#minecraft:logs"`均可。

<LuaCode>
```lua
for _, h in network:findEach("*") do
  if h:hasTag("minecraft:logs") then
    print(h.name, "是一种原木")
  end
end
```
</LuaCode>

标签成员的判定方式于Minecraft在合成配方和生物群系设置中所用的一致，即可作为原版配方中“任意原木”的资源均匹配本示例。

### matches

若资源匹配所给筛选器，返回`true`。筛选器语法与[`network:find`](network.md#find)一致。适合用于路由谓词，以及跳过`:find`流程按物品分支。

<LuaCode>
```lua
function smelt(item: ItemsHandle)
  if item:matches("/_ore$/") then
    machine:insert(item)
    return
  end
  furnace:insert(item)
end
```
</LuaCode>

---

## 向传输方法传入handle

handle不只是只读值，也是**移动相应物品的来源**。大多数传输方法都需要handle作为参数，并会从各来源将资源移动到指定目的地。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  -- 全部搬到箱子里
  chest:insert(coal)
end
```
</LuaCode>

按此方式使用handle的方法有：

- [`card:insert`](card-handle.md#insert)/[`card:tryInsert`](card-handle.md#tryinsert)，送入卡片对应的物品栏
- [`network:insert`](network.md#insert)/[`network:tryInsert`](network.md#tryinsert)，按路由规则送入网络存储
- [`placer:place`](placer-handle.md#place)，使用handle的`.id`挑选放置物

handle的`.count`也是这些方法的移动上限。传入可选的第二个参数可设置更小的上限，适用于空间较小的目的地，如熔炉燃料槽：

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
furnace:insert(coal, 8) -- 向燃料槽补8个煤炭
```
</LuaCode>

> **注意：**&zwnj;`:insert`要么全部移动，要么不移动。若目的地无法容纳所移动的量，则什么都不会移动，且调用返回`false`。若能接受部分移动，可使用`:tryInsert`，也可提供第二个参数作为上限。

---

## 无物匹配时返回nil

筛选器没有匹配的资源时，`:find`和`findEach`会返回`nil`。`count = 0`的handle不可能存在，查询结果为空时返回值也为空。链式调用时务必检查：

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  print(coal.count, "个煤炭可用")
else
  print("网络存储中没有煤炭")
end
```
</LuaCode>

编辑器的类型系统会记录这一性质，鼠标悬停在`coal`上会显示`ItemsHandle?`（`?`是“或nil”记号），在忘记检查时也会进行提示。
