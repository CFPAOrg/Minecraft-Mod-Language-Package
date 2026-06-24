```json
{
  "title": "模块式法术组构台",
  "icon": "trickster:modular_spell_construct",
  "category": "trickster:items",
  "ordinal": 100
}
```

模块式法术组构台和简单的[法术组构台](^trickster:items/spell_construct)不同：它不会执行抄入的法术，而是可以在四角的槽位插入最多四枚[法术核心](^trickster:items/spell_core)。各个法术核心会并发执行，执行所需的魔力来自组构台中央的[晶结](^trickster:items/knots)，并且所有法术核心共享[乌鸦之思](^trickster:tricks/basic#7)。

;;;;;

此类组构台中的法术核心可以互相访问和委托任务，所使用的戏法与操纵玩家法术槽所用的一致。高水平的魔术师和戏法师可借此设计出持久执行的多线程法术。

<recipe;trickster:modular_spell_construct>
