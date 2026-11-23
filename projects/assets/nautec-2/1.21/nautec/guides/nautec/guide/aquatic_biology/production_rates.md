---
navigation:
  title: Production Rates
  icon: minecraft:clock
  position: 10
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Production Rates</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="minecraft:clock" scale="2"/>
  How fast a colony makes items in a reactor, and how much power that takes.
</Column>

The numbers here apply to both the [Bio Reactor](bio_reactor.md) and the [Industrial Bio Reactor](industrial_bio_reactor.md). The Industrial Bio Reactor is not faster per colony; it runs more colonies with more upgrades.

***

## <Color id="gold">The Formula</Color>

Every tick, a working colony adds progress:

progress per tick = Production Rate x size factor x base speed x Strain Yield x speed bonus

* Production Rate is the colony's stat, up to 2 ([Bacteria Stats](bacteria_stats.md)).
* The size factor is 0.5 + 0.5 x size / 40,000, so 0.5 for a tiny colony and 1 at the size cap.
* The base speed is 16.8 in both reactors, configurable for each.
* Strain Yield belongs to the strain, see the table below.
* The speed bonus is 1, plus 0.5 for each [Reactor Speed Upgrade](reactor_upgrades.md).

Every 100 progress completes a cycle, which puts 1 item into the colony's output slot, plus 1 more for each Reactor Yield Upgrade. Leftover progress carries into the next cycle. A minute is 1,200 ticks, so:

items per minute = progress per tick x 12 x items per cycle

***

## <Color id="gold">Strain Yield</Color>

Every strain can be bred to the same Production Rate cap, 2.0 by default. Strain Yield multiplies that stat afterward; it does not lower the cap. Follow the [Mutator's stat-breeding steps](mutator.md#stat-breeding) to improve a colony without risking your best template.

| Strain Yield | NauTec strains | Other mods' materials |
|---|---|---|
| 1 | Lithophiles (stone), Silicophiles (sand), Calciophiles (bone meal), Cryobionts (ice), Carnivorous Bacteria (rotten flesh), and every wood, plant, crop, fungus and mushroom strain | aluminum, bauxite, brass, bronze, graphite, lead, pig iron, steel, tin and zinc ingots; apatite |
| 0.8 | Carbophages (coal), Metallophiles (copper ingots), Sulfurophiles (gunpowder) | silver, nickel, antimony, bismuth, boron, constantan, electrum, invar, rose gold, stainless steel and amethyst bronze ingots; amber, fluorite, jade, peridot, ruby, sapphire and topaz |
| 0.6 | Ferrophiles (iron ingots) | osmium, uranium, cobalt, titanium, tungsten, chromium, manganese, molybdenum, neodymium, niobium, thorium, vanadium, beryllium, monazite, cyanite, desh, hepatizon, iesnium, knightslime, slimesteel, lumium, signalum, manasteel, refined glowstone and refined obsidian ingots; certus quartz, black quartz, cinnabar, dark gem, moonstone and sunstone |
| 0.5 | Acidophiles (redstone), Azuritophiles (lapis lazuli) | |
| 0.4 | Aurrophiles (gold ingots) | platinum, iridium, palladium, enderium, elementium, manyullyn, queen's slime, blutonium, calorite, draconium and ostrum ingots |
| 0.12 | Adamantophiles (diamonds) | netherite, allthemodium, vibranium, unobtainium, neutronium, plutonium and terrasteel ingots |
| 0.1 | Smaragdophiles (emeralds) | |

Strains for other mods' materials only exist when a mod that uses that material is in the pack. When several mods add the same material, the reactor makes the item from the first mod listed in `preferredTagNamespaces` in `config/nautec-common.toml` (default: `minecraft`), and otherwise the first item id in alphabetical order. Cyanobacteria, Halobacteria, Methanogens, Prismatophiles and Thermophiles make nothing, so their Strain Yield does not matter.

JEI's Bio Reactor category and an analyzed dish's tooltip both show a strain's Strain Yield. Packs can set it with the optional `production_multiplier` field in a strain's json, which defaults to 1.

***

## <Color id="gold">Worked Examples</Color>

A colony at the stat caps (Production Rate 2, size 40,000) with no upgrades:

| Strain Yield | Progress per tick | Time per item | Items per minute |
|---|---|---|---|
| 1 (stone) | 33.6 | 0.15 seconds | about 403 |
| 0.8 (coal, copper) | 26.9 | 0.19 seconds | about 323 |
| 0.6 (iron) | 20.2 | 0.25 seconds | about 242 |
| 0.5 (redstone, lapis) | 16.8 | 0.3 seconds | about 202 |
| 0.4 (gold) | 13.4 | 0.37 seconds | about 161 |
| 0.12 (diamond) | 4.03 | 1.2 seconds | about 48 |
| 0.1 (emerald) | 3.36 | 1.5 seconds | about 40 |

A fresh colony is far slower. Ferrophiles with a Production Rate of 0.4 at size 400 makes 0.4 x 0.505 x 16.8 x 0.6 = 2.04 progress per tick: one iron ingot every 2.5 seconds, about 24 a minute.

Upgrades multiply these. The capped diamond colony makes about 97 diamonds a minute with two Reactor Speed Upgrades, or about 145 with two Reactor Yield Upgrades, since every cycle then gives 3.

A capped stone colony fills its 64-item output slot in about ten seconds, and a full slot pauses that colony, so keep the output moving.

***

## <Color id="gold">Power Needed</Color>

Power is a threshold. The reactor needs this much AP arriving every tick or nothing runs and all progress resets. A stronger beam than that speeds production up, see [Stronger Beams](nautec:getting_started/stronger_beams.md).

AP needed = (base + per colony x filled colony slots) x upgrade multipliers, rounded up

| Reactor | Base | Per colony | Full, no upgrades |
|---|---|---|---|
| Bio Reactor | 5 | 15 | 50 AP with 3 colonies |
| Industrial Bio Reactor | 100 | 50 | 550 AP with 9 colonies |

All four values are configurable. Empty colony slots do not count. [Reactor Upgrades](reactor_upgrades.md) lists the multipliers and what common upgrade sets cost.
