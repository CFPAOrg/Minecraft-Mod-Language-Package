---
navigation:
  parent: crazyae2addons_index.md
  title: Crafting Canceler
  icon: crazyae2addons:crafting_canceler
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:crafting_canceler
---

# Crafting Canceler

<BlockImage id="crazyae2addons:crafting_canceler" scale="4"></BlockImage>

The Crafting Canceller is a helpful block that watches your ME network for any crafting jobs that have stalled. If a recipe doesn’t make progress for longer than you allow, the Canceller cancels and immediately restarts it, keeping your automation flowing without manual fixes.

To set it up, place the block anywhere in your network and right-click to open its screen. You’ll find a switch to turn the Canceller on or off and a field to enter the maximum stall time (from 15 to 360 seconds). Click "Save" to apply your choices.

When enabled, the block checks all ongoing crafting tasks in the network. If it spots one that hasn’t changed for your chosen time, it cancels that job and reschedules it right away.
