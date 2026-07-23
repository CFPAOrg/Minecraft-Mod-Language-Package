---
item_ids: [logisticsnetworks:small_filter, logisticsnetworks:medium_filter, logisticsnetworks:big_filter, logisticsnetworks:mod_filter, logisticsnetworks:name_filter]
navigation:
  title: Filters
  position: 4
---

# Filters

Filters are virtual channel rules that decide exactly which resources a channel is allowed to move. Open them from the 3x2 filter grid on the right side of the node screen; see [Filters & Upgrades](../nodes/filters-upgrades.md).

Without any filters the channel transfers everything that matches its Type. Add a filter and only resources that pass the filter's rules get through.

Filter slots are **per-channel**. Every channel on a node keeps its own independent set of 6 filter buttons, so one node can run 6 totally different filter configurations at once.

## Sender vs Receiver

Filters live on both Senders and Receivers, but they do different jobs depending on which side of the transfer you put them on:

- **Sender (exporter)**: the filter decides **what the Sender pulls out** of the block it is attached to. Only resources that pass the filter are extracted and offered to the network.
- **Receiver (importer)**: the filter decides **what the Receiver accepts** into the block it is attached to. The network may be full of resources, but the Receiver only takes the ones that pass its filter.

Most setups put filters on both sides. A Sender-side filter decides what leaves the source; a Receiver-side filter decides what lands at the destination. A common pattern is one Sender pulling a wide range of items from a dump chest, and several Receivers each filtering a narrow subset.

Whitelist / Blacklist, Match Any / Match All, and every per-entry rule all honor this Sender-vs-Receiver split. Stock in particular swaps meaning between the two sides, since "keep a reserve" and "cap the destination" are not the same thing.

## Whitelist vs Blacklist

Every filter has two modes:

- **Whitelist**: the filter is a list of things the channel is **allowed** to move. Anything not on the list is blocked.
- **Blacklist**: the filter is a list of things the channel is **not** allowed to move. Everything else gets through.

Open a virtual filter from the node filter grid to flip the mode.

## Match Any vs Match All

When a channel has more than one filter in its grid, the **Any / All** button at the top of the Filters panel decides how they combine:

- **Match Any**: a resource passes if **at least one** filter accepts it.
- **Match All**: a resource passes only if **every** filter accepts it.

For a full walkthrough, see [Filters & Upgrades](../nodes/filters-upgrades.md#filters).

## Filter Types

### Small, Medium, and Big

Small, Medium, and Big filters all use the same exact-match behavior and the same **45-slot** entry grid.

- Match exact item ids and fluid ids.
- Put any item or fluid bucket into an entry slot to add it to the list.
- Remove the entry to take it off the list.
- Empty entry slots are ignored.

Each entry can also open a Detail page for tag matching, batch overrides, stock thresholds, NBT rules, and attached-inventory slot restrictions.

### Mod

Mod filters match every item or fluid from one configured mod id.

- Set the mod id, such as `minecraft`, `create`, `mekanism`, or `ae2`.
- One Mod filter matches one mod.
- To match several mods, put multiple Mod filters in the same channel and use **Match Any**.

### Regex

Regex filters match resource display names with restricted, case-insensitive regex syntax.

- Maximum pattern length is 128 characters.
- Supported: literals, `.`, character classes such as `[A-Z]`, `^`, `$`, escaped punctuation, and top-level `|` alternatives.
- Unsupported: groups, lookarounds, backreferences, inline flags, and repetition operators `*`, `+`, `?`, or `{...}`.
- Matching searches the full name, so `Iron` already matches `Iron Ingot`; `.*Iron.*` is unnecessary and rejected.
- Unsafe or malformed patterns remain visible for repair but match nothing.

Common examples:

| Pattern | Matches |
|---------|---------|
| `Iron` | Anything containing "Iron" |
| `^Iron` | Names starting with "Iron" |
| `Ingot$` | Names ending with "Ingot" |
| `^Iron Ingot$` | Exactly "Iron Ingot" |
| `Iron|Gold` | Names containing "Iron" or "Gold" |
| `[IG]ron` | "Iron" or "Gron" |

Compiled patterns are reused during each transfer operation. Keep expressions narrow on high-traffic channels.

### Slot

Slot filters restrict which slot indices on the attached block the channel can read or write.

- Use comma-separated slots and ranges, such as `0`, `0-8`, or `0-3,5`.
- Valid slot indices are `0` through `53`.
- On Senders, only the listed source slots are extracted from.
- On Receivers, only the listed destination slots are inserted into.

## Entry Details

Every slot in a Small, Medium, or Big filter's main grid is more than a single-item check. Open the Detail page for a filled entry to configure these per-entry rules:

- **Item or #tag**: match an exact id like `minecraft:iron_ingot`, or a tag like `#c:ores`.
- **Batch**: override how many of this entry move per transfer on the Sender side.
- **Stock**: reserve items on Senders, or cap destination stock on Receivers.
- **NBT**: add up to 6 active NBT/component rules, or paste raw SNBT for advanced cases.
- **Slots**: restrict this entry to specific attached-inventory slot indices.

Leave Batch or Stock at `0` to fall back to the channel settings or disable the threshold.

## Copy & Paste a Filter

While a filter screen is open you can copy its whole configuration and paste it into another open filter. Use **Ctrl + C** to copy and **Ctrl + V** to paste, or click the **copy** and **paste** icon buttons in the top-right of the filter header. Hover either button for a tooltip; the paste button is dimmed until something has been copied.

This clipboard lives only in your current game session. It is **not** saved to the filter item, to a config, or to your operating system clipboard, and it is cleared when you leave the game. It is separate from the wrench [Copy / Paste](../wrench/copy-paste.md) clipboard.

What gets copied depends on the filter type:

- **Small / Medium / Big**: every entry plus its per-entry rules — item, fluid, chemical, or `#tag`, batch and stock amounts, slot mapping, NBT (strict flag, raw SNBT, rules, and Match Any/All mode), durability, and enchanted state — along with the filter's Whitelist/Blacklist mode and Type.
- **Mod**: Whitelist/Blacklist mode, Type, and the selected mod id.
- **Regex**: Whitelist/Blacklist mode, Type, the regex pattern, and the match scope.

A short overlay message confirms each action (`Filter copied`, `Filter pasted`, and so on).

Notes:

- Pasting **replaces** the destination filter. Standard-filter slots are cleared first, then filled from the clipboard.
- If the copied filter has more entries than the destination can hold, paste fills the destination to capacity and reports the truncation, for example `Filter pasted: 6/8 slots copied`.
- Pasting into a different filter type (a standard filter into a Regex filter, for example) is rejected with an incompatible-type message.
- Ctrl + C and Ctrl + V are ignored while a text box such as the regex or mod-id field is focused, so typing is never hijacked.

## Copying Filters Between Nodes

Filter configurations are also copied with node copy/paste, labelled-node sync, and `.lnet` save/load workflows. To clear a virtual filter, clear its entries inside the filter menu.
