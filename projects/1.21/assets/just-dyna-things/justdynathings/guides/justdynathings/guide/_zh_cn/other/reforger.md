---
navigation:
  title: 再造器
  icon: "justdynathings:reforger"
  position : 2
  parent: justdynathings:other.md
item_ids:
  - justdynathings:reforger
---

# 再造器


一台强大的机器，可消耗催化剂将方块变成新方块。

<BlockImage id="justdynathings:reforger" p:facing="up" p:active="true" scale="4.0"/>

<GameScene zoom="4" interactive={true}>

  <Block id="justdynathings:reforger" p:facing="north" p:active="true" />
  <Block z="-1" id="minecraft:stone" />

  <BoxAnnotation color="#000000" min="0.25 0.25 0.25" max="0.75 0.75 0.75">
        内部需有催化剂，如<ItemImage id="minecraft:diamond" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#000000" min="0.25 0.25 -0.25" max="0.75 0.75 -0.75">
        可变成任意有效矿石
  </BoxAnnotation>
</GameScene>

<RecipeFor id="justdynathings:reforger" />