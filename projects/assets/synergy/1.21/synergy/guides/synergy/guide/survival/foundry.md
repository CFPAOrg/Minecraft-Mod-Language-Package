---
navigation:
  title: Foundry Structure
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

# Foundry Structure

<GameScene zoom="2" interactive={true}>
  <Block x="0" y="0" z="0" id="synergy:fuel_tank"/>
  <Block x="0" y="1" z="0" id="synergy:foundry" p:facing="north" p:enabled="true"/>
  <Block x="1" y="1" z="0" id="synergy:faucet" p:facing="west"/>
  <Block x="1" y="0" z="0" id="synergy:casting_table" p:facing="north"/>
</GameScene>

A new set of blocks to melt resources into fluids and cast into other items using molds

<RecipeFor id="synergy:foundry" />
