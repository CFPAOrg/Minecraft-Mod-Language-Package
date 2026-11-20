```json
{
  "title": "Items",
  "icon": "minecraft:grass_block",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Placement Distortion",
    "Pickup Distortion",
    "Distortion of Breadth"
  ]
}
```

Tricks that transform item-related fragments.

;;;;;

<|trick@trickster:templates|trick-id=trickster:block_from_item|>

Returns the block type the given item type can be placed as, or void if the item is not a block.

;;;;;

<|trick@trickster:templates|trick-id=trickster:item_from_block|>

Returns the item type that can be used to place the given block type,
or void if the block doesn't have a corresponding item.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_count|>

Returns the maximum stack size of the given item.
