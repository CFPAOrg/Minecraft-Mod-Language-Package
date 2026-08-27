---
navigation:
  parent: lua-api/index.md
  title: InputItems
  icon: minecraft:cobblestone
categories:
  - api_types
description: "[network:handle回调函数](network.md#handle)需接受的第二个参数，是按配方打包的[`ItemsHandle`](items-handle.md)，按配方输入槽位名称分入各字段"
---

# InputItems

`InputItems`（输入物品）是[`network:handle`](network.md#handle)需接受的第二个参数。网络已经从网络存储中抽出了配方的原材料，汇总结果就是这张表，其中每个字段都对应着一个输出槽位。你需要做的，是把这些物品送到机器中去。

每一个字段都是完整的[ItemsHandle](items-handle.md)对象，可以像其他handle一样对其调用`:insert`、`:tryInsert`、`:count`等。

## 字段名称

字段名称为**驼峰命名（camelCase）的输入物品ID**。也即`minecraft:raw_iron`会变为`items.rawIron`，`minecraft:copper_ingot`会变为`items.copperIngot`。脚本编辑器会根据配方自动补全，无需专门记忆。

<LuaCode>
```lua
local furnace = network:get("furnace")
network:handle("...", function(job: Job, items: InputItems)
  furnace:face("top"):insert(items.rawIron) -- minecraft:raw_iron
  job:pull(furnace:face("bottom"))
end)
```
</LuaCode>

### 重复的原材料

若配方在多个槽位中的原材料相同，则第二次出现处加后缀`2`，第三次加`3`，以此类推。所以需要两个铜锭和一个金锭的配方会公开为`items.copperIngot`、`items.goldIngot`、`items.copperIngot2`。

<LuaCode>
```lua
local press = network:get("press")
network:handle("...", function(job: Job, items: InputItems)
  press:face("top"):insert(items.copperIngot)
  press:face("top"):insert(items.copperIngot2)
  press:face("north"):insert(items.goldIngot)
  job:pull(press:face("bottom"))
end)
```
</LuaCode>

## 必须全部使用

handler应当将所有输入都送入机器。若在handler返回时仍有资源残余在`items.<slot>`中，则网络会认为当次合成作业未完成，并在之后再次尝试。没有“跳过该输入”的方法，配方说需要N个铜锭，那就应当取走N个铜锭。

> **注意：**&zwnj;“使用”指的是将物品送到可被访问的地方，通过`network:insert`送回网络存储也可以。网络只会检查“脚本有没有完全消耗掉输入”，而不关心“输入有没有抵达正确的机器”。
