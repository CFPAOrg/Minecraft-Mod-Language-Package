```json
{
  "title": "向量",
  "icon": "minecraft:arrow",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "甲元之曲变",
    "乙元之曲变",
    "丙元之曲变",
    "吸收之曲变",
    "模长之曲变",
    "合向之曲变",
    "垂直之曲变",
    "归一之曲变",
    "合向归一之曲变"
  ]
}
```

许多向量数学运算都可由基础的[算术](^trickster:distortions/arithmetic)图案实现，但某些运算需要更专精的图案。本节图案正在此列。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_x,title=甲元之曲变|>

vector -> number

---

返回所给向量的X分量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_y,title=乙元之曲变|>

vector -> number

---

返回所给向量的Y分量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:extract_z,title=丙元之曲变|>

vector -> number

---

返回所给向量的Z分量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:merge_vector,title=吸收之曲变|>

number, number, number -> vector

---

将三个输入数合并为向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:length,title=模长之曲变|>

vector -> number

---

返回所给向量的长度。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:dot_product,title=合向之曲变|>

vector, vector -> number

---

返回所给向量的点积。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cross_product,title=垂直之曲变|>

vector, vector -> vector

---

返回所给向量的叉积。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:normalize,title=归一之曲变|>

vector -> vector

---

将所给向量归一化至长度为一。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:align_vector,title=合向归一之曲变|>

vector -> vector

---

将所给向量归一化至长度为一，并将其方向变为最近的轴向。
