---
item_ids: [logisticsnetworks:iron_upgrade, logisticsnetworks:gold_upgrade, logisticsnetworks:diamond_upgrade, logisticsnetworks:netherite_upgrade]
navigation:
  title: Performance Upgrades
  parent: nodes/index.md
  icon: logisticsnetworks:diamond_upgrade
  position: 4
---

# Performance Upgrades

Performance upgrades raise a node's **batch caps** (how much can move per transfer operation) and lower its **minimum delay** (how often it can fire). Every channel on the node benefits — upgrades are per-node, not per-channel.

Install an upgrade in any of the 4 upgrade slots in the [Filters & Upgrades](filters-upgrades.md) panel. Duplicates are rejected.

## Only the highest tier counts

A node picks its effective **tier** as the **highest** upgrade installed:

| Tier | Upgrade |
|------|---------|
| 1 | Iron |
| 2 | Gold |
| 3 | Diamond |
| 4 | Netherite |

If you install Iron + Gold + Diamond all at once, the node uses the **Diamond** caps. The Iron and Gold upgrades sit idle — they do not stack. Fill the other slots with [special upgrades](upgrades-special.md) instead (Dimensional, Mekanism Chemical, Ars Source) to get more mileage out of the extra slots.

## Tier Comparison

| Tier | Item batch | Fluid batch | Energy batch | Min delay |
|------|------------|-------------|--------------|-----------|
| **No upgrade** | configured value | configured value | configured value | configured value |
| **Iron** | 16 items | 1,000 mB | 10,000 RF | 10 ticks |
| **Gold** | 32 items | 5,000 mB | 50,000 RF | 5 ticks |
| **Diamond** | 64 items | 20,000 mB | 250,000 RF | 1 tick |
| **Netherite** | 10,000 items | 1,000,000 mB | Unlimited | 1 tick |

The values in the table are the **ceilings**. A channel's Batch and Delay in the [Channel Settings](channel-settings.md) panel are clamped to these ceilings — you can type 100,000 into a Batch field, but an Iron-tier node will only use 16. Upgrade the node to raise the ceiling.

All four tier caps come from the mod's server config (`UpgradeLimitsConfig`), so a server admin can tune these numbers. If your setup behaves differently from the table above, check the config.

## Iron Upgrade

Entry-level. Gets a node out of its un-upgraded floor and into useful territory for small setups.

<RecipeFor id="logisticsnetworks:iron_upgrade" />

## Gold Upgrade

Mid-tier. Doubles Iron's item cap and bumps fluid + energy throughput by 5x.

<RecipeFor id="logisticsnetworks:gold_upgrade" />

## Diamond Upgrade

High-tier. Full-stack item transfers (64 per op), hits 1-tick min delay so channels can fire every tick.

<RecipeFor id="logisticsnetworks:diamond_upgrade" />

## Netherite Upgrade

Maximum performance. Item batches of 10,000, million-mB fluid batches, unlimited energy per op. Use on the heavy-hitting nodes on your network — hub chests, main fluid distributor, big power buffers.

<RecipeFor id="logisticsnetworks:netherite_upgrade" />
