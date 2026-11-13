---
navigation:
  title: 板条箱与蚀刻
  icon: nautec:rusty_crate
  position: 6
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:etching_acid_bucket
  - nautec:crate
  - nautec:rusty_crate
---

# <Color id="light_purple">板条箱与蚀刻</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="rusty_crate" scale="2"/>
  板条箱可像箱子一样打开，生锈的板条箱则需先用蚀刻酸清洗。
</Column>

***

<Row>
  <ItemImage id="crate"/>
  ### <Color id="aqua">板条箱</Color>
</Row>

有27个槽位的容器，出现于水晶晶洞和原版沉船，也是海底废墟的战利品。右击可像箱子一样打开。可用漏斗送入和取出物品。

破坏板条箱会掉落其自身，保留其中内容物，无论已打开与否；找到的板条箱可以先带回家再打开。

***

<Row>
  <ItemImage id="rusty_crate"/>
  ### <Color id="aqua">生锈的板条箱</Color>
</Row>

从废墟中找到的、锈死的板条箱。它无法直接打开，其内容物不接受漏斗访问，直到蚀刻之后才会恢复原样：把它投入蚀刻酸，它会变为普通的板条箱并保留其中战利品。它的提示文本，以及试图直接打开时显示的消息都会给出同样的提示；JEI会在物品蚀刻分类下展示该蚀刻配方。

生锈板条箱的内容物比普通板条箱更好。可以破坏带走它，它会和普通的板条箱一样保留战利品。

***

## <Color id="gold">蚀刻</Color>

将物品投入蚀刻酸，等待配方耗时（8到10秒）之后即会得到清洗产物。整个堆叠会一起转化。

| 原材料                         | 产物                   | 耗时 |
| ------------------------------ | ---------------------- | ---- |
| 生锈的板条箱                   | 板条箱，保留战利品     | 10 s |
| <ItemLink id="rusty_gear"/>    | <ItemLink id="gear"/>  | 8 s  |
| <ItemLink id="ancient_valve"/> | <ItemLink id="valve"/> | 10 s |

JEI将这些配方归到了物品蚀刻分类下。

蚀刻时有三分之一的概率消耗物品所在的蚀刻酸源。流动的蚀刻酸不会被消耗，蚀刻酸池下部的方块也不会。不过，只要还有盈余的蚀刻酸，那么其实一格深的单个蚀刻酸源就已足够。

***

<Row>
  <ItemImage id="etching_acid_bucket"/>
  ### <Color id="aqua">蚀刻酸</Color>
</Row>

<RecipeFor id="etching_acid_bucket"/>

获得[搅拌机](nautec:laser_chemistry/mixer.md)之后，即可用盐水制造蚀刻酸。蚀刻酸很浓稠：你会在其中下沉，而且无法在其中快速行动；生物会选择绕过它。[深渊压力锻造机](nautec:deep_engineering/pressure_forge.md)的运作需要蚀刻酸。
