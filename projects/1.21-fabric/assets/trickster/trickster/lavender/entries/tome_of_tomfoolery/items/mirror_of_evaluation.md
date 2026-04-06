```json
{
  "title": "Mirror of Evaluation",
  "icon": "trickster:mirror_of_evaluation",
  "category": "trickster:items",
  "ordinal": 35
}
```

A Mirror of Evaluation is a tool very similar to the ever-useful [Scroll and Quill](^trickster:items/scroll_and_quill).
The main difference is that it greedily casts any part of the spell it can while it is being written.


Say for example you write a subcircle with two more subcircles, each containing a [Foundational Delusion](^trickster:constants#1).

;;;;;

When drawn, the glyphs of these subcircles will become literals for the number 2.


Then, you can draw say, an [Annexation Stratagem](^trickster:distortions/arithmetic#2) in the parent circle of the two twos.
This will immediately consume the two subcircles and evaluate to a literal 4 as a glyph in the parent circle.

;;;;;

The best way to understand these workings is absolutely to try them out for yourself:

<recipe;trickster:mirror_of_evaluation>

It's worth noting that, while it casts any part of the spell it can, the mirror still stores the spell its holding 
inside itself as an inscribed spell. 

;;;;;

Thus making it accessible to all conventional spell reading and writing methods.
