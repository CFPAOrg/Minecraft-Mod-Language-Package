```json
{
  "title": "Lists",
  "icon": "minecraft:string",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Catalogue Delusion",
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


Lists are zero indexed.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_create|>

Creates a new empty list.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_size|>

Returns the amount of elements in the given list.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_add|>

Appends one or many elements to the end of the given list.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_add_range|>

Creates a new list containing the elements of all given lists.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_take_range|>

Returns a list containing the elements of the given list with indexes starting at the first number and ending before the second.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_reverse|>

Returns the given list, reversed.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_insert|>

Inserts one or many elements at a specific position in the given list.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_get|>

Finds and returns an element from the given list based on index.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_index_of|>

Finds and returns the index of a specific element in the given list, or void if the element is not in the list.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_remove|>

Removes one or many elements from the given list by their index. Indexes do not move around mid-removal.

;;;;;

<|trick@trickster:templates|trick-id=trickster:list_remove_element|>

Removes one or many elements from the given list by checking their equality with the set of given fragments.

;;;;;

<|trick@trickster:templates|trick-id=trickster:create_number_range|>

Returns a list containing the range of integer numbers starting at the first given number and ending before the second.
