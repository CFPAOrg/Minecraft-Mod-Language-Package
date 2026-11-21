```json
{
  "target": "*trickster:tricks/ploys/entity@trick&trickster:add_velocity",
  "priority": 1000,
  "condition": "trickster:stable_storm_mana",
  "page_background_overlay": "trickster:textures/gui/white_note_overlay.png"
}
```

Looks like this ploy will consume [Tempest](*trickster:mana_types/storm_mana) mana if there's enough. 
It *does* require that the stability be greater than 50%, but that's not an issue most of the time.