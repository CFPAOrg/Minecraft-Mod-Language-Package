---
navigation:
  title: 盾御模块
  icon: nautec:shield_module
  position: 12
  parent: submarine/submarine-index.md
item_ids:
  - nautec:shield_module
---

# <Color id="light_purple">盾御模块</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="shield_module" scale="2"/>
  储能而非船壳。
</Column>

盾御模块可消耗储能以吸收船壳受到的损害，还可放电以轰走船壳周围所有事物。

***

## <Color id="gold">被动护盾</Color>

任意槽位安装有模块时，船壳受到的攻击会首先用储能代偿：每吸收2点损坏度消耗10,000点储能。船壳的护甲可在盾御生效前缓冲攻击，此时只会对护甲没能抵挡的部分耗能。能量库无法覆盖的部分由船壳承担。

充满的能量库最多能吸收100颗心的伤害，但能量库本身还需要供应推进器和空气。交战时务必观察PWR仪表，长时间交战可能导致耗尽储能而切断空气供应。

护盾只会抵御能被盔甲缓冲的伤害。魔法、火焰、监守者音波等忽略盔甲的伤害会直接作用于船壳。

***

## <Color id="gold">放电</Color>

|              | 默认        |
| ------------ | ----------- |
| 每次放电能耗 | 25,000      |
| 半径         | 船壳周围5格 |
| 伤害         | 10（5颗心） |
| 眩晕         | 3秒         |
| 冷却         | 5秒         |

激活模块后船壳会向外发出环状冲击。5格内除该潜水器乘员外的所有活物都会受到10点伤害，被击退离开船壳附近，并令它们眩晕3秒。被眩晕的生物无法移动或攻击，且会丢失原本的追击目标。

在敌对生物外，放电也会伤害玩家、宠物、友好生物等，确保船壳边只有你想伤害的目标。

所有数据均可配置。

***

### <Color id="aqua">盾御模块的配方</Color>

<Recipe id="nautec:shield_module"/>
