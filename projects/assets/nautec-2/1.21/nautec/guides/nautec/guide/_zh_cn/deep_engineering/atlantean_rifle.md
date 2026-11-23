---
navigation:
  title: 海洋步枪
  icon: nautec:atlantean_rifle
  position: 5
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:atlantean_rifle
---

# <Color id="light_purple">海洋步枪</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="atlantean_rifle" scale="2"/>
  按住使用键时会持续发射粒子束的能量武器。
</Column>

按住使用键时，步枪会先蓄能半秒，随后向你的视线落点发射粒子束。只要按住按键，粒子束便会每2刻攻击一次，且持续时间越长攻击力越强。它的运作依赖于储存的AP，耗空时会失去功能。

***

## <Color id="gold">伤害与储能</Color>

在持续开火的前10秒内，伤害和能耗会逐渐从初始值爬升至最大值。松开按键即重置两者。

|                | 初始  | 10秒后 |
| -------------- | ----- | ------ |
| 每次攻击的伤害 | 4     | 20     |
| 每秒伤害       | 40    | 200    |
| 每次攻击AP耗量 | 125   | 625    |
| 每秒AP耗量     | 1,250 | 6,250  |

* 攻击无视目标的无敌帧，也即每次攻击都作数。
* 粒子束最远可达128格处。它能穿过水，会在第一个固体方块处停止，并攻击途经的第一个生物。
* 充满的步枪可连续发射约164秒（2分45秒）。多次短时脉冲发射时，消耗只会停留在曲线的开头，从而整体能续航更长时间。
* 若第一次攻击时步枪就已没有足够的AP，它会显示“海洋步枪储能不足”，且不会开火。储能耗尽时也会停止开火。

表中的所有值、蓄能时间、范围均在`config/nautec-common.toml`中（`rifleBaseDamage`、`rifleMaxDamage`、`rifleBaseDrain`、`rifleMaxDrain`、`rifleRampTicks`、`rifleChargeTicks`、`rifleRange`）。

***

## <Color id="gold">充能</Color>

步枪能容纳1,000,000 AP（`riflePowerCapacity`），新合成时储能为0。它下方的条栏指示了储能，提示文本中能显示具体数值。

* <ItemLink id="charger"/>会按射来光束的功率为其充能，最高每刻20,000 AP（`rifleMaxInput`）。光束越强，充能器充能越快。
* 佩戴于饰品槽并启用能力的<ItemLink id="prismatic_battery"/>可使用其储能为步枪补充AP，最高100 AP每刻。

***

## <Color id="gold">魔咒</Color>

步枪只接受无限和各类诅咒，其余均不适用。无限会让能耗减半，即充满的步枪可连续发射约324秒（5分半）。它的附魔能力很低，因此最好通过铁砧和附魔书添加魔咒，不建议在附魔台处附魔。

安装有神化（Apotheosis）时，步枪会被词缀和宝石视作弓，弓词缀可作用于粒子束：

* 蓄力速度会缩短粒子束的蓄能时间。+50%蓄力速度可让蓄能时间变为三分之二。
* 箭矢速度和箭矢伤害会倍增粒子束的伤害。+50%箭矢速度对应1.5倍伤害。
* 保护穿透和保护撕裂会忽略目标的部分保护点数，盔甲穿透和盔甲撕裂会忽略部分护甲值，这四者均能被宝石增强。
* 暴击率和暴击伤害的效果和其他攻击手段一致。

***

## <Color id="gold">获取</Color>

配方中会用到来自[深渊压力锻造机](pressure_forge.md)的制品，务必先让它运行起来。参见[深海材料](materials.md)。

<Recipe id="nautec:atlantean_rifle"/>
