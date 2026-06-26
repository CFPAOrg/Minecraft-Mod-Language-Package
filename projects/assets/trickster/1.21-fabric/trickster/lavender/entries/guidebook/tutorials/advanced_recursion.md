```json
{
  "title": "Advanced: Recursion",
  "icon": "minecraft:map",
  "ordinal": 100,
  "category": "trickster:tutorials"
}
```

Often times, especially when using [Spell Constructs](^trickster:items/infrastructure/spell_construct), 
it might be helpful to repeat one spell indefinitely.


Spells will always terminate when evaluation reaches their root node.
The easiest way to prevent this from happening is to let the spell cast itself when it is about to finish.

;;;;;

This will then result in the spell casting itself a third time,
(because it is still the same spell) and fourth and fifth time, et cetera. Ad infinitum.


Achieving this may seem impossible at first. How would a spell gain access to itself?
It is however, rather trivial.


A spell can be passed into itself by means of [arguments](^trickster:delusions_ingresses/arguments).

;;;;;

Once a spell has an argument of itself, it is free to use it to cast itself with itself as an argument again.
This process must however, be 'bootstrapped' with a starting spell.


This spell takes an input spell using [Notulist's Ingress](^trickster:tricks/basic#3), and passes it as an argument to an inner circle.
The inner circle then uses this argument twice with a [Grand Deviation](^trickster:tricks/functions#4), to pass the spell into itself.

;;;;;

<|spell-preview@trickster:templates|spell=YxEpKcpMzi4uSS2yKi5IzcmJL0gsKsEqKIgQLEgsAVJ5G32YWJkYmRkYGECYgZERUwkDAxNIiomBWGX41TG6NLWC1QEAyzmT3rgAAAA=|>


A spell that casts itself is referred to as Recursion.

;;;;;

Note: If you want to be able to terminate a recursing spell, it is possible to make the recursion point conditional.

