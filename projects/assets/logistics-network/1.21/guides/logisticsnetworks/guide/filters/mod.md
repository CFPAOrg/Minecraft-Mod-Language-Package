---
item_ids: [logisticsnetworks:mod_filter]
navigation:
  title: Mod Filter
  parent: filters/index.md
  icon: logisticsnetworks:mod_filter
  position: 4
---

# Mod Filter

Matches **every item or fluid from a specific mod** with a single entry. Much smaller and broader than the exact-match filters.

## What It Matches

Any resource whose registry namespace equals the configured mod id. For example, if the Mod Filter is set to `create`, every item and fluid from the Create mod passes the filter.

## Config

- Right-click the filter in-hand to open the menu.
- Set the **mod id** (e.g. `minecraft`, `create`, `mekanism`, `ae2`).
- That is the only field — one Mod Filter = one mod.

## Whitelist vs Blacklist

- **Whitelist** — only resources from the listed mod are allowed through.
- **Blacklist** — everything **except** resources from the listed mod is allowed.

## Use Cases

- Send every Create item to the Create-only storage.
- Blacklist a mod you do not want clogging a general sorting network.

## Crafting Recipe

<RecipeFor id="logisticsnetworks:mod_filter" />

## Stacking Mod Filters

If you need to match several mods, put multiple Mod Filters in the same channel's filter grid and set the channel's filter mode to **Match Any**. Each filter matches one mod; together they cover all the mods you listed.
