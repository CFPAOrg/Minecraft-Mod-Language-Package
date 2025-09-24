---
navigation:
  title: 物品供应节点
  icon: "synergy:item_provider_node"
  parent: pipes.md
  position: 2
categories:
  - pipes
item_ids:
  - synergy:item_provider_node
---

# 物品供应节点

能根据方块排布方式生成资源的方块。

可用<ItemLink id="synergy:pipe" />延展产物输出位置。

<BlockImage id="synergy:item_provider_node" scale="4.0" p:north="false" p:south="false" p:east="false" p:west="false" p:up="false"/>

<RecipeFor id="synergy:item_provider_node" />

<Recipe id="synergy:item_provider_node_alt" />

## 示例#1：圆石生成设施

圆石生成设施的简单示例。

<GameScene zoom="4" interactive={true}>
  <Block x="-1" id="minecraft:water"/>
  <Block x="0" id="minecraft:cobblestone"/>
  <Block x="1" id="minecraft:lava"/>
  <Block x="0" y="1" id="synergy:item_provider_node" p:north="false" p:south="false" p:east="false" p:west="false"/>
  <Block x="0" y="2" id="minecraft:chest"/>

  <BoxAnnotation color="#00FF00" min="0.0 2.0 0.0" max="1.0 3.0 1.0">
        <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#F0F0F0" min="-1.0 0.0 -1.0" max="2.0 1.0 2.0">
       <ItemImage id="minecraft:lava_bucket" scale="0.75" /> + <ItemImage id="minecraft:water_bucket" scale="0.75" /> -> <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

</GameScene>

## 示例#2：玄武岩生成设施

玄武岩生成设施的简单示例。

<GameScene zoom="4" interactive={true}>
  <Block x="-1" id="minecraft:blue_ice"/>
  <Block x="0" id="minecraft:basalt"/>
  <Block x="0" y="-1" id="minecraft:soul_soil"/>
  <Block x="1" id="minecraft:lava"/>
  <Block x="0" y="1" id="synergy:item_provider_node" p:north="false" p:south="false" p:east="false" p:west="false"/>
  <Block x="0" y="2" id="minecraft:chest"/>

  <BoxAnnotation color="#00FF00" min="0.0 2.0 0.0" max="1.0 3.0 1.0">
        <ItemImage id="minecraft:basalt" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.0 -1.0 0.0" max="1.0 0.0 1.0">
       <ItemImage id="minecraft:soul_soil" scale="0.75" /> -> <ItemImage id="minecraft:basalt" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#F0F0F0" min="-1.0 0.0 -1.0" max="2.0 1.0 2.0">
       <ItemImage id="minecraft:lava_bucket" scale="0.75" /> + <ItemImage id="minecraft:blue_ice" scale="0.75" /> ->  <ItemImage id="minecraft:basalt" scale="0.75" />
  </BoxAnnotation>

</GameScene>

## 示例#3：杂糅的生成设施

此例中的玄武岩生成设施残缺，且存在可能组成圆石生成设施的其他方块。

存在 <ItemImage id="minecraft:lava_bucket" scale="0.75" /> 和 <ItemImage id="minecraft:soul_soil" scale="0.75" /> 但找不到 <ItemImage id="minecraft:basalt" scale="0.75" /> 或 <ItemImage id="minecraft:blue_ice" scale="0.75" />，设施残缺。

但同时也存在 <ItemImage id="minecraft:water_bucket" scale="0.75" /> 和 <ItemImage id="minecraft:cobblestone" scale="0.75" />，因此实际会生成 <ItemImage id="minecraft:cobblestone" scale="0.75" />。

<GameScene zoom="4" interactive={true}>
  <Block x="-1" id="minecraft:water"/>
  <Block x="0" id="minecraft:cobblestone"/>
  <Block x="0" y="-1" id="minecraft:soul_soil"/>
  <Block x="1" id="minecraft:lava"/>
  <Block x="0" y="1" id="synergy:item_provider_node" p:north="false" p:south="false" p:east="false" p:west="false"/>
  <Block x="0" y="2" id="minecraft:chest"/>

  <BoxAnnotation color="#00FF00" min="0.0 2.0 0.0" max="1.0 3.0 1.0">
        <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.0 -1.0 0.0" max="1.0 0.0 1.0">
       <ItemImage id="minecraft:soul_soil" scale="0.75" /> -> <ItemImage id="minecraft:basalt" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#F0F0F0" min="-1.0 0.0 -1.0" max="2.0 1.0 2.0">
       <ItemImage id="minecraft:lava_bucket" scale="0.75" /> + <ItemImage id="minecraft:water_bucket" scale="0.75" /> -> <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

</GameScene>
