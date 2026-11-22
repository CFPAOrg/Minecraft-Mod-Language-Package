```json
{
  "title": "基础戏法",
  "icon": "minecraft:bricks",
  "ordinal": 0
}
```

*“基础知识可以说是所有技能体系中最重要的部分，时不时回过头温习不丢人。”*


——摘自橄榄石教授的讲座

;;;;;

#<trickster:note title="抄入的片段" />

所有物品都可以抄入法术片段。其中有一部分物品能够[反应触发](*trickster:concepts/trigger_items)其上法术。若抄入的是方块，放置后其上法术片段即会消失。


读写戏法的作用范围为16格。

;;;;;

#<trickster:trick id="trickster:read_spell" />

从给定槽位中的物品读出法术片段，未指定槽位则从施法者副手读取。读取位置无片段则返回void。

;;;;;

#<trickster:trick id="trickster:write_spell" />

将法术片段抄入所给槽位中的物品，未指定槽位则抄入施法者副手。会在执行一次[衰退](*trickster:concepts/fragment_decay)之后返回其输入值。

;;;;;

#<trickster:trick id="trickster:clear_spell" />

清除所给槽位中物品上的法术片段，未指定槽位则清除施法者副手。

;;;;;

#<trickster:trick id="trickster:reveal" />

将给定的所有值作为聊天消息发送给施法者，返回第一输入片段。

;;;;;

#<trickster:trick id="trickster:reveal_action_bar" />

将所有输入展示到施法者的快捷栏上方，返回第一输入。未提供输入则清空。

;;;;;

#<trickster:note title="乌鸦之思" />

乌鸦之思（不应与其他黑鸟之思混淆）能让法术存入或取回一个法术片段，且该片段会在不同次施法间**保留**。


乌鸦之思可以用作计数器，用来标记位置，以及用来选定目标。

;;;;;

#<trickster:trick id="trickster:read_crow_mind" />

返回施法者乌鸦之思中的值。

;;;;;

#<trickster:trick id="trickster:write_crow_mind" />

将所给值存进施法者的乌鸦之思，并覆盖其中的值。
