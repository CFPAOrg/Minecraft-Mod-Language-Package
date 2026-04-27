---
navigation:
    parent: machines-blocks/machines-blocks-index.md
    title: "Layout"
    icon: "woot_revived:layout"
---
# Layout

<BlockImage id="layout" scale="5"/>

The <ItemImage id="layout" scale="0.5"/> Layout show you a blueprint of the factory

You can right-click it to change the tier of the shown factory

All block in the preview have no collision, are unbreakable, and can be replaced directly with their respective block.

## Craft

<RecipeFor id="layout" />

# Previews

<Row>
  <Column>
    ## Copper

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/copper.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## Iron

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/iron.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## Gold

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/gold.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## Diamond

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/diamond.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## Netherite

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/netherite.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>
</Row>
