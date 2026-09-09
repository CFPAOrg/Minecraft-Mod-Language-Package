---
item_ids: [logisticsnetworks:dimensional_upgrade, logisticsnetworks:mekanism_chemical_upgrade, logisticsnetworks:ars_source_upgrade]
navigation:
  title: 特种升级
  parent: nodes/index.md
  icon: logisticsnetworks:dimensional_upgrade
  position: 5
---

# 特种升级

特种升级不会改动节点的吞吐量上限，而是会解锁**新能力**——跨维度升级可解锁跨维度传输，且可和同节点中的[性能升级](upgrades-performance.md)协同使用。化学品升级和魔源升级物品保留未来兼容使用，当前无作用。

升级槽位于[过滤器与升级](filters-upgrades.md)面板。它们不接受重复升级，但不重复的有效升级可以随意添加。

## 跨维度升级

**解锁跨维度传输。**&zwnj;若未安装此升级，节点便仅能与同维度的节点交流。安装跨维度升级之后，节点就可同其他维度的节点收发资源——主世界和下界、末地和下界，以及其他模组维度。

**传输两端都需安装。**&zwnj;输出端和输入端都需安装跨维度升级。仅在其中一端安装无效——引擎会在跨维度传输前检查两端的节点。

同维度内的传输不受此升级影响——未安装此升级也可进行此类传输。

<RecipeFor id="logisticsnetworks:dimensional_upgrade" />

## 通用机械化学品升级

此物品保留未来兼容使用。它当前不会解锁化学品频道和相应的传输能力。其配方仅会在加载有通用机械时出现。

<RecipeFor id="logisticsnetworks:mekanism_chemical_upgrade" fallbackText="安装通用机械以解锁此配方。" />

## 新生魔艺魔源升级

此物品保留未来兼容使用。它当前不会解锁魔源频道和相应的传输能力。其配方仅会在加载有新生魔艺时出现。

<RecipeFor id="logisticsnetworks:ars_source_upgrade" fallbackText="安装新生魔艺以解锁此配方。" />
