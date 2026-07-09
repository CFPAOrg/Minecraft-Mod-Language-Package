---
navigation:
  parent: lua-api/index.md
  title: CardHandle
  icon: blank_card
categories:
  - api_types
description: reference to a single card in a network
---

# CardHandle

A reference to a single card on the network. You get one from [`network:get(alias)`](network.md#get)
or from a [HandleList](handle-list.md) returned by [`network:getAll(type)`](network.md#getAll).

<ItemImage scale="6" id="blank_card" />

---

## Properties

- **`.name`**
  - the card's alias (same label shown in the terminal sidebar)

---

## Inventory Cards <ItemImage scale="0.5" id="nodeworks:storage_card" /> <ItemImage scale="0.5" id="nodeworks:io_card" />

*Applies to IO Cards and Storage Cards.* Both expose the same Lua API, the
difference is in how the network treats the block they're attached to. See
<ItemLink id="storage_card" /> and <ItemLink id="io_card" /> for the in-world
behavior.

### face

Narrow to a specific face of the adjacent block. Useful when the block
has a different inventory on each side (furnace inputs vs outputs, etc.).

By default a card will choose the face it's facing.

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

Narrow the card's inventory to specific slots using their indices (index starts at 1)

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
card:slots(2, 4):find("*") -- selects Stone and Diorite
```
</LuaCode>

### find

Scans the card's inventory for items/fluids matching the filter. Filter syntax is
identical to [`network:find`](network.md#find), the only difference is the scope
is this card's slots/tanks instead of very storage card on the network.

<LuaCode>
```lua
local coalInCard = card:find("minecraft:coal")
if coalInCard then
  print(coalInCard.count, "coal in this card")
end
```
</LuaCode>

### findEach

Identical to [find](./card-handle.md#find) except this returns a list of [ItemsHandle](./items-handle.md)'s.
Each entry is unique by its Item ID and if it contains NBT Data.

If you had diamond sword in your network, some with enchantments and some without
they would be separated into different entries

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
-- Cobblestone
-- Oak Planks
-- Stick
```
</LuaCode>

### insert

Moves items or fluids *into* this card's inventory. Either the full amount fits and
moves or nothing moves at all. You never end up with a partial transfer.
Returns `true` when the full amount landed, `false` if it wouldn't fit.
Mirrors [`network:insert`](network.md#insert) except it's scoped to this card.

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal and card:insert(coal, 32) then
  print("stored 32 coal in this card")
end
```
</LuaCode>

### tryInsert

Like [`insert`](card-handle.md#insert) but moves whatever fits instead of
all-or-nothing. Returns the count that actually landed (0 up to the requested amount).
Anything that didn't fit stays in the source. Use this when a partial move is fine.

<LuaCode>
```lua
local coal = network:find("minecraft:coal")
if coal then
  local moved = card:tryInsert(coal)
  print("moved", moved, "of", coal.count, "coal")
end
```
</LuaCode>

### count

Returns the total quantity in this card's inventory
that matches the filter. (Fluids count in mB)

The filtering is the exact same syntax as [find](network.md#find)

<LuaCode>
```lua
print(card:count("#minecraft:coals"))
```
</LuaCode>

---

## Redstone Card <ItemImage scale="0.5" id="nodeworks:redstone_card" />

*Applies to <ItemLink id="redstone_card" />'s only.* The inventory methods above don't apply, a
redstone card's `card:find()` is nil.

### powered

Returns `true` if the incoming redstone signal is greater than 0.

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

Returns the incoming redstone signal strength from 0 to 15.

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

Emits a redstone signal. Boolean maps to 15 or 0 just like a <ItemLink id="minecraft:lever" />. Number is clamped to 0 to 15.

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_set_true.snbt" />
  <BoxAnnotation min="3 1 0.2" max="4 1.1 0.8">
    15 strength
  </BoxAnnotation>
  <BoxAnnotation min="4.2 1.2 0.2" max="4 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
  <RemoveBlocks id="minecraft:stone" />
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
card:set(true) -- emit a signal of 15 strength like a lever
card:set(false) -- set emitted signal to 0
```
</LuaCode>

You can use a number to specify the strength of the signal emitted

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_set_low.snbt" />
  <BoxAnnotation min="3 1 0.2" max="4 1.1 0.8">
    3 strength
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

Registers a callback fired whenever the incoming redstone signal strength changes.

<GameScene zoom="5" interactive={true} paddingTop="10" paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/redstone_onchange.snbt" />
  <BoxAnnotation min="3.2 1.2 0.2" max="3 1.8 0.8" color="#F53B68">
    <ItemImage id="nodeworks:redstone_card" />
  </BoxAnnotation>
  <BoxAnnotation min="0 1 0" max="3 2 2">
    redstone clock/pulser
  </BoxAnnotation>
</GameScene>

<LuaCode>
```lua
local card = network:get("redstone_1")
-- print "state changed" when redstone torch turns on and off
local lastPowered = card:powered()
card:onChange(function(strength: number)
    local powered = strength > 0
    if lastPowered == powered then
        return
    end
    lastPowered = powered
    print("state changed")
end)
```
</LuaCode>

> **Tip:** It's also recommended to turn on the ["Autorun"](../items-blocks/scripting_terminal.md#autorun) of the <ItemLink id="terminal" />
> when using `:onChange`

![](../assets/images/autorun.png)

## Observer Card <ItemImage scale="0.5" id="nodeworks:observer_card" />

*Applies to <ItemLink id="observer_card" />'s only.* The inventory methods above
don't apply. An observer card's `card:find()` is nil. The card watches the block
in front of the installed face and exposes its id, properties, and a change event.

### block

Returns the block id at the watched position as a `"namespace:path"` string.

<LuaCode>
```lua
local watcher = network:get("watcher_1")
print(watcher:block())
-- "nodeworks:celestine_cluster"
```
</LuaCode>

If the watched chunk isn't loaded the call still returns the cached block (Minecraft
will load the chunk to read it). For high-volume scripts prefer `:onChange` over
polling `:block()` every tick.

### state

Returns the property table for the watched block. Keys are the block's
property names (`age`, `facing`, `waterlogged`, `lit`, `axis`, ...). Values
come back as numbers, booleans, or lowercase strings depending on the
property's type. Air and other propertyless blocks return an empty table.

<LuaCode>
```lua
local s = network:get("watcher_1"):state()
if s.age == 3 then
    print("fully grown")
end
```
</LuaCode>

Different blocks expose different properties, what `state()` returns depends
entirely on what the watched block is. Use `:block()` first if you need to
branch on which block you're inspecting.

### onChange

Registers a callback that fires whenever the watched block id or any state
property changes. Replaces any previous handler on the same card. The handler
receives the new block id and the new property table.

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

The first poll after registration seeds the "last seen" state silently, a
script that restarts won't fire a phantom event for a block that was already
in its final form before the script came up.

> **Tip:** Like the redstone `:onChange`, this is the kind of callback you'll
> usually want autorunning. Turn on ["Autorun"](../items-blocks/scripting_terminal.md#autorun)
> on the <ItemLink id="terminal" /> so the handler keeps firing across logins.
