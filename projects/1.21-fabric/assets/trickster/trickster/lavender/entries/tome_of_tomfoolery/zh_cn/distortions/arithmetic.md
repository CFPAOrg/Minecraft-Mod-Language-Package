```json
{
  "title": "算术",
  "icon": "minecraft:copper_bulb",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "吞并之谋略",
    "遗弃之谋略",
    "统治之谋略",
    "屈从之谋略",
    "整体之曲变",
    "至尊之曲变",
    "至劣之曲变",
    "高贵之谋略",
    "低位之谋略",
    "壮丽之曲变",
    "谦卑之曲变",
    "客观之曲变",
    "削损之曲变",
    "取反之曲变",
    "绝对主义者之曲变",
    "甲型几何之曲变",
    "乙型几何之曲变",
    "丙型几何之曲变",
    "甲型反几何之曲变",
    "乙型反几何之曲变",
    "丙型反几何之曲变",
    "笛卡尔角之曲变"
  ]
}
```

本节的图案主要涉及基础算术及数学操作。


部分基础戏法能接受多种类型的片段。它们的签名会采用特殊标记，如{#aa4444}可加{}或{#aa4444}可舍入{}。这些术语是后页全称的简写：

;;;;;

{#aa4444}可加{}、{#aa4444}可减{}可以是{#ddaa00}数{}、{#aa7711}向量{}、{#6644aa}图案{}。


{#aa4444}可乘{}、{#aa4444}可除{}、{#aa4444}可舍入{}则只能是{#ddaa00}数{}或{#aa7711}向量{}。

;;;;;

能一次性接受多个参数的曲变术会逐参数执行其操作。例如：

1, 2, 3 传入吞并之谋略 = 1 + 2 + 3 = 6


以及


1, 2, 3 传入屈从之谋略 = 1 / 2 / 3 = 0.1666...

;;;;;

<|trick@trickster:templates|trick-id=trickster:add|>

求各片段的和。

;;;;;

<|trick@trickster:templates|trick-id=trickster:subtract|>

从首个片段中减去其他片段。

;;;;;

<|trick@trickster:templates|trick-id=trickster:multiply|>

求各片段的积。

;;;;;

<|trick@trickster:templates|trick-id=trickster:divide|>

从首个片段开始，依次求各片段对的商。

;;;;;

<|trick@trickster:templates|trick-id=trickster:modulo|>

返回第一个数除以第二个数的余数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:power|>

返回底数为第一个数，指数为第二个数的幂。

;;;;;

<|trick@trickster:templates|trick-id=trickster:logarithm|>

给定两个数。在计算幂时，为让底数为第一个数的幂等于第二个数，指数应为多少，返回该值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:max|>

返回所有输入值中的最大值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:min|>

返回所有输入值中的最小值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:ceil|>

将输入值向上取整。

;;;;;

<|trick@trickster:templates|trick-id=trickster:floor|>

将输入值向下取整。

;;;;;

<|trick@trickster:templates|trick-id=trickster:round|>

将输入值四舍五入。

;;;;;

<|trick@trickster:templates|trick-id=trickster:sqrt|>

返回输入值的平方根。

;;;;;

<|trick@trickster:templates|trick-id=trickster:invert|>

取反所给数或向量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:abs|>

若所给数为负，返回其相反数。否则原样传出。

;;;;;

<|trick@trickster:templates|trick-id=trickster:sin|>

返回所给数的正弦。

;;;;;

<|trick@trickster:templates|trick-id=trickster:cos|>

返回所给数的余弦。

;;;;;

<|trick@trickster:templates|trick-id=trickster:tan|>

返回所给数的正切。

;;;;;

<|trick@trickster:templates|trick-id=trickster:arcsin|>

返回所给数的反正弦。

;;;;;

<|trick@trickster:templates|trick-id=trickster:arccos|>

返回所给数的反余弦。

;;;;;

<|trick@trickster:templates|trick-id=trickster:arctan|>

返回所给数的反正切。

;;;;;

<|trick@trickster:templates|trick-id=trickster:arctan2|>

返回X轴正向与原点至点(y, x)射线的夹角。
