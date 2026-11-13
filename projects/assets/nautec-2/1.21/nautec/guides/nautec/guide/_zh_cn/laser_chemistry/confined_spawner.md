---
navigation:
  title: 约束刷怪笼
  icon: nautec:spawner_confinement_matrix
  position: 12
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:spawner_confinement_matrix
  - nautec:confined_spawner
  - nautec:mob_sampler
  - nautec:mob_sample
---

# <Color id="light_purple">约束刷怪笼</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="spawner_confinement_matrix" scale="2"/>
  将刷怪笼变成一台机器——能直接在其内部产生生物掉落物，无需生成生物。
</Column>

## <Color id="gold">如何约束刷怪笼</Color>

对刷怪笼使用刷怪笼约束矩阵。刷怪笼上会出现一个发光的符文环和一个金属框架，也即变成了约束刷怪笼。约束刷怪笼会保留原刷怪笼的所有数据：生物、一次生成多少、生成频率，以及所有升级。通过神化刷怪笼（Apothic Spawners）增强的刷怪笼也会保留其生成数量和延时，它们变来的约束刷怪笼运转得更快。

空手或手持约束矩阵潜行对约束刷怪笼按下使用键，可释放刷怪笼。它会变回普通的刷怪笼，保留生物和升级，并将矩阵返还至你的物品栏。只有储物空间和经验储罐均为空的刷怪笼可被释放，若不符会发出消息提醒你要先清空。

用镐破坏会让约束刷怪笼掉落自身，有无精准采集都是一样。掉落的物品会保留生物、设置、升级和筛选器，以便无损搬运。它也会保留其中的掉落物和经验，不会把东西散落一地。若需换回普通的刷怪笼，应先清空再释放。

## <Color id="gold">更改生物</Color>

在搅拌器中混合一个玻璃试管、两个海蓝铜锭、一个钻石和250 mB电解藻类浆液可制成<ItemLink id="mob_sampler"/>。一个配方产出一个取样器。

对活体生物使用取样器，可获得一份<ItemLink id="mob_sample"/>。生物不会因此移动或死亡。此操作消耗取样器，所得样本中会表明来源生物。适用于其他模组的生物。

对约束刷怪笼使用样本可消耗样本来更改生物。生成数量、延时、升级、筛选器、掉落物、经验保留不变，周期进度则重置。此后破坏、放置、释放刷怪笼都不会改变生物。样本不可对常规刷怪笼使用。

玩家、已死亡的生物、带有标签`c:capturing_not_supported`的实体均不可被取样。施加样本时会再次检查标签，在整合包改动标签前取得的样本也就无法使用。

<RecipeFor id="mob_sampler"/>

### <Color id="aqua">守卫者材料</Color>

守卫者很适合作为第一个取样对象。守卫者约束刷怪笼能够可再生地产出海晶碎片和海晶砂粒，以用作[海蓝催化器燃料](nautec:getting_started/laser_power.md)和合成原材料，制造海蓝铜混合物就需要用到它们。

这种刷怪笼还有概率产出<ItemLink id="ancient_valve"/>、<ItemLink id="burnt_coil"/>和<ItemLink id="guardian_eye"/>，可用于自动化供应可回收部件，也能为强化件和冲击激光模块提供足量的守卫者之眼。额外生物掉落物参见[回收](nautec:getting_started/salvage.md)，可回收部件的清理参见[板条箱与蚀刻](nautec:getting_started/etching.md)。

## <Color id="gold">供能</Color>

向任意面发射激光。刷怪笼能容纳最多500 AP，运行时每刻消耗50 AP，提供功率高于50 AP的光束就足够它一直运转下去。不过，激光过弱也不会导致它完全停工，只是会随着缓存填充而脉冲式地运转。供应功率的方式参见[激光功率](nautec:getting_started/laser_power.md)。

只要储能足够且缓存还有空间，它就会运转，不需要周围有玩家，也不要求光照或空间达成什么需求。运转时符文会亮起，笼中生物也会旋转得更快。

## <Color id="gold">掉落物</Color>

周期的耗时与刷怪笼自身的延时一致。周期结束时，刷怪笼会为本要生成的每一个生物抽选一次战利品。该操作视作玩家击杀，能产出玩家击杀战利品。产物会存入总计54槽（相当于大箱子）的暂存区。

若所有槽位均已满，刷怪笼即会暂停并保留内容物，直至腾出空间再继续。抽选后装不下的产物会被销毁。

默认情况下，漏斗和管道可从所有面取出物品（[面配置](nautec:getting_started/utilities.md)）。只有刷怪笼本身能向槽位放入物品。

## <Color id="gold">经验</Color>

刷怪笼还会保留生物本要掉落的经验，以液态经验的形式储存于16,000 mB容量的储罐。每点经验转换为20 mB，这也是大多数模组使用的转换比。储罐装满后再产出的经验会被销毁；经验堵塞不会阻碍刷怪笼的运转。

默认情况下，所用的流体是经验藻——一种发着绿光的流体。如果整合包里有其他模组添加了液态经验，可以在`config/nautec-common.toml`中的`confinedSpawnerXpFluids`处列出该流体的ID，刷怪笼会转而产出该流体。经验藻具有`c:experience`流体标签，接受该标签的事物也能接受它。

可以从任意面抽出经验（流体的[面配置](nautec:getting_started/utilities.md)与物品的相独立），也可用空铁桶右击刷怪笼。管道只能抽出。界面左侧的第三个条栏会显示填充程度。破坏刷怪笼会保留经验。

## <Color id="gold">界面</Color>

右击刷怪笼可查看其内容物，也可从中取出物品。面板左侧有三个条栏：AP处理、当前周期的进度、液态经验。将鼠标悬停在条栏上可查看数据。标题旁的状态指示会给出暂停运转的原因。

## <Color id="gold">筛选掉落物</Color>

标题旁的溜槽按钮可打开筛选器面板，其中有18个筛选器槽。

* 拿起物品点击槽位可筛选该物品。也可从JEI中拖放。
* 右击已有物品的槽位可依次切换其标签，循环一遍后回到筛选物品本身。标签筛选槽匹配标签下的所有物品，显示时附带一个金色的&zwnj;**#**。
* 用空光标点击槽位可清空。

顶部的按钮可在下方两个模式间切换：

* **黑名单**匹配所有未筛选的掉落物。
* **白名单**仅匹配筛选的掉落物。

刷怪笼不会产出筛选的掉落物，这些掉落物不会占用储物空间。空的白名单会阻止刷怪笼运转，直到指定筛选项才会恢复。

## <Color id="gold">Jade</Color>

Jade会显示约束刷怪笼的生物、它是否在运转、其AP储量，以及暂存空间的内容物。

***

### <Color id="aqua">刷怪笼约束矩阵的配方</Color>

<RecipeFor id="spawner_confinement_matrix"/>
