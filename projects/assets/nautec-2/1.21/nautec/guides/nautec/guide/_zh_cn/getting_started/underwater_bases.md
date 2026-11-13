---
navigation:
  title: 水下基地
  icon: nautec:pressure_hatch
  position: 18
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:pressure_hatch
  - nautec:oxygen_diffuser
---

# <Color id="light_purple">水下基地</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="pressure_hatch" scale="2"/>
  本页方块可用于在海床上建立干燥的永久基地。
</Column>

先用[气泡锚](bubble_anchor.md)清理区域，然后搭墙，再将锚设为结束至空气。在力场消散时，你建好的墙壁能保持内部干燥。

***

## <Color id="gold">压力舱门</Color>

带有视窗的钢制门，两格高。可手动或通过红石开关。

* 无论舱门开关，海水都无法流过它；可以从外部游进打开的舱门，同时让舱门后方保持干燥。
* 每次关闭舱门时，只要某一侧的水体足够小，它便会泵干那一侧的水：你带进来的水、漏水的门廊、漏水的墙壁都可以被妥善处理。最多一次性能清除64个相连的方块。
* 某一侧若向海洋开放，或充水体积大于64格，那么便不会清理该侧；关闭舱门不会抽干另一侧的海洋。

放置舱门会清除它所在的两格水，方便直接在充水的门廊上放置。

<RecipeFor id="pressure_hatch"/>

***

## <Color id="gold">氧气散布器</Color>

<ItemImage id="oxygen_diffuser" scale="2"/>

给予12格内所有玩家水下呼吸效果，同时填满他们的氧气条，这样无需佩戴头盔也可在开放水体内作业。

* 需要向它的任意面发射至少10 AP的激光束。纯度如何没有影响，哪怕是最弱的光束也能驱动它。
* 激光存在时，它会每秒刷新一次效果。走出范围后效果便只能持续几秒。
* 它可放置在水下。它运作时顶部会发出气泡柱。
* 撤去激光后，它还能再坚持运作2秒。

范围和所需功率可在`config/nautec-common.toml`中配置。

<RecipeFor id="oxygen_diffuser"/>
