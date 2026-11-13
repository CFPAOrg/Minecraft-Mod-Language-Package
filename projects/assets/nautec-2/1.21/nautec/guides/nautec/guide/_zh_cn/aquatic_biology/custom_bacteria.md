---
navigation:
  title: 自定义细菌
  icon: minecraft:command_block
  position: 14
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">自定义细菌</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="minecraft:command_block" scale="2"/>
  可为任意物品创建新细菌品系的管理员命令。
</Column>

该页是为服务端管理员和整合包作者们准备的。此处命令需要管理员权限（2级）。

***

## <Color id="gold">创建品系</Color>

`/nautec bacteria generate <名称> <物品> [稀有度]`

创建名为`<名称>`、产出`<物品>`的品系，同时创建使用该物品为营养物质的培养配方、使用该营养物质的菌落喂养配方、使用该物品为诱变剂的突变配方。稀有度会设置起始时数据、培养增长、突变概率和[品系产量](production_rates.md)，也决定了它突变自哪种细菌：

| 稀有度           | 突变自   | 品系产量 |
| ---------------- | -------- | -------- |
| common           | 嗜岩石菌 | 1        |
| uncommon（默认） | 嗜金属菌 | 0.8      |
| rare             | 嗜铁菌   | 0.6      |
| epic             | 嗜金菌   | 0.4      |
| legendary        | 嗜金刚菌 | 0.12     |

`/nautec bacteria generate-tag <名称> <物品> <标签> [稀有度]`的功能相同，但会以整个物品标签作为营养物质。

在两个命令最后使用`preview`，均可将文件打印至聊天栏供点击复制，而不会实际写入文件。

***

## <Color id="gold">移植来源</Color>

`/nautec bacteria obtain <名称> <方块> <生物群系标签> <概率>`

允许玩家从`<生物群系标签>`下任意生物群系中的`<方块>`移植该品系的细菌，概率可为0到1。不允许使用已是海蓝科技中移植来源的方块。

***

## <Color id="gold">管理</Color>

* `/nautec bacteria list-generated`会列出所有生成的品系、各品系的产物，以及它们有哪些配方。
* `/nautec bacteria delete-generated <名称>`会移除品系的文件及其移植条目。

所有文件均在`config/nautec/generated_pack`中，可供游戏实例中的所有世界共享。运行`/reload`可加载新配方和移植来源。新品系会在下一次加入世界时加载。
