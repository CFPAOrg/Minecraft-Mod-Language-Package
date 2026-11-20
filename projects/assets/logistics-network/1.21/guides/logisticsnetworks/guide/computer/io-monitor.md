---
navigation:
  title: I/O Monitor
  parent: computer/index.md
  position: 2
---

# I/O Monitor

The live telemetry view for a mounted network. One page shows every channel, a live throughput chart for the channel you pick, and exactly which items, fluids and chemicals are moving on it.

Open it from the mounted network's subsystem buttons. Use **Back** in the top-left corner to return to the directory. The page follows your selected UI theme.

## Channel Rail

The left column lists all nine channels (**CH0** to **CH8**). Each row shows:

- The channel's name, or **Channel N** if it has none.
- The channel number and its live rate for the last second, coloured by type: items, fluids, energy, chemicals or source.

Channels with no enabled nodes on this network are dimmed and can't be selected. Use **Primary Interaction (default: Left Click)** on any other row to switch the chart to it instantly.

Rates are aggregated **per channel index** across every node on the network.

## Throughput Chart

- One bar per second, newest on the right. Pick the window with **30s / 1m / 2m**.
- The header shows the channel's current rate in its unit: items per second, `mB/s` for fluids and chemicals, `RF/s` for energy, and source per second.
- Hover a bar to see its exact value and how many seconds ago it was.
- History starts when you open the page and covers up to the last two minutes.

## Resource Breakdown

Item, fluid and chemical channels list what is moving under the chart:

- Icon, name, rate per second and share of the channel's total over the selected window.
- Items are told apart exactly: different potions, enchanted books or named items get their own rows.
- Hover a row for the full item tooltip plus how much moved in the window.
- Use Primary Interaction on a row to show only that resource in the chart and header. Use it again, or the **✕** next to its name, to go back to the total.
- **Other** collects anything outside the 16 busiest resources each second.
- Scroll the list when there are more than three rows.

Energy and Source channels carry a single resource, so they show **Average**, **Peak** and **Moved** cards instead of a list.

## Reading The Chart

- Steady tall bars mean constant throughput.
- An empty chart means the channel exists but nothing is moving. Check filters, redstone mode and whether the source actually has the resource.
- A spiky pattern means bursty transfers, usually high Delay or an intermittent producer.
- A sudden drop to zero means the channel stopped: source drained, redstone turned it off, or the node left the network.
