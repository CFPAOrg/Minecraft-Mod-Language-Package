---
navigation:
  parent: example-setups/index.md
  icon: minecraft:cobblestone
  title: 刷石机
categories:
  - example
---

# 刷石机

刷石机是<ItemLink id="breaker" />最简单的应用方式。按下方示例在刷石机前放置破坏器

<GameScene zoom="5" interactive={true} paddingLeft="60" paddingRight="30">
  <ImportStructure src="../assets/assemblies/cobble_gen.snbt" />
  <IsometricCamera yaw="200" pitch="30" />
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:sandstone" />
  <RemoveBlocks id="minecraft:stone" />
</GameScene>

再将破坏器配置为破坏`minecraft:cobblestone`，将红石模式设为**低**以保持运作。

![破坏器GUI，破坏筛选器为圆石](../assets/images/breaker_cobblestone.png)

若网络中有<ItemLink id="terminal" />，则也可使用下方脚本达成相同功能，适用于多台破坏器。

<LuaCode>
```lua
local breaker_1 = network:get("breaker_1")
scheduler:second(function()
    breaker_1:mine() -- 一直挖掘
end)
```
</LuaCode>