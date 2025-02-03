```json
{
  "title": "Basic Tricks",
  "icon": "minecraft:bricks",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Notulist's Delusion",
    "Notulist's Ploy",
    "Proprietary Notulist's Ploy",
    "Alethophobe's Ploy",
    "Showcase Stratagem",
    "Crow Mind Delusion",
    "Crow Mind Ploy",
    "Cost Ploy"
  ]
}
```

Here listed are the most basic but useful general purpose tricks.
Any aspiring magician is recommended to learn these.

;;;;;

<|page-title@lavender:book_components|title=Note: Inscribed Fragments|>A fragment can be inscribed onto any item that a player can hold in their inventory.
If inscribed on a block, the fragment will be removed if the block is placed.


Some items may have additional interactions when inscribed with fragments, 
[Wands](^trickster:items/wand) for example will cast a spell fragment when right-clicked.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_spell,title=Notulist's Delusion|>

-> any

---

If the item in the caster's other hand contains an inscribed fragment, returns the fragment.
If not, returns void.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_spell,title=Notulist's Ploy|>

any, [slot] -> any

---

Inscribes a fragment onto the item in the given slot or in the caster's offhand.
Returns its input, after ephemeral decay.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_closed_spell,title=Proprietary Notulist's Ploy|>

any, [slot] -> any

---

Same as Notulist's Ploy, but the fragment cannot be read by conventional means.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:clear_spell,title=Alethophobe's Ploy|>

[slot] -> 

---

Clears any fragment inscribed onto the item in the given slot or in the caster's offhand.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:reveal,title=Showcase Stratagem|>

any... -> any

---

Shows all given values as a chat message to the caster and returns the first.

;;;;;

<|page-title@lavender:book_components|title=Note: The Crow Mind|>The Crow Mind, not to be confused with other black bird related minds, 
lets spells store and retrieve any one fragment, **persistently**, between casts.


This can be used for many things, such as counters, 
marking locations, and selecting targets.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:read_crow_mind,title=Crow Mind Delusion|>

-> any

---

Returns the value currently stored in the caster's crow mind.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:write_crow_mind,title=Crow Mind Ploy|>

any -> any

---

Stores the supplied value in the caster's Crow Mind, overwriting any value that might already be present.

;;;;;

<|page-title@lavender:book_components|title=Note: Casting Cost|>After receiving multiple complaints at Tomfoolery Inc. HQ about the balance of this mod,
we've decided to properly implement material spell casting costs.


However, player freedom and choice is also very important to us.
As such, this system operates on an opt-in basis.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:cost,title=Cost Ploy|>

->

---

Consumes one amethyst shard from the caster's inventory. Will blunder if none are available.