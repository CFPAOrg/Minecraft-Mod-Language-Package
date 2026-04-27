---
navigation:
  title: Laser Mirror
  icon: "synergy:laser_mirror"
  parent: lasers.md
  position: 3
categories:
  - lasers
item_ids:
  - synergy:laser_mirror
---

# Laser Mirror

Rotate of 90° any laser tracks

Right click or using a redstone signal can invert the direction

<GameScene zoom="4" interactive={true}>

  <Block z="-1" x="0" id="synergy:solar_panel" p:north="false" p:south="false" p:east="false" p:west="false" p:enabled="true"/>

  <Block x="0" id="synergy:laser_machine_gun" p:facing="south" p:enabled="true"/>

  <Block x="1" id="minecraft:lever" p:face="floor" p:powered="true"/>
  <Block x="0" z="2" id="synergy:laser_mirror" p:inverted="false"/>

  <BoxAnnotation color="#FF0000" min="0.5 0.25 1" max="0.5 0.25 2.5">
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.5 0.25 2.5" max="2.5 0.25 2.5">
       Laser Track is rotated
  </BoxAnnotation>

</GameScene>

<RecipeFor id="synergy:laser_mirror" />
