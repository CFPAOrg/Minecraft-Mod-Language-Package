---
navigation:
  parent: example-setups/index.md
  icon: minecraft:furnace
  title: Smeltery Subnet
categories:
  - example
---

# Smeltery Subnet

Using specialized subnets is a good way to delegate responsibility in your network
and to reuse recipes.

<GameScene zoom="3" interactive={true} paddingLeft="30" paddingRight="30" paddingTop="20">
  <ImportStructure src="../assets/assemblies/roundrobin_smeltery_subnet.snbt" />
  <IsometricCamera yaw="200" pitch="20" />
  <BoxAnnotation min="0 0.75 0" max="3 1 1" color="#B02E26">
    <ItemImage id="storage_card"/> Red Storage Cards to pull finished items from the furnaces
  </BoxAnnotation>
  <BoxAnnotation min="1 3 1" max="2 3.25 2" color="#3C44AA">
    <ItemImage id="storage_card"/> Blue Storage Card for all Processing Handler input items
  </BoxAnnotation>
  <BoxAnnotation min="0 2 0" max="3 2.25 1" color="#80C71F">
    <ItemImage id="storage_card"/> Lime Storage Cards that the Import Chest round-robins items to
  </BoxAnnotation>
  <BlockAnnotation x="1" y="2" z="1">
    RoundRobin is enabled

    Channel set to <Color id="green">Lime</Color>
  </BlockAnnotation>
</GameScene>

Above is an example of a **smeltery** subnet with a <ItemLink id="processing_storage" /> block that's being broadcasted using a <ItemLink id="broadcast_antenna" />. Any
network can be connected to use its recipes using a <ItemLink id="link_crystal" />.

Then I have three <ItemLink id="processing_handler" /> devices bound to the three processing
sets in the network, all pushing their input items into the <ItemLink id="import_chest" />.
The Import Chest is set to round-robin into another channel which I've dedicated to Storage Cards
pointing at the top of the furnaces.
Then there are Red Storage Cards pointing at the bottom of the furnaces

See the [Autocrafting](../nodeworks-mechanics/autocrafting.md) page for more details.