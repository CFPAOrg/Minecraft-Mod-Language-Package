---
navigation:
  title: Bubble Anchor
  icon: nautec:bubble_anchor
  position: 17
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:bubble_anchor
  - nautec:bubble_capsule
---

# <Color id="light_purple">Bubble Anchor</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bubble_anchor" scale="2"/>
  Pushes the sea back from a 15 x 15 x 15 cube so you can build in the dry.
</Column>

Place the anchor, give it fuel, and every block of water in the cube around it is held back: you can walk, mine and build inside as if the sea were not there. Water just outside the cube stays out. A faint ring of bubbles shows the edge.

Kelp, seagrass and bubble columns inside the cube are cleared, and waterlogged blocks are drained. Blocks you place inside the field go straight into the held water.

***

## <Color id="gold">Fuel</Color>

Put fuel in its slot. Hoppers and pipes can feed it too.

| Fuel | Time |
|---|---|
| Dried Kelp Block | 2 minutes |
| Sea Pickle | 30 seconds |
| Dried Kelp | 12 seconds |
| Kelp | 6 seconds |

It warns you 10 seconds before the last of its fuel runs out. The bar beside the slot shows what is left.

***

## <Color id="gold">When the Field Ends</Color>

The field ends when the fuel runs out, when you turn it off, or when you break the anchor. When the fuel runs out or you turn it off, the held water is released from the edges inward. Breaking the anchor releases all of it at once.

The **Ends as** button chooses what fills the space you left open:

* Water: the sea comes back into every space you did not build in. Anything you built stays.
* Air: the space stays empty. Use this once you have walled your room in, so it stays dry for good. If you leave it open, the sea outside flows back in by itself.

The **Cube** button chooses where the cube sits. Centred puts the anchor in the middle. On top sits the cube on the anchor, so an anchor on the sea floor clears the water above it.

***

## <Color id="gold">Laser Power</Color>

A laser beam of 20 AP or more, into any face, runs the anchor with no fuel for as long as the beam holds, and for 2 seconds after it drops. A purer beam makes the field larger:

| Purity | Field |
|---|---|
| below 1.5 | 15 x 15 x 15 |
| 1.5 | 17 x 17 x 17 |
| 2.0 | 21 x 21 x 21 |
| 2.5 | 25 x 25 x 25 |

This turns it into a permanent dry dock for bigger underwater builds. A [Prismarine Crystal](laser_power.md) beam reaches the largest size.

The size, the beam power, the fuel times and how fast it works are in `config/nautec-common.toml`.

<RecipeFor id="bubble_anchor"/>

***

## <Color id="gold">Bubble Capsule</Color>

<Row>
  <ItemImage id="bubble_capsule"/>
  ### <Color id="aqua">For When You Are Out of Air</Color>
</Row>

A single-use pocket of air for emergencies. Use it with your head under water and it pushes the sea back from a 5 x 5 x 5 cube around your head for 30 seconds, and fills your air bar straight away.

The pocket works like a small anchor field: water outside stays out, and anything you build inside stays when it ends. Five seconds before it collapses you get a warning, then the sea comes back into every space you left open. Placing a block where your head was when you used it ends the pocket early.

The size and the time are in `config/nautec-common.toml`.

<RecipeFor id="bubble_capsule"/>
