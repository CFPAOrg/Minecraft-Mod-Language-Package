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

<|ploy@trickster:templates|trick-id=trickster:pin_chunk,cost=4G|>

Fully loads the chunk containing the given position for exactly 4 seconds.

;;;;;

<|page-title@lavender:book_components|title=Note: Bars|>Spells can display arbitrary values on the caster's view as bars.


Bars are identified by a number and can be overwritten at any time by using the same number again.
Bars are randomly colored based on their identifier. The same identifier will always display as the same color.

;;;;;

A bar can either be given one number, which will be interpreted on a scale of 0 to 1, or two numbers, 
which means it will interpret the first as the current and the second as the maximum value.


Ploy of Clarity returns the given value to its parent circle when used, allowing for easy chaining.

;;;;;

<|trick@trickster:templates|trick-id=trickster:show_bar|>

Shows a bar on the caster's view identified by the first number displaying the second number.

;;;;;

<|trick@trickster:templates|trick-id=trickster:clear_bar|>

Immediately clears a bar identified by the given number from the caster's view.
