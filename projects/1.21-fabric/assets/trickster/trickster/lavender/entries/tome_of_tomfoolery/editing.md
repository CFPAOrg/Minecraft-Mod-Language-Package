```json
{
  "title": "Spell-Scribing",
  "icon": "trickster:scroll_and_quill",
  "ordinal": 10
}
```

*"The spell is your canvas. An arbitrarily large and complex canvas, but a canvas nonetheless.*


*And just like you need to know each brush at your disposal to paint effectively, 
you must be familiar with the scribing patterns to create spells effectively.*

;;;;;

*And so we begin, with the very basics of spell scribing."*


— An excerpt from a lecture by Prof. Citrine

---

Unlike other patterns, scribing patterns will immediately disappear when drawn, 
and modify the structure of the spell when they do. They cannot be used as [Macros](^trickster:concepts/macro).

;;;;;

<|revision@trickster:templates|revision-id=trickster:add_subcircle|>

Can be used to add a new subcircle to any circle.

;;;;;

![](trickster:textures/gui/img/extension_revision.png,fit)

When Extensive Revision is drawn in the blue circle, the green circle will be created.

;;;;;

<|revision@trickster:templates|revision-id=trickster:add_inner_circle|>

Adds a new inner circle to an existing circle.
Inner circles act like glyphs, and can be activated as such.
See [Spell Deviations](^trickster:tricks/functions).

;;;;;

![](trickster:textures/gui/img/inner_revision.png,fit)

When Inner Revision is drawn in the outer blue circle, the green circle will be created.

;;;;;

An inner circle acts like a glyph, 
either returning its value, or being executed with arguments.


When no subcircles are connected to it, 
the circle containing the inner circle will return the inner circle as a spell fragment.
This can be used for meta-programming, recursion, and permanent storage of dynamic spells, among other things.

;;;;;

When the circle *does* have connected subcircles, 
it executes the inner circle directly as if it was called by a [Grand Deviation](^trickster:tricks/functions#4),
using the results from the subcircles connected to the outer circle as arguments.


This can be very useful when needing to use one value in multiple places, 
as inner circles and spell fragments are the only way to move fragments back to the leaves of a tree.

;;;;;

<|revision@trickster:templates|revision-id=trickster:to_subcircle|>

Replaces the circle it is drawn in with a new circle, with the old circle as a subcircle.

;;;;;

![](trickster:textures/gui/img/split_revision.png,fit)

When Split Revision is drawn in the blue circle, it adds it as a subcircle to the newly created green circle.

;;;;;

<|revision@trickster:templates|revision-id=trickster:to_inner_circle|>

Nests the circle it is drawn in inside another circle as its inner circle.

;;;;;

![](trickster:textures/gui/img/growth_revision.png,fit)

When Growth is drawn in the blue circle, it adds it as an inner circle to the newly created green circle.

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_self|>

Removes the circle it is drawn in. Will replace it with the original circle's first subcircle if available.

;;;;;

![](trickster:textures/gui/img/grafting_revision.png,fit)

When Grafting is drawn in the yellow circle, it and the red circle are deleted and replaced by the green circle.

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_self_recursive|>

Removes the circle it is drawn in and any attached subcircles.

;;;;;

![](trickster:textures/gui/img/pruning_revision.png,fit)

When Pruning Revision is drawn in the yellow circle, it and the red circles are deleted.

;;;;;

<|revision@trickster:templates|revision-id=trickster:remove_outer|>

Expands the circle it is drawn in to replace its outer circle.

;;;;;

![](trickster:textures/gui/img/ascension_revision.png,fit)

When Ascension Revision is drawn in the blue circle, it deletes and replaces the red circle.

;;;;;

<|revision@trickster:templates|revision-id=trickster:rotate_cw|>

Shifts the subcircles of the circle it is drawn in, clockwise, so that the last subcircle is now the first.

;;;;;

<|revision@trickster:templates|revision-id=trickster:rotate_ccw|>

Accomplishes the opposite of the Shifting Revision, moving subcircles counter-clockwise.

;;;;;

<|revision@trickster:templates|revision-id=trickster:swap|>

Swaps the first subcircle with the second subcircle.

;;;;;

<|revision@trickster:templates|revision-id=trickster:splice|>

Reads a spell from the user's offhand and grafts it onto the spell currently being edited,
replacing the circle it is drawn in.

;;;;;

<|revision@trickster:templates|revision-id=trickster:splice_inner|>

Reads a spell from the user's offhand and places it as a glyph in the center of the circle it is drawn in.

;;;;;

<|revision@trickster:templates|revision-id=trickster:write|>

Copies the circle it is drawn in to the user's offhand.

;;;;;

<|revision@trickster:templates|revision-id=trickster:quote_pattern|>

Creates a pattern literal of the pattern contained within the circle it is drawn in.

;;;;;

<|revision@trickster:templates|revision-id=trickster:write_path|>

When this scribing pattern is drawn, the [address](^trickster:distortions/tree#2) of the circle this pattern was drawn in is written to the item in your other hand.
