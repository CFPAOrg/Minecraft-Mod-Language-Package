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

本节的戏法能让不同法术间互相沟通交流。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:message_send,title=派遣之技巧|>

any, [number] -> any

<|cost-rule@trickster:templates|formula=max(0kG\, 范围 - 16kG)|>

将传入的片段发送到16格内的所有法术。可给定范围参数扩展范围，此时需消耗魔力。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:message_listen,title=收据之技巧|>

number -> any[]

---

在收到消息的后一刻返回所有消息。必须指定超时时间，在此时间后无论收到消息与否均返回。
