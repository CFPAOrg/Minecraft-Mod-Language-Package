---
navigation:
  title: Energy Converter
  icon: nautec:energy_converter
  position: 1
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:energy_converter
  - nautec:creative_power_source
  - nautec:creative_energy_source
  - nautec:energy_conversion_upgrade
  - nautec:advanced_energy_conversion_upgrade
  - nautec:ultimate_energy_conversion_upgrade
---

# <Color id="light_purple">Energy Converter</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="energy_converter" scale="2"/>
  Turns Forge Energy (FE) from other mods into a laser beam.
</Column>

The conversion goes one way only: FE in, AP out.

***

## <Color id="gold">Using It</Color>

Push FE into any side with a cable or generator from another mod. It holds up to 4,000,000 FE (`energyConverterFeCapacity` in `config/nautec-common.toml`).

Every 10 FE becomes 1 AP (`energyConverterFePerAp`). The converter fires its beam out of every side that has a laser receiver in line, up to 16 blocks away. The AP is split evenly between the connected receivers, rounded down, so 150 AP across two receivers gives 75 AP each and across four gives 37. It only spends FE while at least one receiver is connected, so a converter with nothing to power keeps its buffer.

Right-click it to set the transmission rate: the AP it sends each tick. The buttons step by 1 or 10, by 10 or 100 with Shift held, and by 100 or 1,000 with Ctrl held. The screen shows the FE per tick the rate costs, so turn it down to match what your generators supply and the beam stays steady instead of cutting out when the buffer runs dry. A rate of 0 switches it off.

***

## <Color id="gold">Upgrades</Color>

A converter with no upgrades sends up to 150 AP per tick. Its screen has three upgrade slots, one for each tier, and each slot takes up to 8 upgrades of its own tier:

| Upgrade | Adds per upgrade | 8 of them add |
|---|---|---|
| <ItemLink id="energy_conversion_upgrade"/> | 150 AP/t | 1,200 AP/t |
| <ItemLink id="advanced_energy_conversion_upgrade"/> | 500 AP/t | 4,000 AP/t |
| <ItemLink id="ultimate_energy_conversion_upgrade"/> | 1,500 AP/t | 12,000 AP/t |

All three slots full gives 17,350 AP per tick, which burns 173,500 FE per tick. Taking upgrades out lowers the rate to the new limit.

<Recipe id="nautec:energy_conversion_upgrade"/>
<Recipe id="nautec:advanced_energy_conversion_upgrade"/>
<Recipe id="nautec:ultimate_energy_conversion_upgrade"/>

***

## <Color id="gold">Purity</Color>

Its beam has a purity of 0. That runs the [Mixer](mixer.md), the [Deep Sea Drain](drain.md), the [Charger](charger.md) and any Item Transformation that needs no purity. A Focusing Lens cannot raise it, since a lens only adds purity to a beam that already has some.

To get pure power from FE, merge the converter beam with a pure source into the same block, such as a [Laser Junction](laser_manipulation.md). Merged beams keep close to the purity of the purest one: a Prismarine Crystal beam at 3.0 joined by a converter beam comes out at about 2.6 with the power of both. See [Beam Optics](nautec:deep_engineering/beam_optics.md) for the pure sources.

<Recipe id="nautec:energy_converter"/>

***

<Row>
  <ItemImage id="creative_power_source"/>
  ### <Color id="aqua">Creative Power Source</Color>
</Row>

A creative-only laser source for testing builds. It needs no fuel and sends 100 AP per tick at purity 0, split evenly between every side that has a receiver in line. It is in the NauTec creative tab.

***

<Row>
  <ItemImage id="creative_energy_source"/>
  ### <Color id="aqua">Creative Energy Source</Color>
</Row>

An endless supply of FE for testing an Energy Converter. It does not push energy out, so connect it with a cable that pulls from it. It is in the NauTec creative tab.
