```json
{
  "title": "Maps",
  "icon": "minecraft:filled_map",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Charting Stratagem",
    "Navigator's Distortion",
    "Admiral's Stratagem",
    "Stratagem of Annulment"
  ]
}
```

This chapter describes patterns that can be used to work with maps. 
Maps allow for an association between one fragment and another, 
similarly to how a dictionary associates a word to a definition.


To acquire an empty map constant, see the relevant [revision](^trickster:constants#4).

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_insert,title=Charting Stratagem|>

{any: any}, [any, any]... -> any

---

Inserts key-value pairs into the given map.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_get,title=Navigator's Distortion|>

{any: any}, any -> any

---

If there is a value associated with the given fragment, returns it. Otherwise, returns void.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_merge,title=Admiral's Stratagem|>

{any: any}, {any: any}... -> {any: any}

---

Combines many maps into one. Duplicate entries are prioritized by input index.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:map_remove,title=Stratagem of Annulment|>

{any: any}, any... -> {any: any}

---

Removes entries from the given map which have any of the given keys.
