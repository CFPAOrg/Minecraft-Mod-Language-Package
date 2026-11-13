---
navigation:
  title: 海洋发电器
  icon: nautec:tidal_rotor
  position: 16
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:tidal_rotor
  - nautec:thermal_vent_tap
---

# <Color id="light_purple">海洋发电器</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="tidal_rotor" scale="2"/>
    <ItemImage id="thermal_vent_tap" scale="2"/>
  </Row>
  这些发电机能利用海洋输出Forge能量（FE）供其他模组的机器使用。
</Column>

海蓝科技有四种FE发电器。潮汐转子机以海洋本身为动力源，喷口汇热器能利用海床的热量煮沸盐水，[燃烧发电机](nautec:getting_started/combustion_dynamo.md)可燃烧细菌产出的原油，[聚变反应堆](nautec:deep_engineering/fusion_plant.md)则是游戏后期的发电堆。所有发电器都会向相邻的线缆和机器送出FE。

***

<Row>
  <ItemImage id="tidal_rotor"/>
  ### <Color id="aqua">潮汐转子机</Color>
</Row>

前期可用的铸铁转子涡轮机，无需燃料，输出40到80 FE/t。

将它放在海洋生物群系的水下。处于刚好达到要求的位置时，可输出40 FE/t；水域越宽阔，深度越深，输出量越大。每一面都有水且上方有24格水时达到最大值80 FE/t。埋入海床，以及与其他转子机距离过近时，其输出量会下降。最好分散放置，而不是全部堆在一起。

***

<Row>
  <ItemImage id="thermal_vent_tap"/>
  ### <Color id="aqua">喷口汇热器</Color>
</Row>

游戏中期的发电器，能在岩浆块和熔岩上方煮沸盐水，输出350到1,250 FE/t。

* **热量。**&zwnj;汇热器会检查下方九个方块中有无岩浆块或熔岩。一个热源方块输出350 FE/t，九个热源方块输出1,250 FE/t。一个<ItemLink id="hydrothermal_vent"/>（来自热液喷口区）计作三个热源方块。在热液喷口区生物群系内，海床也计作三个热源，但需要至少已有一个热源方块。
* **燃料。**&zwnj;可从任意面注入盐水。汇热器运行时每刻蒸干10 mB，一台[深海排水口](nautec:laser_chemistry/drain.md)仅大致足够让两个汇热器运转。
* **盐。**&zwnj;每蒸干1,000 mB的盐水会留下一份<ItemLink id="salt"/>。汇热器会向箱子等相邻的容器输出盐，或也可用管道和漏斗抽取。槽位塞满只会停止产盐，但不会中断发电。

Jade可显示发电器的输出和未达成的需求。

<RecipeFor id="tidal_rotor"/>

<RecipeFor id="thermal_vent_tap"/>
