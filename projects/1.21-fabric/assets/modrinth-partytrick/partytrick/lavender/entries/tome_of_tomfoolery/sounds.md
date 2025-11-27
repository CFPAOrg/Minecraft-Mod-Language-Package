```json
{
  "title": "Sounds",
  "icon": "minecraft:music_disc_5",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Mike's Ingress",
    "Siren's Ploy",
    "Ploy of Tismphones"
  ]
}
```

*"A question often asked is: "If a tree falls in a forest and no one is around to hear it, does it make a sound?". The answer does not matter, all that is important is how the sound can be obtained. Magic does not have ears or some other way to perceive sound. Instead, a human can be queried to make use of their perception."*

-- Drunk Dutch wizard at 2am explaining sound (PartyTrick)

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_sound|>

Returns a list of sounds that just hit given player's ear drums. The output only changing every tick

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:play_sound,cost=2G|>

Plays a sound at the given location optionally volume, pitch and players who will hear it can be provided.

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:muffle_sound,cost=10G|>

Changes the mental perception of the volume of the given sounds or all if none provided. By adding the given number to a multiplier