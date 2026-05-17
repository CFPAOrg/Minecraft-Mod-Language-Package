```json
{
  "title": "Misc Ploys",
  "icon": "minecraft:iron_ingot",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of Celestial Pin",
    "Ploy of Clarity",
    "Ploy of Obfuscation"
  ]
}
```

A few miscellaneous ploys that don't fit into any other category.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:pin_chunk,title=Ploy of Celestial Pin|>

vector -> vector

<|cost-rule@trickster:templates|formula=4kG|>

Fully loads the chunk containing the given position for exactly 4 seconds.

;;;;;

<|page-title@lavender:book_components|title=Note: Bars|>Spells can display arbitrary values on the caster's screen as bars.


Bars are identified by a number and can be overwritten at any time by using the same number again.
Bars are randomly colored based on their identifier. The same identifier will always display as the same color.

;;;;;

A bar can either be given one number, which will be interpreted on a scale of 0 to 1, or two numbers, 
which means it will interpret the first as the current and the second as the maximum value.


It also always returns the given value to its parent circle when updated, allowing for easy chaining.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:show_bar,title=Ploy of Clarity|>

number, number, [number] -> number

---

Shows a bar on the caster's screen identified by the first number displaying the second number.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:clear_bar,title=Ploy of Obfuscation|>

number -> number

---

Immediately clears a bar from the caster's screen identified by the given number.
