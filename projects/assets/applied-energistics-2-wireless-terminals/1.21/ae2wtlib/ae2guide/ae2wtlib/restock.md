---
navigation:
  parent: ae2wtlib/ae2wtlib-index.md
  title: Restocking
  position: 110
categories:
- ae2wtlib
---

# Restocking

If Restock is enabled, your <ItemLink id="ae2:wireless_crafting_terminal" /> will try to replace items you use with items from the ME System.

You can enable it in the GUI, or using a Keybind.

When enabled, it will try to keep the Stack you are using at the max stack size, so 64 for most items.
It will take any missing items from your ME System,
or put excess items into your ME System if you pick up more.
This means that if you place a few items, then break them again, the item won't overflow into a different slot,
even if you don't hava an active <ItemLink id="ae2wtlib:magnet_card" />.

It will **NOT** restock stacks holding a single item before being used.

It will also change the item count in your hotbar,
to show the item count in the network (+ the items that actually are in your hotbar).

It only works as long as you are in range of an access point,
or if your terminal is [quantum linked](quantum_bridge_card.md).

In creative mode, this is automatically disabled since you are not depleting items anyway.

Restock works for most actions like placing blocks, eating food and shooting with a bow, restock should work,
but other actions (especially actions from other mods) might not be recognized and items used won't be restocked.
