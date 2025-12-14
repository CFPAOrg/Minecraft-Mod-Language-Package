---
navigation:
  title: Extended Terminal
  icon: et_terminal
  parent: index.md
  position: 1
categories:
  - extendedterminal
item_ids:
  - et_terminal
  - wireless_et_terminal
---

# Extended Terminal

<ItemImage id="extendedterminal:et_terminal" scale={3}/>

<ItemLink id="extendedterminal:et_terminal" /> is all in one terminal that include Crafting, Smithing, Stonecutter and Anvil.

## CAUTION!!
<ItemLink id="minecraft:anvil"/> does <Color id="red"> **NOT YET SUPPORT JEI/EMI TRANSFER**</Color> and may be  **<Color id="red">incompatible</Color>** with some Anvil related mods

## Recipe
<RecipeFor id="extendedterminal:et_terminal" />

<et:condition load="AE2WTLib" silent="true">
# Wireless Terminal
<ItemLink id="extendedterminal:wireless_et_terminal" /> is a wireless version of the <ItemLink id="extendedterminal:et_terminal" />. It requires a <ItemLink id="ae2:wireless_access_point"/> to function.
## Recipe
<RecipeFor id="extendedterminal:wireless_et_terminal" />

### Universal Wireless Terminal
<ItemLink id="extendedterminal:wireless_et_terminal"/> can be combined with <ItemLink id="ae2wtlib:wireless_universal_terminal"/> as well
<Row>
    <Recipe id="ae2wtlib/etc" />
    <Recipe id="ae2wtlib/etp" />
    <Recipe id="ae2wtlib/upgrade_wireless_et_terminal" />
</Row>

</et:condition>