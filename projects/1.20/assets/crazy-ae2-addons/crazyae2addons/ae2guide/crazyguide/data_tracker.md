---
navigation:
  parent: crazyae2addons_index.md
  title: Data Tracker
  icon: crazyae2addons:data_tracker
categories:
  - Data Variables
item_ids:
  - crazyae2addons:data_tracker
---

# Data Tracker

<BlockImage id="crazyae2addons:data_tracker" scale="4"></BlockImage>

The Data Tracker is a simple block that watches the value of a specific ME network variable and emits a redstone signal based on its state. When the value is greater than zero, the block outputs full redstone power; no power otherwise.

## How to Use

1. **Place the block**: Attach the Data Tracker to any spot in your ME network.
2. **Set the tracked variable**: Right-click the block to open its interface. Enter the name of the variable you want to monitor (for example, `&ABC`).
3. **Save and apply**: Press the "Save".
4. **Redstone output**: Whenever the value of the tracked variable is greater than 0, the Data Tracker will emit a redstone signal. Otherwise, it stays off.

You can use the Data Tracker to trigger external systems based on for example the progress of your furnace smelting things.