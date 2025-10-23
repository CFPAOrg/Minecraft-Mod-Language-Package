---
navigation:
  title: 抽取节点
  icon: "synergy:item_retrieval_node"
  parent: logistics.md
  position: 3
categories:
  - logistics
item_ids:
  - synergy:item_retrieval_node
  - synergy:energy_retrieval_node
---

# 抽取节点

它与<ItemLink id="synergy:item_transfer_node" />类似，可以在多个方块间传输事物，但其工作方式与后者相反。

它会抽取其他位置的事物，并存入其所面对的容器。

<BlockImage id="synergy:item_retrieval_node" scale="4.0" p:north="false" p:south="false" p:east="false" p:west="false" p:up="false"/>

## 工作原理

它会从首个可用的容器中抽取物品，并将其存入其所面对的容器。

<GameScene zoom="4" interactive={true}>
  <Block x="4" id="minecraft:chest"/>
  <Block x="0" id="minecraft:chest"/>

  <Block x="0" y="1" id="synergy:item_retrieval_node" p:north="false" p:south="false" p:east="true" p:west="false" p:up="false" p:down="true"/>

  <Block x="3" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="2" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="1" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="4" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="false" p:west="true" p:up="false"/>

  <BoxAnnotation color="#00FF00" min="0.0 0.0 0.0" max="1.0 1.0 1.0">
       网络 -> <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#00FF00" min="4.0 0.0 0.0" max="5.0 1.0 1.0">
        <ItemImage id="minecraft:cobblestone" scale="0.75" /> -> 网络
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.39 1.39 0.39" max="0.61 1.61 0.61">
        目的
  </BoxAnnotation>

  <BoxAnnotation color="#0099FF" min="4.39 1.39 0.39" max="4.61 1.61 0.61">
        提取
  </BoxAnnotation>

  <BoxAnnotation color="#FFFF00" min="0.78 1.39 0.39" max="4.22 1.61 0.61">
        网络
  </BoxAnnotation>

</GameScene>

<RecipeFor id="synergy:item_retrieval_node" />

<Recipe id="synergy:item_retrieval_node_alt" />
