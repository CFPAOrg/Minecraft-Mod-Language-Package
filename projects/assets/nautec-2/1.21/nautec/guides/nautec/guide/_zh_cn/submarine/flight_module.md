---
navigation:
  title: 飞行模块
  icon: nautec:flight_module
  position: 15
  parent: submarine/submarine-index.md
item_ids:
  - nautec:flight_module
---

# <Color id="light_purple">飞行模块</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="flight_module" scale="2"/>
  可让海洋斥候离开水体飞上天空。
</Column>

安装有飞行模块时，潜水器不会在离开水体时坠落。它能像在水中航行一样在空中飞行，只不过在空中飞行得稍慢些。

***

## <Color id="gold">飞行</Color>

该模块是被动模块，可在任意槽位中运作。直接开出水体，或在陆地上按空格，均可起飞；离水时会保留之前的运动状态。

* 操控方式和在水下完全一致：潜水器前部跟随你的视线，也能改变俯仰角，空格上升C降落。
* 在空中时，它的移动速度大约是水下的一半，最高速度也会降低一半。
* 降落到地面或重新潜入水中可着陆。

无人驾驶时，飞行的潜水器会缓慢向地面降落而非直接坠落，这样在空中下船也不会损坏它。潜水器免疫摔落伤害。

***

## <Color id="gold">能耗</Color>

空中航行会在常规消耗之上额外每刻消耗4点储能，位于空中且潜水器中有人时即生效。储能耗空后潜水器会和其他实体一样直接下坠，在长距离飞行时务必关注仪表。

速度乘数和常态消耗均可配置（`submarineFlightSpeedMultiplier`、`submarineFlightPowerUsage`）。飞行模块只需要一个，第二个没有额外功能。

***

### <Color id="aqua">飞行模块的配方</Color>

<Recipe id="nautec:flight_module"/>
