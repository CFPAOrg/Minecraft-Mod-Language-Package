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

各类能获取实体信息的戏法。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_entity_type,title=动机验证之辑流|>

entity -> entity_type

---

给定实体，返回其类型。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_position,title=位置之辑流|>

entity -> vector

---

给定实体，返回其在世界中的位置。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_eye_position,title=视角之辑流|>

entity -> vector

---

给定实体，返回其头部位置。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_facing,title=朝向之辑流|>

entity -> vector

---

给定实体，返回其朝向向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_velocity,title=运动之辑流|>

entity -> vector

---

给定实体，返回其当前的速度向量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:height_reflection,title=身材之辑流|>

entity -> number

---

给定实体，返回其高度，以格为单位。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sneaking_reflection,title=换立之辑流|>

entity -> boolean

---

给定实体，检查其是否在潜行。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:burning_reflection,title=炉灶之辑流|>

entity -> boolean

---

给定实体，检查其是否着火。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:sprinting_reflection,title=远足之辑流|>

entity -> boolean

---

给定实体，检查其是否在疾跑。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:blocking_reflection,title=盾护之辑流|>

entity -> boolean

---

给定实体，检查其是否在举盾防御。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_max_health,title=活力之辑流|>

entity -> number

---

给定实体，返回其最大生命值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_health,title=体健之辑流|>

entity -> number

---

给定实体，返回其当前生命值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_armour,title=垒墙之辑流|>

entity -> number

---

给定实体，返回其总护甲值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_scale,title=居形之辑流|>

entity -> number

---

返回所给实体的尺寸。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_flecks,title=观察者之辑流|>

[entity] -> number[]

---

返回施法者或给定玩家可见所有视形的标识符。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_player_food,title=食欲之辑流|>

entity -> number

---

给定玩家，返回其当前饥饿值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_player_saturation,title=饱足之辑流|>

entity -> number

---

给定玩家，返回其当前饱和度。
