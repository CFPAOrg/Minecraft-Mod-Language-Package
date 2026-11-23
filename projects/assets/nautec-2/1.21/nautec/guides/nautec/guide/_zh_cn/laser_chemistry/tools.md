---
navigation:
  title: 海蓝钢工具
  icon: nautec:aquarine_steel_axe
  position: 8
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:aquarine_steel_sword
  - nautec:aquarine_steel_pickaxe
  - nautec:aquarine_steel_axe
  - nautec:aquarine_steel_shovel
  - nautec:aquarine_steel_hoe
---

# <Color id="light_purple">海蓝钢工具</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquarine_steel_axe" scale="2"/>
  依赖AP而非耐久度运作的工具，每一件都有可用EAS解锁的能力。
</Column>

## <Color id="gold">储能</Color>

这些工具不会损毁，只会在使用时消耗AP：挖掘大多数方块或击中生物消耗1 AP。图标下方的条栏可指示储能，详细数据在提示文本中。

工具耗尽AP后即失去挖掘、工具、使用功能，务必使用[充能器](charger.md)或[海晶电池](prismatic_battery.md)补充储能。锄可容纳700 AP，其他工具可容纳1,200。

***

## <Color id="gold">解锁能力</Color>

工具刚制成时能力仍处于锁定状态。倒出一桶[电解藻类浆液](chemistry_introduction.md)流体源，再将工具投入其中。等待约7.5秒，工具便会被注能，同时消耗EAS。

注能之后，持有工具Shift右击可开关其能力。启用能力后工具会发出光效。

***

<Row>
  <ItemImage id="aquarine_steel_pickaxe"/>
  ### <Color id="aqua">镐</Color>
</Row>

挖掘3x3区域的石材，也适用于破坏区域中其他可被镐挖掘的方块，每方块消耗2 AP。它会跳过箱子、机器等方块实体。

由能力破坏的方块会和用普通工具破坏一样掉落，如果想让时运或精准采集生效，需关闭能力。斧和锹在这方面上和镐一样。

开启能力的镐也可用于开凿<ItemLink id="prismarine_crystal"/>，参见[海晶水晶碎片](crystal_shards.md)。

<RecipeFor id="aquarine_steel_pickaxe"/>

***

<Row>
  <ItemImage id="aquarine_steel_axe"/>
  ### <Color id="aqua">斧</Color>
</Row>

破坏原木会连带破坏与它相连的所有原木，每方块消耗2 AP，直至砍倒整棵树或斧的储能耗尽。

<RecipeFor id="aquarine_steel_axe"/>

***

<Row>
  <ItemImage id="aquarine_steel_shovel"/>
  ### <Color id="aqua">锹</Color>
</Row>

每挖掘一个方块消耗1 AP。开启能力后，它会按3x3范围挖掘泥土、沙子、沙砾以及所有可被锹挖掘的方块，你点击的面即是破坏操作的交互面，每额外破坏一个方块消耗2 AP。它会跳过方块实体。

<RecipeFor id="aquarine_steel_shovel"/>

***

<Row>
  <ItemImage id="aquarine_steel_hoe"/>
  ### <Color id="aqua">锄</Color>
</Row>

一次性将3x3范围的泥土或草方块开垦为耕地，每方块消耗2 AP。

<RecipeFor id="aquarine_steel_hoe"/>

***

<Row>
  <ItemImage id="aquarine_steel_sword"/>
  ### <Color id="aqua">剑</Color>
</Row>

有AP且开启能力时能额外造成70%的伤害，并对击中的目标落雷。每次击中消耗10 AP。

<Color id="gold">注意</Color>：闪电会攻击目标周围几格内的所有东西，也包括你，同时有可能让周围着火。

<RecipeFor id="aquarine_steel_sword"/>
