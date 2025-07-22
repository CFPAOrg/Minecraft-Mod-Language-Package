---
navigation:
  title: 热力发电器
  icon: "justdynathings:thermo_generator"
  position: 6
  parent: justdynathings:other.md
item_ids:
  - justdynathings:thermo_generator
---

# 大地的力量

仅加热时FE生产速率：**270 FE/t**
加热和冷却时FE生产速率：**1620 FE/t**

一种全新的发电器，会根据热源和流体冷却剂（可选，用于增加产量）生成Forge能量（Forge Energy）。

<BlockImage id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:thermo_cooled="false" p:thermo_heated="false"/>

<GameScene zoom="4" interactive={true}>
  <Block id="minecraft:magma_block"/>
  <Block y="1" id="justdynathings:thermo_generator" scale="4.0" p:facing="down" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block y="-1" id="justdynathings:thermo_generator" scale="4.0" p:facing="up" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block x="1" id="justdynathings:thermo_generator" scale="4.0" p:facing="west" p:thermo_cooled="false" p:thermo_heated="true"/>

  <Block x="-1" id="justdynathings:thermo_generator" scale="4.0" p:facing="east" p:thermo_cooled="false" p:thermo_heated="true"/>

  <BoxAnnotation color="#00FF00" min="0.25 -0.75 0.25" max="0.75 -1 0.75">
        对头，倒过来也能用！
  </BoxAnnotation>

</GameScene>

<RecipeFor id="justdynathings:thermo_generator" />
