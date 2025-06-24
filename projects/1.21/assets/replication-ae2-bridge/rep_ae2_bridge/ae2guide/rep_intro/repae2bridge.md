---
navigation:
    parent: rep_intro/rep_intro-index.md
    title: ME-Replication Bridge
    icon: rep_ae2_bridge:rep_ae2_bridge
categories:
- rep_bridge_components
item_ids:
- rep_ae2_bridge:rep_ae2_bridge
---

# ME-Replication Bridge

<Row gap="20">
<BlockImage id="rep_ae2_bridge:rep_ae2_bridge" scale="8"></BlockImage>
</Row>

The RepAE2Bridge is a component that connects the AE2 ME system with the Replication matter network.

## Features

The bridge acts as a translator between the two systems, allowing Replication matter data to be accessible within the AE2 ME system and vice versa.

This enables you to:
- View matter quantities in the Replication network
- Request replications through AE2's autocrafting system

## Placing

To place the bridge, follow these steps:

1. Place the RepAE2Bridge block at a point that can reach both networks
2. Connect an AE2 ME cable to one side of the block
3. Connect a Replication matter pipe to another side of the block

## Optimal Setup

* Use only one Replication network
* By default, the bridge can handle ~20 replicators simultaneously
* To support a larger number of replicators, use a crafting CPU with a high number of Crafting Co-processing Units 