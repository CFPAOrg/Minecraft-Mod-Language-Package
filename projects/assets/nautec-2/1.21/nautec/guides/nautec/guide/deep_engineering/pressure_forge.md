---
navigation:
  title: Abyssal Pressure Forge
  icon: nautec:pressure_forge
  position: 3
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:pressure_forge
  - nautec:pressure_synthesizer
  - nautec:atlantean_pressure_synthesizer
---

# <Color id="light_purple">Abyssal Pressure Forge</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="pressure_forge" scale="2"/>
  Presses materials under deep water using a laser beam and Etching Acid.
</Column>

The Abyssal Pressure Forge makes Flawless Prismarine Crystals, Atlantic Gold Ingots and Deep Steel Plating. It only runs deep underground and under a column of water, so build it on the sea floor or flood a deep shaft.

***

## <Color id="gold">Requirements</Color>

All of these have to be true at the same time. If any one of them stops being true, the current press starts again from zero.

* Depth: the Forge must be at Y 0 or lower (`pressureForgeDepth`). Each recipe also has its own maximum Y, listed below.
* Water: the 8 blocks directly above the Forge must all be water source blocks (`pressureForgeWaterColumn`). Depth alone is not enough; a dry shaft does not count. A Pressure Synthesizer replaces this, see below.
* Power: a beam of at least 40 AP per tick (`pressureForgePowerUsage`). The Forge takes beams on its four sides and its top.
* Purity: the beam must meet the recipe's purity.
* Etching Acid: at least 250 mb in the tank. Each finished press uses 250 mb (`pressureForgeAcidUsage`). The tank holds 4,000 mb (`pressureForgeCapacity`).

All of these values are in `config/nautec-common.toml`.

***

## <Color id="gold">Recipes</Color>

| Input | Output | Purity | Max Y | Time |
|---|---|---|---|---|
| Resonant Shard | Flawless Prismarine Crystal | 2.0 | -20 | 10 seconds |
| Block of Gold | 2 Atlantic Gold Ingots | 2.0 | -20 | 15 seconds |
| Aquarine Steel Ingot | Deep Steel Plating | 2.5 | -40 | 15 seconds |

The recipes are also shown in JEI. See [Deep Materials](materials.md) for what the outputs are used for.

***

## <Color id="gold">Using It</Color>

Right-click with an empty hand to open the Forge. Its screen holds the input, the output, the acid tank and the synthesizer slot, with a progress arrow between input and output. Below them a checklist shows each requirement in green or red with its current value: depth, water above, beam power, beam purity against the recipe, and Etching Acid. Hover a line for what it needs. Click the arrow to see the Forge's recipes in JEI.

You can still right-click with a forgeable item to put it in, and with an <ItemLink id="etching_acid_bucket"/> to fill the tank.

Hoppers and pipes can put items and Etching Acid in and take finished items out, through any face by default. [Side Configuration](nautec:getting_started/utilities.md) sets each face separately for items and fluids. Since the top has to stay under water, feed it from the sides. The Forge presses one item at a time and only finishes a press when there is room in the output slot.

Look at it through a <ItemLink id="prism_monocle"/> to check it. It shows "Under pressure" with the acid level and beam purity when it is set up correctly, or the depth and water it still needs when it is not.

## <Color id="gold">Pressure Synthesizers</Color>

A synthesizer fitted to the Forge stands in for the deep water, so you can build the Forge somewhere that looks the way you want. Right-click the Forge with one, or place it in the synthesizer slot of its screen, to fit it. Take it out of that slot, or sneak and right-click with an empty hand, to take it off. Fitting a different one swaps them and hands the old one back, and breaking the Forge drops whatever is fitted. A <ItemLink id="prism_monocle"/> shows which one is fitted.

<Row>
  <ItemImage id="pressure_synthesizer"/>
  <ItemImage id="atlantean_pressure_synthesizer"/>
</Row>

* <ItemLink id="pressure_synthesizer"/>: replaces the column of water above the Forge. The Forge still has to be at Y 0 or lower, and each recipe's own maximum Y still applies. Made in the [Mixer](nautec:laser_chemistry/mixer.md) from 1 Flawless Prismarine Crystal and 8,000 mB of Salt Water.
* <ItemLink id="atlantean_pressure_synthesizer"/>: the Forge runs anywhere, at any height, with no water above it, and recipes ignore their maximum Y. Made in the Mixer from 1 Pressure Synthesizer, 1 Heart of the Sea, 1 Nether Star and 4 Ender Pearls with 8,000 mB of Salt Water.

You need a working Forge under real water first, since the Flawless Prismarine Crystal comes out of one.

<Color id="gold">Tip</Color>: Laser beams pass through water. A <ItemLink id="bacterial_fuel_cell"/> at full purity (2.5) covers all three recipes, and so does a <ItemLink id="prismarine_crystal"/> (3.0), routed through relays or a [Laser Junction](nautec:laser_chemistry/laser_manipulation.md) to turn corners.

***

### <Color id="aqua">Abyssal Pressure Forge Recipe</Color>

<Recipe id="nautec:pressure_forge"/>

***

## <Color id="gold">Stronger Beams</Color>

The Pressure Forge needs 40 AP. A stronger beam forges faster: its speed is the square root of (beam ÷ 40).

| Beam | Speed |
|---|---|
| 40 AP | ×1 (normal) |
| 160 AP | ×2 |
| 360 AP | ×3 |
| 640 AP | ×4 |

The times in the recipe table are on a 40 AP beam. The Etching Acid each recipe uses does not change.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.
