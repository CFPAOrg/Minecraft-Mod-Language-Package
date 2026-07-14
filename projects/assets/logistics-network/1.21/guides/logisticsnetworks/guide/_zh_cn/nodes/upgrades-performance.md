---
item_ids: [logisticsnetworks:iron_upgrade, logisticsnetworks:gold_upgrade, logisticsnetworks:diamond_upgrade, logisticsnetworks:netherite_upgrade]
navigation:
  title: 性能升级
  parent: nodes/index.md
  icon: logisticsnetworks:diamond_upgrade
  position: 4
---

# 性能升级

性能升级可增加节点的**单次数量上限**（单次传输可移动的资源量）并降低其**最小延迟**（发送资源的频率）。节点中的所有频道都能享受到升级的效果——升级按节点设置，不按频道。

可在[过滤器与升级](filters-upgrades.md)面板中的4个升级槽安装升级。不允许重复安装。

## 仅计算最高等级

节点会选用**最高等级**的升级作为节点**等级**：

| 等级 | 升级       |
| ---- | ---------- |
| 1    | 铁级       |
| 2    | 金级       |
| 3    | 钻石级     |
| 4    | 下界合金级 |

若同时安装了铁级、金级、钻石级升级，节点会选用**钻石级**的上下限。铁级和金级不会被使用——升级本身无法堆叠。可以往剩下的槽位里放入[特种升级](upgrades-special.md)（跨维度、通用机械化学品、新生魔艺魔源），增加剩余槽位的利用率。

## 等级对比

| 等级           | 物品单次数量 | 流体单次数量 | 能量单次数量 | 最小延迟 |
| -------------- | ------------ | ------------ | ------------ | -------- |
| **无升级**     | 配置值       | 配置值       | 配置值       | 配置值   |
| **铁级**       | 16个物品     | 1,000 mB     | 10,000 RF    | 10刻     |
| **金级**       | 32个物品     | 5,000 mB     | 50,000 RF    | 5刻      |
| **钻石级**     | 64个物品     | 20,000 mB    | 250,000 RF   | 1刻      |
| **下界合金级** | 10,000个物品 | 1,000,000 mB | 无限制       | 1刻      |

表格中的值为**上限/下限**。[频道设置](channel-settings.md)面板中的单次数量和延迟会受其限制——单次数量行可以输入100,000，但铁级节点只会使用16。升级节点可提高上限/降低下限。

这四个等级的上下限均取自模组的服务端配置（`UpgradeLimitsConfig`），服务器管理员可更改它们。如果你的节点行为和表格中的不同，请检查配置。

## 铁级升级

入门等级。将节点拉出未经升级的水平，让它在小型设施中具备实用性。

<RecipeFor id="logisticsnetworks:iron_upgrade" />

## 金级升级

中等等级。物品上限是铁级的2倍，流体和能量的则是5倍。

<RecipeFor id="logisticsnetworks:gold_upgrade" />

## 钻石级升级

高级等级。整组传输（每次操作64个），最小延迟可达1刻，即节点每一刻都能运作。

<RecipeFor id="logisticsnetworks:diamond_upgrade" />

## 下界合金级升级

最强性能。物品单次数量为10,000，流体单次数量达一百万毫桶，能量单次则没有上限。可以用作网络中的枢纽节点——枢纽箱子、主要流体分配器、大型能量缓存等。

<RecipeFor id="logisticsnetworks:netherite_upgrade" />
