---
navigation:
  parent: crazyae2addons_index.md
  title: 数据提取器
  icon: crazyae2addons:data_extractor
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:data_extractor
  - crazyae2addons:player_data_extractor
---

# 数据提取器与玩家数据提取器指南

本指南会介绍在应用能源2（AE2）网络中使用**数据提取器**和**玩家数据提取器**的方法。这些部件可读取外部数据，并将其送至**ME数据控制器**。此后，该数据会以变量的形式存在，供自动化和逻辑设施使用。

---

## 数据提取器

**数据提取器**专长于从直接相邻的方块和方块实体中读取信息。

### 可读取的数据

* **物品管理器（Item handler）数据**

    * `percentFilled` – 已填充的物品栏槽位的百分比占比。
* **流体管理器（Fluid handler）数据**

    * `fluidPercentFilled` – 流体容器（tank）的填充程度。
    * `fluidAmount` – 当前流体的储量。
    * `fluidCapacity` – 容器的容量。
* **能量管理器（Energy handler）数据**

    * `storedEnergy` – 当前FE的储量。
    * `energyCapacity` – FE容器的最大容量。
* **方块状态（Block state）数据**

    * `blockName` – 方块的名称。
    * `isAir` – 方块是否是空气。
    * `isSolid` – 方块是否是固体方块。
    * `redstonePower` – 相邻方块的红石信号强度。
    * `blockLight` / `skyLight` – 方块处的光照等级。
    * `blockHardness` – 摧毁所需时间。
    * `blockExplosionResistance` – 爆炸抗性。
    * `blockState:property` – 任意方块状态属性（如朝向）。

* **安装有ComputerCraft Tweaked时功能更强**
  * 相当于CC电脑，且可从外围设备中读取信息。

### 使用方法

1. 面向读取目标**放置子部件**。
2. **右击**打开GUI。
3. 点击**拉取**/**Fetch**以侦测目标所有可用的变量。
4. 使用箭头按钮浏览可用变量。
5. 选择其一，为其分配**变量名**。
6. 设置**延时**（两次更新的间隔刻数）。
7. 选定的值会以所给名称发送至**ME数据控制器**。

---

## 玩家数据提取器

**玩家数据提取器**的功能与前者类似，但它会从玩家中读取，而非方块。

### 可读取的数据

* `playerName` – 玩家的名称。
* `playerHealth` / `playerMaxHealth` – 当前生命值和最大生命值。
* `playerDistance` – 与提取器的距离。
* `playerIsSneaking` – 玩家是否在潜行。
* `playerIsSprinting` – 玩家是否在疾跑。
* `playerYaw` – 玩家的水平旋转角度。
* `playerPitch` – 玩家的垂直旋转角度。

### 使用方法

1. **将子部件放置**于网络。
2. 放置时，其会自动将放置者识别为目标。
3. 打开GUI以查看可用变量。
4. 点击**拉取**/**Fetch**以刷新列表。
5. 选择其一，为其分配**变量名**。
6. 设置**延时**以控制更新频率。
7. 所选数据会发送至**ME数据控制器**。

默认情况下，提取器会搜寻**距离最近的玩家**。在**玩家模式**下，其会选定特定的UUID（放置它的玩家）。

---

## GUI控制（两者均适用）

* **拉取**/**Fetch** – 刷新可用变量。
* **箭头（< >）** – 滚动变量界面。
* **按钮（0–3）** – 选择列出的变量。
* **所选**/**Selected** – 显示当前选中的变量。
* **变量名** – 变量命名文本框（必须为ASCII字符，且会被转换为大写）。
* **延时** – 更新间隔，以刻计。
* **保存（+）** – 保存设置。

---

## 实用示例

* 对某流体储罐放置**数据提取器**。
* 拉取变量，选择`fluidAmount`。
* 将变量名设为`&WATER_LEVEL`。
* 此后即可在**ME数据控制器**中使用`&WATER_LEVEL`进行自动化。

---

这两种提取器都是强大的工具。它们能在AE2网络和**实时世界信息与玩家数据**间建立联系，以便进行高水平的自动化、状态监测，也可借此搭建功能自定的逻辑设施。
