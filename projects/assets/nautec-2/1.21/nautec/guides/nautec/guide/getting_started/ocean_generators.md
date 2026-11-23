---
navigation:
  title: Ocean Generators
  icon: nautec:tidal_rotor
  position: 16
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:tidal_rotor
  - nautec:thermal_vent_tap
---

# <Color id="light_purple">Ocean Generators</Color>

<Column alignItems="center" fullWidth={true}>
  <Row>
    <ItemImage id="tidal_rotor" scale="2"/>
    <ItemImage id="thermal_vent_tap" scale="2"/>
  </Row>
  Generators that turn the ocean into Forge Energy (FE) for other mods' machines.
</Column>

NauTec has four FE generators. The Tidal Rotor runs on the ocean itself, the Thermal Vent Tap boils Salt Water over the seabed's heat, the [Combustion Dynamo](nautec:getting_started/combustion_dynamo.md) burns oil grown by bacteria, and the [Fusion Plant](nautec:deep_engineering/fusion_plant.md) is the late-game reactor. Every generator pushes its FE into any cable or machine touching it.

***

<Row>
  <ItemImage id="tidal_rotor"/>
  ### <Color id="aqua">Tidal Rotor</Color>
</Row>

A cast iron turbine for the early game, 40 to 80 FE/t with no fuel.

Place it underwater in an ocean biome. It makes 40 FE/t in the tightest spot that works and more the more open and deep the water is, reaching 80 FE/t with water on every side and 24 blocks of water above it. A rotor dug into the seabed or packed against other rotors makes less, so spread a field of them out across the ocean floor rather than stacking them.

***

<Row>
  <ItemImage id="thermal_vent_tap"/>
  ### <Color id="aqua">Thermal Vent Tap</Color>
</Row>

A mid-game generator that boils Salt Water over magma or lava, 350 to 1,250 FE/t.

* **Heat.** The tap checks the nine blocks directly beneath it for Magma Blocks or lava. One hot block gives 350 FE/t, and all nine give 1,250 FE/t. A <ItemLink id="hydrothermal_vent"/> from a vent field counts as three hot blocks on its own. In the Hydrothermal Vents biome the seabed adds three more, as long as at least one hot block is there.
* **Fuel.** Pipe Salt Water into any side. The tap boils 10 mB every tick while it runs, so one [Deep Sea Drain](nautec:laser_chemistry/drain.md) keeps two taps going with a little to spare.
* **Salt.** Every 1,000 mB it boils leaves one <ItemLink id="salt"/> behind. The tap pushes it into any chest or other inventory touching it, or you can pull it out of any side with a pipe or hopper. A full slot stops the salt, not the power.

Jade shows each generator's output and what it is missing.

<RecipeFor id="tidal_rotor"/>

<RecipeFor id="thermal_vent_tap"/>
