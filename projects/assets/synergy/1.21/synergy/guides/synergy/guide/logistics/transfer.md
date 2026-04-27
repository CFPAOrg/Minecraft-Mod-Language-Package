---
navigation:
  title: Transfer Nodes
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

# Transfer Nodes

A block that allow to extract and insert things across containers

It can be extended using <ItemLink id="synergy:pipe" />

<BlockImage id="synergy:item_transfer_node" scale="4.0" p:north="false" p:south="false" p:east="false" p:west="false" p:up="false"/>

## How it work

It will extract items from any storage and insert it at the first storage path-findable without store any item

<GameScene zoom="4" interactive={true}>
  <Block x="4" id="minecraft:chest"/>
  <Block x="0" id="minecraft:chest"/>

  <Block x="4" y="1" id="synergy:item_transfer_node" p:north="false" p:south="false" p:east="false" p:west="true" p:up="false"/>

  <Block x="3" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="2" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="1" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="true" p:up="false" p:down="false"/>

  <Block x="0" y="1" id="synergy:pipe" p:north="false" p:south="false" p:east="true" p:west="false" p:up="false" p:down="true"/>

  <BoxAnnotation color="#00FF00" min="0.0 0.0 0.0" max="1.0 1.0 1.0">
       Network -> <ItemImage id="minecraft:cobblestone" scale="0.75" />
  </BoxAnnotation>

  <BoxAnnotation color="#00FF00" min="4.0 0.0 0.0" max="5.0 1.0 1.0">
        <ItemImage id="minecraft:cobblestone" scale="0.75" /> -> Network
  </BoxAnnotation>

  <BoxAnnotation color="#FF0000" min="0.39 1.39 0.39" max="0.61 1.61 0.61">
        Destination
  </BoxAnnotation>

  <BoxAnnotation color="#0099FF" min="4.39 1.39 0.39" max="4.61 1.61 0.61">
        Extraction
  </BoxAnnotation>

  <BoxAnnotation color="#FFFF00" min="0.78 1.39 0.39" max="4.22 1.61 0.61">
        Network
  </BoxAnnotation>

</GameScene>

<RecipeFor id="synergy:item_transfer_node" />

<Recipe id="synergy:item_transfer_node_alt" />

### FunFact

_I started playing modded minecraft on 1.7.10 with [ExtraUtils](https://ftbwiki.org/Extra_Utilities) loving it , now that was abandoned I want to make history repeat!_

- DevDyna
