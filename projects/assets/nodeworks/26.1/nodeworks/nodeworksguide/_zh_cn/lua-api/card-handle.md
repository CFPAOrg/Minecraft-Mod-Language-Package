---
navigation:
  parent: lua-api/index.md
  title: CardHandle
  icon: blank_card
categories:
  - api_types
description: 对网络中单张卡片的引用
---

# CardHandle

`CardHandle`（卡片句柄）是网络中单张卡片的引用。[`network:get(alias)`](network.md#get)或[`network:getAll(type)`](network.md#getAll)所返回[HandleList](handle-list.md)的返回值即为该类型。

<ItemImage scale="6" id="blank_card" />

---

## 属性

- **`.name`**
  - 卡片的别名（和终端侧边栏中的一致）

---

## 物品栏卡 <ItemImage scale="0.5" id="nodeworks:storage_card" /> <ItemImage scale="0.5" id="nodeworks:io_card" />

*适用于IO卡和存储卡。*&zwnj;两者公开的Lua API一致，区别只在于网络如何对待与两者相连的方块。有关世界中的行为参见<ItemLink id="storage_card" />和<ItemLink id="io_card" />。

### face

限制卡片为仅与相邻方块的特定面交互。当方块各面的物品栏不同时（熔炉输入/输出等）很有用。

默认情况下，卡片会选择它面对的面。

<GameScene zoom="5" interactive={true} paddingLeft="50" paddingRight="60">
  <ImportStructure src="../assets/assemblies/furnace_and_terminal.snbt" />
  <BoxAnnotation min="0 0.9 0" max="1 1.1 1" color="#00ff00">
    `card:face("top")`
  </BoxAnnotation>
  <BoxAnnotation min="1.1 0 0" max="0.9 1 1" color="#00ff00">
    `card`
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local card = network:get("io_1")
card:insert(coal)
card:face("top"):insert(inputItem)
```
</LuaCode>

### slots

按索引限制卡片为仅与物品栏的特定槽位交互（索引从1开始）。

<ItemGrid>
  <ItemIcon id="minecraft:cobblestone" />
  <ItemIcon id="minecraft:stone" components="minecraft:enchantment_glint_override=true,custom_name=Selected" />
  <ItemIcon id="minecraft:oak_planks" />
  <ItemIcon id="minecraft:diorite" components="minecraft:enchantment_glint_override=true,custom_name=Selected" />
  <ItemIcon id="minecraft:deepslate" />
  <ItemIcon id="minecraft:stick" />
</ItemGrid>

<LuaCode>
```lua
local card = network:get("io_1")
card:slots(2, 4):find("*") -- 选择石头和闪长岩
```
</LuaCode>

### find

扫描卡片的物品栏，搜索匹配筛选器的物品/流体。筛选器语法与[`network:find`](network.md#find)一致，区别仅在于作用域仅在卡片所对的槽位/流体容器，而不是网络中的所有存储卡。

<LuaCode>
```lua
local coalInCard = card:find("minecraft:coal")
if coalInCard then
  print("卡片中有", coalInCard.count, "个煤炭")
end
```
</LuaCode>

### findEach

与[find](./card-handle.md#find)一致，区别在于此方法会返回[ItemsHandle](./items-handle.md)列表，按物品ID和是否包含NBT数据去重。

若网络中有钻石剑，那么有魔咒的和无魔咒的会被分入不同条目。

<ItemGrid>
  <ItemIcon id="minecraft:cobblestone" />
  <ItemIcon id="minecraft:cobblestone" />
  <ItemIcon id="minecraft:oak_planks" />
  <ItemIcon id="minecraft:cobblestone" />
  <ItemIcon id="minecraft:oak_planks" />
  <ItemIcon id="minecraft:stick" />
</ItemGrid>

<LuaCode>
```lua
local allItems = card:findEach("*")
for _, val in allItems do
  print(val.name)
end
-- 圆石
-- 橡木木板
-- 木棍
```
</LuaCode>

### insert

将物品或流体*移入*此卡片的物品栏。要么全部移动，要么不移动，永远不会只移动一部分。完整移动时返回`true`，无法移动时返回`false`。和[`network:insert`](network.md#insert)一致，区别在于作用域限制于这张卡片。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal and card:insert(coal, 32) then
  print("已向卡片存储32个煤炭")
end
```
</LuaCode>

### tryInsert

与[`insert`](card-handle.md#insert)类似，但会按剩余空间移动，不只是全部移动或不移动。返回实际移动的数量（0到所请求数量）。无法传输的会留在来源中。若能接受部分移动，可使用此方法。

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  local moved = card:tryInsert(coal)
  print("移动了", coal.count, "个煤炭中的", moved, "个")
end
```
</LuaCode>

### count

返回此卡片所对物品栏中匹配筛选器的资源总数（流体以mB计）。

筛选器语法与[find](network.md#find)一致。

<LuaCode>
```lua
print(card:count("#minecraft:coals"))
```
</LuaCode>

---

## 红石卡 <ItemImage scale="0.5" id="nodeworks:redstone_card" />

*仅适用于<ItemLink id="redstone_card" />。*&zwnj;上文的物品栏方法无效，且红石卡的`card:find()`会返回`nil`。

### powered

输入红石信号大于0时返回`true`。

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_read_lever.snbt" />
  <BoxAnnotation min="1.2 0.2 1.2" max="1 0.8 1.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
print(card:powered())
-- true
```
</LuaCode>

### strength

返回输入的红石信号强度，值在0到15之间。

<GameScene zoom="5" interactive={true} paddingTop="10" paddingBottom="40" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_read_strength.snbt" />
  <BoxAnnotation min="3.2 1.2 0.2" max="3 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
print(card:strength())
-- "14"
```
</LuaCode>

### set

发出红石信号。布尔值会映射为15和0，与<ItemLink id="minecraft:lever" />类似。数则取上下限至0到15。

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_set_true.snbt" />
  <BoxAnnotation min="3 1 0.2" max="4 1.1 0.8">
    强度15
  </BoxAnnotation>
  <BoxAnnotation min="4.2 1.2 0.2" max="4 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
  <RemoveBlocks id="minecraft:stone" />
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
card:set(true) -- 和拉杆类似，发出强度为15的信号
card:set(false) -- 将输出信号的强度设为0
```
</LuaCode>

也可用数指定输出信号的强度。

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_set_low.snbt" />
  <BoxAnnotation min="3 1 0.2" max="4 1.1 0.8">
    强度3
  </BoxAnnotation>
  <BoxAnnotation min="4.2 1.2 0.2" max="4 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
  <RemoveBlocks id="minecraft:stone" />
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
card:set(3)
```
</LuaCode>

### onChange

注册一个回调函数，在输入信号的强度变化时触发。

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_onchange.snbt" />
  <BoxAnnotation min="3.2 1.2 0.2" max="3 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
  <BoxAnnotation min="0 1 0" max="3 2 2">
    红石钟/红石脉冲器
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
-- 红石火把点燃或熄灭时打印"状态已改变"
local lastPowered = card:powered()
card:onChange(function(strength: number)
    local powered = strength > 0
    if lastPowered == powered then
        return
    end
    lastPowered = powered
    print("状态已改变")
end)
```
</LuaCode>

> **提示：**&zwnj;建议在使用`:onChange`时启用<ItemLink id="terminal" />的[“自动运行”](../items-blocks/scripting_terminal.md#自动运行)。

![](../assets/images/autorun.png)

## 侦测卡 <ItemImage scale="0.5" id="nodeworks:observer_card" />

*仅适用于<ItemLink id="observer_card" />。*&zwnj;上文的物品栏方法无效，且侦测卡的`card:find()`会返回`nil`。卡片会监测所安装面前方的方块，并公开其ID、属性、状态改变事件。

### block

返回所监测位置方块的ID，形式为`"namespace:path"`字符串。

<LuaCode>
```lua
local watcher = network:get("watcher_1")
print(watcher:block())
-- "nodeworks:celestine_cluster"
```
</LuaCode>

若所监测位置的区块未被加载，调用时仍能返回缓存的方块（Minecraft会加载区块以读取）。建议在大型脚本中使用`:onChange`，而不是每刻调用`:block()`。

### state

返回所监测方块的属性表。键为方块的属性名（`age`、`facing`、`waterlogged`、`lit`、`axis`……）。根据属性种类的不同，返回值可为数、布尔值，以及全小写字符串。空气和其他无属性方块会返回空表。

<LuaCode>
```lua
local s = network:get("watcher_1"):state()
if s.age == 3 then
    print("已完全长成")
end
```
</LuaCode>

不同方块公开的属性不同，`state()`的返回值完全取决于所监测的方块。如果需要对监测方块的种类分支，可先使用`:block()`。

### onChange

注册一个回调函数，它会在所监测方块的ID或任意状态属性改变时触发。会替换同卡片已有的handler。handler会收到新方块的ID和新的属性表。

<LuaCode>
```lua
local watcher = network:get("watcher_1")
local breaker = network:get("breaker_1")

watcher:onChange(function(block: string, state: { [string]: any })
    if block == "nodeworks:celestine_cluster" then
        breaker:set(true)
        scheduler:delay(2, function() breaker:set(false) end)
    end
end)
```
</LuaCode>

注册后的第一次触发会静默使用“最后一次观察”得到的状态。若有方块在脚本重新启动前就已达到最终状态，脚本便不会触发伪事件。

> **提示：**&zwnj;和红石卡的`:onChange`类似，这种回调函数通常也需自动运行。可启用<ItemLink id="terminal" />的[“自动运行”](../items-blocks/scripting_terminal.md#自动运行)，以在不同游戏会话间不停触发handler。
