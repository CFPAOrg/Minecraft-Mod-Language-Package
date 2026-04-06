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

The RepAE2Bridge is a component that connects the AE2 ME system with the Replication matter network, providing seamless integration between the two systems.

## Features

The bridge acts as a translator between the two systems, allowing Replication matter data to be accessible within the AE2 ME system and vice versa.

This enables you to:
- View matter quantities in the Replication network through AE2 terminals
- Request replications through AE2's autocrafting system
- Configure crafting priorities for optimal resource management

## Placing

To place the bridge, follow these steps:

1. Place the RepAE2Bridge block at a point that can reach both networks
2. Connect an AE2 ME cable to one side of the block
3. Connect a Replication matter pipe to another side of the block

## Priority Configuration

The bridge includes a priority system that allows you to control the order in which crafting requests are processed. This is especially useful when you have multiple bridges or want to prioritize certain types of items.

### Accessing the Priority GUI

1. **Right-click** on the bridge block to open the priority configuration interface
2. Enter a priority value in the number field
3. The value can range from -2,147,483,648 to +2,147,483,647
4. Higher priority values are processed first
5. Lower priority values are processed later

### Priority Guidelines

- **Positive values (1-1000)**: High priority, processed early
- **Zero (0)**: Default priority, normal processing order
- **Negative values (-1 to -1000)**: Low priority, processed later

### Use Cases

- **Production Bridges**: Set high priority (100-500) for bridges that handle critical production items
- **Backup Bridges**: Set low priority (-100 to -500) for bridges that provide backup crafting capacity
- **Experimental Items**: Set very low priority (-1000+) for testing or experimental crafting

## Optimal Setup

* Use only one Replication network per bridge
* By default, the bridge can handle ~20 replicators simultaneously
* To support a larger number of replicators, use a crafting CPU with a high number of Crafting Co-processing Units
* Configure priorities based on your production needs and resource availability 