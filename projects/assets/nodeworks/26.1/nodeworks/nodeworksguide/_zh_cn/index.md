---
navigation:
  title: 概览
  position: 0
item_ids:
- nodeworks:nodeworks_book
---

# 节点工程

可编程的物流和自动化网络。

<GameScene zoom="3" interactive={false} paddingTop="30" paddingRight="30" paddingLeft="10">
  <ImportStructure src="assets/assemblies/subnet.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <RemoveBlocks id="minecraft:sandstone" />
</GameScene>

## 章节

- [新手入门](./getting-started.md)
- [脚本参考](./lua-api/index.md)
- [节点工程机制](./nodeworks-mechanics/index.md)
- [物品/方块](./items-blocks/index.md)
- [示例设施](./example-setups/index.md)

在脚本终端的编辑器中，可以将鼠标悬停在任意有文档的标识符上，以查看其签名和描述。悬停时按下<Color id="green">[ <KeyBind id="key.nodeworks.open_docs" /> ]</Color>可打开相关页面。

有关添加文档的信息，参见[docs/authoring.md](https://github.com/damienfamed75/nodeworks/blob/main/docs/authoring.md)。
