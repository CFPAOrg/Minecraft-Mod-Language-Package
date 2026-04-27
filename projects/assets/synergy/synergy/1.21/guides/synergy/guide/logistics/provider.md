---
navigation:
  title: Provider Nodes
  icon: "synergy:item_provider_node"
  parent: logistics.md
  position: 2
categories:
  - logistics
item_ids:
  - synergy:item_provider_node
  - synergy:fluid_provider_node
---

# Provider Nodes

A block that allow to generate resorces based on block patterns

It can be extended the result output using <ItemLink id="synergy:pipe" />

<BlockImage id="synergy:item_provider_node" scale="4.0" p:north="false" p:south="false" p:east="false" p:west="false" p:up="false"/>

## Example #1 : Cobblestone gen

A simple example of how to generate cobblestone

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

## Example #2 : Basalt gen

A simple example of how to generate basalt

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

## Example #3 : Mixed gen

On this example there is a broken basalt gen with other blocks that maybe will hide a cobblestone gen

It can find <ItemImage id="minecraft:lava_bucket" scale="0.75" /> and <ItemImage id="minecraft:soul_soil" scale="0.75" /> but cannot find <ItemImage id="minecraft:basalt" scale="0.75" /> and <ItemImage id="minecraft:blue_ice" scale="0.75" /> so it still incomplete

However it has found <ItemImage id="minecraft:water_bucket" scale="0.75" /> and <ItemImage id="minecraft:cobblestone" scale="0.75" /> so it will produce <ItemImage id="minecraft:cobblestone" scale="0.75" />

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

<RecipeFor id="synergy:item_provider_node" />

<Recipe id="synergy:item_provider_node_alt" />
