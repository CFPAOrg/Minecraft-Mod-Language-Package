---
navigation:
    parent: epp_intro/epp_intro-index.md
    title: ME Wireless Connector
    icon: extendedae:wireless_connect
categories:
- extended devices
item_ids:
- extendedae:wireless_connect
- extendedae:wireless_tool
---

# ME Wireless Connector

<Row gap="20">
<BlockImage id="extendedae:wireless_connect" scale="6"></BlockImage>
<ItemImage id="extendedae:wireless_tool" scale="6"></ItemImage>
</Row>

ME Wireless Connector can link two networks like <ItemLink id="ae2:quantum_link" /> but with limited distances and can't 
cross dimensions.

## Link the Wireless Connectors

Click the two Wireless Connectors that you want to link with the ME Wireless Setup Kit, then you can link them together.

Sneak + Click to clear ME Wireless Setup Kit's current setting.

ME Wireless Connector will change its texture when a link is successfully established.

Unlinked ME Wireless Connectors

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_off.snbt"></ImportStructure>
</GameScene>

Linked ME Wireless Connectors

<GameScene zoom="5" background="transparent">
  <ImportStructure src="../structure/wireless_connector_on.snbt"></ImportStructure>
</GameScene>

## Color

Wireless Connectors can be colored like cables and only connect the cable/connectors with the same color.

You need a <ItemLink id="ae2:color_applicator" /> to color the connector.

So you can set up your wireless connectors like this:

<GameScene zoom="3" background="transparent" interactive={true}>
  <ImportStructure src="../structure/wireless_connector_setup.snbt"></ImportStructure>
</GameScene>

## Power Usage

ME Wireless Connector costs more energy when they are farther apart. Its cost-distance curve isn't linear so the power 
cost can get very high if when they are too far apart.

You can use <ItemLink id="ae2:energy_card" /> to save power, every card can reduce 10% energy cost.

