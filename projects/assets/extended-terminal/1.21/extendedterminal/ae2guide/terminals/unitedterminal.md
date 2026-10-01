---
navigation:
  title: United Terminal
  icon: united_terminal
  parent: index.md
  position: 021
categories:
  - extendedterminal
item_ids:
  - united_terminal
  - wireless_united_terminal
---
# United Terminal
<ItemImage id="extendedterminal:united_terminal" scale={3}/>

<ItemLink id="extendedterminal:united_terminal" /> combines the Extended Terminal tools with Extended Crafting support in a single terminal.
Use it when you want one terminal for normal crafting, smithing, stonecutting, anvil work, and extended crafting grids.

## Recipe
<RecipeFor id="extendedterminal:united_terminal" />

<myotus:condition load="ae2wtlib" silent="true">
## Wireless United Terminal
<ItemLink id="extendedterminal:wireless_united_terminal" /> is a wireless version of the <ItemLink id="extendedterminal:united_terminal" />.
It requires a <ItemLink id="ae2:wireless_access_point"/> to function.

## Recipe
<RecipeFor id="extendedterminal:wireless_united_terminal" />

### Universal Wireless Terminal
<ItemLink id="extendedterminal:wireless_united_terminal"/> can be combined with <ItemLink id="ae2wtlib:wireless_universal_terminal"/> as well.
<Row>
    <Recipe id="extendedterminal:ae2wtlib/united_etc" />
    <Recipe id="extendedterminal:ae2wtlib/united_etp" />
    <Recipe id="extendedterminal:ae2wtlib/upgrade_wireless_united_terminal" />
</Row>
</myotus:condition>
