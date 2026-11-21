```json
{
  "title": {
    "text": "Quartz Knot",
    "modifiers": [
      "italic"
    ]
  },
  "icon": "trickster:quartz_knot",
  "condition": "trickster:quartz_knot",
  "ordinal": 50,
  "book_texture_override": "trickster:white_note",
  "associated_items": [
    "trickster:quartz_knot"
  ]
}
```

Aha, a [Knot](*trickster:items/mana/knots) based on Nether Quartz crystals! It seems more than just gems can be turned into mana containers.


This one however, has a rather abysmal capacity, on par with its Amethyst sibling.
Its natural recharge rate is also pitifully at the levels of an Emerald Knot of its same capacity. Not terrible, but definitely not great.


Regardless, it has some redeeming qualities.

;;;;;

For one, inserting this Knot into a construct accelerates its casting ever so slightly. 
It really isn't much, but even a few extra circles can vastly improve a spell's effectiveness.


Its second uniqueness is far more interesting though.


By augmenting the [Ploy of Receipt](*trickster:tricks/ploys/message@trick&trickster:message_listen) with a slot as a second input, it is possible to listen
for messages from an item.


Most items do not react to this at all, but trying the same on this Knot, it responds!

;;;;;

When a Quartz Knot is queried in this way, it replies with an ever-incrementing number, 
starting at zero at its initial creation, and counting up by about twenty every second.


A message can also be sent into the Knot using a similar method to resynchronize it, 
and offset its counter by a given number.


When I listen closely, I can hear the faint ticking of a clock coming from within the Quartz Knot...


Yet, the Knot contains no moving parts...


What a strange object...
