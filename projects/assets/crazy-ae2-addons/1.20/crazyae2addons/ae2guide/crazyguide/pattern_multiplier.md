---
navigation:
  parent: crazyae2addons_index.md
  title: Pattern Multiplier
  icon: crazyae2addons:pattern_multiplier
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:pattern_multiplier

---

# Pattern Multiplier

The **Pattern Multiplier** modifies encoded processing patterns by multiplying their input and output amounts.

It can be used from its own internal inventory or applied directly to inventories in the world, like pattern providers, or chests.

Only processing patterns are modified. Crafting patterns are skipped and left unchanged.

---

## Internal inventory

The item has an internal pattern inventory.

Patterns placed inside the item can be modified in bulk using the stored multiplier and output limit.

The multiplier and limit values are saved on the item.

---

## Direct block apply

Shift-right-clicking a supported block applies the Pattern Multiplier directly to encoded patterns inside that block.

The stored multiplier and limit from the item are used.

Supported targets include ME Interfaces, Pattern Providers, and normal inventory blocks containing encoded patterns.

---

## Multiplier

The multiplier changes every input and output amount in each valid processing pattern.

A multiplier of 0 does nothing.

A multiplier greater than or equal to 1 scales amounts up.

Results are floored, but no input or output slot is allowed to become 0.

The multiplier and limit fields support simple math expressions (see the [Math Parser](./math_parser.md)).

---

## Fractions

Multipliers below 1 must behave as exact reductions.

For item amounts, every non-fluid input and output in a pattern must divide cleanly by the reduction factor.

If any non-fluid item amount cannot be divided cleanly, that whole pattern is skipped and left unchanged.

Fluids are not part of this divisibility check, but their amounts are still scaled.

---

## Output limit

The limit field can cap the effective multiplier per pattern.

When the limit is greater than 0, the pattern is scaled only as much as possible without making the total output exceed the limit.

A limit of 0 disables the cap.

---

## Clear behavior

The clear button replaces all patterns in the internal inventory with blank patterns.

---