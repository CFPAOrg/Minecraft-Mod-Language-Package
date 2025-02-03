```json
{
  "title": "Items",
  "icon": "minecraft:grass_block",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Placement Distortion",
    "Pickup Distortion"
  ]
}
```

Tricks that transform item-related fragments.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:block_from_item,title=Placement Distortion|>

item -> block | void

---

Returns the block type the given item type can be placed as, or void if the item is not a block.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:item_from_block,title=Pickup Distortion|>

block -> item | void

---

Returns the item type that can be used to place the given block type,
or void if the block doesn't have a corresponding item.