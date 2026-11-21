```json
{
  "title": "Inventory Information",
  "icon": "minecraft:bundle"
}
```

These are tricks which acquire information relating to $$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$s.


Remember: Creating a $$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$ comes at no cost. However, 
moving the contained resources will always have a cost of (distance * amount * 0.5G). 
**Move costs are NOT noted as part of the cost of any ploy.**

;;;;;

#<trickster:trick id="trickster:get_item_in_slot" />

Returns the type of item that the given slot contains.

;;;;;

#<trickster:trick id="trickster:get_slots" />

Returns a list of slots from a container. Blunders if the container has no slotted representation.

;;;;;

A resource type or list of them may be passed as a filter to get only relevant slots from the container.

;;;;;

#<trickster:trick id="trickster:list_resources" />

Returns a list of resource types in the container.

;;;;;

#<trickster:trick id="trickster:count_resources" />

Returns the amount of the given resource type in the container.

;;;;;

#<trickster:trick id="trickster:get_inventory_size" />

Returns the number of slots in a container.

;;;;;

#<trickster:trick id="trickster:get_count_in_slot" />

Returns the amount of items stored in the given slot.

;;;;;

#<trickster:trick id="trickster:get_durability" />

Returns how much durability the item in the given slot has left as a number.

;;;;;

#<trickster:trick id="trickster:get_max_damage" />

Returns the maximum amount of damage the item in the given slot can sustain.
