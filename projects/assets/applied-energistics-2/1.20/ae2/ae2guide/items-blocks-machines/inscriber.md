---
navigation:
  parent: items-blocks-machines/items-blocks-machines-index.md
  title: 压印器
  icon: inscriber
  position: 310
categories:
- machines
item_ids:
- ae2:inscriber
---

# 压印器

<BlockImage id="inscriber" scale="8" />

压印器可用[压印模板](presses.md)压印电路板和[处理器](processors.md)，也可将若干物品打成粉末。它能接受AE2能量（AE）和Fabric/Forge能量（E/FE）。其可设置为面敏感，如此从不同面输入的物品会进入不同槽位。可用<ItemLink id="certus_quartz_wrench" />旋转以利用此特性。也可将其设置为将产物弹出至相邻容器。

输入缓存的大小可以调整。假如需要用单个容器为许多压印器提供材料，则可使用小缓存，以提高材料的分配效率（而非第一台填满至64个而其余的仍为空）。

4种电路板压印模板可用于制作[处理器](processors.md)。

<Row>
  <ItemImage id="silicon_press" scale="4" />

  <ItemImage id="logic_processor_press" scale="4" />

  <ItemImage id="calculation_processor_press" scale="4" />

  <ItemImage id="engineering_processor_press" scale="4" />
</Row>

而名称压印模板则可像铁砧一样命名物品，便于在<ItemLink id="pattern_access_terminal" />中标记事物。

<ItemImage id="name_press" scale="4" />

## 设置

* 压印器可设置为面敏感（解释见下），或是允许从所有面输入，并交由内部过滤决定目标槽位。在非面敏感模式下，无法从其顶部和底部槽位抽取物品。
* 压印器可设置为向相邻容器弹出物品。
* 压印器的输入缓存可调，大缓存适用于手动供材的独立压印器，而小缓存适合大量并行的压印器。


## GUI与面敏感性

处于面敏感模式时，压印器会根据物品输入输出的面决定其目标槽位。

![压印器GUI](../assets/diagrams/inscriber_gui.png) ![压印器各面](../assets/diagrams/inscriber_sides.png)

A. **顶面输入**需从顶面访问（允许输入输出）

B. **中央输入**需从左面、右面、前面、后面访问（允许输入，不允许输出）

C. **底部输入**需从底面访问（允许输入输出）

D. **输出**可从左面、右面、前面、后面抽出（允许输出，不允许输入）

## 简单自动化

如下例，压印器的面敏感性和可旋转性使其能按下述方式半自动化：

<GameScene zoom="4" background="transparent">
  <ImportStructure src="../assets/assemblies/inscriber_hopper_automation.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

也可以在非面敏感状态直接输入输出物品。

## 升级

压印器支持以下[升级](upgrade_cards.md)：

*   <ItemLink id="speed_card" />

## 配方

<RecipeFor id="inscriber" />
