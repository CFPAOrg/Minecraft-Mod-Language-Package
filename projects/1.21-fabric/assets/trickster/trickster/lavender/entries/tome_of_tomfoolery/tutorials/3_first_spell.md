```json
{
  "title": "3. Your First Spell",
  "icon": "minecraft:paper",
  "ordinal": 2,
  "category": "trickster:tutorials"
}
```

Now that you've got a [Scroll](^trickster:items/scroll_and_quill) you can right-click it to open the spell-scribing interface.
Spells consist of a tree-like structure of intersecting circles, and each circle contains a center glyph to denote its function.

;;;;;

When first opening a new scroll, you will see just one circle. This is the **root node**.
Every other circle in your spell originates from it.


To begin writing a spell, so-called scribing patterns or revisions can be used to add, remove, and move around circles.
The most basic scribing pattern is [Extensive Revision](^trickster:editing#1), 
which adds one extra subcircle to the circle it's drawn in.

;;;;;

Unlike most patterns, revisions activate instantly when drawn at any point in either a scroll or mirror.
They are the only way to directly affect the shape of your spell.


Another scribing pattern that may be useful for basic spells is [Grafting Revision](^trickster:editing#12),
which removes excess circles from the hierarchy.


With that out of the way, try to recreate the following spell in your scroll:

;;;;;

<|spell-preview-unloadable@trickster:templates|spell=YwyT9+YP6GBjZQQxGFwOMIAZHCEMDAwA8vUGkRwAAAA=|>

{gray}(Drag to pan and scroll to zoom){}

;;;;;

Once that's done, hold the scroll in your offhand, and draw the following spell in your mirror:

<|spell-preview-unloadable@trickster:templates|spell=YwyT9+bf6MPEyghiMLo0tTIAADybrxgTAAAA|>

;;;;;

You may notice that, while drawing, the top pattern gets replaced with the spell from your scroll.


Afterward, if you did everything correctly, the spell should have targeted and broken the block you were looking at!
This is the most basic way of spellcasting, write the spell in a scroll, and cast it using your mirror.


**But why did this work?**

;;;;;

When a spell is cast, drawn glyphs will take the output from connected subcircles as input, 
perform an operation, and output to their parent circle.


Think of a spell like a tree with many splitting branches.
First, the leaves of the tree (the most deeply nested circles) create or read values from the world.
These can be constants or, for example, a reference to the caster.
These are called [Delusions](^trickster:delusions_ingresses).

;;;;;

After this, intermediate glyphs process the information into an appropriate format,
for example taking a reference to a creature, and returning its position.
These are either [Distortions](^trickster:distortions) or [Ingresses](^trickster:delusions_ingresses).


Some glyphs may not return a value, often called [Ploys](^trickster:ploys).
These glyphs will affect the world, which is usually the end goal of the entire spell.

;;;;;

With this information in mind, we can take a look back at the spell in our scroll, 
and recognise three types of glyphs (also known as tricks).


The most deeply nested glyph must be a Delusion, as it takes no inputs.
Meanwhile, the glyph in the root node has to be a Ploy, since it only takes inputs, and provides no output.
Which means the intermediate circle must contain either a Distortion or an Ingress.

;;;;;

If you were to look up these patterns in the [Tricks](^trickster:tricks) section of this book, 
you'd see this assessment is correct. From smallest to largest circle, this spell is made up of:

- [Reflection Delusion](^trickster:delusions_ingresses/caster_tricks#4)
- [Archer's Ingress](^trickster:delusions_ingresses/raycast#2)
- and [Ploy of Destruction](^trickster:ploys/block#2)

Take a look at the inputs and outputs listed for these tricks, and try to understand how this spell combines them!

;;;;;

**Okay, but how did we cast it?**


Well, we took advantage of the mirror's tendency to cast anything it touches.
The patterns we drew in the mirror are [Notulist's Delusion](^trickster:tricks/basic#3) and [Grand Stratagem](^trickster:distortions/functions#3).
The former returns any spell held in the caster's offhand as data, while the latter takes a spell as data and casts it.


Yes, spells can cast other spells.

;;;;;

This chapter covered the basic concepts you need to know to start making simple spells of your own.
Go experiment, and see what's possible!
