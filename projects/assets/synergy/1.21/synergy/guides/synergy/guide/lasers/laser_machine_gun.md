---
navigation:
  title: Laser Machine Gun
  icon: "synergy:laser_machine_gun"
  parent: lasers.md
  position: 1
categories:
  - lasers
item_ids:
  - synergy:laser_machine_gun
---

# Laser Machine Gun

When powered and added a redstone signal , it will create a laser track

Right clicking with a dye can change the laser track

Right click can rotate the block

# Laser Track

### Any laser track has specific properties:

- Can cause an explosion when interact with a laser machine gun

- It will break when interact with an entity or a solid faced block

<GameScene zoom="4" interactive={true}>

  <Block z="-1" x="0" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block z="-1" x="2" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block x="0" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="2" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="1" id="minecraft:lever" p:face="floor" p:powered="true"/>
  <Block x="0" z="2" id="minecraft:stone"/>

  <BoxAnnotation color="#FF0000" min="0.5 0.25 1" max="0.5 0.25 2">
       Laser Track is blocked from a solid faced block
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="2.5 0.25 1" max="2.5 0.25 3">
       Laser Track can procede
  </BoxAnnotation>
</GameScene>

<RecipeFor id="synergy:laser_machine_gun" />
