---
navigation:
  title: ComputerCraft
  parent: integrations/index.md
  position: 1
---

# ComputerCraft

With [CC: Tweaked](https://modrinth.com/mod/cc-tweaked) installed, the Computer doubles as a peripheral. Scripts can read everything the Computer screens show — networks, channels, nodes, the node graph and live I/O telemetry — and draw it on monitors.

## Connecting

Place a CC computer next to the Computer, or link them with a wired modem. The peripheral type is `logistics_computer`:

```lua
local lc = peripheral.find("logistics_computer")
```

## Ownership

A Computer belongs to the player who placed it. Scripts see exactly the networks that player can open, following the server's node access rules and FTB Teams. Anyone who connects a CC computer to it can read those networks, so keep it where only you can reach it.

A Computer placed before this update has no owner. Break it and place it again to use it with ComputerCraft.

## Methods

`net` is a network id or its exact name. Channel lists are in screen order and each entry's `index` is the `CH` number shown in the [I/O Monitor](../computer/io-monitor.md), which starts at 0 — so CH0 is `channels[1]`. Graph edge `channels` also hold CH numbers.

| Method | Returns |
|---|---|
| `listNetworks()` | `{ {id, name, nodeCount, starred, color, createdAt}, ... }` |
| `getChannels(net)` | `{ {index, name, type, nodeCount}, ... }` — `type` is nil when a channel has no enabled nodes |
| `getNodes(net)` | `{ {id, label, block, pos, attachedPos, dimension, visible, highlighted}, ... }` — loaded nodes only |
| `getGraph(net)` | `{ name, totalNodes, vertices, edges }` — vertices have `key, label, x, y, nodes`; edges have `from, to, type, channels` |
| `watch(net)` | Starts live telemetry for this computer |
| `unwatch(net)` | Stops it |
| `getFlow(net)` | Last telemetry sample, or nil before the first second; errors if the network isn't watched |

Types are `item`, `fluid`, `energy`, `chemical` and `source`.

## Live Telemetry

After `watch`, a `logistics_flow` event arrives every second:

```lua
local _, side, networkId, sample = os.pullEvent("logistics_flow")
-- sample.channels[1].total, sample.channels[1].resources[1].displayName
```

Each channel has `index`, `type`, `total` (amount moved in that second, in the I/O Monitor's units) and `resources` — the top 16 items, fluids or chemicals with `kind`, `name`, `displayName` and `amount`. Energy and Source channels have an empty resource list.

Watches end when the computer restarts or is disconnected, so call `watch` from your `startup` script. They also stop without an error if the owner loses access to the network or the network is deleted.

## Example

Shows every channel's live rate on an attached monitor:

```lua
local lc = peripheral.find("logistics_computer")
local mon = peripheral.find("monitor")
local net = "Main Base"

mon.setTextScale(0.5)
lc.watch(net)
while true do
  local _, _, _, sample = os.pullEvent("logistics_flow")
  mon.clear()
  for i, ch in ipairs(sample.channels) do
    mon.setCursorPos(1, i)
    mon.write(("CH%d %-8s %d/s"):format(ch.index, ch.type or "-", ch.total))
  end
end
```
