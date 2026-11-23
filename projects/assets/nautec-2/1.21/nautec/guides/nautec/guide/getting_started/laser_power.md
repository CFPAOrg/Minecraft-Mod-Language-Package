---
navigation:
  title: Laser Power
  icon: nautec:aquatic_catalyst
  position: 1
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:aquatic_catalyst
  - nautec:advanced_aquatic_catalyst
  - nautec:prismarine_crystal
---

# <Color id="light_purple">Laser Power</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="aquatic_catalyst" scale="2"/>
  The Aquatic Catalyst burns prismarine and fires it as a laser beam.
</Column>

NauTec machines run on laser power, measured in AP per tick (AP/t). A beam carries two values: its power, and its purity. Machines use the power to run, and recipes check the purity before they start.

A beam only forms between two laser blocks. The sending block needs something on that side that accepts a beam (a machine, a relay, a junction, a lens), no more than 16 blocks away (`laserDistance` in `config/nautec-common.toml`), or 64 from a relay, with no solid block in between. Beams pass through water and through glass, so you can wall a beam in glass.

***

<Row>
  <ItemImage id="aquatic_catalyst"/>
  ### <Color id="aqua">Aquatic Catalyst</Color>
</Row>

Your first power source. It burns prismarine items one at a time and fires a beam out of one face.

<Recipe id="nautec:aquatic_catalyst"/>

Load fuel by right-clicking the catalyst with a stack, or feed it from a hopper. Right-click it with an empty hand to take back the fuel it has not started on yet.

| Fuel | Purity | Power | Burn time |
|---|---|---|---|
| Prismarine Shard | 0.4 | 12 AP/t | 30 s |
| Prismarine Crystals | 0.8 | 6 AP/t | 30 s |
| <ItemLink id="prismarine_crystal_shard"/> | 1.2 | 20 AP/t | 75 s |

The face you are looking at when you place it is the pale intake, with eight sockets that fill as you load fuel. The beam leaves from the opposite face, the dark one with the cyan lens. Look down while placing it to fire downward, look up to fire upward. An <ItemLink id="aquarine_steel_wrench"/> rotates a placed catalyst.

The catalyst only burns while a receiver is on its emitter side. With nothing there it holds its fuel and waits, so a catalyst with no target wastes nothing. It moves straight from one fuel item to the next, so the beam stays on as long as the stack lasts. A stack of 64 shards runs for 32 minutes.

A redstone signal pauses it. A paused catalyst sends no beam and keeps its fuel and the progress on the item it was burning, then carries on where it left off once the signal stops.

<ItemLink id="budding_prismarine"/> touching the catalyst on any face except the lens face boosts it. Each block adds 25% to its power and 0.1 to its purity, up to a purity of 2.0 (`catalystBuddingOutputBonus`, `catalystBuddingPurityBonus` and `catalystBuddingMaxPurity`). A boosting Budding Prismarine grows nothing: the catalyst breaks any Prismarine Cluster on it every second, with no drop.

The two small lamps near the lens end of each side show whether it has found a receiver. Green means a laser block within range takes the beam. Red means it has not: nothing is in line with the lens, a solid block is in the way, or the block in front does not take a beam from that side (a relay facing the wrong way is the usual cause). Shift-right-click the catalyst with an empty hand for a chat readout of its fuel, which way it fires, what the beam hits and how to fix it.

<Color id="gold">Tip</Color>: the beam burns anything standing in it, you included, and a stronger beam burns harder (see [Moving Laser Power](nautec:laser_chemistry/laser_manipulation.md)). Walk around running beams, or run them through glass.

***

<Row>
  <ItemImage id="advanced_aquatic_catalyst"/>
  ### <Color id="aqua">Advanced Aquatic Catalyst</Color>
</Row>

An Aquatic Catalyst with a gold-trimmed frame that burns eight fuel items at once. Each burn lasts as long as one item does in the Aquatic Catalyst, and the beam carries eight times the power, so a stack of shards gives 160 AP per tick instead of 20 and runs out eight times as fast. The energy from each item is the same; you get it all sooner.

<Recipe id="nautec:advanced_aquatic_catalyst"/>

| Fuel | Purity | Power | Burn time |
|---|---|---|---|
| Prismarine Shard | 0.44 | 96 AP/t | 30 s |
| Prismarine Crystals | 0.88 | 48 AP/t | 30 s |
| <ItemLink id="prismarine_crystal_shard"/> | 1.32 | 160 AP/t | 75 s |

Its beam is 10% purer than the same fuel in an Aquatic Catalyst, before any Budding Prismarine boost. With fewer than eight items loaded it burns what is there, at that many times the power. Everything else works like the Aquatic Catalyst: placement, lamps, redstone pausing, Budding Prismarine and the shift-right-click readout. `advancedCatalystFuelMultiplier` and `advancedCatalystPurityMultiplier` set the eight and the 10%.

***

## <Color id="gold">Purity</Color>

Purity is set where a beam starts. A catalyst beam carries its fuel's purity, 0.4 to 1.2, plus any Budding Prismarine boost. When two or more beams feed the same block, their power adds up and their purity stays close to the purest beam. The result is the highest purity minus a quarter of the gap between it and the average of all of them (`beamMergePurityDrop`), so a 3.0 beam merged with a 0 beam comes out at about 2.6.

Higher purity comes from a <ItemLink id="prismarine_crystal"/> (3.0 in the wild, 3.00-6.00 when newly cultivated, up to 12 once enriched), a <ItemLink id="bacterial_fuel_cell"/> (up to 2.5), or a <ItemLink id="focusing_lens"/> added to an existing beam. [Beam Optics](nautec:deep_engineering/beam_optics.md) covers turning, splitting and focusing beams.

***

<Row>
  <ItemImage id="prismarine_crystal"/>
  ### <Color id="aqua">Prismarine Crystal</Color>
</Row>

A six block tall crystal found standing inside Crystal Geodes under the ocean floor (see [Structures](structures.md)). It turns any beam into a purity 3.0 beam. Wild crystals are rooted in place, but you can grow a movable crystal that rolls 3.00-6.00 purity on maturity: see [Crystal Cultivation](nautec:deep_engineering/crystal_cultivation.md). A [Bacterial Enrichment Catalyst](nautec:deep_engineering/bacterial_enrichment_catalyst.md) can then raise it up to 12.

Fire a beam into the crystal from the side. Any of its six blocks takes a beam on any of its four sides, and beams from several sources add together. The top block then fires straight up and the bottom block fires straight down, both at the crystal's purity: 3.0 for natural crystals, or the fixed value rolled when a cultivated crystal matures. If only one of them reaches a receiver, that beam carries the full incoming power. If both do, the power is split evenly between them, so a crystal never puts out more AP than goes in. These two beams run until they reach a receiver or a solid block, so they work into an empty floor or ceiling as well.

The crystal stays where it generated, so build around it. An Aquarine Steel Pickaxe with its ability on chips [Prismarine Crystal Shards](nautec:laser_chemistry/crystal_shards.md) off it, but every hit has a chance to shatter the whole crystal.

***

## <Color id="gold">Moving Power</Color>

* [Laser Manipulation](nautec:laser_chemistry/laser_manipulation.md): the Prismarine Laser Relay passes a beam on, and the Laser Junction merges and splits beams.
* [Beam Optics](nautec:deep_engineering/beam_optics.md): the Focusing Lens, for raising purity.
* [Charger](nautec:laser_chemistry/charger.md) and [Prismatic Battery](nautec:laser_chemistry/prismatic_battery.md): storing power in items.

Wear a <ItemLink id="prism_monocle"/> to read the power and purity arriving at any laser block.

***

## <Color id="gold">Stronger Beams</Color>

A machine's AP figure is the least it needs to run, not a cost. A stronger beam than that is never wasted: most machines run faster on it, by the square root of (beam ÷ what they need), so four times the power runs a machine twice as fast. [Stronger Beams](nautec:getting_started/stronger_beams.md) has the full rule and the list of machines.
