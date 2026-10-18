```json
{
  "title": "方块交互",
  "icon": "minecraft:string",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "摧毁之技巧",
    "造物之技巧",
    "交换之技巧",
    "轻羽之技巧",
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

<|glyph@trickster:templates|trick-id=trickster:break_block,title=摧毁之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=max(硬度 * 1kG\, 8kG)|>

破坏给定位置处的方块。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:place_block,title=造物之技巧|>

vector, slot, [vector, vector] |

vector, block, [vector, vector] -> vector

<|cost-rule@trickster:templates|formula=max(距离 * 1kG\, 8kG)|>

将所给方块放置在所给位置处。会消耗物品。

;;;;;

此技巧术还会接受两个额外参数。

- 第一个参数用于指定放置的方向。
- 第二个参数用于指定放置时，应与相邻方块的哪一面进行交互。

部分方块的朝向和其他属性可能会因这些参数而产生变化。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:change_weight,title=轻羽之技巧|>

vector, number -> entity

<|cost-rule@trickster:templates|formula=60kG * (1 - 倍数)|>

给定0到1之间的数，让所给位置处方块所受重力变为原重力与所给数的积，令其向上飘浮。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:swap_block,title=交换之技巧|>

vector, vector ->

<|cost-rule@trickster:templates|formula=60kG + 距离 * 1kG|>

交换世界中两个位置处的方块。两处均不允许为空气。

;;;;;

<|page-title@lavender:book_components|title=笔记：加热与冷却|>向方块灌入大量魔力可加热方块，从中抽出大量魔力可冷却。


某些方块经受此类极端温度变化后会变为有用的事物，不过如此操作会对其周围方块产生附带效果。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:heat,title=赋权之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

立即猛烈加热所给方块。


可借此高效加热熔炉。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cool,title=撤权之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

立即让所给方块大幅冷却。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:erode,title=损蚀之技巧|>

vector, vector -> vector

<|cost-rule@trickster:templates|formula=80kG|>

使用第二个位置处的水锈蚀第一个位置处的方块。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_flower,title=花卉之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=5kG|>

在所给位置处随机构筑一朵花。下方方块的顶面需为土壤。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_water,title=盈水之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=15kG|>

在所给位置处构筑出一潭水。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:conjure_light,title=光辉之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=20kG|>

在所给位置处构筑出一个永久性光源。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:power_resonator,title=谐振之技巧|>

vector, number -> boolean

<|cost-rule@trickster:templates|formula=距离 / 2kG|>

令所给位置处[法术谐振器](^trickster:items/spell_resonator)产生所给强度的信号，强度需在0到15之间。
