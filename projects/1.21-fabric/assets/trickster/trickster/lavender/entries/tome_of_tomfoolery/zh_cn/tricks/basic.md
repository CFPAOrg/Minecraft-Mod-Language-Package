```json
{
  "title": "基础戏法",
  "icon": "minecraft:bricks",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "记事员之错觉",
    "记事员之技巧",
    "禁文记事员之技巧",
    "畏真者之技巧",
    "展示之谋略",
    "乌鸦灵思之错觉",
    "乌鸦灵思之技巧",
    "消耗之技巧"
  ]
}
```

本节列出了最为基础也最为通用的戏法。推荐每一位雄心勃勃的魔术师和戏法师都学会这些戏法。

;;;;;

<|page-title@lavender:book_components|title=笔记：抄入的片段|>只要某一物品可存储在玩家物品栏中，那就可以抄入法术片段。若抄入的是方块，放置后其上法术片段即会消失。


某些物品抄入法术后会具有额外的交互功能，如[魔杖](^trickster:items/wand)会在右击时施放法术片段。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_spell,title=记事员之错觉|>

-> any

---

若施法者另一只手中物品抄有法术片段，则返回该片段；否则返回void。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_spell,title=记事员之技巧|>

any, [slot] -> any

---

将法术片段抄入所给槽位中或施法者副手中的物品。在片刻之后返回其输入值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_closed_spell,title=禁文记事员之技巧|>

any, [slot] -> any

---

与记事员之技巧相同，但抄入的片段无法以常规方式读出。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:clear_spell,title=畏真者之技巧|>

[slot] -> 

---

清除所给槽位中或施法者副手中物品上的法术片段。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:reveal,title=展示之谋略|>

any... -> any

---

将给定的所有值作为聊天信息发送给施法者，返回第一参数。

;;;;;

<|page-title@lavender:book_components|title=笔记：乌鸦之思|>乌鸦之思（不应与其他黑鸟之思混淆）能让法术存入或取回一个法术片段，且该片段会在不同次施法间**保留**。


乌鸦之思可以用作计数器，用来标记位置，以及用来选定目标。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_crow_mind,title=乌鸦灵思之错觉|>

-> any

---

返回施法者乌鸦之思中的值。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_crow_mind,title=乌鸦灵思之技巧|>

any -> any

---

将所给值存进施法者的乌鸦之思，并覆盖其中的值。

;;;;;

<|page-title@lavender:book_components|title=笔记：施法消耗|>在收到多封来自魔术把戏股份有限公司总部关于本模组平衡性的投诉信后，我们决定正式实装物质层面上的法术消耗。


但是，玩家们的自由和选择权利也对我们至关重要。因此，本系统不作强制要求。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cost,title=消耗之技巧|>

->

---

消耗施法者物品栏中的一个紫水晶碎片。若无则产生失策。
