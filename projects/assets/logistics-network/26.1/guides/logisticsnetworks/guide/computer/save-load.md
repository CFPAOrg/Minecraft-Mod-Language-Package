---
navigation:
  title: Save & Load Networks
  parent: computer/index.md
  position: 4
---

# Saving & Loading Networks

The Computer can write a whole network's node setup to a `.lnet` file on disk and read it back later. This lets you keep a library of network blueprints — back up a working setup, copy it to another world, or hand it to someone else.

A `.lnet` file is a plain-text snapshot. For every node on the network it stores the node's **label**, whether it is **visible**, and the node's full **clipboard config** (all 9 channels, their modes, filters, and upgrades). It does **not** store block positions — a file is a recipe for configuring nodes, not a copy of the world.

## Where Files Live

Saved networks go in:

```
config/logistics-network/networks/
```

inside your instance folder. Each file is named after the network (sanitised — only letters, numbers, `.`, `_`, `-`; trimmed to 48 characters). You can copy these files between instances or share them like any other file.

## Saving A Network

1. Mount a network from the [Network Directory](network-directory.md).
2. On the mounted-network panel, click **SAVE NETWORK** (`Write .lnet file`). This opens the **FILES** page.
3. Hit the **SAVE** button at the top of the page.

The Computer exports the mounted network and writes `<network-name>.lnet`. Saving again with the same network name **overwrites** the existing file.

### Every Node Needs A Unique Label

The export only works if **every node on the network has a label** and **no two labels are the same**. Labels are how a file matches a saved config back to a node. If the network isn't clean you get an error instead of a file:

- `Missing labels: X nodes` — that many nodes have no label. Open them and name them.
- `Duplicate labels: ...` — two or more nodes share a label. Rename so each is unique.

Set labels from the [Node Table](node-table.md) or the node config screen before saving.

## Loading A Network

Loading does **not** auto-build a network. It pulls one saved node config onto the Computer's [Wrench](../wrench/index.md), which you then paste onto a real node.

1. From the [Network Directory](network-directory.md) with **no network mounted**, click **LOAD NETWORK** (`Read .lnet file`) to open the **FILES** page.
2. Pick a file from the **FILES** column. Its node labels fill the **LABELS** column.
3. Pick a label. The **PREVIEW** column shows that node's summary — channel count, filter count, upgrades, and any required items.
4. Click **COPY TO WRENCH**. The selected label's config is loaded into the Computer's wrench slot.
5. Take the wrench and paste the config onto a node with right-click. See [Copy & Paste](../wrench/copy-paste.md) for how pasting works.

Repeat per label to rebuild each node of the saved network.

## The FILES Page

- **SAVE** — export the currently mounted network (top-left).
- **REFRESH** — re-scan the folder if you added or removed files outside the game.
- **FILES** / **LABELS** / **PREVIEW** — the three columns described above. Scroll the wheel over the file or label column to page through long lists.

If the folder is empty the page reads **No .lnet files**. A file that can't be parsed reports **Invalid .lnet file** — the format is text, so a hand-edited file with a broken header or bad clipboard data will be rejected.
