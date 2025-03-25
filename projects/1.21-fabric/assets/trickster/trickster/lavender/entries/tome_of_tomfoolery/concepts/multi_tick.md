```json
{
  "title": "Long Spells",
  "icon": "minecraft:clock",
  "category": "trickster:concepts"
}
```

Spells do not all execute instantly. Unless cast through a mirror, a big enough spell limits execution to a certain amount of circles per second. 
It may even run forever, 
provided its caster remains alive, the spell does not blunder, and it never runs out of circles to execute.

;;;;;

To cast a spell capable of running long, a free spell slot is required, even if the spell completes within one twentieth of a second. 


Without an empty spell slot, no spells can be cast except through a mirror. Spell slots may be viewed from the caster's inventory.

;;;;;

Spell slots have the following states: 

- inactive (collapsed)
- inactive and blundered (red)
- active and okay (green)
- active and at maximum executions per second (orange)
- active but waiting (white)

;;;;;

Patterns that execute spell fragments create sub-spells within their current spell. 
A spell may not have a sub-spell more than 255 spells deep, 
and will blunder if such a thing is attempted. 


If a so-called forking pattern is *effectively* the final pattern in the current spell, **this limit is ignored**.