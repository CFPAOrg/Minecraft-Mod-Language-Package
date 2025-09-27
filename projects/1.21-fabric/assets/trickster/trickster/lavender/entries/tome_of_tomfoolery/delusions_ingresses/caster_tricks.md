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

*"More often than not, casting a spell will start from the Self."*


*"Whether it be a human caster, a construct, or something else entirely,*
*the Self is how we perceive the world, and as such, it is the lens through which we view our magic."*


-- An excerpt from a lecture by Prof. Citrine.

;;;;;

<|trick@trickster:templates|trick-id=trickster:reflection|>

Returns the location the spell is being cast from.

;;;;;

<|trick@trickster:templates|trick-id=trickster:facing_reflection|>

Returns the direction the caster is facing as a unit vector.

;;;;;

<|trick@trickster:templates|trick-id=trickster:caster_reflection|>

Returns the entity casting the spell, if available.

;;;;;

<|trick@trickster:templates|trick-id=trickster:mana_reflection|>

Returns the amount of mana directly available to the spell.

;;;;;

This delusion counts the amount of mana in all mana-carrying items the caster is holding or wearing, 
including [Knots](^trickster:items/knots) and [Whorls](^trickster:items/amethyst_whorl).


When cast from a [Spell Construct](^trickster:items/spell_construct), only the mana in the Construct's one Knot slot is counted.

;;;;;

<|trick@trickster:templates|trick-id=trickster:max_mana_reflection|>

Returns the maximum amount of mana that the caster of the spell can store. Works similarly to the previous delusion.

;;;;;

<|trick@trickster:templates|trick-id=trickster:current_thread|>

Returns the spell slot running this spell, or void if this spell is not running in a spell slot.

;;;;;

<|trick@trickster:templates|trick-id=trickster:read_macro_ring|>

Returns a map containing the combined maps of all rings worn, with any entries that aren't valid macros filtered out.

;;;;;

The result of this trick is equal to the map used when evaluating macros.


See the entry on [Macros](^trickster:concepts/macro) for more details.

;;;;;

<|trick@trickster:templates|trick-id=trickster:hotbar_reflection|>

Returns the selected hotbar slot of the caster, if available.

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_dimension|>

Returns the dimension where this spell is being cast.
