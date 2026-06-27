---
navigation:
  parent: crazyae2addons_index.md
  title: Ejector
  icon: crazyae2addons:ejector
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:ejector
---

# Ejector

Upon receiving a redstone pulse the **Ejector** pulls configured items from the ME network and inserts them into the inventory in front of its output face.

---

## Atomic eject

The Ejector does not partially insert a configured batch into the target inventory.

Before ejecting, it simulates inserting the full buffered set into the adjacent target.

If every item fits, the whole batch is inserted.

If any item does not fit, nothing is inserted and the items are flushed back to ME storage.

---

## Missing items

When a cycle starts, the Ejector first tries to pull the configured items from ME storage.

If some items are missing and crafting is enabled in config, it submits one crafting job for all missing items together.

When the job finishes, the crafted items are added to the buffer and the eject cycle continues automatically.

If crafting cannot be started, the GUI shows the missing item that blocked the cycle.

---

## Pattern import

A processing pattern can be loaded into the pattern slot to configure the Ejector faster.

The load button copies the pattern inputs into the Ejector config slots.

The pattern is used only for configuration. 

---

## Output face

The Ejector inserts into the block in front of its output face.

The output face can be rotated with a wrench.

If the target disappears or cannot accept items, the Ejector tries to return buffered items to ME storage.

---