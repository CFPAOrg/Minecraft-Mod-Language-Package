---
navigation:
  title: Reforger
  icon: "justdynathings:reforger"
  position : 2
  parent: justdynathings:other.md
item_ids:
  - justdynathings:reforger
---

# Reforger


A powerful machine that allow to convert blocks into other at the cost of a catalyst

<BlockImage id="justdynathings:reforger" p:facing="up" p:active="true" scale="4.0"/>

<GameScene zoom="4" interactive={true}>

  <Block id="justdynathings:reforger" p:facing="north" p:active="true" />
  <Block z="-1" id="minecraft:stone" />

  <BoxAnnotation color="#000000" min="0.25 0.25 0.25" max="0.75 0.75 0.75">
        Require a catalyst inside like <ItemImage id="minecraft:diamond" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#000000" min="0.25 0.25 -0.25" max="0.75 0.75 -0.75">
        Can be converted into any valid ores
  </BoxAnnotation>
</GameScene>

<RecipeFor id="justdynathings:reforger" />