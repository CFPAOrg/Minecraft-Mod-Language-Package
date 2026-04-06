```json
{
  "title": "A Shimmer in the Night",
  "icon": "trickster:echo_knot",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "Ploy of the Moon Watcher",
    "Benevolent Conduit's Ploy",
    "Malevolent Conduit's Ploy"
  ]
}
```

Ploys for creating [Knots](^trickster:items/knots) and moving mana between them.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:battery_creation,title=Ploy of the Moon Watcher|>

[slot], [slot] ->

---

Creates a Knot of the type of the given item using a Glass Block. Uses amethyst if no slot is provided.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:push_mana,title=Benevolent Conduit's Ploy|>

number, slot... | slot[] -> number

---

Pushes mana into the given slots, up to an amount, and returns the amount moved.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:pull_mana,title=Malevolent Conduit's Ploy|>

number, slot... | slot[] -> number

---

Pulls mana from the given slots, up to an amount, and returns the amount moved.