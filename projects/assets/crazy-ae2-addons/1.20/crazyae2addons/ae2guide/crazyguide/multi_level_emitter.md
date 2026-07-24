---
navigation:
  parent: crazyae2addons_index.md
  title: Multi Level Emitter
  icon: crazyae2addons:multi_level_emitter
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:multi_level_emitter
---

# Multi Level Emitter

The **Multi Level Emitter** is a ME Level Emitter variant with multiple independent filter slots.

Each slot can have its own resource, threshold, comparison direction, or crafting-state condition.

---

## Slot evaluation

The emitter can track up to 16 slots, with each slot is evaluated independently.

Empty slots are ignored, unless they have a threshold set, then they monitor all resources.

The final redstone state is calculated from all active slots using AND or OR logic.

---

## Per-slot comparison

In storage mode, every slot has its own comparison toggle.

---

## AND / OR invariant

OR mode matches when at least one active slot matches.

AND mode matches only when every active slot matches.

Slots with no resource and no threshold do not participate in the result.

---

## Empty slot with threshold

An empty slot with a threshold becomes a total-network-storage check.

Instead of checking one resource, it compares the threshold against the total amount of all stored resources in the ME network.

---

## Threshold fields

An empty threshold field is treated as 0.

Simple math expressions can be used in threshold fields (see the [Math Parser](./math_parser.md)).

Invalid values are highlighted and are not applied.

---

## Fuzzy Card invariant

With a Fuzzy Card installed, configured resources are counted using AE2 fuzzy matching.

Matching stacks are summed according to the selected fuzzy mode.

---

## Crafting Card mode

Installing a Crafting Card switches the part from storage checks to crafting request checks.

Threshold fields are hidden in this mode because thresholds are not used.

Each configured slot checks whether that resource is currently requested by the crafting system.

The slot toggle changes between matching while the resource is being crafted and matching while it is not being crafted.

AND / OR logic still applies to the slot results.

---

## Crafting fallback

If Crafting Card mode has no configured resources, the emitter checks whether the network is requesting any crafting job.

---