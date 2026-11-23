---
navigation:
  title: Stronger Beams
  icon: nautec:focusing_lens
  position: 2
  parent: getting_started/getting_started-index.md
---

# <Color id="light_purple">Stronger Beams</Color>

Every NauTec machine that needs a laser beam has a minimum: the AP per tick it must receive before it runs at all. A beam stronger than that minimum is never wasted. Most machines run faster on it, and the Deep Sea Drain pumps more.

***

## <Color id="gold">The Rule</Color>

**Speed = the square root of (beam ÷ what the machine needs).**

Four times the power runs a machine twice as fast. Nine times runs it three times as fast. There is no upper limit, but each extra step costs more power than the last.

| Beam, as a multiple of what the machine needs | Speed |
|---|---|
| less than 1× | does not run |
| 1× | ×1 (normal) |
| 2× | ×1.41 |
| 4× | ×2 |
| 9× | ×3 |
| 16× | ×4 |
| 25× | ×5 |
| 100× | ×10 |

A machine on a 40 AP beam that needs 10 AP runs at ×2. The same machine on 90 AP runs at ×3.

Purity does not speed anything up. A machine that needs a minimum purity (the Advanced Bacterial Analyzer, the Colony Replicator and the Grafting Station) still stops below it, however much power arrives.

***

## <Color id="gold">Which Machines</Color>

| Machine | Needs (default) | What a stronger beam speeds up |
|---|---|---|
| [Mixer](nautec:laser_chemistry/mixer.md) | 10 AP | more crafts per cycle, one per 10 AP up to 64; past 640 AP each cycle runs faster |
| [Mutator](nautec:aquatic_biology/mutator.md) | 10 AP | mutation attempts, so more tries per minute |
| [Incubator](nautec:aquatic_biology/incubator.md) | 20 AP | growth cycles, and the nutrient each cycle eats |
| [Bacterial Analyzer](nautec:aquatic_biology/bacterial_analyzer.md) | 5 AP | analysis |
| [Advanced Bacterial Analyzer](nautec:aquatic_biology/bacterial_analyzer.md) | 40 AP at purity 2.1 | analysis of all nine dishes |
| [Pressure Forge](nautec:deep_engineering/pressure_forge.md) | 40 AP | forging |
| [Colony Replicator](nautec:aquatic_biology/colony_replicator.md) | 80 AP at purity 2.0 | each copy |
| [Grafting Station](nautec:aquatic_biology/bacteria_grafting.md) | 100 AP at purity 2.8, 500 AP with an Advanced Grafting Anchor | each graft |
| [Bio Reactor](nautec:aquatic_biology/bio_reactor.md) | 5 AP, plus 15 per colony, times its upgrades | production |
| [Industrial Bio Reactor](nautec:aquatic_biology/industrial_bio_reactor.md) | 100 AP, plus 50 per colony, times its upgrades | production |
| [Augmentation Station](nautec:laser_augmentation/augmentation_station.md) | 25 AP into each extension in use | installing an augment, at the pace of the weakest extension |
| [Submarine Dock](nautec:submarine/submarine_dock.md) | 20 AP | how fast it charges a docked submarine |
| [Deep Sea Drain](nautec:laser_chemistry/drain.md) | more than 20 AP | Salt Water pumped each second, in direct proportion to the beam |
| [Osmosis Filter](nautec:laser_chemistry/osmosis_filter.md) | none | water output doubles every 40 AP |

**Stacking.** The Bio Reactors work out what they need from their colonies and upgrades first, and a stronger beam then speeds up on top of their Speed Upgrades. A reactor whose upgrades make it run ×1.5 and that gets four times the power it needs runs ×3. A stronger beam does not make a colony eat its nutrient any faster, so it is pure extra output. The Advanced Grafting Anchor works the same way: it raises the station's need to 500 AP and grafts faster, and a beam above 500 AP speeds it up again.

**No speed-up.** The [Laser Purification Smelter](nautec:deep_engineering/laser_purification_smelter.md) runs at the speed of its conduit upgrade, however strong the beam. A purer beam lowers the AP it needs instead.

**Already scaling.** The [Resonance Chamber](nautec:deep_engineering/resonance_chamber.md) charges by however much power it receives, and a [Crystal Cradle](nautec:deep_engineering/crystal_cultivation.md) grows by the total power it has taken in, so both already go faster on a stronger beam, in direct proportion.

***

## <Color id="gold">Seeing It</Color>

Jade shows the speed on any of these machines, with the beam it is getting and what it needs, for example "Speed x2.00 on a 40 AP beam (needs 10)". A beam that is too weak shows in red. A <ItemLink id="prism_monocle"/> shows the power and purity arriving at any laser block.

To get a stronger beam, merge several sources with a [Laser Junction](nautec:laser_chemistry/laser_manipulation.md), or feed a machine from a stronger generator such as an [Energy Converter](nautec:laser_chemistry/energy_converter.md).

***

## <Color id="gold">For Pack Makers</Color>

`beamOverclock` in `config/nautec-common.toml` turns the speed-up off, so every machine runs at normal speed above its minimum. `beamOverclockMaxSpeed` caps the speed multiplier; 0 means no cap. The Deep Sea Drain's pumping has its own settings, described on its page.
