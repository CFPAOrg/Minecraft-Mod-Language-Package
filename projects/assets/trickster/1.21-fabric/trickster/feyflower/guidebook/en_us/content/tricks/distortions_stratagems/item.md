```json
{
  "title": "Items",
  "icon": "minecraft:grass_block"
}
```

Tricks that transform item-related fragments.

;;;;;

#<trickster:trick id="trickster:block_from_item" />

Returns the block type the given item type can be placed as, or void if the item is not a block.

;;;;;

#<trickster:trick id="trickster:item_from_block" />

Returns the item type that can be used to place the given block type,
or void if the block doesn't have a corresponding item.

;;;;;

#<trickster:trick id="trickster:get_max_count" />

Returns the maximum stack size of the given item.
