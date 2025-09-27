```json
{
  "title": "方块交互",
  "icon": "minecraft:string",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "摧毁之技巧",
    "造物之技巧",
    "交换之技巧",
    "羽落之技巧",
    "赋权之技巧",
    "撤权之技巧",
    "损蚀之技巧",
    "花卉之技巧",
    "盈水之技巧",
    "光辉之技巧",
    "谐振之技巧"
  ]
}
```

本节中的图案会直接操作世界中的方块。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:break_block,cost=max(硬度 * 1G\, 8G)|>

破坏给定位置处的方块。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:place_block,cost=max(距离 * 1G\, 8G)|>

将所给方块放置在所给位置处。会消耗物品。

;;;;;

放置时使用何种方块由槽位引用或方块类型片段决定。


若传入方块类型，则选取施法者物品栏中首个可用的该类型物品。

;;;;;

造物之技巧还会接受两个额外参数。

- 第一个参数用于指定放置的方向。
- 第二个参数用于指定放置时，应与相邻方块的哪一面进行交互。

部分方块的朝向和其他属性可能会因这些参数而产生变化。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:change_weight,cost=10G + 30G * (1 - 倍数)|>

给定0到1之间的数，让所给位置处方块所受重力变为原重力与所给数的积，令其变为受重力影响的实体。

;;;;;

如果不重新施加，羽落之技巧的重力操纵效果通常会在约一秒后消失。


再次对受影响的方块使用此技巧术可延长效果持续时间，即便方块已经接触到地面也是一样。

;;;;;

如果需要强行撤去此戏法的影响，且不考虑方块的位置和状态，可对其使用倍数为1的羽落之技巧。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:swap_block,cost=60G + 距离 * 1G|>

交换世界中两个位置处的方块。两处均不允许为空气。

;;;;;

<|page-title@lavender:book_components|title=笔记：加热与冷却|>向方块灌入大量魔力可加热方块，从中抽出大量魔力可让其冷却。


某些方块经受此类极端温度变化后会变成有用的事物，不过如此操作也会对其周围方块产生附带的副作用。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:heat,cost=80G|>

立即猛烈加热所给方块。


可借此高效加热熔炉。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:cool,cost=80G|>

立即让所给方块大幅冷却。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:erode,cost=80G|>

使用第二个位置处的水锈蚀第一个位置处的方块。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:conjure_flower,cost=5G|>

在所给位置处随机构筑一朵花。下方方块的顶面需为土壤。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:conjure_water,cost=15G|>

在所给位置处构筑出水，水量恰好够装满一个铁桶。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:conjure_light,cost=20G|>

在所给位置处构筑出一个永久性光源。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:power_resonator,cost=4G|>

令所给位置处[法术谐振器](^trickster:items/spell_resonator)产生所给强度的信号，强度需在0到15之间。
