---
navigation:
  parent: crazyae2addons_index.md
  title: CPU Priorities
  icon: crazyae2addons:cpu_prio_tuner
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:cpu_prio_tuner
---

# Crafting CPU Priorities

Normally in **Applied Energistics 2**, when you have multiple **Crafting CPUs** in your ME Network, the system automatically decides which CPU should receive items needed for autocrafting. By default, this choice is more or less random — whichever CPU happens to be available will take the items first.

This can sometimes lead to unwanted behavior, especially if you want one CPU to always finish its task first or to make sure that certain crafting jobs do not "steal" items from another CPU.

---

## Why Priorities?

With this addon, every Crafting CPU can now be assigned a **priority value**.

* CPUs with **higher priority** will receive the required items before lower-priority ones.
* If two CPUs are waiting for the same item, the one with the **higher priority** will get it first.
* This allows you to control how your crafting jobs compete for items inside the network.

This feature helps if you:

* Want a **“main” CPU** to always handle critical recipes before smaller ones.
* Need to **separate tasks** (e.g., keep your auto-processing CPU from interfering with your bulk crafting CPU).
* Prefer predictable crafting flows rather than random assignment.

---

## How to Set CPU Priority

1. Craft and hold the **CPU Priority Tuner** item (the tool used to configure CPU clusters).
2. Right-click on a block that belongs to the **Crafting CPU cluster** you want to configure.
3. A configuration screen will open.
4. Enter a number in the priority field:
  * Higher numbers mean **higher priority**.
  * Negative or lower numbers mean **lower priority**.
5. Press **Save**.

The new priority is stored directly in the CPU cluster. You can repeat this process for each CPU in your network.

---

## Tips

* If all CPUs have the same priority, the system will behave like vanilla AE2 — distributing items randomly.
* Use **high positive values** for your main CPU(s) and **lower or negative values** for secondary ones.
* You can change priorities at any time without breaking or rebuilding the CPU.
