```json
{
  "title": "Transmogrification",
  "icon": "transmog:void_fragment",
  "category": "trickster:tricks",
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

<|glyph@trickster:templates|trick-id=trickster:transmog,title=Ploy of Transmogrification|>

slot, item -> boolean

<|cost-rule@trickster:templates|formula=20kG|>

Transmogrifies the item in the given slot to appear as the given item. Returns true if changes were made.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:hidden_transmog,title=Ploy of Subterfuge|>

slot -> boolean

<|cost-rule@trickster:templates|formula=30kG|>

Applies a void transmogrification to the item in the given slot. Returns true if changes were made.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:remove_transmog,title=Ploy of Origin|>

slot -> boolean

<|cost-rule@trickster:templates|formula=10kG|>

Removes any transmogrification from the item in the given slot. Returns true if changes were made.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_transmog,title=Ingress of Transmogrification|>

slot -> item

---

Returns the transmogrification on the item in the given slot, or void if none is applied.
