```json
{
  "title": "Illusionist",
  "icon": "minecraft:sea_lantern",
  "category": "trickster:tricks"
}
```

Shadow blocks, 
sometimes also referred to as echoes or echo blocks, 
are illusions superimposed onto a material block. 
They are dispelled when the state of the material block changes, 
but can also be removed using a Revelation Ploy.

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:disguise_block,title=Shadow Ploy|>

vector, block -> boolean

<|cost-rule@trickster:templates|formula=20kG|>

Places a shadow of the given block at the given position and returns whether there was any change.

;;;;;

<|glyph@trickster:templates|trick-id=illusionist:dispel_block_disguise,title=Revelation Ploy|>

vector -> boolean

<|cost-rule@trickster:templates|formula=10kG|>

Dispels any shadow block at the given position and returns whether there was one initially.
