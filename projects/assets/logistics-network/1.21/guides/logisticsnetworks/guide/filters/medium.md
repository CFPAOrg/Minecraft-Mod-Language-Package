---
item_ids: [logisticsnetworks:medium_filter]
navigation:
  title: Medium Filter
  parent: filters/index.md
  icon: logisticsnetworks:medium_filter
  position: 2
---

# Medium Filter

Same exact-match behavior as the [Small Filter](small.md), just with more room: **18 entry slots** instead of 9.

## What It Matches

Any resource whose item id or fluid id is in the filter's entry list. Matching is exact.

## Entry Slots

- **18 slots** (arranged as a 3x6 grid inside the filter menu).
- Right-click the filter in-hand to open the menu.
- Empty slots are ignored.

Each entry has a hidden **Detail** page with per-entry options — see [Advanced Filtering](advanced-filtering.md).

## Whitelist vs Blacklist

- **Whitelist** — only the listed entries are allowed through.
- **Blacklist** — everything except the listed entries is allowed.

## Use Cases

- Route all common ores (coal, iron, gold, copper, diamond, emerald, redstone, lapis — plus their deepslate variants) through one channel.
- Blacklist a medium set of buffer-only items you never want leaving storage.

## Crafting Recipe

<RecipeFor id="logisticsnetworks:medium_filter" />
