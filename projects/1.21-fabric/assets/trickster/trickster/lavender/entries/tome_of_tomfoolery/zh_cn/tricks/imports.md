```json
{
  "title": "可重用性",
  "icon": "trickster:top_hat",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "协助之转离",
    "颅骨之转离"
  ]
}
```

有若干图案能轻松重复利用施法者物品栏中存储的法术片段。


这些图案会直接执行物品中的法术，并使用输入作为执行参数。执行后有可能会向调用法术返回值与片段，或是会产生其他副作用。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:import,title=协助之转离|>

item, any... -> any

---

寻找施法者物品栏中的所给物品，并施放第一个抄有法术的目标物品中的法术，使用输入值作为执行参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:import_hat,title=颅骨之转离|>

number, any... -> any

---

获取施法者[高顶礼帽](^trickster:items/top_hat)中给定槽位处的法术，使用输入值作为执行参数施放，并返回执行结果。
