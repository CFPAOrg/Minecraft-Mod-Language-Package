---
item_ids: [logisticsnetworks:small_filter]
navigation:
  title: Small Filter
  parent: filters/index.md
  icon: logisticsnetworks:small_filter
  position: 1
---

# Small Filter

The entry-level filter. Matches **exact items or fluids** against a list of up to **9 entries**.

## What It Matches

Any resource whose item id or fluid id is in the filter's entry list. Matching is exact — no tags, no mod-wide wildcards, no name patterns. If the thing in the entry slot is iron ingot, only iron ingot matches.

## Entry Slots

- **9 slots** (3x3 grid inside the filter menu).
- Right-click the filter while holding it in hand to open the menu.
- Put any item or fluid bucket into an entry slot to add it to the list. Remove it to take it off the list.
- Empty entry slots are ignored. A filter with zero entries matches nothing in Whitelist mode and everything in Blacklist mode.

Each entry has a hidden **Detail** page with per-entry options — match by tag, override batch size, set a stock threshold, add NBT rules, restrict to specific inventory slots. See [Advanced Filtering](advanced-filtering.md).

## Whitelist vs Blacklist

- **Whitelist** — only the 9 listed entries are allowed to move through this channel.
- **Blacklist** — everything **except** the 9 listed entries is allowed.

Toggle the mode inside the filter menu. The item's tooltip shows the current mode at a glance.

## Use Cases

- Restrict a chest's export channel to a specific set of ingots.
- Block a few known junk items from entering your storage network while letting everything else through (Blacklist).

## Crafting Recipe

<RecipeFor id="logisticsnetworks:small_filter" />
