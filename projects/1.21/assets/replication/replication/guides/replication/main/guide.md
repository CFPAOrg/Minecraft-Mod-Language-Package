---
navigation:
  title: Replication
  icon: replication:replicator
item_ids:
  - replication:replicator
  - replication:matter_network_pipe
  - replication:identification_chamber
  - replication:disintegrator
  - replication:matter_tank
  - replication:replication_terminal
  - replication:chip_storage
---

# Replication

**Replication** is a tech mod that allows you to replicate resources of similar types. You can transform dirt to stone
but you can't transform dirt to diamonds.

## Important Concepts

**Matter pipes** will allow you to connect Replication machines and they will automate some processes:

* Transfer **Power**: they work like any power pipe
* Transfer **Matter**: they will transfer matter from the **Disintegrator** to **Matter Tanks** and from **Matter Tanks
  ** to **other machines** that need it

The **Identification Chamber** will scan items to know their matter values and store them into chips. Those **Chips**
can be stored in the **Chip Storage** and will be available to the network.

**Replicators** can be used in "Infinite Mode", where they will keep replicating a resource until it is full or has run
out of matter, you can configure that mode in the GUI.

## How it works

To transform items you will need to break them down to their primal values using a **Disintegrator**. Using that machine
you will transform any item with matter values into matter. Once you have scanned some items and stored their values
into chips you can use the **Replication Terminal** to request items. With a request created **Replicators** will use
the Matter stored in tanks to replicate the item from scratch and send it back to the terminal.

<GameScene zoom="4" interactive={true}>
  <ImportStructure src="setup.snbt" />
  <IsometricCamera  yaw="30" pitch="30" />
</GameScene>

## MatterOpedia

The MatterOpedia is a searcheable list that will allow you to search what items have a specific Matter Value. You can
access using the button on the left of the Search Bar in the Replication Terminal screen, you can also access it by
clicking on the matter displays on the right of the terminal.

In the search bar of the MatterOpedia you can use:

* Any matter name: will show all the items that have that matter
* `earth>10` will show all the items that have more than 10 earth
* `nether=20` will show all the items that have exactly 20 nether
* `quantum<6` will show all the items that have less than 6 quantum
* `!earth` will show all the items that don't have earth
* `*metallic` will show all the items that only have metallic