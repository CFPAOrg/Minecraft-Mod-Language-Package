---
navigation:
  parent: crazyae2addons_index.md
  title: More View Cells
  icon: crazyae2addons:tag_view_cell
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:tag_view_cell
  - crazyae2addons:nbt_view_cell
---
# NBT & Tag View Cells

The **NBT View Cell** and **Tag View Cell** are special types of view cells you can place in your ME Terminal to filter what items are displayed.

## How they work

* Both cells allow you to enter a **custom filter string** directly inside their interface.
* The filter is saved on the cell’s item, so you can move it between terminals and keep your settings.
* When placed in a terminal, only items matching the filter will appear.

## [Video Tutorial](https://youtu.be/bConD7dV_p0&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

## NBT View Cell

* Filters items by matching their **NBT data** against the filter expression.
* You can write expressions using SNBT snippets inside `{ ... }`, combined with logic operators.
* **Supported operators:**
    * `&&` or `and` → logical AND
    * `||` or `or` → logical OR
    * `^^` or `xor` → exclusive OR
    * `!` or `not` → negation
    * `nand` or `!&` → negated AND
* Parentheses `( )` can be used to group expressions.
* Wildcard `*` can match any value or any key.
* Example: `{Enchantments:[{id:"minecraft:sharpness"}]}` will only match items with Sharpness enchant.

## Tag View Cell

* Filters items by **Minecraft tags**.
* Enter the tag name (e.g., `#minecraft:wool`) and the terminal will only display items with that tag.
* Supports **glob matching** with `*` – for example `#minecraft:*_logs` matches all log tags.
* Logical operators are also supported:
    * `&&`, `||`, `^^`, `!`, `nand`
* Example: `#minecraft:logs && !#minecraft:oak_logs` → matches all logs except oak.

## Interface

* Open the cell to configure it:

    * A text field lets you type your filter expression.
    * Use the **scrollbar** if your filter is long and doesn’t fit in the box.
    * Press the **Confirm button** to save your filter.
* The filter is immediately applied to the cell and stored on the item itself.

## Notes

* These cells only affect **what you see in the terminal** – they do not remove or block items from the network.
* Multiple view cells can be combined; filters will stack with the usual AE2 priority rules.
* If no filter is set, the cell behaves like an empty slot.

---

With NBT and Tag View Cells you can keep your terminals clean and focused, whether you want to see only a specific potion variant or a whole tag category of blocks.
