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

本节的图案主要涉及基础算术及简单数学操作。


许多基础算术操作对数和向量都有效，但并非所有戏法都是这样。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add,title=吞并之谋略|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

将多个数或向量加为单个值。数和向量的和是向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:subtract,title=遗弃之谋略|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

将多个数或向量减为单个值。数和向量的差是向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:multiply,title=统治之谋略|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

将多个数或向量乘为单个值。数和向量的积是向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:divide,title=屈从之谋略|>

(number | vec)... | (number | vec)[] -> (number | vec)

---

将多个数或向量除为单个值。数和向量的商是向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:modulo,title=整体之曲变|>

number, number -> number

---

返回第一个数除以第二个数的余数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:power,title=至尊之曲变|>

number, number -> number

---

返回底数为第一个数，指数为第二个数的幂。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:max,title=高贵之谋略|>

number... | number[] -> number

---

返回所有输入值中的最大值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:min,title=低位之谋略|>

number... | number[] -> number

---

返回所有输入值中的最小值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:ceil,title=壮丽之曲变|>

number -> number

---

将输入值向上取整。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:floor,title=谦卑之曲变|>

number -> number

---

将输入值向下取整。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:round,title=客观之曲变|>

number -> number

---

将输入值四舍五入。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sqrt,title=削损之曲变|>

number -> number

---

返回输入值的平方根。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:invert,title=取反之曲变|>

number -> number | vec -> vec

---

取反所给数或向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:abs,title=绝对主义者之曲变|>

number -> number

---

若所给数为负，返回其相反数。否则直接传出。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sin,title=甲型几何之曲变|>

number -> number

---

返回所给数的正弦。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cos,title=乙型几何之曲变|>

number -> number

---

返回所给数的余弦。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:tan,title=丙型几何之曲变|>

number -> number

---

返回所给数的正切。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arcsin,title=甲型反几何之曲变|>

number -> number

---

返回所给数的反正弦。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arccos,title=乙型反几何之曲变|>

number -> number

---

返回所给数的反余弦。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arctan,title=丙型反几何之曲变|>

number -> number

---

返回所给数的反正切。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:arctan2,title=笛卡尔角之曲变|>

number, number -> number

---

返回X轴正向与原点至点(y, x)射线的夹角。
