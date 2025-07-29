---
item_ids: 
- schematicenergistics:cannon_interface
- schematicenergistics:cannon_interface_part
---

# Cannon Interface

A block that allows the Schematic Cannon from Create mod to connect to AE2 storage and autocraft.

<GameScene zoom="2" background="transparent" interactive={false}>
    <Block id="schematicenergistics:cannon_interface" />
</GameScene>

## Usage
Place it next to a Schematic Cannon and connect it to an AE2 network. It will allow the cannon to access items from the network.
Only one Cannon Interface can be connected to a Schematic Cannon at a time.

<GameScene zoom="2" background="transparent" interactive={true}>
  <ImportStructure src="./structure/example.snbt"></ImportStructure>
</GameScene>

The Cannon will ALWAYS priotize items from other inventories before accessing the AE2 network. This means that items from chest, barrels, etc, will be used first.

The Cannon Interface will also export gunpowder from the AE2 network to the Schematic Cannon, if it is connected to the network.

## Recipe

<Recipe id="cannon_interface" />
<Recipe id="cannon_interface_to_part" />
