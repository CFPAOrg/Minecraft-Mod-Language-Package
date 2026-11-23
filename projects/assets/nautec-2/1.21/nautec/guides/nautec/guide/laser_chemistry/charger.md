---
navigation:
  title: Charger
  icon: nautec:charger
  position: 6
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:charger
---

# <Color id="light_purple">Charger</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="charger" scale="2"/>
  Fills items that run on AP from a laser beam.
</Column>

## <Color id="gold">Using It</Color>

Right-click the Charger with an item to set it on the pad, and right-click with an empty hand to take it back. It holds one item at a time.

Aim a beam into any face. The Charger is a low block, so a beam running along the ground catches it from the side as well as from above. Sparks fly while it charges and stop when the item is full.

Each tick the item takes the power the beam delivers, up to the item's own input limit. A stronger beam charges faster until it reaches that limit.

It charges any item that stores AP, including the [Aquarine Steel tools](tools.md) and [armor](nautec:laser_augmentation/aquarine_steel_armor.md), the [Prismatic Battery](prismatic_battery.md), the <ItemLink id="wave_jet"/> and the <ItemLink id="atlantean_rifle"/>.

| Item | Capacity | Most it takes per tick |
|---|---|---|
| Aquarine Steel Pickaxe, Axe, Shovel or Sword | 1,200 AP | 128 AP |
| Aquarine Steel Hoe | 700 AP | 128 AP |
| Prismatic Battery | 10,000 AP | 128 AP |

***

### <Color id="aqua">Charger Recipe</Color>

<RecipeFor id="charger"/>
