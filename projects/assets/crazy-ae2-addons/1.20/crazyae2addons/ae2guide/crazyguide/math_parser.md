---
navigation:
  parent: crazyae2addons_index.md
  title: Math Parser
---

# Math Parser

The **Math Parser** is used by several Crazy AE2 Addons text fields that accept numbers.

It lets you enter simple expressions instead of calculating values manually before typing them into the GUI.

---

## Supported operators

The parser supports the basic arithmetic operators:

* addition with +
* subtraction with -
* multiplication with *
* division with /
* modulo with %
* parentheses with ( and )

Expressions follow normal operator priority, so multiplication and division are evaluated before addition and subtraction.

---

## Number suffixes

Large numbers can be shortened with suffixes.

Supported suffixes:

* k means thousand
* m means million
* g means billion
* t means trillion

Suffixes are not case-sensitive.

For example, 5k means 5000 and 2m means 2000000.

---

## Decimal numbers

The parser supports decimal numbers.

However, some fields may still reject decimals after parsing.

---

## Scientific notation

Scientific notation is supported for large or small values.

For example, 1e6 means 1000000.

---

## Spaces and underscores

Spaces and underscores are ignored before parsing.

This means 1 000, 1_000, and 1000 are treated as the same value.

---
