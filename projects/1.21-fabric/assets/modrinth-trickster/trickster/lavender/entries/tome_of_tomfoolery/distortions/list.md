```json
{
  "title": "List Manipulation",
  "icon": "minecraft:string",
  "category": "trickster:distortions"
}
```

Within spells, it is possible to create lists of an arbitrary amount of fragments merged into a single value.


Lists are zero indexed.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_size,title=Tally Distortion|>

any[] -> number

---

Returns the amount of elements in the given list.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_add,title=Expansion Stratagem|>

any[], any... -> any[]

---

Appends one or many elements to the end of the given list.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_add_range,title=Collection Stratagem|>

any[], any[]... -> any[]

---

Creates a new list containing the elements of all given lists.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_insert,title=Inflation Stratagem|>

any[], number, any... -> any[]

---

Inserts one or many elements at a specific position in the given list.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_get,title=Extraction Distortion|>

any[], number -> any

---

Finds and returns an element from the given list based on index.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_index_of,title=Locating Distortion|>

any[], any -> number | void

---

Finds and returns the index of a specific element in the given list, or void if the element is not in the list.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_remove,title=Expulsion Stratagem|>

any[], number... -> any[]

---

Removes one or many elements from the given list by their index. Indexes do not move around mid-removal.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_remove_element,title=Eviction Stratagem|>

any[], any... -> any[]

---

Removes one or many elements from the given list by checking their equality with the set of given fragments.
