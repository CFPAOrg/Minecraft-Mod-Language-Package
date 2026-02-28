```json
{
  "title": "Interspell Communication",
  "icon": "minecraft:feather",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Dispatch Ploy",
    "Ploy of Receipt"
  ]
}
```

Utilizing the following tricks, otherwise separate spells may communicate with each other.

;;;;;

<|ploy@trickster:templates|trick-id=trickster:message_send,cost=max(0G\, range - 16G)|>

Sends the given fragment to all spells within 16 blocks. Range may be extended by the given number at the cost of mana.

;;;;;

<|trick@trickster:templates|trick-id=trickster:message_listen|>

Returns all messages received on the tick after they were received. Must be provided with a timeout after which to return anyway.

;;;;;

A slot fragment may be supplied as the second argument to Dispatch Ploy instead of a number,
which will send the message *into* the item present in that slot, if possible.


Ploy of Receipt works similarly for receiving messages *from* items.


Not all items are able to channel messages.