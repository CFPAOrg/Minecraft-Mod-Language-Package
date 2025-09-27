```json
{
  "title": "法术间交流",
  "icon": "minecraft:feather",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "派遣之技巧",
    "收据之技巧"
  ]
}
```

本节的戏法能让原本相互独立的法术互相沟通交流。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:message_send,cost=max(0G\, 范围 - 16G)|>

将传入的片段发送给16格内的所有法术。可给定范围参数扩展范围，此时需消耗魔力。

;;;;;

<|trick@trickster:templates|trick-id=trickster:message_listen|>

在收到消息的后一刻返回所有消息。必须指定超时时间，在此时间后无论收到消息与否均返回。

;;;;;

派遣之技巧的第二参数不只会接受数，槽位片段也可以。如可行，此情况下消息会*直接*发送给该槽位中的物品。


收据之技巧也有此性质，可用其*直接*从物品中接受消息。


不是所有物品都能用于传递消息。