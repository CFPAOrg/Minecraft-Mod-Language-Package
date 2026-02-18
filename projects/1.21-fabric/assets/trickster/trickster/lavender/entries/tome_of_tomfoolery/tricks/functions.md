```json
{
  "title": "Spell Deviations",
  "icon": "minecraft:paper",
  "category": "trickster:tricks",
  "ordinal": 10,
  "additional_search_terms": [
    "Deviation of Suspension",
    "Grand Deviation",
    "Quiet Deviation",
    "Utensil Deviation",
    "Folding Deviation",
    "Cautious Deviation",
    "Deviation of Singularity",
    "Executioner's Deviation",
    "Ingress of Origin",
    "Turtle's Ingress"
  ]
}
```

Just as values can be created, passed around, and used by spells, so can parts of the spell itself.


When nesting one circle as a glyph inside another, 
but not immediately providing any subcircles to the outer circle, 
the outer circle will return the entire inner circle with all its subcircles and glyphs as a fragment.

;;;;;

This fragment can be used in a number of ways, including being written to an item using [Notulist's Ploy](^trickster:tricks/basic#4), 
and being cast later or reused multiple times within the same spell.


It is also very possible to pass a spell fragment inside of itself, and cast it again there, 
using recursion to create repeating behaviour.

;;;;;

<|trick@trickster:templates|trick-id=trickster:delay_execution|>

Delays the execution of the current spell by the given number of ticks, or until the next tick. 
Returns the delay.

;;;;;

<|trick@trickster:templates|trick-id=trickster:execute|>

Casts the given spell fragment, 
providing it with all additional given fragments as arguments, in order of their appearance.

;;;;;

<|trick@trickster:templates|trick-id=trickster:execute_same_scope|>

Casts the given spell with the current spell's arguments.

;;;;;

<|trick@trickster:templates|trick-id=trickster:try_catch|>

Attempts to execute the first spell. If it blunders, the second spell is run and the blunder is silenced. Excess values are arguments to both.

;;;;;

<|trick@trickster:templates|trick-id=trickster:atomic|>

Executes the given spell in a single tick, blundering if this cannot be guaranteed due to spell size or illegal operations.

;;;;;

If there are not enough circle evaluations available in the tick that this trick is used, 
there will be a one tick delay before the entirety of the given spell is run at once.


Illegal operations include the following:
- [Deviation of Suspension](^trickster:tricks/functions#3).
- [Ploy of Receipt](^trickster:ploys/message#3).
- Any Deviation which evaluates a sub-spell.
- Implicit sub-spell evaluation.

;;;;;

<|trick@trickster:templates|trick-id=trickster:fork|>

Dispatches the given spell to another spell slot.

;;;;;

If the caster doesn't support spell slots, this trick will blunder. 
If there are no free spell slots, this trick will return void. 
Otherwise, the index of the spell slot which was dispatched to is returned.

;;;;;

<|page-title@lavender:book_components|title=Note: Foldables|>{#aa4444}Foldables{} are fragments which contain other fragments and may be accessed using a specific key. 
Lists are {#aa4444}Foldables{} where the key is a whole number between zero and the size of the list, exclusive. 
Maps are also {#aa4444}Foldables{}, though their keys may be any value and aren't automatically determined by order of insertion.

;;;;;

<|trick@trickster:templates|trick-id=trickster:fold|>

For each entry in the {#aa4444}Foldable{}, execute the given spell, with the given fragment as the first result.

;;;;;

Each iteration receives four arguments:

---

{#aa4444}Any{}, {#aa4444}Any{}, {#aa4444}Any{}, {#aa4444}Foldable{}

---

These represent the following values, in order:

- The result of the last iteration.
- The current value.
- The key of the current value.
- The full {#aa4444}Foldable{}.

;;;;;

The result of each execution is passed as the first argument to the next, where the last's result is the return value of this trick overall.

;;;;;

<|page-title@lavender:book_components|title=Note: Arguments|>Fragments can be passed into executed spell fragments as arguments.


See the chapter on [arguments](^trickster:delusions_ingresses/arguments) for more information.

;;;;;

<|trick@trickster:templates|trick-id=trickster:kill_thread|>

Ends the spell running in the given spell slot or the current slot if none is provided. Returns whether it succeeded.

;;;;;

<|trick@trickster:templates|trick-id=trickster:thread_root|>

Fetches the original spell that spawned the given spell slot, or the current slot if none is provided.

;;;;;

<|trick@trickster:templates|trick-id=trickster:spell_state|>

Returns the number of circles that were executed in the last tick in a given spell slot, or the current slot if none is provided.
