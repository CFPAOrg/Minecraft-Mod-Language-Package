---
navigation:
  title: Machines
  icon: spaceploitation:planet_simulator_controller
  position: 3
item_ids:
  - spaceploitation:planet_simulator_controller
  - spaceploitation:planet_simulator_frame
  - spaceploitation:planet_simulator_casing
  - spaceploitation:compressor
---

# Machines

## Planet Simulator

A 7x7x3 multiblock that runs space missions to collect resources.

### Structure

<GameScene zoom="3" interactive={true} fullWidth={true}>
  <MultiblockShape multiblock="spaceploitation:planet_simulator" formed={true} unformed={true} direction="east"> </MultiblockShape>
</GameScene>

**Components:**
- <ItemLink id="spaceploitation:planet_simulator_controller" /> (1x)
- <ItemLink id="spaceploitation:planet_simulator_frame" /> (structure outline)
- <ItemLink id="spaceploitation:planet_simulator_casing" /> (walls - can be replaced with buses)
- Input/Output buses (see **Buses** page)

### How It Works

1. Insert an activated <ItemLink id="spaceploitation:planet_card" />
2. Supply input items via <ItemLink id="spaceploitation:item_input_bus" />
3. Provide energy via <ItemLink id="spaceploitation:energy_input_bus" />
4. Collect outputs from <ItemLink id="spaceploitation:item_output_bus" /> or <ItemLink id="spaceploitation:energy_output_bus" />

Different planets accept different inputs - check JEI for all recipes.

### Upgrades

Install upgrades to boost performance:
- <ItemLink id="spaceploitation:upgrade_speed" /> - Faster processing
- <ItemLink id="spaceploitation:upgrade_energy" /> - Lower energy cost
- <ItemLink id="spaceploitation:upgrade_luck" /> - Bonus output chance

---

## Compressor

Creates compressed materials from ingots.

<ItemImage id="spaceploitation:compressor" />

Connect to power, insert <ItemLink id="spaceploitation:tantalum_ingot" />, receive <ItemLink id="spaceploitation:tantalum_sheet" />.

<Recipe id="spaceploitation:tantalum_plate_compressing" />

Supports the same upgrade system as the Planet Simulator.
