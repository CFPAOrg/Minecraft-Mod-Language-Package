---
navigation:
  title: Filters
  position: 4
---

# Filters

Filters are items that tell a channel exactly which resources it is allowed to move. Drop them into a channel's filter grid (the 3x3 panel on the right side of the node screen — see [Filters & Upgrades](../nodes/filters-upgrades.md)) to narrow down what the channel transfers.

Without any filters the channel transfers everything that matches its Type. Add a filter and only resources that pass the filter's rules get through.

Filter slots are **per-channel**. Every channel on a node keeps its own independent set of 9 filter slots, so one node can run 9 totally different filter configurations at once.

## Sender vs Receiver Side

Filters live on both Senders and Receivers, but they do different jobs depending on which side of the transfer you put them on:

- **Sender (exporter)** — the filter decides **what the Sender pulls out** of the block it is attached to. Only resources that pass the filter are extracted and offered to the network. Everything else stays in the source block.
- **Receiver (importer)** — the filter decides **what the Receiver accepts** into the block it is attached to. The network may be full of resources, but the Receiver only takes the ones that pass its filter. The rest keep flowing past to other Receivers.

Most setups put filters on both sides. A Sender-side filter decides what leaves the source; a Receiver-side filter decides what lands at the destination. A common pattern: one Sender pulling a wide range of items from a dump chest, and several Receivers each filtering a narrow subset (iron → iron chest, coal → coal chest, etc.).

Whitelist / Blacklist, Match Any / Match All, and every per-entry rule (Stock, Batch, NBT, Slots — see [Advanced Filtering](advanced-filtering.md)) all honour this Sender-vs-Receiver split. Stock in particular swaps meaning between the two sides, since "keep a reserve" and "cap the destination" are not the same thing.

## Whitelist vs Blacklist

Every filter has two modes:

- **Whitelist** — the filter is a list of things the channel is **allowed** to move. Anything not on the list is blocked.
- **Blacklist** — the filter is a list of things the channel is **not** allowed to move. Everything else gets through.

Open a filter item in your hand (right-click while holding it) to flip the mode. The tooltip on the item shows the current mode at a glance.

## Match Any vs Match All

When a channel has more than one filter in its grid, the **Any / All** button at the top of the Filters panel decides how they combine:

- **Match Any** — a resource passes if **at least one** filter accepts it.
- **Match All** — a resource passes only if **every** filter accepts it.

For a full walkthrough, see [Filters & Upgrades → Filters](../nodes/filters-upgrades.md#filters).

## Filter Types

- [Small Filter](small.md) — exact item/fluid match, 9 entry slots.
- [Medium Filter](medium.md) — exact item/fluid match, 18 entry slots.
- [Big Filter](big.md) — exact item/fluid match, 27 entry slots.
- [Mod Filter](mod.md) — match everything from a chosen mod.
- [Regex Filter](regex.md) — match items by name or tooltip using a regular expression.

## Copying Filters

You can duplicate or clear filter configurations using the crafting grid:

- **Copy** — place a configured filter together with an empty filter of the same type in the crafting grid. The empty filter gets a copy of the configured one's setup. Both come out together.
- **Clear** — place a configured filter alone in the crafting grid. It comes out empty, stripped of its entries and mode.

This works for every filter type on this page.
