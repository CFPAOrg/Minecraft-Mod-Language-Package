---
item_ids: [logisticsnetworks:dimensional_upgrade, logisticsnetworks:mekanism_chemical_upgrade, logisticsnetworks:ars_source_upgrade]
navigation:
  title: Special Upgrades
  parent: nodes/index.md
  icon: logisticsnetworks:dimensional_upgrade
  position: 5
---

# Special Upgrades

Special upgrades do not change a node's throughput caps. The Dimensional Upgrade unlocks cross-dimension transfers and can be combined with a [performance upgrade](upgrades-performance.md) on the same node. The Chemical and Source upgrade items are retained for future compatibility but are currently inactive.

Upgrade slots are on the [Filters & Upgrades](filters-upgrades.md) panel. Duplicates are rejected, but different active upgrades can share the four slots.

## Dimensional Upgrade

**Unlocks cross-dimension transfers.** Without this upgrade, a node can only talk to nodes in the same dimension. Install the Dimensional Upgrade and the node can transfer to and from nodes in other dimensions — between the Overworld and the Nether, the End and the Overworld, or any modded dimension.

**Both ends must have it.** Both the Sender node and the Receiver node need a Dimensional Upgrade installed. Installing it on only one side is not enough — the engine checks both nodes before allowing a cross-dimension hop.

Inside the same dimension the upgrade does nothing extra — normal transfers work without it.

<RecipeFor id="logisticsnetworks:dimensional_upgrade" />

## Mekanism Chemical Upgrade

This item is retained for future compatibility. It does not currently unlock Chemical channels or transfers. Its recipe appears only when Mekanism is loaded.

<RecipeFor id="logisticsnetworks:mekanism_chemical_upgrade" fallbackText="Install Mekanism to unlock this recipe." />

## Ars Source Upgrade

This item is retained for future compatibility. It does not currently unlock Source channels or transfers. Its recipe appears only when Ars Nouveau is loaded.

<RecipeFor id="logisticsnetworks:ars_source_upgrade" fallbackText="Install Ars Nouveau to unlock this recipe." />
