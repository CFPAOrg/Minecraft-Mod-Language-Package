---
navigation:
  title: 共鸣室
  icon: nautec:resonance_chamber
  position: 1
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:resonance_chamber
---

# <Color id="light_purple">共鸣室</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="resonance_chamber" scale="2"/>
  将激光束的功率储存为充能，再在充能达到临界水平时合成制造。
</Column>

共鸣室能将<ItemLink id="prismarine_crystal_shard"/>变成共鸣碎片，还能把惰性水晶种子唤醒为海晶水晶种子，以供[水晶培育](crystal_cultivation.md)使用。它需要从四个侧面或顶面接受纯度3.0及以上的光束。

***

## <Color id="gold">充能和限度</Color>

射来的光束拥有至少20 AP/t（`resonancePowerUsage`）时，共鸣室会按功率每刻不断充能。光束过弱时会损失充能。

限度代表共鸣室充能的安全上限。它的值为2,000 x (1 + 纯度)，纯度3.0光束的限度为8,000。基值2,000可通过`config/nautec-common.toml`中的`resonanceBaseCeiling`配置。

| 充能              | 行为                               |
| ----------------- | ---------------------------------- |
| 低于限度的90%     | 持续充能                           |
| 90%至110%（临界） | 若可行则合成一个物品，随后清空充能 |
| 高于110%          | 泄能                               |

在纯度为3.0时，临界区域落在7,200到8,800点充能之间。40 AP的光束会在180刻（9秒）后进入临界区间。

***

## <Color id="gold">合成加工</Color>

在充能进入临界区间之前放入海晶水晶碎片。每次达到临界水平时，共鸣室都会消耗一个碎片，并在输出槽中产生一片共鸣碎片，随后清空充能从头开始。放入一整组后不需要时时监督。

用碎片右击可放入。它只会接受可被加工的物品，手动或自动放入均可。空手右击可取出产物，无产物时取出原材料。漏斗和管道能送入水晶碎片和抽出共鸣碎片，比如放在它下面的漏斗就可以。默认情况下每面均可输入输出，也可用[面配置](nautec:getting_started/utilities.md)调整。

透过<ItemLink id="prism_monocle"/>观察会按相对于限度的百分比展示充能，同时展示限度和光束纯度。临界区间下充能行会变为金色。

***

## <Color id="gold">泄能</Color>

充能超过限度的110%后共鸣室会泄能。共鸣室会对4格内所有生物造成8点伤害，随后自身进入破裂状态，持续10秒，其间无法加工和充能。机器本身不会被破坏。

充能达到临界区间又无法加工时就会泄能，比如：

* 输入槽为空
* 光束纯度不足3.0
* 输出槽已满

应持续清理输出，或也可在共鸣室下放置漏斗，同时在水晶碎片不足时撤走光束。光束强度无论多高都是安全的：从限度90%以下开始充能，进入临界区间的那一刻最多只能达到限度的100%，无论光束强弱。

泄能伤害、半径、冷却分别对应`config/nautec-common.toml`中的`resonanceVentDamage`、`resonanceVentRadius`、`resonanceVentCooldown`。

***

## <Color id="gold">获得3.0纯度</Color>

侧面被光束击中的<ItemLink id="prismarine_crystal"/>会发出纯度3.0的光束。直接让它指向共鸣室，或通过不改动纯度的海晶石激光中继器和激光转接器传导激光。[聚焦透镜](beam_optics.md)最多只能将纯度升至2.0，这里它帮不上忙。

***

### <Color id="aqua">共鸣室的配方</Color>

<Recipe id="nautec:resonance_chamber"/>

***

## <Color id="gold">更强大的光束</Color>

共鸣室已会完整接收光束的功率，因此使用强激光会按正比提高速度：功率两倍，那么速度也是两倍。它不遵守其他机器的平方根法则。

加速规则和各个适用的机器参见[更强大的光束](nautec:getting_started/stronger_beams.md)。
