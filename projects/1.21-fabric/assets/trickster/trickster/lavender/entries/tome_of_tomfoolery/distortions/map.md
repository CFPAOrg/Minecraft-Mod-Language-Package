```json
{
  "title": "Maps",
  "icon": "minecraft:filled_map",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Cartographer's Delusion",
    "Charting Stratagem",
    "Navigator's Distortion",
    "Admiral's Stratagem",
    "Stratagem of Annulment"
  ]
}
```

This chapter describes patterns that can be used to work with maps. 
Maps allow for an association between one fragment and another, 
similarly to how a dictionary associates a word with a definition.

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_create|>

Creates a new empty map.

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_insert|>

Inserts key-value pairs into the given map.

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_get|>

If there is a value associated with the given fragment, returns it. Otherwise, returns void.

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_merge|>

Combines many maps into one. Duplicate entries are prioritized by input index.

;;;;;

<|trick@trickster:templates|trick-id=trickster:map_remove|>

Removes entries from the given map which have any of the given keys.
