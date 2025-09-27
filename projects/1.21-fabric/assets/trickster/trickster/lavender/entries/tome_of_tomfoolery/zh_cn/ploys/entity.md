```json
{
  "title": "实体交互",
  "icon": "minecraft:sheep_spawn_egg",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "动能之技巧",
    "羽落之技巧",
    "篡夺者之技巧",
    "变身之技巧",
    "解除变身之技巧",
    "收容之技巧",
    "释脱之技巧",
    "居形之技巧"
  ]
}
```

*“你们之前应该读到过曼顿效应吧？它确实很奇怪。*


*“没人知道这些限制为什么以现有的形态存在，但也可能只是我们还没找到正确的解读方法。但不管怎么说，我们都要每时每刻谨记它们。”*


——摘自橄榄石教授的讲座

;;;;;

<|ploy@trickster:templates|trick-id=trickster:change_weight,cost=10G + 30G * (1 - 倍数)|>

给定0到1之间的数，让给定活物所受重力变为原重力与所给数的积，持续1秒。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:add_velocity,cost=3G + 长度^3 * 2G|>

将所给向量视为速度，并施予所给实体。

;;;;;

动能之技巧的消耗积累极其迅速。在同一个1/20秒内多次施放该技巧术，*等价*于单次施放，且计算消耗时所用的长度为**各次施放向量长度之和**。


因为此技巧术的消耗按照立方增长，在绝大多数情况下要避免产生前文提到的效应。若可行，可以考虑使用[挂起之转离](^trickster:tricks/functions#3)延迟下一次施放。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:set_scale,cost=abs(当前尺寸 - 新尺寸)^2 * 100G + 新尺寸 * 50G|>

变动所给实体的尺寸。目标尺寸不可小于原大的0.0625，也不可大于原大的8倍。

;;;;;

受此影响而发生尺寸变化的实体会缓慢变回其原本的尺寸，不断重复施放可阻断此效应。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:displace,cost=20G + 1.35G^长度|>

在两秒后按照所给向量令给定实体位移。此技巧术的消耗拥有和动能之技巧类似的叠加效应。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:polymorph,cost=8000G|>

将第一个实体的外形变为第二个实体。两个实体必须都是玩家。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:dispel_polymorph,cost=1000G|>

解除所给实体具有的变身效果。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:store_entity,cost=2000G + 1G * 距离 ^ (距离 / 5)|>

将所给实体存储到施法者的[帽子](^trickster:items/top_hat)中。帽子必须处于副手位置，且实体不得为玩家。

;;;;;

某些实体无法被存到帽子里，通常是因为它们的体型太大。试图存储此类实体会导致失策。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:release_entity,cost=2000G + 1G * 距离 ^ (距离 / 5)|>

将存储在施法者[帽子](^trickster:items/top_hat)中的实体释放到给定位置，并返回该实体的引用。若无实体，返回void。
