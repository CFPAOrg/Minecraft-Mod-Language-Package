---
navigation:
  title: Custom Bacteria
  icon: minecraft:command_block
  position: 14
  parent: aquatic_biology/aquatic_biology-index.md
---

# <Color id="light_purple">Custom Bacteria</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="minecraft:command_block" scale="2"/>
  An admin command makes a new bacteria strain for any item.
</Column>

This page is for server admins and pack makers. The commands need operator permission (level 2).

***

## <Color id="gold">Making a Strain</Color>

`/nautec bacteria generate <name> <item> [rarity]`

Creates a strain called `<name>` that produces `<item>`, together with an incubation recipe that uses the item itself as the nutrient, a colony feeding recipe with the same nutrient, and a mutation recipe that uses it as the catalyst. The rarity sets the starting stats, the incubation growth, the mutation chance and the [Strain Yield](production_rates.md), and picks the strain it mutates from:

| Rarity | Mutates from | Strain Yield |
|---|---|---|
| common | Lithophiles | 1 |
| uncommon (default) | Metallophiles | 0.8 |
| rare | Ferrophiles | 0.6 |
| epic | Aurrophiles | 0.4 |
| legendary | Adamantophiles | 0.12 |

`/nautec bacteria generate-tag <name> <item> <tag> [rarity]` does the same but uses a whole item tag as the nutrient.

Add `preview` to the end of either command to print the files in chat, click to copy, without writing anything.

***

## <Color id="gold">Grafting Source</Color>

`/nautec bacteria obtain <name> <block> <biometag> <chance>`

Lets players graft the strain from `<block>` in any biome in `<biometag>`, with a chance from 0 to 1. Pick a block NauTec does not already graft from.

***

## <Color id="gold">Managing Them</Color>

* `/nautec bacteria list-generated` lists every generated strain, what it makes and which recipes it has.
* `/nautec bacteria delete-generated <name>` removes a strain's files and its grafting entries.

Everything goes in `config/nautec/generated_pack`, which every world in the instance shares. Run `/reload` to pick up new recipes and grafting sources. A new strain itself loads the next time you join a world.
