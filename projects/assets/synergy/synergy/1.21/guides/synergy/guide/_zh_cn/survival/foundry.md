---
navigation:
  title: 熔炼炉结构
  icon: "synergy:foundry"
  parent: survival.md
  position: 1
categories:
  - survival
item_ids:
  - synergy:foundry
  - synergy:fuel_tank
  - synergy:faucet
  - synergy:casting_table
---

# 熔炼炉结构

<GameScene zoom="2" interactive={true}>
  <Block x="0" y="0" z="0" id="synergy:fuel_tank"/>
  <Block x="0" y="1" z="0" id="synergy:foundry" p:facing="north" p:enabled="true"/>
  <Block x="1" y="1" z="0" id="synergy:faucet" p:facing="west"/>
  <Block x="1" y="0" z="0" id="synergy:casting_table" p:facing="north"/>
</GameScene>

一套全新的方块，可将资源熔炼为流体，而后可通过模具将流体浇铸成其他物品。

<RecipeFor id="synergy:foundry" />
