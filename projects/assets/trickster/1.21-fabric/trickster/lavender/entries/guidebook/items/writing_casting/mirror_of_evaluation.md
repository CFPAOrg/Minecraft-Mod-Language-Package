```json
{
  "title": "Mirror of Evaluation",
  "icon": "trickster:mirror_of_evaluation",
  "category": "trickster:writing_casting",
  "ordinal": 0
}
```

A Mirror of Evaluation is a tool very similar to the ever-useful [Scroll and Quill](^trickster:items/writing_casting/scroll_and_quill).
The main difference is that it has the ability to individually cast, thus evaluate, 
any part of the spell that is being written using it.

;;;;;

Spell circles drawn in the Mirror will contain a smaller circle inside them, off to the side of their glyphs.

![](trickster:textures/gui/img/evaluation_node.png,fit)

;;;;;

This node, commonly referred to as the Evaluation Node, can be clicked to evaluate *that specific* circle's glyph and subcircles,
replacing it with the result of the evaluation.


Say for example one writes a circle with two subcircles, each containing a [Directional Delusion](^trickster:delusions_ingresses/caster_tricks#3).
When clicking the Evaluation Node on one of them, its glyph will become the literal value of ones current facing.

;;;;;

The interesting part is that this value, being evaluated, is now set in stone.
As is, it can be embedded into any spell to represent the same constant direction, 
though of course, it can also be used in the Mirror directly.

;;;;;

One could now turn themselves around and draw say, an [Annexation Stratagem](^trickster:distortions/arithmetic#4) in the middle circle.
If activated using the Evaluation Node, this trick would consume and evaluate both subcircles and add ones old look direction to the new.

;;;;;

Note that, despite us selectively activating parts of the spell independently of others, 
the final result is equivalent to if we'd activated it in one go, save for us turning around between casts.


This underlines an important part of the mirror's function: 
It can effectively condense select parts of a spell that might not need to be evaluated every time it is cast.

;;;;;

The best way to understand these workings is absolutely to try them out for oneself:

<recipe;trickster:mirror_of_evaluation>

;;;;;

Like a scroll, the mirror keeps the spell it is holding 
inside itself as an inscribed spell. 
Thus making it accessible to all conventional spell reading and writing methods.
