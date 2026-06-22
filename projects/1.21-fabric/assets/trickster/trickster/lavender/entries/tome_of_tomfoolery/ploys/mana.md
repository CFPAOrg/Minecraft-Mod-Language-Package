```json
{
  "title": "A Shimmer in the Night",
  "icon": "trickster:echo_knot",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of the Moon Watcher",
    "Benevolent Conduit's Ploy",
    "Malevolent Conduit's Ploy",
    "Astrafel's Ploy",
    "Terrafel's Ploy"
  ]
}
```

*"mun en kon suli o lawa e mi*


*o pana tawa mi*


*o pona e mi"*


— jan Enali

;;;;;

<|trick@trickster:templates|trick-id=trickster:battery_creation|>

Creates a [Knot](^trickster:items/mana/knots) using the crystal in the given slot and a Glass Block. Uses amethyst if no first slot is provided.

;;;;;

<|page-title@lavender:book_components|title=Note: Mana Transfers|>Mana can only ever be moved between the caster's 
reserves and external storages, never between two arbitrary external storages. 
When pushing to or pulling from a storage with multiple slots, load is equally split between all of them.


When pulling or pushing mana over a distance lesser than 16 blocks, transfers are lossless.

;;;;;

Over greater distances though, 
a loss is incurred proportional to the amount of mana transferred multiplied by distance.


This loss follows a roughly exponential scale, reaching around 50% at or near 100 blocks of distance.

;;;;;

The provided amount is split equally between all slots of the provided storage, even if the given slots cannot provide or store a sufficient amount of mana. Any mana that would overflow a slot is not transferred.

;;;;;

<|trick@trickster:templates|trick-id=trickster:push_mana|>

Pushes mana into the given storage from the caster's reserves, up to an amount. Returns the amount pushed.

;;;;;

<|trick@trickster:templates|trick-id=trickster:pull_mana|>

Pulls mana from the given storage into the caster's reserves, up to an amount. Returns the amount pulled.

;;;;;

<|trick@trickster:templates|trick-id=trickster:convert_mana|>

Attempts to convert mana in-place to the given type. Returns the amount converted.

;;;;;

<|trick@trickster:templates|trick-id=trickster:trigger_converter|>

Activates the mana-conversion catalyst in the given slot, returning the mana type if it changed.
