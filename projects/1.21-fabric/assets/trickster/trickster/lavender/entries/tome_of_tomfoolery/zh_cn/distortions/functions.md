```json
{
  "title": "法术片段",
  "icon": "minecraft:paper",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "宏伟之谋略",
    "静默之曲变",
    "器具之谋略",
    "折叠之曲变",
    "谨慎之谋略",
    "奇点之谋略",
    "供给之曲变",
    "闭包之谋略"
  ]
}
```

普通的值可以创建、传递、为法术所用，法术自身的片段同样可以。


将圆嵌套到其他圆的内部作为内圆符记，但不为外圆创建子圆，则外圆执行时会将其内圆返回为法术片段。

;;;;;

然后就可对该片段执行多种操作，比如通过[记事员之技巧](^trickster:tricks/basic#4)写入其他物品，或是晚些时候再施放，甚至是在同一个法术中多次施放。


也可以向法术片段传入其自身，然后在那里再次执行，借用递归制造循环。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:execute,title=宏伟之谋略|>

spell, any... -> any

---

相当强大的戏法，会执行所给法术片段，将其他输入作为执行时的参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:execute_same_scope,title=静默之曲变|>

spell -> any

---

执行所给法术，以当前法术的参数作为其参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:fork,title=器具之谋略|>

spell, any... -> number

---

为所给法术分配一个空法术槽。返回所占用法术槽的索引，若未能成功分配则返回一个负数。

;;;;;

<|page-title@lavender:book_components|title=笔记：集合|>集合是一类法术片段，其中装有其他法术片段，且可通过特定键访问。列表是集合的一种，键为零到列表长度之间的整数，左闭右开。映射也是集合的一种，其键可为任意量，且不会按照插入顺序自动分配。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:fold,title=折叠之曲变|>

spell, collection, any -> any

---

对集合中的所有元素执行所给法术，第三参数传入为第一次迭代时的“上一迭代的结果”参数。

;;;;;

每次迭代都有四个输入参数：

---

any, any, any, collection

---

第一参数为上一迭代的结果，第二参数为当前操作的值，第三参数为当前操作的键，第四参数为所给集合。

;;;;;

每次迭代的执行结果均会用作下一次迭代的第一参数，最后一次迭代的结果即是整个戏法的结果。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:try_catch,title=谨慎之谋略|>

spell, spell, any... -> any

---

尝试执行第一法术参数。若产生失策，换而执行第二法术参数并静默该失策。其他输入值同时用作两个法术的参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:atomic,title=奇点之谋略|>

spell, any... -> any

---

在单刻内执行所给法术。若法术过大，或产生非法操作，则导致失策。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:supplier,title=供给之曲变|>

any -> spell

---

创建一个新法术片段，其执行结果即是所给参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:closure,title=闭包之谋略|>

spell, {any: any} -> spell

---

将所给法术中与所给映射键对应的符记换成其映射的值。

;;;;;

<|page-title@lavender:book_components|title=笔记：参数|>法术片段可以作为参数传入法术片段。


更多信息参见[参数](^trickster:delusions_ingresses/arguments)章节。
