---
navigation:
  parent: crazyae2addons_index.md
  title: Recipe Fabricator
  icon: crazyae2addons:recipe_fabricator
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:recipe_fabricator
---

# Recipe Fabricator

The **Recipe Fabricator** is a processing block for custom fabrication recipes.

It is not a generic crafting machine and does not process normal crafting, smelting, or processing recipes.

---

## Outputs

The machine has one item output slot and one fluid output tank. The item output can be extracted by external automation.
The fluid output tank can be drained by external automation. If outputs cannot fit, the recipe does not start.

---

## Auto-eject

After completing a recipe, the machine tries to push its outputs into adjacent blocks.

If both item and fluid outputs exist, the target must be able to accept both together.

If the full output cannot be accepted together, nothing is ejected and the outputs stay inside the machine.

If no adjacent block accepts the output, the item slot and fluid tank keep the results until they are extracted later.

---

## Preferred eject side

The machine remembers the side that last received an inserted input.

When auto-ejecting, it checks that side first, then falls back to the other sides.

This makes automation layouts more predictable when the same side is used for input and output routing.

---

## JEI and EMI

The Recipe Fabricator has its own recipe category in JEI and EMI.

Loaded fabrication recipes are shown with their item and fluid inputs and outputs.
