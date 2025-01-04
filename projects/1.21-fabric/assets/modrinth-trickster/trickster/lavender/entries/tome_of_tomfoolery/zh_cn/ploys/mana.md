```json
{
  "title": "黑夜中的幽光",
  "icon": "trickster:echo_knot",
  "category": "trickster:ploys"
}
```

用于制造[晶结](^trickster:items/knots)和在其间转移魔力的戏法。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:battery_creation,title=望月者之技巧|>

[slot], [slot] ->

---

使用所给槽位中的宝石和水晶及玻璃制造晶结。若未提供槽位参数，则使用紫水晶。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:push_mana,title=善流之技巧|>

number, slot... -> number

---

将施法者的魔力传输到给定槽位中的物品处，最多传输给定数的量，并返回实际传输的量。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:pull_mana,title=恶流之技巧|>

number, slot... -> number

---

从给定槽位的物品中传输魔力到施法者处，最多传输给定数的量，并返回实际传输的量。
