```json
{
  "title": "视形",
  "icon": "minecraft:ghast_tear",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "营销员之技巧",
    "艺术家之技巧",
    "奥威尔之技巧"
  ]
}
```

*人世茫茫，*

*于间彷徨。*


*意识回环，*

*于间镌廊。*


*目光乍落，*

*于间显相，*


*华若天赐，*

*人心向往。*


—— 欧阿菲利

;;;;;

视形是对特定玩家显示数据的方法。视形只会显示短短一秒，因此需要不停刷新。


所有制造视形的戏法都需要用作标识的数，后续其他施法者也可以用该数更新和覆写视形。戏法会返回该数，便于链式执行。视形还能接受一个玩家列表或玩家的可选参数，只有这些玩家能看见该视形。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:draw_spell,title=营销员之技巧|>

number, vector, vector, spell, [number], [entity[] | entity] -> number

---

在所给位置以所给朝向显示所给法术，缩放参数可选。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:draw_line,title=艺术家之技巧|>

number, vector, vector, [entity[] | entity] -> number

---

在所给位置间绘制线段。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:delete_fleck,title=奥威尔之技巧|>

number, [entity[] | entity] -> number

---

移除所给ID对应的视形。
