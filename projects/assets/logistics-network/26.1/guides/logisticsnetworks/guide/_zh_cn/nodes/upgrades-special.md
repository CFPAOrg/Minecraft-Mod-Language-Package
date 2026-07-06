---
item_ids: [logisticsnetworks:dimensional_upgrade, logisticsnetworks:mekanism_chemical_upgrade, logisticsnetworks:ars_source_upgrade]
navigation:
  title: 特种升级
  parent: nodes/index.md
  icon: logisticsnetworks:dimensional_upgrade
  position: 5
---

# 特种升级

特种升级不会改动节点的吞吐量上限，而是会解锁**新能力**——跨维度传输、传输通用机械的化学品、传输新生魔艺的魔源。每一种都需占据一个升级槽，且可和同节点中的[性能升级](upgrades-performance.md)协同使用。

升级槽位于[过滤器与升级](filters-upgrades.md)面板。它们不接受重复升级，但不重复的升级可以随意添加——通常来说，高端节点的配置如下：下界合金级、跨维度、通用机械化学品、新生魔艺魔源各一。

## 跨维度升级

**解锁跨维度传输。**&zwnj;若未安装此升级，节点便仅能与同维度的节点交流。安装跨维度升级之后，节点就可同其他维度的节点收发资源——主世界和下界、末地和下界，以及其他模组维度。

**传输两端都需安装。**&zwnj;输出端和输入端都需安装跨维度升级。仅在其中一端安装无效——引擎会在跨维度传输前检查两端的节点。

同维度内的传输不受此升级影响——未安装此升级也可进行此类传输。

<RecipeFor id="logisticsnetworks:dimensional_upgrade" />

## 通用机械化学品升级

**解锁化学品频道类型。**&zwnj;若未安装此升级，[频道设置](channel-settings.md)中的类型便无法设为化学品。安装后，节点即可通过化学品频道感知和传输通用机械的化学品（气体、灌注类型、颜料、浆液）。

此升级仅会在经过配置的频道中生效。化学品输出端需要此升级，化学品输入端节点也需要。无需传输化学品的节点不用安装此升级。

需要安装**通用机械**模组才可合成和使用。下方配方仅会在加载有通用机械时出现。

<RecipeFor id="logisticsnetworks:mekanism_chemical_upgrade" fallbackText="安装通用机械以解锁此配方。" />

## 新生魔艺魔源升级

**解锁魔源频道类型。**&zwnj;与通用机械化学品升级一致，只不过对应的是新生魔艺魔源。安装后，即可将频道类型设为魔源，并在新生魔艺魔源罐和其他接受魔源的方块间进行传输。

需要传输魔源的所有节点（输出端和输入端）都需安装新生魔艺魔源升级。

需要安装**新生魔艺**模组才可合成和使用。下方配方仅会在加载有新生魔艺时出现。

<RecipeFor id="logisticsnetworks:ars_source_upgrade" fallbackText="安装新生魔艺以解锁此配方。" />
