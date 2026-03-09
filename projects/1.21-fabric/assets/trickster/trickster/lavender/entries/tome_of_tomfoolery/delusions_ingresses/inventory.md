```json
{
  "title": "Inventory Information",
  "icon": "minecraft:bundle",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Fence's Ingress",
    "Juggling Delusion",
    "Catch Delusion",
    "Stockpile Ingress",
    "Basin Ingress",
    "Intrusive Ingress",
    "Collector's Ingress",
    "Ingress of Inventory",
    "Cranium Delusion",
    "Ingress of Authority",
    "Crowning Ingress",
    "Ingress of Plenitude",
    "Investigative Ingress"
  ]
}
```

These are tricks that pull information from an inventory.
This can either be the caster's own, or an external block or entity.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_in_slot|>

Returns the type of item that the given slot contains.

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand|>

Returns the type of item in the caster's offhand.

;;;;;

<|page-title@lavender:book_components|title=Note: Slot References|>Resource slots may be referenced by spells.
Creating such a reference comes at no cost. However, using the reference in a way that moves the resources within the slot, will incur a move cost.
This cost is equivalent to (distance * amount * 0.5G).

;;;;;

Slot references either use the position of the caster at the time of move, or the position of their target when calculating cost.


Many entities, like dropped items, minecarts, and donkeys can be interacted with as containers. 
This is not the case for players that are not the caster.

;;;;;

<|trick@trickster:templates|trick-id=trickster:other_hand_slot|>

Returns a slot reference of the caster's offhand.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_item_container|>

;;;;;

Returns a reference to the item container of the passed value, or of the caster.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_fluid_container|>

Returns a reference to the fluid container of the passed value.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_slot|>

Constructs and returns a slot from a container and the given index. Blunders if the container has no slotted representation.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_slots|>

Returns a list of slots from a container. Blunders if the container has no slotted representation.

;;;;;

A resource type or list of them may be passed as a filter to get only relevant slots from the container.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_resources|>

Returns a list of resource types in the container.

;;;;;

<|trick@trickster:templates|trick-id=trickster:count_resources|>

Returns the amount of the given resource type in the container.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_inventory_size|>

Returns the number of slots in a container.

;;;;;

<|trick@trickster:templates|trick-id=trickster:check_hat|>

Returns the selected slot in the caster's [Hat](^trickster:items/top_hat).

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_mana_in_slot|>

Returns the amount of mana in the given slots.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_max_mana_in_slot|>

Returns the maximum amount of mana which may be stored in total in the given slots.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_count_in_slot|>

Returns the amount of items stored in the given slot.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_equipment|>

Returns a list of the given entity's currently worn equipment as item types. Comes in the order: mainhand, offhand, boots, leggings, chestplate, helmet
