```json
{
  "title": "实体查询",
  "icon": "minecraft:cow_spawn_egg",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "动机验证之辑流",
    "位置之辑流",
    "视角之辑流",
    "朝向之辑流",
    "运动之辑流",
    "身材之辑流",
    "换立之辑流",
    "炉灶之辑流",
    "远足之辑流",
    "盾护之辑流",
    "活力之辑流",
    "体健之辑流",
    "垒墙之辑流",
    "居形之辑流",
    "观察者之辑流",
    "食欲之辑流",
    "饱足之辑流"
  ]
}
```

这些戏法能提供世界中实体的信息。


戏法无法观测到目标时会导致失策。


务必注意，实体片段可能会[衰退](^trickster:concepts/fragment_decay)。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_entity_type|>

给定实体，返回其类型。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_position|>

给定实体，返回其足部位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_eye_position|>

给定实体，返回其头部位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_facing|>

给定实体，将其朝向返回为单位向量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_velocity|>

给定实体，返回其当前的速度向量，以格每刻为单位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:height_reflection|>

给定实体，返回其高度，以格为单位。

;;;;;

<|trick@trickster:templates|trick-id=trickster:sneaking_reflection|>

给定实体，检查其是否在潜行。若实体不具潜行能力，则返回false。

;;;;;

<|trick@trickster:templates|trick-id=trickster:burning_reflection|>

给定实体，检查其是否着火。

;;;;;

<|trick@trickster:templates|trick-id=trickster:sprinting_reflection|>

给定实体，检查其是否在疾跑。若实体不具疾跑能力，则返回false。

;;;;;

<|trick@trickster:templates|trick-id=trickster:blocking_reflection|>

给定实体，检查其是否在举盾防御。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_health|>

给定实体，返回其最大生命值。实体无生命值会导致失策。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_health|>

给定实体，返回其当前生命值。实体无生命值会导致失策。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_armour|>

给定实体，返回其总护甲值。实体不具穿戴盔甲能力会导致失策。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_scale|>

返回所给实体的尺寸。实体无法被缩放会导致失策。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_flecks|>

返回给定玩家可见所有视形的标识符。若未传入玩家，则以施法者为主体进行判定。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_player_food|>

给定玩家，返回其当前饥饿值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_player_saturation|>

给定玩家，返回其当前饱和度。
