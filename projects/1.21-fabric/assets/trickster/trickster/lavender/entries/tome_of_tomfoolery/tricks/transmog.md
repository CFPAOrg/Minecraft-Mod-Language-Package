```json
{
  "title": "Transmogrification",
  "icon": "transmog:void_fragment",
  "category": "trickster:tricks",
  "ordinal": 100,
  "additional_search_terms": [
    "Ploy of Transmogrification",
    "Ploy of Subterfuge",
    "Ploy of Origin",
    "Ingress of Transmogrification"
  ],
  "fabric:load_conditions": {
    "condition": "fabric:any_mods_loaded",
    "values": [
      "transmog"
    ]
  }
}
```

It seems that, unlike some, this world supports the transmogrification of one item into another.


Transmogrification is a way to change purely the appearance of items, 
keeping all their attributes and other behaviour intact.

;;;;;

<|trick@trickster:templates|trick-id=trickster:transmog|>

Transmogrifies the item in the given slot to appear as the given item. Returns true if changes were made.

;;;;;

<|trick@trickster:templates|trick-id=trickster:hidden_transmog|>

Applies a void transmogrification to the item in the given slot. Returns true if changes were made.

;;;;;

<|trick@trickster:templates|trick-id=trickster:remove_transmog|>

Removes any transmogrification from the item in the given slot. Returns true if changes were made.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_transmog|>

Returns the transmogrification on the item in the given slot, or void if none is applied.
