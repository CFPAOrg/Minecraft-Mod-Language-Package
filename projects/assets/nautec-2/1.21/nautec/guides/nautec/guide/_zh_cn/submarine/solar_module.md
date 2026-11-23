---
navigation:
  title: 太阳能模块
  icon: nautec:solar_module
  position: 7
  parent: submarine/submarine-index.md
item_ids:
  - nautec:solar_module
---

# <Color id="light_purple">太阳能模块</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="solar_module" scale="2"/>
  使用日光被动充能。
</Column>

在白天且处于露天位置时，太阳能模块每5秒会为船壳补充2,000点储能（总容量的0.2%，约20每刻）。

***

## <Color id="gold">充能方式</Color>

该模块是被动模块，可在任意槽位中运作。透过水能看见天空也视作露天，因此潜入水下也会被动充能；潜水器和天空中有固体方块时视作不露天。该模块只会在白天运作，在下界、末地等没有日夜循环的维度中无效。

无人在艇时也会持续充能。停在开放水域中的潜水器需42分钟的日光照射才可从空充能至满。[海洋斥候停靠坞](submarine_dock.md)的速率是它的两倍。

潜水器只需要一个太阳能模块，第二个模块没有额外功能。充能速率可配置（`submarineSolarPercentPer5s`）。

***

### <Color id="aqua">太阳能模块的配方</Color>

<Recipe id="nautec:solar_module"/>
