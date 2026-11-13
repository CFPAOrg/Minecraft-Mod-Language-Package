---
navigation:
  title: Shield Module
  icon: nautec:shield_module
  position: 12
  parent: submarine/submarine-index.md
item_ids:
  - nautec:shield_module
---

# <Color id="light_purple">Shield Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="shield_module" scale="2"/>
  Power instead of hull.
</Column>

The Shield Module spends stored power to absorb damage to the hull, and can be fired to blast everything around the hull away.

***

## <Color id="gold">Passive Shield</Color>

While the module is installed, in any slot, hits on the hull are paid for from the cell first: 10,000 power for every heart the shield absorbs. The hull's armour reduces the hit before the shield takes it, so the power only covers what gets through. If the cell cannot cover all of it, the rest goes to the hull.

A full cell absorbs up to 100 hearts, but the same cell also runs the thrusters and keeps the crew breathing. Watch the PWR row in a fight, because a long one can drain the cell and cut your air.

The shield covers hits that armour reduces. Damage that ignores armour, such as magic, fire or a Warden's sonic boom, goes straight to the hull.

***

## <Color id="gold">Discharge</Color>

| | Default |
|---|---|
| Power per discharge | 25,000 |
| Radius | 5 blocks around the hull |
| Damage | 10 (5 hearts) |
| Stun | 3 seconds |
| Cooldown | 5 seconds |

Fire the module and a ring bursts out from the hull. Every living thing within 5 blocks, apart from the hull's own crew, takes 10 damage, is knocked away from the hull and is Stunned for 3 seconds. A stunned creature cannot move or attack, and forgets what it was chasing.

The discharge hits players, pets and passive creatures as well as hostile ones, so make sure only what you want hurt is near the hull.

All the figures are configurable.

***

### <Color id="aqua">Shield Module Recipe</Color>

<Recipe id="nautec:shield_module"/>
