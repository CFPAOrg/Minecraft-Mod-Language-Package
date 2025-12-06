---
navigation:
  title: Planet Cards
  icon: spaceploitation:planet_card
  position: 2
item_ids:
  - spaceploitation:planet_card
  - spaceploitation:tinted_planet_card
---

# Planet Cards

Planet cards link the Planet Simulator to dimensions, enabling space missions.

## Linking a Card

1. Craft a blank <ItemLink id="spaceploitation:planet_card" />
2. Travel to your target dimension
3. Right-click to link the card to that dimension's planet
4. Right-click again to activate it

Cards show their dimension and activation status in the tooltip.

## Available Planets

### Earth (Overworld)

<ItemImage id="spaceploitation:planet_card" components="spaceploitation:planet={planet_type:{texture:'minecraft:item/planet_card/planets/overworld',dimension:'minecraft:overworld'},activated:true}" />

Basic resource generation from common Overworld materials.

### Mars (Nether)

<ItemImage id="spaceploitation:planet_card" components="spaceploitation:planet={planet_type:{texture:'minecraft:item/planet_card/planets/the_nether',dimension:'minecraft:the_nether'},activated:true}" />

Power generation and Nether resource processing.

### Venus (End)

Advanced End resources, including Shulker Shells and Elytra duplication.

### Black Hole (Deep Dark)

Endgame content - activate in the Deep Dark biome.

## Unlinking Cards

Craft a linked card to reset it back to blank:

<Recipe id="spaceploitation:unlink_planet_card" />

## Tips

- Check JEI for all available recipes per planet
- Different planets accept different input materials
- Keep multiple activated cards for quick switching
