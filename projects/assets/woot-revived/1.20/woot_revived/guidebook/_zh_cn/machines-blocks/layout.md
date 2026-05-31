---
navigation:
    parent: machines-blocks/machines-blocks-index.md
    title: "结构展示器"
    icon: "woot_revived:layout"
---
# 结构展示器

<BlockImage id="layout" scale="5"/>

<ItemImage id="layout" scale="0.5"/>结构展示器可显示工厂的结构

对其右击来更改所显示的工厂等级

预览中的所有方块都无法破坏且没有碰撞箱，可被对应方块直接替换。

## 合成

<RecipeFor id="layout" />

# 预览

<Row>
  <Column>
    ## 铜

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/copper.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## 铁

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/iron.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## 金

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/gold.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## 钻石

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/diamond.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>

  <Column>
    ## 下界合金

    <GameScene zoom="2.5" interactive={true}>
        <ImportStructure src="../assets/layout/netherite.snbt" />
        <IsometricCamera yaw="195" pitch="6" />
    </GameScene>
  </Column>
</Row>
