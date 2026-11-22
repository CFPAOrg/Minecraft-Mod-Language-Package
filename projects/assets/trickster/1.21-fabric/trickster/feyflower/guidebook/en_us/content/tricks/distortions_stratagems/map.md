```json
{
  "title": "Maps",
  "icon": "minecraft:filled_map"
}
```

This chapter describes tricks that can be used to work with maps. 
Maps allow for an association between one fragment and another, 
similarly to how a dictionary associates a word with a definition.

;;;;;

#<trickster:revision id="trickster:empty_map" />

A [Constant Revision](*trickster:constants) that replaces the glyph with an empty map.

;;;;;

#<trickster:trick id="trickster:list_size" />

Returns the amount of entries in the given map.

;;;;;

#<trickster:trick id="trickster:map_insert" />

Inserts key-value pairs into the given map.

;;;;;

#<trickster:trick id="trickster:map_merge" />

Combines many maps into one. Duplicate entries are prioritized by input index.

;;;;;

#<trickster:trick id="trickster:map_get" />

If there is a value associated with the given fragment, returns it. Otherwise, returns void.

;;;;;

#<trickster:trick id="trickster:map_get_keys" />

Returns a list of all keys in the given map.

;;;;;

#<trickster:trick id="trickster:map_get_values" />

Returns a list of all values in the given map.

;;;;;

#<trickster:trick id="trickster:map_remove" />

Removes entries from the given map which have any of the given keys.
