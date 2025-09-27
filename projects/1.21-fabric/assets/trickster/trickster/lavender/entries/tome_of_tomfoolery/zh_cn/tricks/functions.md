```json
{
  "title": "法术转离",
  "icon": "minecraft:paper",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "挂起之转离",
    "宏伟之转离",
    "静默之转离",
    "器具之转离",
    "折叠之转离",
    "谨慎之转离",
    "奇点之转离",
    "行刑者之转离",
    "原点之辑流",
    "海龟之辑流"
  ]
}
```

普通的值可以创建、传递、为法术所用，法术自身的片段同样可以。


若将圆嵌套到其他圆的内部作为内圆符记，但不为外圆创建子圆，那么外圆执行时即会将其内圆及内圆的子圆返回为法术片段。

;;;;;

可对该片段执行多种操作，比如通过[记事员之技巧](^trickster:tricks/basic#4)写入其他物品，或是晚些时候再施放，或是在同一个法术中多次重复使用。


也可以向法术片段传入其自身，然后在那里再次施放，借助递归制造循环。

;;;;;

<|trick@trickster:templates|trick-id=trickster:delay_execution|>

将当前法术的执行延迟所给数刻，未指定则延迟1刻。返回延迟量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:execute|>

施放所给法术片段，其他输入则按序作为施放时的参数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:execute_same_scope|>

施放所给法术，以当前法术的参数作为其参数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:try_catch|>

尝试执行第一个法术。若产生失策，换而执行第二个法术并静默该失策。其他输入值同时用作两个法术的参数。

;;;;;

<|trick@trickster:templates|trick-id=trickster:atomic|>

在单刻内执行所给法术。法术过大或产生非法操作会导致失策。

;;;;;

如果施放的那一刻内没有足够的圆执行操作供戏法使用，则会先延后1刻，然后再一次性执行整条法术。


非法操作包括：
- [挂起之转离](^trickster:tricks/functions#3)。
- [收据之技巧](^trickster:ploys/message#3)。
- 执行子法术的任意转离术。
- 隐式子法术执行。

;;;;;

<|trick@trickster:templates|trick-id=trickster:fork|>

为所给法术另外分配一个法术槽。

;;;;;

如果施法对象不具备法术槽，此戏法即会导致失策。如果没有空闲的法术槽，此戏法会返回void。其他情况下，此戏法会返回所分配法术槽的索引。

;;;;;

<|page-title@lavender:book_components|title=笔记：可折叠|>{#aa4444}可折叠{}是一类法术片段，其中装有其他法术片段，且可通过特定键访问。列表是一种{#aa4444}可折叠{}片段，键为0到列表长度之间的整数，左闭右开。映射也是一种{#aa4444}可折叠{}片段，其键可为任意量，且不会按照插入顺序自动分配。

;;;;;

<|trick@trickster:templates|trick-id=trickster:fold|>

对{#aa4444}可折叠{}片段中的所有元素执行所给法术，第三参数传入为第一次迭代时的“上一迭代的结果”参数。

;;;;;

每次迭代都有四个输入参数：

---

{#aa4444}任意{}, {#aa4444}任意{}, {#aa4444}任意{}, {#aa4444}可折叠{}

---

这些参数分别具有如下意义，按序为：

- 上一次迭代的结果。
- 当前操作的值。
- 当前操作值对应的键。
- {#aa4444}可折叠{}片段本身。

;;;;;

每次迭代的执行结果均会用作下一次迭代的第一参数，最后一次迭代的结果即是整个戏法的结果。

;;;;;

<|page-title@lavender:book_components|title=笔记：参数|>法术片段可以作为参数传入法术片段。


更多信息参见[参数](^trickster:delusions_ingresses/arguments)章节。

;;;;;

<|trick@trickster:templates|trick-id=trickster:kill_thread|>

终止所给法术槽中的法术，未指定法术槽即使用当前法术槽。根据成功与否返回布尔值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:thread_root|>

获取分配至所给法术槽的原始法术，未指定法术槽即使用当前法术槽。

;;;;;

<|trick@trickster:templates|trick-id=trickster:spell_state|>

返回所给法术槽在上一刻执行的圆的数量，未指定法术槽即使用当前法术槽。
