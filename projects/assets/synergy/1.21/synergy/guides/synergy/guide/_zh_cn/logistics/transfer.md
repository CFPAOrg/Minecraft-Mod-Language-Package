---
navigation:
  title: 传输节点
  icon: "synergy:item_transfer_node"
  parent: logistics.md
  position: 1
categories:
  - logistics
item_ids:
  - synergy:item_transfer_node
  - synergy:energy_transfer_node
  - synergy:fluid_transfer_node
---

# 传输节点

可在多个容器间抽取和存入事物的方块。

可用<ItemLink id="synergy:pipe" />延展。

<BlockImage id="synergy:item_transfer_node" scale="4.0" p:north="false" p:south="false" p:east="false" p:west="false" p:up="false"/>

## 工作原理

它会从任意容器中抽取物品，并将其存入首个可寻路得到的容器，中途不会暂存物品。

<GameScene zoom="4" interactive={true}>
  <Block x="4" id="minecraft:chest"/>
  <Block x="0" id="minecraft:chest"/>

  <Block x="4" y="1" id="synergy:item_transfer_node" p:north="false" p:south="false" p:east="false" p:west="true" p:up="false"/>

  <Block x="3" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="2" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="1" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="0" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="false" p:up="false" p:down="true"/>

  <BoxAnnotation color="#00FF00" min="0.0 0.0 0.0" max="1.0 1.0 1.0">
       网络 -> <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#00FF00" min="4.0 0.0 0.0" max="5.0 1.0 1.0">
        <ItemImage id="minecraft:cobblestone" scale="0.75" /> -> 网络
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.39 1.39 0.39" max="0.61 1.61 0.61">
        目的点
  </BoxAnnotation>

  <BoxAnnotation color="#0099FF" min="4.39 1.39 0.39" max="4.61 1.61 0.61">
        提取点
  </BoxAnnotation>

  <BoxAnnotation color="#FFFF00" min="0.78 1.39 0.39" max="4.22 1.61 0.61">
        网络
  </BoxAnnotation>

</GameScene>

<RecipeFor id="synergy:item_transfer_node" />

<Recipe id="synergy:item_transfer_node_alt" />

### 有趣的事实

_我刚开始玩模组Minecraft是在1.7.10，装了[ExtraUtils](https://ftbwiki.org/Extra_Utilities)，很喜欢。这个模组现在已经无人维护，所以我想让旧版本的东西在新版本重现！_

——DevDyna
