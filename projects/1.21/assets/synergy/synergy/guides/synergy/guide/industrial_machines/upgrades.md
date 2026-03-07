---
navigation:
  title: Machine Upgrades
  icon: "synergy:upgrade_speed"
  parent: industrial_machines.md
  position: 2
categories:
  - machines
item_ids:
  - synergy:speed_upgrade
  - synergy:energy_upgrade
  - synergy:luck_upgrade
  - synergy:fluid_upgrade
---

# Machine Upgrades

<GameScene zoom={4} interactive={true}>
    <Entity x="-1" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:speed_upgrade'}}" />
    <Entity x="0" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:energy_upgrade'}}" />
    <Entity x="1" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:luck_upgrade'}}" />
    <Entity x="2" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:fluid_upgrade'}}" />
</GameScene>

A new set of items that allow to improve any industrial machine stats

Every modifier stored inside any upgrade can be customized IN-WORLD editing the related item component

<RecipeFor id="synergy:speed_upgrade" />
<RecipeFor id="synergy:energy_upgrade" />
<RecipeFor id="synergy:luck_upgrade" />
<RecipeFor id="synergy:fluid_upgrade" />

