```json
{
  "title": "Spell Deviations",
  "icon": "minecraft:paper",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "Deviation of Suspension",
    "Grand Deviation",
    "Quiet Deviation",
    "Utensil Deviation",
    "Folding Deviation",
    "Cautious Deviation",
    "Deviation of Singularity",
    "Executioner's Deviation"
  ]
}
```

Just as values can be created, passed around, and used by spells, so can parts of the spell itself.


When nesting one circle as a glyph inside another, 
but not immediately providing any subcircles to the upper circle, 
the upper circle will return the inner circle as a fragment.

;;;;;

This fragment can then be used in a number of ways, including being written to an item using [Notulist's Ploy](^trickster:tricks/basic#4), 
and being cast later or even multiple times within the same spell.


It is also very possible to pass a spell fragment inside of itself, and execute it again there, 
using recursion to create what is essentially a loop.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:delay_execution,title=Deviation of Suspension|>

[number] -> number

---

Delays the execution of the current spell by the given number of ticks, or until the next tick. 
Returns the delay.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:execute,title=Grand Deviation|>

spell, any... -> any

---

A powerful trick indeed, it executes the passed in spell fragment, 
providing it with all other passed in fragments as arguments.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:execute_same_scope,title=Quiet Deviation|>

spell -> any

---

Executes the given spell with the current spell's arguments.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:fork,title=Utensil Deviation|>

spell, any... -> number

---

Dispatches the given spell to a free spell slot. The used spell slot is returned, or a negative if it failed.

;;;;;

<|page-title@lavender:book_components|title=Note: Collections|>Collections are fragments which contain other fragments and may be accessed using a specific key. 
Lists are collections where the key is a whole number between zero and the size of the list, exclusive. 
Maps are also collections, though their keys may be any value and aren't automatically determined by order of insertion.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:fold,title=Folding Deviation|>

spell, collection, any -> any

---

For each entry in the collection, execute the given spell, with the given fragment as the first result.

;;;;;

Each iteration receives four arguments:

---

any, any, any, collection

---

Where the first argument is the result of the last iteration, the second is the current value, the third is its key, 
and the fourth is the given collection.

;;;;;

The result of each execution is passed as the first argument to the next, where the last's result is the return of this trick.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:try_catch,title=Cautious Deviation|>

spell, spell, any... -> any

---

Attempts to execute the first spell. If it blunders, the second spell is run and the blunder is silenced. Excess values are arguments to both.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:atomic,title=Deviation of Singularity|>

spell, any... -> any

---

Executes the given spell in a single tick, blundering if it's not possible due to spell size or illegal operations.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:kill_thread,title=Executioner's Deviation|>

[number] -> boolean

---

Ends the spell running in the given spell slot or the current slot if not provided. Returns whether it succeeded.

;;;;;

<|page-title@lavender:book_components|title=Note: Arguments|>Fragments can be passed into executed spell fragments as arguments.


See the chapter on [arguments](^trickster:delusions_ingresses/arguments) for more information.
