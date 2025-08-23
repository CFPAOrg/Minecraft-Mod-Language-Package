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

NBT输出总线是应用能源2（AE2）输出总线的高级版本，能**根据NBT数据**进行过滤和控制对存储空间的访问权限。

---

## 使用方法

1. **对容器方块放置**
    - 将NBT输出总线放置到箱子、抽屉，或任意具有物品容器的方块上。

2. **打开配置GUI**
    - 右击子部件以配置其过滤器和行为。
    - GUI中可以：
        - 设置输入/输出许可
        - 切换操作过滤器
        - 配置NBT匹配表达式

3. **编写NBT过滤器**
    - 使用文本输入区输入**NBT匹配表达式**。
    - 示例：
        - {Enchantments:[{id:"minecraft:sharpness"}]} - 只匹配拥有锋利魔咒的物品
        - {display:{Name:我的剑}} - 匹配“display”标签为“Name: 我的剑”的物品
        - {\*:"value"} - 如果*任意*NBT的值为"value"，则通过匹配
        - {key:!"value"} - 如果名为“key”的NBT键的值不为"value"，则通过匹配
    - 支持&&、||、!、nand等逻辑表达式。

4. **从物品中加载NBT**&zwnj;*（可选）*
    - 向对应槽位放入虚拟物品，然后按下**加载**/**Load**按钮。
    - 会自动将物品的NBT导入过滤器。

---

## 匹配系统

此处NBT表达式的解析器支持：

- **通配键和通配值**：“\*”
- **与/或/与非/异或逻辑**
- **递归键匹配**
- **反选语法**：!value

匹配表达式的物品才可由总线输出。