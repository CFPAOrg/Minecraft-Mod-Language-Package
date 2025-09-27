```json
{
  "title": "基础戏法",
  "icon": "minecraft:bricks",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "记事员之辑流",
    "记事员之技巧",
    "禁文记事员之技巧",
    "畏真者之技巧",
    "展示之技巧",
    "乌鸦灵思之错觉",
    "乌鸦灵思之技巧"
  ]
}
```

*“基础知识可以说是所有技能体系中最重要的部分，时不时回过头温习不丢人。”*


——摘选自橄榄石教授的讲座

;;;;;

<|page-title@lavender:book_components|title=笔记：抄入的片段|>只要某一物品可存储在玩家物品栏中，那就可以抄入法术片段。若抄入的是方块，放置后其上法术片段即会消失。


某些物品抄入法术后会具有额外的交互功能，如[魔杖](^trickster:items/wand)会在右击时施放法术片段。

;;;;;

<|trick@trickster:templates|trick-id=trickster:read_spell|>

从给定槽位中的物品读出法术片段，未指定槽位则从施法者副手读取。读取位置无片段则返回void。

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_spell|>

将法术片段抄入所给槽位中的物品，未指定槽位则抄入施法者副手。会在执行一次[衰退](^trickster:concepts/fragment_decay)之后返回其输入值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_closed_spell|>

与记事员之技巧相同，但抄入的片段无法以常规方式读出。

;;;;;

<|trick@trickster:templates|trick-id=trickster:clear_spell|>

清除所给槽位中物品上的法术片段，未指定槽位则清除施法者副手。

;;;;;

<|trick@trickster:templates|trick-id=trickster:reveal|>

将给定的所有值作为聊天消息发送给施法者，返回第一参数。

;;;;;

<|page-title@lavender:book_components|title=笔记：乌鸦之思|>乌鸦之思（不应与其他黑鸟之思混淆）能让法术存入或取回一个法术片段，且该片段会在不同次施法间**保留**。


乌鸦之思可以用作计数器，用来标记位置，以及用来选定目标。

;;;;;

<|trick@trickster:templates|trick-id=trickster:read_crow_mind|>

返回施法者乌鸦之思中的值。

;;;;;

<|trick@trickster:templates|trick-id=trickster:write_crow_mind|>

将所给值存进施法者的乌鸦之思，并覆盖其中的值。
