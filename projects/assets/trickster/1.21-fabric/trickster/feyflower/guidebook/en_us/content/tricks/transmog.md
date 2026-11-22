```json
{
  "title": "Transmogrification",
  "icon": "transmog:void_fragment",
  "ordinal": 100,
  "fabric:load_conditions": {
    "condition": "fabric:any_mods_loaded",
    "values": [
      "transmog"
    ]
  }
}
```

Unlike some, this world supports the transmogrification of one item into another.


Transmogrification is a way to change purely the appearance of items, 
keeping all their attributes and other behaviour intact.

;;;;;

#<trickster:trick id="trickster:transmog" />

Transmogrifies the item in the given slot to appear as the given item.

;;;;;

#<trickster:trick id="trickster:hidden_transmog" />

Applies a void transmogrification to the item in the given slot.

;;;;;

#<trickster:trick id="trickster:remove_transmog" />

Removes any transmogrification from the item in the given slot.

;;;;;

#<trickster:trick id="trickster:get_transmog" />

Returns the transmogrification on the item in the given slot, or $$trickster:void$$ if none is applied.
