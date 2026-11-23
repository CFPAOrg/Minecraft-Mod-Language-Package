---
navigation:
  title: Armour Module
  icon: nautec:armor_module
  position: 8
  parent: submarine/submarine-index.md
item_ids:
  - nautec:armor_module
---

# <Color id="light_purple">Armour Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="armor_module" scale="2"/>
  Heavier plating for the hull.
</Column>

The Armour Module raises the hull's armour toughness and stops it being knocked around by hits.

***

## <Color id="gold">What It Changes</Color>

| | Without | With |
|---|---|---|
| Armour | 20 | 20 |
| Armour toughness | 8 (diamond) | 12 (netherite) |
| Knockback | Normal | None |

Toughness cuts how much armour a big hit gets through, so the module matters most against heavy attackers. With knockback gone, a strike no longer shoves you off course.

It is passive, works from any slot and uses no power. Take it out and the hull goes straight back to the stock figures. One is enough, since a second adds nothing. The toughness it gives is configurable (`submarineArmorModuleToughness`).

Pair it with a [Shield Module](shield_module.md) to soak what the armour lets through. See [Hull and Repair](submarine_hull.md) for the rest of the hull's defences.

***

### <Color id="aqua">Armour Module Recipe</Color>

<Recipe id="nautec:armor_module"/>
