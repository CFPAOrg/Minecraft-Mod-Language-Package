---
navigation:
  title: 机器升级
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

# 机器升级

<GameScene zoom={4} interactive={true}>
    <Entity x="-1" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:speed_upgrade'}}" />
    <Entity x="0" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:energy_upgrade'}}" />
    <Entity x="1" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:luck_upgrade'}}" />
    <Entity x="2" y="0" z="0" id="minecraft:item" data="{Item:{count: 1, id: 'synergy:fluid_upgrade'}}" />
</GameScene>

一系列用于增强工业机器属性的物品。

修改相应物品组件即可自定义升级提供的属性，此操作可在世界中完成。

<RecipeFor id="synergy:speed_upgrade" />
<RecipeFor id="synergy:energy_upgrade" />
<RecipeFor id="synergy:luck_upgrade" />
<RecipeFor id="synergy:fluid_upgrade" />

