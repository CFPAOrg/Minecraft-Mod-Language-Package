---
navigation:
  title: Extended Crafting Terminal
  icon: extendedcrafting:ultimate_table
  parent: index.md
  position: 020
categories:
  - extendedterminal
item_ids:
  - basic_terminal
  - advanced_terminal
  - elite_terminal
  - ultimate_terminal
---
# Extended Crafting Terminal
<et:condition load="ExtendedCrafting">
    <Column alignItems="center" fullwidth={true}>
        <GameScene zoom={4} interactive={true}>
            <ImportStructure src="../structures/extendedcrafting.snbt" />
            <IsometricCamera yaw="225" pitch="20" />
        </GameScene>
    </Column>  

## Basic Extended Crafting Terminal
<Row>
<ItemImage id="extendedterminal:basic_terminal" scale={3}/>
<ItemImage id="extendedcrafting:basic_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:basic_terminal" /> is terminal version of <ItemLink id="extendedcrafting:basic_table"/>.

## Advanced Extended Crafting Terminal
<Row>
<ItemImage id="extendedterminal:advanced_terminal" scale={3}/>
<ItemImage id="extendedcrafting:advanced_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:advanced_terminal" /> is terminal version of
<ItemLink id="extendedcrafting:advanced_table"/>.
## Elite Extended Crafting Terminal
<Row>
<ItemImage id="extendedterminal:elite_terminal" scale={3}/>
<ItemImage id="extendedcrafting:elite_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:elite_terminal" /> is terminal version of 
<ItemLink id="extendedcrafting:elite_table"/>.
## Ultimate Extended Crafting Terminal
<Row>
<ItemImage id="extendedterminal:ultimate_terminal" scale={3}/>
<ItemImage id="extendedcrafting:ultimate_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:ultimate_terminal" /> is terminal version of
<ItemLink id="extendedcrafting:ultimate_table"/>.  

## Recipes 
    <Column>
        <Row>
            <RecipeFor id="extendedterminal:basic_terminal" />
            <RecipeFor id="extendedterminal:elite_terminal" />
        </Row>
        <Row>
            <RecipeFor id="extendedterminal:advanced_terminal" />
            <RecipeFor id="extendedterminal:ultimate_terminal" />
        </Row>
    </Column>
</et:condition>
