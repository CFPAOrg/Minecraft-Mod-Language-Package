---
navigation:
  parent: crazyae2addons_index.md
  title: Resource Tracking Terminal
  icon: crazyae2addons:resource_tracking_terminal
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:resource_tracking_terminal
---

# Resource Tracking Terminal

The **Resource Tracking Terminal** answers the question "where is all my iron going". It watches what leaves
the network and shows every resource with the rate it is being consumed at, and by what.

Items and fluids are both tracked, and anything else the network stores as long as something on this list
pulls it out.

---

## What counts as consumption

Only a resource that leaves the network into something that uses it is counted. What gets registered:

* crafting jobs, when a CPU pulls ingredients out for a recipe
* ME Interfaces stocking items or fluids
* Export buses pushing into a machine
* the [Ejector](./ejector.md), and other mod machines that buffer network resources, counted at the moment
  the resource actually leaves the buffer
* with GregTech installed, ME Stocking Buses and Hatches and ME Input Buses and Hatches

Moving things around inside the network, or into plain storage, is not consumption and does not show up here.

---

## Overview grid

Resources are shown in a grid, like a normal ME Terminal.

The number on each entry is how much of it was consumed in the last 60 seconds. Anything that has not been
touched for a minute drops off the grid on its own.

The search field filters by name.

---

## Details view

Clicking an entry opens the breakdown of what consumed it. Rows are sorted by rate, biggest first, and each
row carries the same last-60-seconds number as the grid.

A crafting row shows the item the job was making, so you can tell which recipe ate the resource.

A block row shows the coordinates of the consumer. It also has an eye button, and pressing it draws a red
pulsing outline around that block in the world for 10 seconds, which is how you find the one interface out of
forty that is draining your network.

The back button returns to the overview grid.

---

## Notes

Tracking is per network. Two separate networks keep separate numbers, and the data lives only in memory, so a
server restart starts the counting from scratch.

The whole feature can be turned off in the config.
