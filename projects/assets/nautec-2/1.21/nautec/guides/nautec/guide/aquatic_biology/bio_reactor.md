---
navigation:
  title: Bio Reactor
  icon: nautec:bio_reactor
  position: 8
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:bio_reactor
  - nautec:bacterial_containment_shield
---

# <Color id="light_purple">Bio Reactor</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bio_reactor" scale="2"/>
  The Bio Reactor puts up to three colonies to work making items.
</Column>

Each colony makes the item its strain produces, one at a time, for as long as the reactor has power. Producing items does not use up the colony, and a colony that is kept fed from the reactor's nutrient slots does not age either. The [Industrial Bio Reactor](industrial_bio_reactor.md) is the larger version for nine colonies.

***

## <Color id="gold">Building It</Color>

A 3 by 3 by 2 structure:

* Bottom layer: Dark Prismarine Pillars in the corners, Bacteria Containment Shields on the edges, Polished Prismarine in the middle.
* Top layer: Dark Prismarine Pillars in the corners, Bacteria Containment Shields on the edges, the Bio Reactor in the middle.

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="1" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="1" z="1"/>
  <Block id="nautec:bio_reactor" x="1" y="1" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="1" z="1"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="1" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="1" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="1" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="0" z="0"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="0" z="0"/>
  <Block id="nautec:bacterial_containment_shield" x="0" y="0" z="1"/>
  <Block id="nautec:polished_prismarine" x="1" y="0" z="1"/>
  <Block id="nautec:bacterial_containment_shield" x="2" y="0" z="1"/>
  <Block id="nautec:dark_prismarine_pillar" x="0" y="0" z="2"/>
  <Block id="nautec:bacterial_containment_shield" x="1" y="0" z="2"/>
  <Block id="nautec:dark_prismarine_pillar" x="2" y="0" z="2"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

Right-click the Bio Reactor with an <ItemLink id="aquarine_steel_wrench"/> in Rotate mode, without sneaking, to form it. If a block is wrong, chat names its position, what is there and what should be. Breaking any block of a formed reactor takes it apart again.

Once it is formed, right-click the Bio Reactor to open it.

***

## <Color id="gold">The Screen</Color>

* The three colony slots take colonies from Petri Dishes, as described in [Bacteria Introduction](bacteria_introduction.md).
* The thin bar beside each colony is its nutrient buffer. Hover it to see how many seconds of feeding are left.
* Each colony has its own output slot to its right.
* The two slots on the far left are nutrient slots. [Colony Feeding](colony_feeding.md) explains what goes in them.
* The two slots on the far right take [Reactor Upgrades](reactor_upgrades.md), one per slot.
* Hover a progress arrow to see the power arriving against the power needed.
* A yellow or red "!" on a colony means it needs attention: its nutrient is not in the nutrient slots, it is aging, or it is Senescent. Hover the colony to see which, and what it eats.

***

## <Color id="gold">Power and Hatches</Color>

The reactor takes power through hatches. Right-click one of the four Bacteria Containment Shields in the top layer with the wrench to turn it into a hatch (click again to turn it back), then point a beam down into the hatch from above. This does not work in Item Sides mode, which sets the reactor's sides instead. You can open more than one hatch, and their power adds together.

| Colonies | AP needed |
|---|---|
| 1 | 20 |
| 2 | 35 |
| 3 | 50 |

That is 5 AP for the reactor plus 15 AP per filled colony slot, both configurable. Upgrades multiply the total, see [Reactor Upgrades](reactor_upgrades.md). The power is a threshold, not a cost. Below it nothing runs and all progress resets, and a stronger beam speeds the reactor up (see Stronger Beams below).

One <ItemLink id="aquatic_catalyst"/> gives 12 AP on Prismarine Shards, so two catalysts on two hatches run one colony and three run two. For three colonies, touch the catalysts with <ItemLink id="budding_prismarine"/> to boost them, add a fourth hatch, or combine beams in a <ItemLink id="laser_junction"/> before they reach a hatch. A [Bacterial Fuel Cell](bacterial_fuel_cell.md) gives up to 48 AP from a single beam.

***

## <Color id="gold">Production Speed</Color>

Speed is Production Rate times a size factor that runs from 0.5 for a tiny colony to 1 at the size cap, times the strain's Strain Yield. For a strain with a Strain Yield of 1, such as Lithophiles:

| Colony | Time per item |
|---|---|
| Production Rate 0.3, size 400 | about 2 seconds |
| Production Rate 1, size 20,000 | about 0.4 seconds |
| Production Rate 2, size 40,000 | about 0.15 seconds |

Valuable strains are slower: a diamond colony takes a little over eight times as long. [Production Rates](production_rates.md) has the full formula and every strain's Strain Yield.

Each colony has its own output slot. When a slot is full, that colony pauses until there is room: it makes nothing, eats nothing, does not age and does not shrink.

***

## <Color id="gold">Automation</Color>

* Every outer face of the formed reactor takes and gives items: a hopper under the base pulls output, a hopper on top of the Bio Reactor block feeds nutrients, and a pipe works on any side.
* [Side Configuration](nautec:getting_started/utilities.md) sets what each side of the structure does. Use the tab on the right of the reactor's screen, or the wrench in Item Sides mode on any block of the reactor. One setting covers a whole side, so Bottom set to Extract lets pipes only extract from the entire base. The reactor treats its north side as the front.
* Load and unload colonies through the Dish Port. A dish goes into the slot at the bottom left and dishes holding a colony come out of the slot beside it; empty dishes come out of the slot under the upgrades. A Petri Dish holding a colony loads it into the first colony slot that can take all of it. Once every colony slot is full, a new colony dish swaps instead, but only for a Senescent colony: its colony replaces the oldest Senescent one, and the old colony comes out in that same dish, so no empty dish is left over. While no colony is Senescent the dish waits in the port, and a swap also waits while the colony output slot is full. An empty dish takes out the oldest Senescent colony and waits in the port while none is Senescent, and the port refuses dishes holding a Senescent colony, so one chest can collect from the port and feed it at the same time. To take out a colony that is not Senescent, click its colony slot with an empty dish. Automation reaches the port wherever it reaches the other slots.

Automation only puts items into the nutrient, upgrade and Dish Port slots and only takes them from the output slots and the Dish Port. With nutrients coming in and output going out, the reactor runs indefinitely.

***

## <Color id="gold">Aging and Decay</Color>

A working colony spends its nutrient buffer instead of aging. When the buffer runs out, the reactor feeds it the next matching nutrient from a nutrient slot. Only when there is no matching nutrient does the colony age, one tick for every tick it works, and its bar reads "No nutrients: the colony is aging".

Once its age passes its Lifespan the colony is Senescent. A senescent colony that is starving loses 2% of its size (at least 1) for every second it works, so about half of it is gone after 35 seconds. The rate is configurable.

Feeding stops the loss at once, but it does not make the colony young again: it stays Senescent and starts shrinking again as soon as the nutrients run out. One completed [Incubator](incubator.md) cycle resets its age.

***

## <Color id="gold">Recipes</Color>

<Recipe id="nautec:bio_reactor"/>

<RecipesFor id="bacterial_containment_shield"/>

***

## <Color id="gold">Stronger Beams</Color>

A Bio Reactor first works out the AP it needs from its colonies and upgrades. A stronger beam than that speeds up production on top of its Speed Upgrades: speed is the square root of (beam ÷ what it needs).

| Beam, as a multiple of what it needs | Speed |
|---|---|
| 1× | ×1 (normal) |
| 4× | ×2 |
| 9× | ×3 |
| 16× | ×4 |

The two multiply. A reactor whose Speed Upgrade makes it run ×1.5 and that gets four times the power it needs runs ×3. Nutrients are spent per tick of work, so a stronger beam makes more items from the same nutrient. Hover a progress arrow to see the beam speed and the total speed with upgrades; Jade shows the beam speed too.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

<RecipeFor id="polished_prismarine"/>

<RecipeFor id="dark_prismarine_pillar"/>
