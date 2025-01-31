```json
{
  "title": "杂项技巧术",
  "icon": "minecraft:iron_ingot",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "挂起之技巧",
    "天钉之技巧",
    "清晰之技巧",
    "混淆之技巧",
    "行刑者之技巧"
  ]
}
```

没法分进其他章节的若干杂项技巧术。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:delay_execution,title=挂起之技巧|>

[number] -> number

---

将当前法术的执行延迟所给数刻，未指定则延迟一刻。返回延迟量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:pin_chunk,title=天钉之技巧|>

vector -> vector

<|cost-rule@trickster:templates|formula=4 kG|>

将包含所给位置的区块完全加载4秒。

;;;;;

<|page-title@lavender:book_components|title=笔记：条栏|>法术可在施法者的屏幕上将任意值显示为条栏。


条栏由数标识，且可借此数随时修改。条栏的颜色由其标识符决定，同样的标识符必定产生同样的颜色。

;;;;;

可向条栏传入一个数，视作0到1之间的比例；也可传入两个数，第一个数为当前量，第二个为最大量。


更新时其会向父圆返回其值，方便链式执行。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:show_bar,title=清晰之技巧|>

number, number, [number] -> number

---

在施法者的屏幕中显示一个条栏，使用第一个数作为标识符，并显示第二个数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:clear_bar,title=混淆之技巧|>

number -> number

---

立即清除施法者屏幕中标识符为所给数的条栏。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:kill_thread,title=行刑者之技巧|>

[number] -> boolean

---

终止所给法术槽中的法术，若未指定法术槽则终止当前法术。根据成功与否返回布尔值。
