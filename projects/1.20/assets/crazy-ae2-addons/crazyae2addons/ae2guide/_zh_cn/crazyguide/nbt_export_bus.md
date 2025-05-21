---
navigation:
  parent: crazyae2addons_index.md
  title: NBT输出总线
  icon: crazyae2addons:nbt_export_bus
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:nbt_export_bus
---
# NBT输出总线

**如需禁用此总线，应在输入框为空时保存过滤器。**

NBT输出总线是一类子部件，可按照物品的NBT数据从ME网络中输出物品。输入任意有效的NBT标签字符串即可过滤输出物品，还可选择匹配所有标签或匹配标签之一。总线还支持`ANY`通配符；如果不需要指明具体标签值，只要求标签存在，通配符就能派上用场。例如：`{StoredEnchantments:ANY}`。

## 使用方法

1. **放置子部件**：将NBT输出总线放置在ME线缆上。
2. **打开设置**：右击子部件打开其配置界面。
3. **设置NBT过滤器**：在文本框中输入NBT过滤器字符串（例如`{StoredEnchantments:[{lvl:5S,id:"minecraft:sharpness"}]}`）。**`lvl:5S`中的`S`也很重要！**
4. **选择匹配模式**：“匹配全部”/“Match Any”勾选框可让总线在输出时匹配*任一*标签（未勾选）或匹配*全部*标签（勾选）。
5. **保存**：点击“保存”/“Save”。总线即会从ME存储空间中取出匹配的物品，并送入相邻的容器。

将NBT输出总线设为`{ANY:ANY}`，并启用`Match Any`，即可轻松输出ME系统中所有携带NBT标签的物品。