---
navigation:
  title: Fusion Plant
  icon: nautec:fusion_controller
  position: 8
  parent: deep_engineering/deep_engineering-index.md
item_ids:
  - nautec:fusion_controller
  - nautec:fusion_casing
  - nautec:aquamarine_structural_glass
  - nautec:laser_injector
  - nautec:fusion_collector
  - nautec:containment_coil
  - nautec:fusion_port
---

# <Color id="light_purple">Fusion Plant</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="fusion_controller" scale="2"/>
    <ItemImage id="laser_injector" scale="2"/>
    <ItemImage id="containment_coil" scale="2"/>
  </Row>
  A laser fusion reactor built around a Cultivated Prismarine Crystal. It burns Salt Water and makes Forge Energy (FE) for other mods' machines.
</Column>

Laser Injectors fire beams into the crystal heart. The crystal fires them on as plasma beams into two Fusion Collectors, and the plasma fuses Salt Water into FE. A small chamber makes around 20,000 FE/t; a large one with a full set of Containment Coils makes 300,000 FE/t, and satellite crystals in its corners take it up to 700,000 FE/t.

***

## <Color id="gold">What It Needs</Color>

* A Cultivated Prismarine Crystal, grown as described on [Crystal Cultivation](crystal_cultivation.md). The heart must be cultivated.
* Laser beams with a purity of 2.0 or more. Purity 3.0 gives the base 50 FE per AP, so the strongest plants are fed through another crystal. A [Bacterial Fuel Cell](nautec:aquatic_biology/bacterial_fuel_cell.md) at its best (2.5) gives five sixths of that. Beams purer than 3.0 give more, see Running It.
* A steady supply of Salt Water from [Deep Sea Drains](nautec:laser_chemistry/drain.md).
* The parts below. JEI shows their recipes: they take Deep Steel Plating, Atlantic Gold, Ender Pearls, Flawless Prismarine Crystals and, for the controller, a Nether Star.

***

## <Color id="gold">Building the Chamber</Color>

The crystal stands in the middle of a hollow, square box. Inside, the box is exactly as tall as the crystal (6 blocks) and 3, 5, 7 or 9 blocks wide and deep. The walls, floor and ceiling are one block thick around that space.

<GameScene zoom="2.5" background="#333333" interactive={true}>
  <Block id="nautec:fusion_casing" x="0" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="1" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="2" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="3" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="0"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="0" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="1"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="1"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="2"/>
  <Block id="nautec:fusion_collector" x="2" y="0" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="2"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="2"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="0" z="3"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="0" z="3"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="1" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="2" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="3" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="0" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="1" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="1" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="1" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="1" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="1" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="2" z="0"/>
  <Block id="nautec:containment_coil" x="1" y="2" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="2" z="0"/>
  <Block id="nautec:containment_coil" x="3" y="2" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="2" z="0"/>
  <Block id="nautec:fusion_port" x="0" y="2" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="2" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="2" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="2" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="2" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="3" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="3" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="3" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="3" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="3" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="4" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="4" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="4" z="1"/>
  <Block id="nautec:laser_injector" x="0" y="4" z="2" p:facing="east"/>
  <Block id="nautec:laser_injector" x="4" y="4" z="2" p:facing="west"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="4" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="4" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="4" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="5" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="5" z="0"/>
  <Block id="nautec:fusion_controller" x="2" y="5" z="0" p:facing="north"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="5" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="5" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="5" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="5" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="5" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="1" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="2" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="3" y="6" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="6" z="0"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="1"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="2"/>
  <Block id="nautec:aquamarine_structural_glass" x="0" y="6" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="6" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="6" z="4"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="1" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="2" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="3" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="0"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="1"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="1"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="2"/>
  <Block id="nautec:fusion_collector" x="2" y="7" z="2"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="2"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="3"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="3"/>
  <Block id="nautec:fusion_casing" x="0" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="1" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="2" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="3" y="7" z="4"/>
  <Block id="nautec:fusion_casing" x="4" y="7" z="4"/>
  <BoxAnnotation min="2 1 2" max="3 7 3" color="#52e8ff" thickness="0.6">
    The Cultivated Prismarine Crystal stands here, filling the chamber from floor to ceiling.
  </BoxAnnotation>
  <BlockAnnotation x="2" y="5" z="0" color="#ffd86b">
    Fusion Controller, in a side wall, facing out.
  </BlockAnnotation>
  <BlockAnnotation x="0" y="4" z="2" color="#52e8ff">
    Laser Injector, in the middle of a side wall at the height of the crystal core, pointing at it.
  </BlockAnnotation>
  <BlockAnnotation x="2" y="0" z="2" color="#b8a6ff">
    Fusion Collector, in the middle of the floor. Another goes in the middle of the ceiling.
  </BlockAnnotation>
  <BlockAnnotation x="1" y="2" z="0" color="#ffd86b">
    Containment Coil, anywhere in a wall, floor or ceiling.
  </BlockAnnotation>
  <BlockAnnotation x="0" y="2" z="1" color="#8cc4f2">
    Fusion Port, anywhere in a wall, floor or ceiling.
  </BlockAnnotation>
  <IsometricCamera yaw="135" pitch="25"/>
</GameScene>

The scene leaves out two walls and the ceiling so you can see inside.

* <ItemLink id="fusion_casing"/> goes on every edge of the box.
* The rest of the walls, floor and ceiling can be <ItemLink id="aquamarine_structural_glass"/>, Fusion Casing, Containment Coils or Fusion Ports. Glass lets you watch the plasma.
* A <ItemLink id="fusion_collector"/> goes in the middle of the ceiling and another in the middle of the floor, in line with the crystal.
* A <ItemLink id="laser_injector"/> goes in the middle of any side wall, level with the crystal's core (the fourth block up from its base). Place it while looking into the chamber so it points at the crystal. Up to four fit, one per wall.
* The <ItemLink id="fusion_controller"/> goes anywhere in a side wall away from the edges, facing out. It looks for the crystal 2 to 5 blocks behind it.
* Leave the inside empty apart from the crystal and any satellite crystals in its corners (see Satellite Crystals below). Air and water are both fine, so the plant can be built underwater.

Right-click the controller, or any Fusion Port, to open its screen. While the chamber is incomplete, the bottom line names the first thing that is wrong.

***

## <Color id="gold">Running It</Color>

1. **Fuel.** Pipe Salt Water into the controller or a <ItemLink id="fusion_port"/>. They take nothing else.
2. **Ignition.** Fire beams into the backs of the injectors from outside. A cold plant soaks up its first 5,000,000 AP as heat before it makes anything, which is about 40 seconds at 6,000 AP/t or several minutes for a small feed. The left bar on the screen shows the heat.
3. **Power.** Once the heat bar is full, each AP injected makes 50 FE at purity 3.0. Lower purity scales that down: purity 2.4 gives 40 FE per AP. Purity above 3.0 adds to it on a curve that flattens out: about 1.35 times as much at purity 6, 1.55 times at 9 and 1.69 times at 12. Purer beams come from enriched crystals, see [Bacterial Enrichment Catalyst](bacterial_enrichment_catalyst.md).
4. **Burn.** Each mB of Salt Water makes 2,000 FE, so a plant at 300,000 FE/t burns 150 mB every tick. That is what six Deep Sea Drains pump.
5. **Output.** The controller and every Fusion Port push FE into any cable or machine touching them.

If the fuel or the beam stops, the plasma cools and the plant goes cold again over 20 seconds. A short gap costs only the heat it lost, which the beams put back quickly.

***

## <Color id="gold">Output Ceiling</Color>

The chamber caps how much plasma it can hold. Beams past the ceiling are wasted, and the screen shows **At ceiling**.

| Inside | Ceiling |
|---|---|
| 3 x 3 | 20,000 FE/t |
| 5 x 5 | 50,000 FE/t |
| 7 x 7 | 100,000 FE/t |
| 9 x 9 | 200,000 FE/t |

Each <ItemLink id="containment_coil"/> in the shell adds 4,000 FE/t, up to 300,000 FE/t in total. A 9 x 9 chamber reaches that with 25 coils, fed by 6,000 AP/t of purity 3.0 beams.

***

## <Color id="gold">Heart Purity</Color>

The heart crystal's own purity raises the plant's output ceiling and its maximum output by 10% for every point above 3.0: +30% at purity 6 and +90% at purity 12. A cultivated crystal that rolled a high purity does better, and an enriched one better still.

A crystal cannot be enriched while it is inside a formed plant. Enrich it outside with a [Bacterial Enrichment Catalyst](bacterial_enrichment_catalyst.md), pick it up with a wrench and place it as the heart.

***

## <Color id="gold">Satellite Crystals</Color>

A 7 x 7 or 9 x 9 chamber has room for more crystals. Set a Cultivated Prismarine Crystal in each of the four inner corners, standing on the floor and reaching the ceiling the same way the heart does. Each satellite crystal:

* adds 100,000 FE/t to the ceiling and raises the 300,000 FE/t limit by the same amount
* adds 10 FE to what each AP injected makes, so 50 becomes 60 with one satellite and 90 with all four

<GameScene zoom="2.5" background="#333333" interactive={true}>
  <ImportStructure src="fusion_plant_satellites.nbt" />
  <IsometricCamera yaw="225" pitch="30" />
  <BoxAnnotation min="3.97 0.97 3.97" max="5.03 7.03 5.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **Heart.** The Cultivated Prismarine Crystal the plant is built around stands here, floor to ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="0.97 0.97 0.97" max="2.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **Satellite crystal.** A Cultivated Prismarine Crystal stands here, floor to ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="6.97 0.97 0.97" max="8.03 7.03 2.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **Satellite crystal.** A Cultivated Prismarine Crystal stands here, floor to ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="0.97 0.97 6.97" max="2.03 7.03 8.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **Satellite crystal.** A Cultivated Prismarine Crystal stands here, floor to ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="6.97 0.97 6.97" max="8.03 7.03 8.03" color="#ff6ec7" thickness="0.06" alwaysOnTop={true}>
    **Satellite crystal.** A Cultivated Prismarine Crystal stands here, floor to ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="3.97 4.97 -0.03" max="5.03 6.03 1.03" color="#ffd86b" thickness="0.06" alwaysOnTop={true}>
    **Fusion Controller.** In a side wall away from the edges, facing out.
  </BoxAnnotation>
  <BoxAnnotation min="3.97 3.97 -0.03" max="5.03 5.03 1.03" color="#52e8ff" thickness="0.06" alwaysOnTop={true}>
    **Laser Injector.** In the middle of a side wall, level with the crystal core, pointing at it. This plant has one on each wall.
  </BoxAnnotation>
  <BoxAnnotation min="3.97 -0.03 3.97" max="5.03 1.03 5.03" color="#b8a6ff" thickness="0.06" alwaysOnTop={true}>
    **Fusion Collector.** In the middle of the floor, and another in the middle of the ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="7.97 1.97 0.97" max="9.03 3.03 2.03" color="#ffb74d" thickness="0.06" alwaysOnTop={true}>
    **Containment Coil.** The east wall has two rows of them. Each adds 4,000 FE/t to the ceiling.
  </BoxAnnotation>
  <BoxAnnotation min="-0.03 1.97 3.97" max="1.03 3.03 5.03" color="#8cc4f2" thickness="0.06" alwaysOnTop={true}>
    **Fusion Port.** Takes Salt Water and gives FE, like the controller.
  </BoxAnnotation>
</GameScene>

A 7 x 7 plant with all four satellites: 88 Fusion Casing on the edges, 244 Aquarine Structural Glass, 14 Containment Coils, 4 Laser Injectors, 2 Fusion Collectors, a Fusion Port and the controller, 354 blocks in all, plus the five crystals. The crystals are drawn by their own renderer, so the scene marks their places instead of showing them. Drag the scene to turn it.

| Satellites | Most output | FE per AP | AP/t of purity 3.0 to reach it |
|---|---|---|---|
| 0 | 300,000 FE/t | 50 | 6,000 |
| 1 | 400,000 FE/t | 60 | 6,667 |
| 2 | 500,000 FE/t | 70 | 7,143 |
| 3 | 600,000 FE/t | 80 | 7,500 |
| 4 | 700,000 FE/t | 90 | 7,778 |

Every satellite has to be cultivated, see [Crystal Cultivation](crystal_cultivation.md), so each one costs another 10,000,000 AP of growing. Salt Water still makes 2,000 FE per mB, so a plant at 700,000 FE/t burns 350 mB every tick, the output of 14 Deep Sea Drains. The screen's Satellites line shows how many the chamber has, and a crystal anywhere else inside still stops it forming.

The numbers are `fusionSatelliteContainment` and `fusionSatelliteFePerAp` in `config/nautec-common.toml`.

<Color id="gold">Tip</Color>: an [Energy Converter](nautec:laser_chemistry/energy_converter.md) can feed the plant some of its own FE back as AP. Converter beams have a purity of 0, so send them through another Prismarine Crystal first to bring them up to its purity.
