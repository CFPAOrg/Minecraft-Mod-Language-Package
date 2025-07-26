---
navigation:
  parent: appliede-index.md
  title: Transmutation Devices
  icon: emc_interface
  position: 10
categories:
  - appliede
item_ids:
  - appliede:emc_interface
  - appliede:cable_emc_interface
  - appliede:emc_export_bus
  - appliede:emc_import_bus
  - appliede:learning_card
---

# Transmutation Devices

<GameScene zoom="4" background="transparent">
  <ImportStructure src="assemblies/transmutation_devices.snbt" />
  <IsometricCamera yaw="195" pitch="30" />
</GameScene>

As a complement to the existing AE2 <ItemLink id="ae2:interface" />, <ItemLink id="ae2:export_bus" /> and
<ItemLink id="ae2:import_bus" />, AppliedE offers its own counterparts to all these devices which function almost
identically to the native AE2 devices and still work with regular items. The key difference, however, is that the items
are all transmuted to or from EMC during every operation.

While each device can be filtered to any item, they will only be able to perform their respective function on items
which have been learned by at least one player tracked by a
<ItemLink id="appliede:emc_module">Transmutation Module</ItemLink> on the network. In the case of the
<ItemLink id="appliede:emc_interface" />, items also will not be accepted into its internal storage to be converted and
sent to EMC storage unless they have been learned and are known to the network in advance. Likewise, the
<ItemLink id="appliede:emc_import_bus" /> will not pull in any items which are unlearned.

## Alchemical Mastery Card

<ItemImage id="learning_card" scale="4" />

However, it would quickly become a chore for the user to have to learn every item in advance before it can be
automatically pulled into an ME system to be turned into EMC. For this reason, the
<ItemLink id="appliede:learning_card" /> can be installed into either the <ItemLink id="appliede:emc_interface" /> or
<ItemLink id="appliede:emc_import_bus" /> for these to automatically learn the items coming in, provided that they have
an EMC value in general.

Note, however, that these items will only be learned by the owner of the device itself, i.e. the player who placed down
the import bus, the interface or the network device sending items into the interface.

## Recipes

<RecipeFor id="appliede:emc_interface" />
<RecipeFor id="appliede:emc_export_bus" />
<RecipeFor id="appliede:emc_import_bus" />
<RecipeFor id="appliede:learning_card" />
