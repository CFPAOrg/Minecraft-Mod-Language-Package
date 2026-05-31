```json
{
  "title": "Inventory Information",
  "icon": "minecraft:bundle",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Fence's Ingress",
    "Juggling Delusion",
    "Catch Delusion",
    "Intrusive Ingress",
    "Cranium Delusion",
    "Ingress of Authority",
    "Crowning Ingress",
    "Ingress of Plenitude"
  ]
}
```

Tricks that pull information from the caster's inventory.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_item_in_slot,title=Fence's Ingress|>

slot -> item

---

Returns the type of item that the given slot contains.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:other_hand,title=Juggling Delusion|>

-> item

---

Returns the type of item in the caster's other hand.

;;;;;

<|page-title@lavender:book_components|title=Note: Slot References|>Item slots may be referenced by spells.
Creating such a reference comes at no cost. However, using the reference in a way that moves the items within the slot, will incur a move cost.
This cost is equivalent to (distance * amount * 0.5kG). Slot references will always point to a block position, or use the *current caster at the time of move*.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:other_hand_slot,title=Catch Delusion|>

-> slot

---

Returns a slot reference of the caster's other hand.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_inventory_slot,title=Intrusive Ingress|>

number, [vector | entity] -> slot

---

Constructs a slot from an index and an inventory source, using the caster by default.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:check_hat,title=Cranium Delusion|>

-> number | void

---

Returns the selected slot in the caster's [Top Hat](^trickster:items/top_hat).

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_mana_in_slot,title=Ingress of Authority|>

slot... -> number

---

Returns the amount of mana in the given slots.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_max_mana_in_slot,title=Crowning Ingress|>

slot... -> number

---

Returns the maximum amount of mana which may be stored in the given slots.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_count_in_slot,title=Ingress of Plenitude|>

slot -> number

---

Returns the amount of items stored in the given slot.

;;;;;