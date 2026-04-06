```json
{
  "title": "射线追踪",
  "icon": "minecraft:spectral_arrow",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "着点之辑流",
    "承座之辑流",
    "标记之辑流"
  ]
}
```

射线追踪戏法会接受一个实体或位置或方向，并返回该实体的目光所在，或该向量的指向。


以方块为目标的射线追踪可以返回流体，需将最后一个参数设为true。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:raycast,title=着点之辑流|>

entity, [boolean] -> vector |

vector, vector, [boolean] -> vector

---

返回射线追踪命中的方块。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:raycast_side,title=承座之辑流|>

entity, [boolean] -> vector |

vector, vector, [boolean] -> vector

---

返回射线追踪命中的方块的面，以向量表示。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:raycast_entity,title=标记之辑流|>

entity -> entity |

vector, vector -> entity

---

返回射线追踪命中的实体。
