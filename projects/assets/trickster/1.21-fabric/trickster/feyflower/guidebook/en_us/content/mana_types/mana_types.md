```json
{
  "title": {
    "text": "Types of Mana",
    "modifiers": [
      "italic"
    ]
  },
  "icon": "minecraft:dragon_breath",
  "ordinal": -10,
  "book_texture_override": "trickster:white_note"
}
```

Now this is very interesting. It seems this book, elaborate as it is, 
completely fails to document the existence of discrete *types* of Mana.


Now that I'm looking for it though, it is clearly implicitly mentioned in a few places.
For example, with [Astrafel's](*trickster:tricks/ploys/mana@trick&trickster:convert_mana) and [Terrafel's](*trickster:tricks/ploys/mana@trick&trickster:trigger_converter) ploys.


This might imply that Mana types are common knowledge to the target audience of this book, and just not worth mentioning.

;;;;;

Regardless, I suppose I shall have to do the documenting in their absence.


As far as I can tell, a Knot can only hold one type of Mana at a time.
The type of mana stored can be gotten as a fragment using [Derivate Ingress](*trickster:tricks/delusions_ingresses/mana@trick&trickster:get_mana_type_in_slot),
which can in turn be used to filter [transfers](*trickster:tricks/ploys/mana@note&Mana Transfers).


For lack of a better term, I shall refer to the type of mana I'm most used to as Traditional.
This is still the only type I can use for the vast majority of tricks.


I'm not sure how many types of Mana are out there, and I don't think there's any easy way to find out.
