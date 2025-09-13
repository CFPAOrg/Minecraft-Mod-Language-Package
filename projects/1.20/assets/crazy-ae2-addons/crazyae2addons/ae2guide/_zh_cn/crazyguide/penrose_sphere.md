---
navigation:
  parent: crazyae2addons_index.md
  title: 彭罗斯球
  icon: crazyae2addons:penrose_controller
categories:
  - Energy and Item Transfer
item_ids:
   - crazyae2addons:penrose_controller
   - crazyae2addons:penrose_frame
   - crazyae2addons:penrose_coil
   - crazyae2addons:penrose_port
---

# 彭罗斯球

<GameScene zoom="0.5" interactive={true}>
  <ImportStructure src="../assets/penrose_sphere.nbt" />
</GameScene>

彭罗斯球是游戏后期的多方块产能设备，其中的**超级奇点**能将**物质**转变成Forge能量（Forge Energy，FE）。是一种扩展性极强的能量源。

---

## 工作原理

1. **放入存储元件**
   - 只接受仅装有超级奇点的**1k物品存储元件**。
   - 需放入左侧元件槽。

2. **放入超级奇点**
   - 向右侧输入槽放入超级奇点，点击箭头可向元件存入/从元件取出。
   - 元件中超级奇点数量越多，多方块结构的能量产出量就越高。

3. **设置目标资源**
   - 在配置槽中设定目标物品，如圆石、奇点、物质球等。
   - 决定了能量的产出量。

4. **自动化产能**
   - 控制器每刻会消耗ME网络中的目标物品。
   - 根据元件中超级奇点的数量产出FE。
   - 可从任意彭罗斯框架处取出能量。
   - 能量端口会向相邻方块主动输出。

5. **升级**
   - 此结构共有4级，每级都会增加1个存储元件槽。也就是说，可以放进更多奇点，产出更多能量。
   - 每级都额外让能量产出量变为2倍。

---

## 能量产出

- 只有1个超级奇点、接受“普通”物品作为输入时，能量产出最低，接近于零。
- 物质球和奇点会增加输出：
  - 使用物质球时：**+8x**
  - 使用AE2奇点时：**+64x**
- 最大功率：约1000MFE/t（放入4个装满的元件、使用奇点作为燃料时），是通用机械（Mekanism）聚变反应堆的4倍。

---

## 注意事项

- 多方块结构缺损即停工。
- 能量会存储于控制器内部。
- 可从任意彭罗斯框架处取出能量。
- 能量会从彭罗斯端口处主动输出。
- 与所有基于FE的系统兼容。
- 可以为ME系统功能，也适用于其他使用FE的事物。
