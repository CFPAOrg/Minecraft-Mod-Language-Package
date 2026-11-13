---
navigation:
  title: Prism Monocle
  icon: nautec:prism_monocle
  position: 9
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:prism_monocle
---

# <Color id="light_purple">Prism Monocle</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="prism_monocle" scale="2"/>
  Shows a readout for the NauTec block you are looking at.
</Column>

Wear the monocle in your helmet slot or in its own Monocle curio slot. While it is on, looking at a NauTec machine or laser block shows its readout in the middle of the screen. It also clears the underwater fog, the same as the Diving Helmet.

<Recipe id="nautec:prism_monocle"/>

***

## <Color id="gold">Readouts</Color>

| Block | Shows |
|---|---|
| Any machine, relay, optic or other laser block | Power arriving (AP per tick) and Purity |
| <ItemLink id="aquatic_catalyst"/> | Duration: ticks the current fuel item has been burning |
| <ItemLink id="bacterial_fuel_cell"/> | Output (AP per tick), Purity and Fuel, or No colony |
| <ItemLink id="pressure_forge"/> | Any synthesizer fitted, then Under pressure, Acid (mb) and Purity, or what depth and water it still needs |
| <ItemLink id="resonance_chamber"/> | Charge, Ceiling and Purity, or Cracked while it cools down |
| <ItemLink id="gateway"/> and its ring | Its Address; whether it is open, ready, idle, out of power, held shut by redstone or blocked; whether it is a wild ring; and its stored power |
| <ItemLink id="submarine_dock"/> | Whether a Sea Scout is docked |
| Deep Sea Drain wall | Power and Fluid Stored |
| <ItemLink id="bubble_anchor"/> | Its status, the field size, and the fuel left or what it ends as |
| <ItemLink id="oxygen_diffuser"/> | Its range while running, or the AP it needs |
| <ItemLink id="energy_converter"/> | AP sent, how many beams share it and the FE/t it costs, or why it is idle |
| <ItemLink id="grafting_station"/> and <ItemLink id="advanced_bacterial_analyzer"/> | Status, Power and Purity |
| <ItemLink id="colony_replicator"/> | Status, Replicate or Splice mode, and Biomass |
| <ItemLink id="uplink_array"/> | Its status |

Use it to check that a beam is arriving and pure enough before you blame a recipe. Purity drops a little when a weaker beam feeds the same block as a pure one.

A <ItemLink id="resonance_charm"/> worn in a charm slot does the same job, so you do not need both. See [Resonance Network](nautec:deep_engineering/resonance_network.md).

***

## <Color id="gold">With Jade</Color>

If Jade is installed it adds its own tooltips for some blocks: the Aquatic Catalyst's status, queued fuel, remaining ticks, AP per tick and what its beam reaches, plus the Mixer, Laser Junction, Deep Sea Drain, Confined Spawner, Crystal Cradle, Prismarine Crystal, Fusion Plant controller, Tidal Rotor, Thermal Vent Tap and Energy Converter.
