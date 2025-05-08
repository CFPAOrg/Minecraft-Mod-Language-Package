```json
{
  "title": "Spells",
  "icon": "minecraft:oak_sapling",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Supply Distortion",
    "Closure Stratagem",
    "Pinpoint Distortion",
    "Discovering Distortion",
    "Retrieval Distortion",
    "Replacement Distortion",
    "Bundle Distortion",
    "Felling Distortion",
    "Grafting Distortion",
    "Branching Distortion",
    "Pruning Distortion"
  ]
}
```

Although [Scribing Patterns](^trickster:editing) allow for spells to be edited before they are cast, 
the following patterns allow for a spell to modify other spells *during* the cast.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:supplier,title=Supply Distortion|>

any -> spell

---

Creates a new spell fragment which returns the previously provided fragment when executed.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:closure,title=Closure Stratagem|>

spell, {any: any} -> spell

---

Replaces the keys of the map that are in the given spell with the value they map to.

;;;;;

<|page-title@lavender:book_components|title=Note: Addresses|>Just as elements of a list are accessed by their index, 
parts of a spell are accessed by their address. 
An address is a list of integers that forms a path to a specific circle in a spell.

;;;;;

To find the address of a circle, start at the central circle in the spell. Next, find the sub-circle attached to the central circle that is in the
path to the circle you are finding the address of. Take the index of that circle, which is the number of circles that come before it, counterclockwise. 
Repeat this process, adding each index to the list until you reach the circle you are finding the address of. The list you constructed is the address to
that circle.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:locate_glyph,title=Pinpoint Distortion|>

spell, any -> number[] | void

---

Returns the address of the first circle in the given spell with a glyph matching the given fragment. 
The spell is searched using [BFS](https://en.wikipedia.org/wiki/Breadth-first_search).

;;;;;

<|glyph@trickster:templates|trick-id=trickster:locate_glyphs,title=Discovering Distortion|>

spell, any -> number[][]

---

Returns a list of all the addresses of circles in the given spell with a glyph matching the given fragment.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:retrieve_glyph,title=Retrieval Distortion|>

spell, number[] -> any

---

Returns the glyph of the circle at the given address.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_glyph,title=Replacement Distortion|>

spell, number[], any -> spell

---

Replaces the glyph of the circle at the given address with the given fragment.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_subparts,title=Bundle Distortion|>

spell -> spell[]

---

Returns the branches of a spell as a list.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:retrieve_subtree,title=Felling Distortion|>

spell, number[] -> spell | void

---

Returns the circle (and its branches) at the given address.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_subtree,title=Grafting Distortion|>

spell, number[], spell -> spell

---

Grafts the latter spell into the former, replacing the circle at the given address.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add_subtree,title=Branching Distortion|>

spell, number[], spell -> spell

---

Attaches the latter spell to the circle at the given address as a new branch.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:remove_subtree,title=Pruning Distortion|>

spell, number[] -> spell | void

---

Removes the circle at the given address. Returns void if the root node is removed.
