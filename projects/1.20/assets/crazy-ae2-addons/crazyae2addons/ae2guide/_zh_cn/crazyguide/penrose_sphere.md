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
---

# 彭罗斯球

<Row>
   <BlockImage id="crazyae2addons:penrose_controller" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:penrose_frame" scale="4"></BlockImage>
   <BlockImage id="crazyae2addons:penrose_coil" scale="4"></BlockImage>
</Row>

彭罗斯球是游戏后期的多方块产能设备，其中的**超级奇点**能将**物质**转变成Forge能量（Forge Energy，FE）。它的能量产出量可以自行调控。

---

## 结构示例

此结构为7x3x7的多方块，包含彭罗斯框架和彭罗斯线圈。在[Github Wiki](https://github.com/GilbertzRivi/CrazyAE2Addons/wiki/penrose_sphere)可读性更好。

- **F** – 彭罗斯框架
- **O** – 彭罗斯线圈
- **C** – 彭罗斯控制器

#### 第1层：
F F F F F F F F F F F<br/>
F A A A A A A A A A F<br/>
F A A A A A A A A A F<br/>
F A A A F O F A A A F<br/>
F A A F F O F F A A F<br/>
F A A O O O O O A A F<br/>
F A A F F O F F A A F<br/>
F A A A F O F A A A F<br/>
F A A A A A A A A A F<br/>
F A A A A A A A A A F<br/>
F F F F F F F F F F F

#### 第2层：
F A A A A A A A A A F<br/>
A A A A A A A A A A A<br/>
A A A F F O F F A A A<br/>
A A F F A A A F F A A<br/>
A A F A A A A A F A A<br/>
A A O A A A A A O A A<br/>
A A F A A A A A F A A<br/>
A A F F A A A F F A A<br/>
A A A F F O F F A A A<br/>
A A A A A A A A A A A<br/>
F A A A A A A A A A F

#### 第3层：
F A A A A A A A A A F<br/>
A A A F F O F F A A A<br/>
A A F F A A A F F A A<br/>
A F F A A A A A F F A<br/>
A F A A A A A A A F A<br/>
A O A A A A A A A O A<br/>
A F A A A A A A A F A<br/>
A F F A A A A A F F A<br/>
A A F F A A A F F A A<br/>
A A A F F O F F A A A<br/>
F A A A A A A A A A F

#### 第4层：
F A A A F O F A A A F<br/>
A A F F F A F F F A A<br/>
A F F A A A A A F F A<br/>
A F A A A A A A A F A<br/>
F F A A A A A A A F F<br/>
O A A A A A A A A A O<br/>
F F A A A A A A A F F<br/>
A F A A A A A A A F A<br/>
A F F A A A A A F F A<br/>
A A F F F A F F F A A<br/>
F A A A F O F A A A F

#### 第5层：
F A A F F O F F A A F<br/>
A A F F A A A F F A A<br/>
A F A A A A A A A F A<br/>
F F A A A A A A A F F<br/>
F A A A A A A A A A F<br/>
O A A A A A A A A A O<br/>
F A A A A A A A A A F<br/>
F F A A A A A A A F F<br/>
A F A A A A A A A F A<br/>
A A F F A A A F F A A<br/>
F A A F F O F F A A F

#### 第6层：
F A A O O O O O A A F<br/>
A A O A A A A A O A A<br/>
A O A A A A A A A O A<br/>
O A A A A A A A A A O<br/>
O A A A A A A A A A O<br/>
O A A A A A A A A A O<br/>
O A A A A A A A A A O<br/>
O A A A A A A A A A O<br/>
A O A A A A A A A O A<br/>
A A O A A A A A O A A<br/>
F A A O O C O O A A F

#### 第7层：
F A A F F O F F A A F<br/>
A A F F A A A F F A A<br/>
A F A A A A A A A F A<br/>
F F A A A A A A A F F<br/>
F A A A A A A A A A F<br/>
O A A A A A A A A A O<br/>
F A A A A A A A A A F<br/>
F F A A A A A A A F F<br/>
A F A A A A A A A F A<br/>
A A F F A A A F F A A<br/>
F A A F F O F F A A F

#### 第8层：
F A A A F O F A A A F<br/>
A A F F F A F F F A A<br/>
A F F A A A A A F F A<br/>
A F A A A A A A A F A<br/>
F F A A A A A A A F F<br/>
O A A A A A A A A A O<br/>
F F A A A A A A A F F<br/>
A F A A A A A A A F A<br/>
A F F A A A A A F F A<br/>
A A F F F A F F F A A<br/>
F A A A F O F A A A F

#### 第9层：
F A A A A A A A A A F<br/>
A A A F F O F F A A A<br/>
A A F F A A A F F A A<br/>
A F F A A A A A F F A<br/>
A F A A A A A A A F A<br/>
A O A A A A A A A O A<br/>
A F A A A A A A A F A<br/>
A F F A A A A A F F A<br/>
A A F F A A A F F A A<br/>
A A A F F O F F A A A<br/>
F A A A A A A A A A F

#### 第10层：
F A A A A A A A A A F<br/>
A A A A A A A A A A A<br/>
A A A F F O F F A A A<br/>
A A F F A A A F F A A<br/>
A A F A A A A A F A A<br/>
A A O A A A A A O A A<br/>
A A F A A A A A F A A<br/>
A A F F A A A F F A A<br/>
A A A F F O F F A A A<br/>
A A A A A A A A A A A<br/>
F A A A A A A A A A F

#### 第11层：
F F F F F F F F F F F<br/>
F A A A A A A A A A F<br/>
F A A A A A A A A A F<br/>
F A A A F O F A A A F<br/>
F A A F F O F F A A F<br/>
F A A O O O O O A A F<br/>
F A A F F O F F A A F<br/>
F A A A F O F A A A F<br/>
F A A A A A A A A A F<br/>
F A A A A A A A A A F<br/>
F F F F F F F F F F F

搭建完成后，框架方块的外观会发生变化。

---

## 工作原理

1. **放入存储元件**
   - 只接受仅装有超级奇点的**4k物品存储元件**。
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

---

## 能量产出

- 最低产量出现于1个超级奇点、接受“普通”物品时，为1024FE/t。
- 物质球和奇点会增加输出：
  - 使用物质球时：**+8x**
  - 使用AE2奇点时：**+64x**
- 最大功率：约1000MFE/t，在元件装满超级奇点、使用奇点作为燃料时达成，是通用机械（Mekanism）聚变反应堆的4倍。

---

## 注意事项

- 多方块结构缺损即停工。
- 能量会存储于控制器内部。
- 可从任意彭罗斯框架处取出能量。
- 与所有基于FE的系统兼容。
