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

射线追踪戏法会接受一个实体，并返回其视线落点。也可接受一个位置和一个方向，返回两向量的指向。


采用向量参数时，第一个向量视作追踪的起始点，第二个作为代表视线方向的单位向量。

;;;;;

将最后一个参数设为true时，以方块为目标的射线追踪可以返回流体。


如果射线追踪在64格没有观测到任何有意义的事物，则返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast|>

返回射线追踪所命中方块的位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast_entity|>

返回射线追踪命中的实体。

;;;;;

<|trick@trickster:templates|trick-id=trickster:raycast_side|>

返回射线追踪命中的方块的面，以单位向量表示。
