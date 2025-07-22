```json
{
  "title": "Casting Context",
  "icon": "trickster:wand",
  "category": "trickster:delusions_ingresses",
  "additional_search_terms": [
    "Positioning Delusion",
    "Directional Delusion",
    "Reflection Delusion",
    "Dimensional Delusion",
    "Authority Delusion",
    "Crowning Delusion",
    "Delusion of Order",
    "Framed Delusion",
    "Macro Delusion"
  ]
}
```

This entry contains delusion tricks that retrieve context about the casting entity or block.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:reflection,title=Positioning Delusion|>

-> vector

---

Returns the location the spell is being cast from.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:facing_reflection,title=Directional Delusion|>

-> vector

---

Returns the direction the casting block or entity is facing as a unit vector, if available.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:caster_reflection,title=Reflection Delusion|>

-> entity

---

Returns the entity casting the spell.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_dimension,title=Dimensional Delusion|>

-> dimension

---

Returns the dimension which the caster is in.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:mana_reflection,title=Authority Delusion|>

-> number

---

Returns the amount of mana directly available to the spell.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:max_mana_reflection,title=Crowning Delusion|>

-> number

---

Returns the maximum amount of mana that *could be* available to the spell.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:current_thread,title=Delusion of Order|>

-> number | void

---

Returns the spell slot running this spell, or void if spell slots are not supported.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:hotbar_reflection,title=Framed Delusion|>

-> number

---

Returns the selected hotbar slot of the caster, if available.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_macro_ring,title=Macro Delusion|>

-> {pattern: spell}

---

Retrieves a map containing the combined maps of all rings worn.
