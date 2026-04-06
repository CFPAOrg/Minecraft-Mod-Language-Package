```json
{
  "title": "Lists",
  "icon": "minecraft:string",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Tally Distortion",
    "Expansion Stratagem",
    "Collection Stratagem",
    "Isolation Distortion",
    "Counter Distortion",
    "Inflation Stratagem",
    "Extraction Distortion",
    "Locating Distortion",
    "Expulsion Stratagem",
    "Eviction Stratagem",
    "Interlude Distortion"
  ]
}
```

Within spells, it is possible to create lists of an arbitrary amount of fragments merged into a single value.


Lists are zero indexed. To acquire an empty list constant, see the relevant [revision](^trickster:constants#3).

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

<|glyph@trickster:templates|trick-id=trickster:list_take_range,title=Isolation Distortion|>

any[], number, [number] -> any[]

---

Returns a list containing the elements of the given list with indexes starting at the first number and ending before the second.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:list_reverse,title=Counter Distortion|>

any[] -> any[]

---

Returns the given list, reversed.

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

;;;;;

<|glyph@trickster:templates|trick-id=trickster:create_number_range,title=Interlude Distortion|>

number, number -> number[]

---

Returns a list containing the range of integer numbers starting at the first given number and ending before the second.