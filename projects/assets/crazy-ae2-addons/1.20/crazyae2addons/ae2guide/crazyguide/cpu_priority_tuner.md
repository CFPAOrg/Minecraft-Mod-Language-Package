---
navigation:
  parent: crazyae2addons_index.md
  title: CPU Priority Tuner
  icon: crazyae2addons:cpu_priority_tuner
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:cpu_priority_tuner
---

# CPU Priority Tuner

The **CPU Priority Tuner** sets a numeric priority on an AE2 Crafting CPU.

Priority changes which valid CPU is picked first.

When AE2 distributes work between CPUs, higher priority CPUs are considered first.
This means that a CPU with a higher priority will get to use machines first, and will get crafting results first.

The best use case is to keep your player request CPUs on the highest priority.

---

## Automatic Selection

When the CPU selector is left on Automatic, the network tries valid idle CPUs from highest priority to lowest priority.

A CPU still needs to satisfy the normal AE2 requirements, such as having enough storage for the job.

Priority only affects the order in which valid CPUs are considered.

---

## Crafting Status screen

The Crafting Status CPU list is sorted by priority.

Higher priority CPUs are shown first.

The CPU tooltip shows the current priority value.

---