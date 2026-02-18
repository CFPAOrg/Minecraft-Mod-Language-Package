```json
{
  "title": "Spell-Scribing",
  "icon": "trickster:scroll_and_quill",
  "ordinal": 10
}
```

<|revision@trickster:templates|pattern=0\,4\,8\,7,title=Extensive Revision|>

Can be used to add a new subcircle to any circle. 

;;;;;

![](trickster:textures/gui/img/extension_revision.png,fit)

When Extensive Revision is drawn in the blue circle, the green circle will be created.

;;;;;

<|revision@trickster:templates|pattern=0\,4\,8\,5,title=Inner Revision|>

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

<|revision@trickster:templates|pattern=3\,0\,4\,8,title=Split Revision|>

Replaces the circle it is drawn in with a new circle, with the old circle as a subcircle.

;;;;;

![](trickster:textures/gui/img/split_revision.png,fit)

When Split Revision is drawn in the blue circle, it adds it as a subcircle to the newly created green circle.

;;;;;

<|revision@trickster:templates|pattern=1\,0\,4\,8,title=Growth Revision|>

Nests the circle it is drawn in inside another circle as its inner circle.

;;;;;

![](trickster:textures/gui/img/growth_revision.png,fit)

When Growth is drawn in the blue circle, it adds it as an inner circle to the newly created green circle.

;;;;;

<|revision@trickster:templates|pattern=0\,4\,8,title=Grafting Revision|>

Removes the circle it is drawn in. Will replace it with the original circle's first subcircle if available.

;;;;;

![](trickster:textures/gui/img/grafting_revision.png,fit)

When Grafting is drawn in the yellow circle, it and the red circle are deleted and replaced by the green circle.

;;;;;

<|revision@trickster:templates|pattern=0\,4\,8\,5\,2\,1\,0\,3\,6\,7\,8,title=Pruning Revision|>

Removes the circle it is drawn in and any attached subcircles.

;;;;;

![](trickster:textures/gui/img/pruning_revision.png,fit)

When Pruning Revision is drawn in the yellow circle, it and the red circles are deleted.

;;;;;

<|revision@trickster:templates|pattern=1\,2\,4\,6,title=Ascension Revision|>

Expands the circle it is drawn in to replace its outer circle.

;;;;;

![](trickster:textures/gui/img/ascension_revision.png,fit)

When Ascension Revision is drawn in the blue circle, it deletes and replaces the red circle.

;;;;;

<|revision@trickster:templates|pattern=6\,3\,0\,4\,8,title=Devotion Revision|>

Adds a new subcircle to the outer circle.

;;;;;

![](trickster:textures/gui/img/devotion_revision.png,fit)

When Devotion Revision is drawn in the blue circle, the green circle is created.

;;;;;

<|revision@trickster:templates|pattern=1\,2\,5,title=Shifting Revision|>

Shifts the subcircles of the circle it is drawn in, clockwise, so that the last subcircle is now the first.

;;;;;

<|revision@trickster:templates|pattern=1\,0\,3,title=Reverse Shifting Revision|>

Accomplishes the opposite of the Shifting Revision, moving subcircles counter-clockwise.

;;;;;

<|revision@trickster:templates|pattern=2\,4\,3,title=Shuffling Revision|>

Swaps the first subcircle with the second subcircle.

;;;;;

<|revision@trickster:templates|pattern=4\,0\,1\,4\,2\,1,title=Notulist's Revision|>

Reads a spell from the user's offhand and grafts it onto the spell currently being edited,
replacing the circle it is drawn in.

;;;;;

<|revision@trickster:templates|pattern=1\,2\,4\,1\,0\,4\,7,title=Inner Notulist's Revision|>

Reads a spell from the user's offhand and places it as a glyph in the center of the circle it is drawn in.

;;;;;

<|revision@trickster:templates|pattern=4\,3\,0\,4\,5\,2\,4\,1,title=Grand Revision|>

Replaces the glyph of the circle it is drawn in with the result of executing the user's offhand spell. 
Requires possession of a [Mirror](^trickster:items/mirror_of_evaluation).

;;;;;

<|revision@trickster:templates|pattern=1\,4\,7\,6\,4\,8\,7,title=Plagiarist's Revision|>

Copies the circle it is drawn in to the user's offhand.

;;;;;

<|revision@trickster:templates|pattern=1\,8\,6\,1,title=Interpretation Revision|>

Creates a pattern literal of the pattern contained within the circle it is drawn in.

;;;;;

<|revision@trickster:templates|pattern=1\,0\,4\,8\,7\,6\,4\,2\,1\,4,title=Address Revision|>

When this scribing pattern is drawn, the [address](^trickster:distortions/tree#2) of the circle this pattern was drawn in is written to the item in your other hand.
