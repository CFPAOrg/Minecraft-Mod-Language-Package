---
navigation:
  title: Re:Avaritia Crafting Terminal
  icon: avaritia:extreme_crafting_table
  parent: index.md
  position: 020
categories:
  - extendedterminal
item_ids:
  - sculk_terminal
  - nether_terminal
  - end_terminal
  - extreme_terminal
---

# Re:Avaritia Crafting Terminal

<et:condition load="ReAvaritia">


<GameScene zoom={4} interactive={true}>
    <ImportStructure src="../structures/reavaritia.snbt" />
    <IsometricCamera yaw="225" pitch="20" />
</GameScene>

## Sculk Crafting Terminal

<Row>
<ItemImage id="extendedterminal:sculk_terminal" scale={3}/>
<ItemImage id="avaritia:sculk_crafting_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:sculk_terminal" /> is terminal version of <ItemLink
    id="avaritia:sculk_crafting_table"/>.
## Nether Crafting Terminal
<Row>
<ItemImage id="extendedterminal:nether_terminal" scale={3}/>
<ItemImage id="avaritia:nether_crafting_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:nether_terminal" /> is terminal version of <ItemLink
    id="avaritia:nether_crafting_table"/>.
## End Crafting Terminal
<Row>
<ItemImage id="extendedterminal:end_terminal" scale={3}/>
<ItemImage id="avaritia:end_crafting_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:end_terminal" /> is terminal version of <ItemLink
    id="avaritia:end_crafting_table"/>.
## Extreme Crafting Terminal
<Row>
<ItemImage id="extendedterminal:extreme_terminal" scale={3}/>
<ItemImage id="avaritia:extreme_crafting_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:extreme_terminal" /> is terminal version of <ItemLink
    id="avaritia:extreme_crafting_table"/>.

## Recipes

<Column>
    <Row>
        <RecipeFor id="extendedterminal:sculk_terminal" />
        <RecipeFor id="extendedterminal:end_terminal" />
    </Row>
    <Row>
        <RecipeFor id="extendedterminal:nether_terminal" />
        <RecipeFor id="extendedterminal:extreme_terminal" />
    </Row>
</Column>

</et:condition>