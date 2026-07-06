---
item_ids: [logisticsnetworks:big_filter]
navigation:
  title: Big Filter
  parent: filters/index.md
  icon: logisticsnetworks:big_filter
  position: 3
---

# Big Filter

The largest exact-match filter. Same behavior as the [Small Filter](small.md), expanded to **27 entry slots**.

## What It Matches

Any resource whose item id or fluid id is in the filter's entry list. Matching is exact.

## Entry Slots

- **27 slots** (3x9 grid inside the filter menu — one full double-chest row's worth of entries).
- Right-click the filter in-hand to open the menu.
- Empty slots are ignored.

Each entry has a hidden **Detail** page with per-entry options — see [Advanced Filtering](advanced-filtering.md).

## Whitelist vs Blacklist

- **Whitelist** — only the listed entries are allowed through.
- **Blacklist** — everything except the listed entries is allowed.

## Use Cases

- One big explicit whitelist of every building block you want sent to a builder's chest.
- A single-channel setup that needs to name-check a large batch of crafting ingredients.

## Crafting Recipe

<RecipeFor id="logisticsnetworks:big_filter" />
