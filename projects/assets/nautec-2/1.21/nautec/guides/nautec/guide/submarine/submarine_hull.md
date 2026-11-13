---
navigation:
  title: Hull and Repair
  icon: nautec:submarine
  position: 3
  parent: submarine/submarine-index.md
---

# <Color id="light_purple">Hull and Repair</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="submarine" scale="2"/>
  Damage, breaching and repair.
</Column>

The hull has its own health and armour, and while you are aboard it is what gets attacked, not you.

***

## <Color id="gold">Hull Strength</Color>

| | Default |
|---|---|
| Hull points | 80 (40 hearts) |
| Armour | 20, the same as full diamond |
| Armour toughness | 8, the same as full diamond |

All three are configurable. The [Armour Module](armor_module.md) raises toughness and stops knockback, and the [Shield Module](shield_module.md) spends power to absorb hits.

When you board, any creature within 32 blocks that was hunting you switches to the hull, and while you ride, anything that tries to target you targets the hull instead. The [Stealth Module](stealth_module.md) is the way to shake them.

The hull takes no damage from drowning, freezing, suffocating in blocks, crowding or falling, and nobody aboard can damage it. Potions and healing have no effect on it.

***

## <Color id="gold">Self Repair</Color>

The hull restores 1% of its points every 10 seconds, whether or not anyone is aboard, so a scratched hull left alone for a while comes back to full. The interval and amount are configurable, and a pack can turn self repair off.

The HULL row of the readout shows where you stand (see [Piloting](submarine_controls.md)).

***

## <Color id="gold">Breaching</Color>

When the hull runs out of points it throws the crew out unharmed and drops as an item with all its modules and charge. That item is breached: using it gives "The hull is breached. Repair it on an anvil before launching", and its tooltip says the same.

<Color id="gold">Tip</Color>: the crew are dumped wherever the hull broke, often deep under water. Keep a [Diving Suit](nautec:getting_started/diving_gear.md) on if you are pushing a damaged hull.

***

## <Color id="gold">Repairing on an Anvil</Color>

<ItemImage id="deep_steel_plating" scale="1"/>

Put the hull in the left slot of an anvil and <ItemLink id="deep_steel_plating"/> in the right. Each plating restores 20% of the hull and costs 2 levels, and the anvil uses only as many as the repair needs, so five take a breached hull back to full.

This works on any damaged hull item, not only a breached one. Deep Steel Plating is pressed in the [Abyssal Pressure Forge](nautec:deep_engineering/pressure_forge.md). The repair item and the amount per item are configurable, and a pack may have switched the repair item to diamonds.
