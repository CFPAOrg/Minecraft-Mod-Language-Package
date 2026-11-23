---
navigation:
  title: 海王三叉戟
  icon: nautec:neptunes_trident
  position: 6
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:neptunes_trident
---

# <Color id="light_purple">海王三叉戟</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="neptunes_trident" scale="2"/>
  无法破坏的三叉戟，它能自行返回，还能在击中位置发出潮汐冲击波。
</Column>

海王三叉戟类似于伤害更高的原版三叉戟。它不会损坏，还能用忠诚 III的速度飞回你的位置。按住使用键再松开以投掷，按下攻击键可用它近战攻击。

***

## <Color id="gold">伤害</Color>

| 攻击     | 伤害               |
| -------- | ------------------ |
| 投掷     | 18                 |
| 近战     | 19（1.2 攻击速度） |
| 激流滚转 | 18                 |

近战攻击能和剑一样横扫，除了直接目标外还能击中附近的生物。

***

## <Color id="gold">潮汐冲击波</Color>

三叉戟投出后会在击中的第一个生物或方块处释放一道潮汐冲击波。波源处会有闪电标记；这道闪电只是视觉效果，不会点火。

* 冲击波会攻击波源向外5格内的所有事物，造成14点伤害，在边缘处衰减至7点，并将所有目标推离波源。
* 每级锋利追加3点伤害，每级击退追加击退力度。
* 冲击波不会攻击你、你驯服的宠物、你的队友、创造模式或旁观模式下的玩家。
* 发射冲击波后，三叉戟需要等待3秒才能发射另一道。冷却过程中可以继续投掷，只是不会产生冲击波而已。三叉戟的物品栏图标会显示剩余冷却。

半径、伤害、魔咒每等级增益、冷却均在`config/nautec-common.toml`中（`tridentShockwaveRadius`、`tridentShockwaveDamage`、`tridentShockwaveDamagePerSharpness`、`tridentShockwaveKnockback`、`tridentShockwaveKnockbackPerLevel`、`tridentShockwaveCooldown`）。

***

## <Color id="gold">魔咒</Color>

它接受三叉戟魔咒和剑魔咒：

* 穿刺、激流、引雷
* 锋利、亡灵杀手、节肢杀手、击退、火焰附加、抢夺、横扫之刃
* 消失诅咒

三叉戟默认带有忠诚，它也不需要耐久或经验修补。和其他三叉戟一样，锋利、亡灵杀手、节肢杀手、穿刺只能四选一。锋利魔咒同时还能增加冲击波伤害。激流和引雷互斥。

在水中或雨中投掷拥有激流的三叉戟会连带将你自己发射出去，而不是投掷三叉戟；这种三叉戟不会发出冲击波。雷暴时，拥有引雷的三叉戟会向露天目标落下真正的雷，和原版三叉戟一致。

它的附魔能力很低，因此最好通过铁砧和附魔书添加魔咒，不建议在附魔台处附魔。

***

## <Color id="gold">获取</Color>

配方中会用到来自[共鸣室](resonance_chamber.md)和[深渊压力锻造机](pressure_forge.md)的制品，务必先让它们两个运行起来。参见[深海材料](materials.md)。

<Recipe id="nautec:neptunes_trident"/>
