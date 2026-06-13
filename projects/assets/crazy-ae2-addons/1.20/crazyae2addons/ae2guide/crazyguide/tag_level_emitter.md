---
navigation:
  parent: crazyae2addons_index.md
  title: Tag Level Emitter
  icon: crazyae2addons:tag_level_emitter
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:tag_level_emitter
---

# Tag Level Emitter

The **Tag Level Emitter** is a ME Level Emitter variant that counts resources matched by a tag expression instead of a single configured resource.

---

## Tag expression

The expression field selects which stored resources should count.

Expression syntax is shared with other tag-based features (see the [Tag Matcher](./tag_matcher.md)).

The expression is applied to the stored contents of the connected ME network.

---

## Empty expression invariant

An empty expression does not mean no filter.

When the expression is empty, the emitter counts all stored items in the ME network.

Fluids are not included in this empty-expression fallback.

---

## Invalid expression invariant

If the expression is invalid, the counted amount becomes 0.

If the expression does not contain any tag checks, the counted amount also becomes 0.

This prevents plain text or incomplete expressions from accidentally matching the whole network.

---

## Threshold field

The threshold field uses the counted value produced by the tag expression.

The value must be a whole number and cannot be negative.

Simple math expressions can be used in the threshold field (see the [Math Parser](./math_parser.md)).

Invalid threshold values are highlighted and are not applied.

---

## Analog Card

The Tag Level Emitter supports the Analog Card upgrade.

With an Analog Card installed, the part outputs an analog redstone signal based on the matched amount and the configured threshold.

---

## Analog output modes

See the [Analog Card](./analog_card.md)

---
