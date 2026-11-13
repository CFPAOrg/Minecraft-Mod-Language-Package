---
navigation:
  title: 回收
  icon: nautec:atlantic_gold_nugget
  position: 4
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:atlantic_gold_nugget
  - nautec:atlantic_gold_ingot
  - nautec:prismarine_lens
---

# <Color id="light_purple">回收</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="atlantic_gold_nugget" scale="2"/>
  海蓝科技中各种探索所得资源的出处。
</Column>

许多海蓝科技的配方都需要用到可搜寻修复而非合成制造的部件。本页列出了它们的来源出处。[远古机器部件](machine_part.md)页面则介绍了修复方法。

***

## <Color id="gold">结构</Color>

| 地点                     | 可得资源                                                                                                                                                                                                                     |
| ------------------------ | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| 海底废墟（海蓝科技）     | 一个海蓝催化器、一个生锈的板条箱、可疑的沙砾                                                                                                                                                                                 |
| 水晶晶洞                 | 装有大量部件和材料的木桶、板条箱以及生锈的板条箱                                                                                                                                                                             |
| 沉船宝藏箱子             | 三分之二概率出现一个板条箱                                                                                                                                                                                                   |
| 原版海底废墟箱子         | 三分之二概率出现一个板条箱，四分之一概率出现零散回收品：海晶水晶碎片、海洋金粒、生锈的齿轮、烧坏的线圈、远古阀门、损坏的海蓝芯片、破损的搅拌器、深海海带，偶会出现海晶透镜。大型废墟中有概率出现海蓝钢锭、共鸣碎片、潜水头盔 |
| 暖水海底废墟内可疑的沙子 | 偶会出现板条箱                                                                                                                                                                                                               |
| 埋藏的宝藏               | 损坏的海蓝芯片，概率略低于一半                                                                                                                                                                                               |

来自原版箱子的板条箱中会出现烧坏的线圈、<ItemLink id="brown_polymer"/>、铸铁锭、海蓝钢混合物、海洋金粒、海晶石、铁、金。海蓝科技结构中板条箱内容物参见[结构](structures.md)，如何打开板条箱参见[板条箱与蚀刻](etching.md)。

***

## <Color id="gold">生物掉落物</Color>

| 生物       | 额外掉落物                                                 |
| ---------- | ---------------------------------------------------------- |
| 守卫者     | 五分之一概率：远古阀门、烧坏的线圈、或守卫者之眼           |
| 远古守卫者 | 必定，从远古阀门、生锈的齿轮、烧坏的线圈、邪能之心中选三次 |
| 溺尸       | 五分之一概率：破损的搅拌器或溺尸之肺                       |
| 海豚       | 五分之一概率：海豚鳍                                       |

生物器官（守卫者之眼、邪能之心、溺尸之肺、海豚鳍）都可用作强化件：参见[生物强化件](nautec:laser_augmentation/mob_augments.md)。深海生物也有独特的掉落物，详见[深海生物](deep_life.md)。

***

## <Color id="gold">垂钓</Color>

幸运垂钓区和海晶钓鱼竿能抽选额外战利品，范围包括生锈的齿轮、远古阀门、破损的搅拌器、海晶透镜、海洋金粒，也包括所在生物群系的稀有战利品。参见[垂钓](fishing.md)。

***

<Row>
  <ItemImage id="atlantic_gold_nugget"/>
  ### <Color id="aqua">海洋金</Color>
</Row>

<ItemLink id="atlantic_gold_nugget"/>会出现于板条箱、生锈的板条箱，以及任意海洋的幸运区宝藏。九个粒可合成<ItemLink id="atlantic_gold_ingot"/>，锭可合成回九个粒。之后会有更可靠的制造手段：位于Y -20及以下的[深渊压力锻造机](nautec:deep_engineering/pressure_forge.md)可将金块锻压为两个海洋金锭，需要纯度2.0的光束，耗时15秒。

<Recipe id="nautec:atlantic_gold_ingot_from_nuggets"/>

<Recipe id="nautec:atlantic_gold_nuggets_from_ingot"/>

海洋金锭是海洋斥候、太阳能模块、声呐模块、辅助心室强化件、共鸣护符的原材料，再之后还需用于制造聚变反应堆部件、育晶仪、海棱人造卫星和共鸣网络方块。

***

<Row>
  <ItemImage id="prismarine_lens"/>
  ### <Color id="aqua">海晶透镜</Color>
</Row>

制造细菌分析机、移植站、激光注入器、海晶送电器、冲击激光模块、太阳能模块、声呐模块以及不少后期机器的原材料。可用海蓝钢合成，也可在幸运区中作为宝藏钓起。

<RecipeFor id="prismarine_lens"/>
