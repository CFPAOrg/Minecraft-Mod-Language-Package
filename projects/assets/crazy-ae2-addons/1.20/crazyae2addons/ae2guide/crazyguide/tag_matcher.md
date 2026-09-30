---
navigation:
  parent: crazyae2addons_index.md
  title: Tag Matcher
---

# Tag Matcher

The **Tag Matcher** is used by features that filter resources using tag expressions.

Instead of selecting one specific item or fluid, a tag expression can match many resources at once.

It is used by features such as the Tag Level Emitter and Tag View Cell.

---

## Tags

Do not include # before the tag name.

For example, use forge:ingots/iron instead of #forge:ingots/iron.

The # character is not allowed in tag expressions.

---

## Operators

Tag expressions support boolean operators.

* ! means NOT
* & means AND
* | means OR
* ^ means XOR

The longer forms && and || are also accepted and are treated as & and |.

---

## Operator priority

Operators are evaluated in this order:

* !
* &
* ^
* |

Parentheses can be used to group parts of an expression.

---

## Wildcards

The * character can be used as a wildcard inside tag names.

A wildcard expression matches if any tag on the resource matches the pattern.

A single * matches any tagged resource.

---

## Empty expression

An empty expression is valid, but it does not match any item or fluid by itself.

Individual features may give empty expressions special meaning.

For example, a feature may treat an empty expression as a fallback mode instead of calling the matcher.

---

## Invalid expression

Invalid expressions do not match anything.

This includes expressions with broken parentheses, missing operands, unexpected operators, or the # character.

Features using the Tag Matcher should treat invalid expressions as matching 0 resources.

---

## Examples

Match iron ingots:

forge:ingots/iron

Match iron or gold ingots:

forge:ingots/iron | forge:ingots/gold

Match ingots except iron:

forge:ingots/* & !forge:ingots/iron

Match resources that are in exactly one of two tags:

forge:ingots/iron ^ forge:storage_blocks/iron

Match any tagged resource from the forge namespace:

forge:*
