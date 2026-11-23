---
navigation:
  title: Underwater Bases
  icon: nautec:pressure_hatch
  position: 18
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:pressure_hatch
  - nautec:oxygen_diffuser
---

# <Color id="light_purple">Underwater Bases</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="pressure_hatch" scale="2"/>
  Blocks for a dry, permanent base on the sea floor.
</Column>

Clear the space first with a [Bubble Anchor](bubble_anchor.md), wall it in, and set the anchor to leave air when it ends. These blocks keep the room dry afterwards.

***

## <Color id="gold">Pressure Hatch</Color>

A steel door with a porthole, two blocks tall. Open and close it by hand or with redstone.

* The sea never comes through it, open or closed, so you can swim in through an open hatch and the room behind it stays dry.
* Every time it closes it pumps out the water on both sides of it, as long as that water is a small pocket: the water you dragged in, a flooded doorway, a leak. Up to 64 blocks of connected water are cleared at once.
* Water that is part of the sea, or a flooded room bigger than 64 blocks, is left alone, so closing a hatch never drains the ocean outside.

Placing a hatch in water clears the two blocks it fills, so you can fit one straight into a flooded doorway.

<RecipeFor id="pressure_hatch"/>

***

## <Color id="gold">Oxygen Diffuser</Color>

<ItemImage id="oxygen_diffuser" scale="2"/>

Gives every player within 12 blocks Water Breathing and keeps their air full, so you can work in the open water around your base without a helmet.

* It needs a laser beam of at least 10 AP into any face. Purity does not matter, so the weakest early beam runs it.
* It refreshes the effect every second while the beam holds. Step out of range and the effect runs out a few seconds later.
* It can sit underwater. Bubbles stream from its top while it runs.
* If the beam drops for a moment, it keeps going for two seconds before it stops.

The range and the power are in `config/nautec-common.toml`.

<RecipeFor id="oxygen_diffuser"/>
