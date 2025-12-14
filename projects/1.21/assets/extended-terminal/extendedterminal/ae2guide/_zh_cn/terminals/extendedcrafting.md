---
navigation:
  title: 拓展合成终端
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
# 拓展合成终端
<et:condition load="ExtendedCrafting">
    <Column alignItems="center" fullwidth={true}>
        <GameScene zoom={4} interactive={true}>
            <ImportStructure src="../structures/extendedcrafting.snbt" />
            <IsometricCamera yaw="225" pitch="20" />
        </GameScene>
    </Column>  

## 基础拓展合成终端
<Row>
<ItemImage id="extendedterminal:basic_terminal" scale={3}/>
<ItemImage id="extendedcrafting:basic_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:basic_terminal" />是终端版本的<ItemLink id="extendedcrafting:basic_table"/>。

## 高级拓展合成终端
<Row>
<ItemImage id="extendedterminal:advanced_terminal" scale={3}/>
<ItemImage id="extendedcrafting:advanced_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:advanced_terminal" />是终端版本的<ItemLink id="extendedcrafting:advanced_table"/>。
## 精英拓展合成终端
<Row>
<ItemImage id="extendedterminal:elite_terminal" scale={3}/>
<ItemImage id="extendedcrafting:elite_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:elite_terminal" />是终端版本的<ItemLink id="extendedcrafting:elite_table"/>。
## 终极拓展合成终端
<Row>
<ItemImage id="extendedterminal:ultimate_terminal" scale={3}/>
<ItemImage id="extendedcrafting:ultimate_table" scale={3}/>
</Row>
<ItemLink id="extendedterminal:ultimate_terminal" />是终端版本的<ItemLink id="extendedcrafting:ultimate_table"/>。  

## 配方
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
