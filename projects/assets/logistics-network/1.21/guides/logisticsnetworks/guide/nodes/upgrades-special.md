---
item_ids: [logisticsnetworks:dimensional_upgrade, logisticsnetworks:mekanism_chemical_upgrade, logisticsnetworks:ars_source_upgrade]
navigation:
  title: Special Upgrades
  parent: nodes/index.md
  icon: logisticsnetworks:dimensional_upgrade
  position: 5
---

# Special Upgrades

Special upgrades do not change a node's throughput caps. They unlock **new capabilities** — cross-dimension transfers, Mekanism chemicals, Ars Nouveau source. Each one sits in an upgrade slot and can be combined with a [performance upgrade](upgrades-performance.md) on the same node.

Upgrade slots are on the [Filters & Upgrades](filters-upgrades.md) panel. Duplicates are rejected, but different upgrades stack fine — a typical high-end node might hold one Netherite + one Dimensional + one Mekanism Chemical + one Ars Source.

## Dimensional Upgrade

**Unlocks cross-dimension transfers.** Without this upgrade, a node can only talk to nodes in the same dimension. Install the Dimensional Upgrade and the node can transfer to and from nodes in other dimensions — between the Overworld and the Nether, the End and the Overworld, or any modded dimension.

**Both ends must have it.** Both the Sender node and the Receiver node need a Dimensional Upgrade installed. Installing it on only one side is not enough — the engine checks both nodes before allowing a cross-dimension hop.

Inside the same dimension the upgrade does nothing extra — normal transfers work without it.

<RecipeFor id="logisticsnetworks:dimensional_upgrade" />

## Mekanism Chemical Upgrade

**Unlocks the Chemical channel type.** Without this upgrade, the Type setting in [Channel Settings](channel-settings.md) cannot be set to Chemical on the node. Installed, the node can sense and transfer Mekanism chemicals (gases, infuse types, pigments, slurries) through any channel whose Type is set to Chemical.

The upgrade only matters on the node where the channel is configured. A Chemical Sender needs the upgrade; a Chemical Receiver also needs the upgrade on its own node. Nodes that do not move chemicals do not need it.

Requires the **Mekanism** mod to be installed to both craft and use. The recipe below only appears when Mekanism is loaded.

<RecipeFor id="logisticsnetworks:mekanism_chemical_upgrade" fallbackText="Install Mekanism to unlock this recipe." />

## Ars Source Upgrade

**Unlocks the Source channel type.** Same pattern as the Mekanism Chemical Upgrade, but for Ars Nouveau source. Installed, the node can set a channel's Type to Source and move source between Ars Nouveau source jars and any other source-compatible block.

Each node that moves source (Sender or Receiver) needs its own Ars Source Upgrade.

Requires the **Ars Nouveau** mod to be installed to both craft and use. The recipe below only appears when Ars Nouveau is loaded.

<RecipeFor id="logisticsnetworks:ars_source_upgrade" fallbackText="Install Ars Nouveau to unlock this recipe." />
