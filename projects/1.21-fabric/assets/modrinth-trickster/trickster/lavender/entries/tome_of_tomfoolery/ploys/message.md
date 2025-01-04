```json
{
  "title": "Interspell Communication",
  "icon": "minecraft:feather",
  "category": "trickster:ploys"
}
```

Utilizing the following tricks, spells may communicate with each other.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:message_send,title=Dispatch Ploy|>

any, [number] -> any

<|cost-rule@trickster:templates|formula=max(0kG\, range - 16kG)|>

Sends the given fragment to all spells within 16 blocks. Range may be extended by the given number at the cost of mana.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:message_listen,title=Ploy of Receipt|>

-> any[]

---

Returns all messages received on the tick after they were received. Will not return until at least one message is received.
