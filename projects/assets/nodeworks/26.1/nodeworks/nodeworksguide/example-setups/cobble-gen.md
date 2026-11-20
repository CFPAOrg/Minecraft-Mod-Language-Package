---
navigation:
  parent: example-setups/index.md
  icon: minecraft:cobblestone
  title: Cobblestone Generator
categories:
  - example
---

# Cobblestone Generator

Cobblestone generators is the simplest way to use a <ItemLink id="breaker" />.
Place a Breaker in front of a cobblestone generator like the following

<GameScene zoom="5" interactive={true} paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/cobble_gen.snbt" />
  <IsometricCamera yaw="200" pitch="30" />
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:stone" />
</GameScene>

Then you configure the Breaker to break `minecraft:cobblestone` with the redstone
mode set to **Low** to make it always active.

![image of the breaker GUI with cobblestone set as its filter to break](../assets/images/breaker_cobblestone.png)

Or if you had a <ItemLink id="terminal" /> in your network you can use the following
script to achieve the same thing but for many breakers.

<LuaCode>
```lua
local breaker_1 = network:get("breaker_1")
scheduler:second(function()
    breaker_1:mine() -- always mine
end)
```
</LuaCode>