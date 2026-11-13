---
navigation:
  title: Bacterial Fuel Cell
  icon: nautec:bacterial_fuel_cell
  position: 13
  parent: aquatic_biology/aquatic_biology-index.md
item_ids:
  - nautec:bacterial_fuel_cell
---

# <Color id="light_purple">Bacterial Fuel Cell</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="bacterial_fuel_cell" scale="2"/>
  The Bacterial Fuel Cell burns a colony to fire a laser beam.
</Column>

Right-click the Fuel Cell with a <ItemLink id="petri_dish"/> to load the colony into it. Right-click with an empty dish to take back whatever is left. A loaded colony merges with the one already inside only if it is the same strain with exactly the same stats.

Hoppers and pipes can feed it too. A dish holding a colony goes in through any face and loads as soon as the Fuel Cell is empty or holds a matching colony with room to spare, and the empty dish can be pulled back out. It refuses empty dishes and colonies it cannot take yet, so a chest of dishes behind it keeps it burning one colony after another. [Side Configuration](nautec:getting_started/utilities.md) sets what each face allows, with the wrench since the Fuel Cell has no screen.

It works with any colony, analyzed or not, including the strains that make nothing in the [Bio Reactor](bio_reactor.md).

***

## <Color id="gold">Placing It</Color>

The beam leaves from the side opposite the face you were looking at when you placed it, so it fires away from you. That can be up or down as well as sideways.

It only fires, and only burns colony, while a block that accepts a beam is within 16 blocks on that side. With nothing to hit, the colony sits there untouched.

***

## <Color id="gold">Output</Color>

| Stat | Effect |
|---|---|
| Production Rate | Power is 24 AP per point of Production Rate (48 AP at the cap of 2). It also burns half a point of size per tick per point of Production Rate. |
| Mutation Resistance | Purity is 2.5 at the resistance cap and scales down to 0 with no resistance. |
| Size | How long it lasts. |

Power and burn rise together, so every point of size gives the same total energy. A fast colony only spends it sooner. A full 40,000 colony gives 24 AP for about 67 minutes at Production Rate 1, or 48 AP for about 33 minutes at Production Rate 2.

Most [Item Transformation](nautec:getting_started/item_transformation.md) recipes NauTec ships need a purity of 2.0 or less, which a colony reaches at 0.8 Mutation Resistance. That runs them without building a Prismarine Crystal core. Gears from a Cast Iron Block need 2.5, so only a colony at the resistance cap runs that one.

The base power (24), burn rate (0.5) and top purity (2.5) are all configurable.

***

## <Color id="gold">Choosing Between Matter and Energy</Color>

The Fuel Cell never ages a colony, so Vitality does not matter here, and a senescent colony burns exactly as well as a fresh one. That makes it the right home for a colony too old to be worth feeding. The Bio Reactor wants the same good colonies, so for each one you choose items or power.

***

## <Color id="gold">Recipe</Color>

<Recipe id="nautec:bacterial_fuel_cell"/>
