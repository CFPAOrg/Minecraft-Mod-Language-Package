---
navigation:
  parent: ae2wtlib/ae2wtlib-index.md
  title: AE2WTLib Wireless Terminals
  icon: ae2wtlib:wireless_universal_terminal
  position: 10
categories:
- ae2wtlib
item_ids:
  - ae2wtlib:wireless_pattern_encoding_terminal
  - ae2wtlib:wireless_pattern_access_terminal
---

# Wireless Terminals

<ItemGrid>
  <ItemIcon id="ae2wtlib:wireless_universal_terminal" />
  <ItemIcon id="ae2:wireless_crafting_terminal" />
  <ItemIcon id="ae2wtlib:wireless_pattern_encoding_terminal" />
  <ItemIcon id="ae2wtlib:wireless_pattern_access_terminal" />
</ItemGrid>

In addition to the <ItemLink id="ae2:energy_card" />, all AE2WTLib Wireless Terminals can be upgrade with the <ItemLink id="ae2wtlib:quantum_bridge_card" />
and combined into a <ItemLink id="ae2wtlib:wireless_universal_terminal" />.

Like AE2's <ItemLink id="ae2:wireless_terminal" />, it can be accessed using a Keybind and be put in a curio slot
(if any mod implementing the curio api is installed.)

Wireless Terminals can also be linked like a normal <ItemLink id="ae2:wireless_terminal" />, using a <ItemLink id="ae2:wireless_access_point" />

## Wireless Universal Terminal

<ItemImage id="ae2wtlib:wireless_universal_terminal" scale="3" />

The <ItemLink id="ae2wtlib:wireless_universal_terminal" /> is a combination of multiple Wireless Terminals into one item.

## Wireless Crafting Terminal

<ItemImage id="ae2:wireless_crafting_terminal" scale="3" />

The <ItemLink id="ae2:wireless_crafting_terminal" /> is a wireless version of the crafting terminal.
It has some [additional functionality](wireless_crafting_terminal.md) compared to vanilla AE2.

## Wireless Pattern Encoding Terminal

<ItemImage id="ae2wtlib:wireless_pattern_encoding_terminal" scale="3" />

A wireless version of the <ItemLink id="ae2:pattern_encoding_terminal" />

<RecipeFor id="ae2wtlib:wireless_pattern_encoding_terminal" />

## Wireless Pattern Access Terminal

<ItemImage id="ae2wtlib:wireless_pattern_access_terminal" scale="3" />

A wireless version of the <ItemLink id="ae2:pattern_access_terminal" />

<RecipeFor id="ae2wtlib:wireless_pattern_access_terminal" />

## Addon Terminals

Most wireless terminals from other Addons also work with the <ItemLink id="ae2wtlib:wireless_universal_terminal" />.

## Terminals that don't work in the universal terminal

The <ItemLink id="ae2:wireless_terminal" /> can not be used in the <ItemLink id="ae2wtlib:wireless_universal_terminal" />,
since it wouldn't provide any benefit over a <ItemLink id="ae2:wireless_crafting_terminal" />.
It also can't use the <ItemLink id="ae2wtlib:quantum_bridge_card" />
