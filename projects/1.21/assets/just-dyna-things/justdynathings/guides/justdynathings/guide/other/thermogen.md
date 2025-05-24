---
navigation:
  title: Thermo Generator
  icon: "justdynathings:thermo_generator"
  position: 6
  parent: justdynathings:other.md
item_ids:
  - justdynathings:thermo_generator
---

# The Power of Earth

Only Heated FE rate : **270 FE/t**
Heated & Cooled FE rate : **1620 FE/t**

A new generator that generate Forge Energy based on a heat source block and a fluid coolant (optional to provide a multiplier)

<BlockImage id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:thermo_cooled="false" p:thermo_heated="false"/>

<GameScene zoom="4" interactive={true}>
  <Block id="minecraft:magma_block"/>
  <Block y="1" id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block y="-1" id="justdynathings:thermo_generator" scale="4.0" p:facing="up" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block x="1" id="justdynathings:thermo_generator" scale="4.0" p:facing="west" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block x="-1" id="justdynathings:thermo_generator" scale="4.0" p:facing="east" p:thermo_cooled="false" p:thermo_heated="true"/>

  <BoxAnnotation color="#00FF00" min="0.25 -0.75 0.25" max="0.75 -1 0.75">
        Yes , you can place upsidedown and it work!
  </BoxAnnotation>

</GameScene>

<RecipeFor id="justdynathings:thermo_generator" />
