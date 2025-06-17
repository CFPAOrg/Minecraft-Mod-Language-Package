---
navigation:
  parent: crazyae2addons_index.md
  title: NBT Export Bus
  icon: crazyae2addons:nbt_export_bus
categories:
  - Energy and Item Transfer
item_ids:
  - crazyae2addons:nbt_export_bus
---
# NBT Export Bus

**To turn it off, save the filter when nothing is in the input box.**

The NBT Export Bus part lets you export items from your ME network based on their NBT data. You can enter any valid NBT tag string to filter which items will be sent out, and choose whether items must match every tag or just one of them. It also supports a wildcard: `ANY`, when you don't want to specify the exact tag, when just the existence of it is enough. Example: `{StoredEnchantments:ANY}`

## How to Use

1. **Attach the part**: Place the NBT Export Bus on any side of an ME cable.
2. **Open settings**: Right-click the part with to open its configuration screen.
3. **Set NBT filter**: In the text box, type your NBT filter string (for example, `{StoredEnchantments:[{lvl:5S,id:"minecraft:sharpness"}]}`). **The `S` in `lvl:5S` is also important!**
4. **Choose match mode**: Use the "Match Any" checkbox to decide if the bus should export items matching *any* one of the tags (when checked) or *all* tags exactly (when unchecked).
5. **Save**: Click Save. The bus will now pull matching items from your ME storage and deposit them into the connected inventory.

With the NBT Export Bus set to `{ANY:ANY}` and `Match Any` selected, you can easily export all items that have any NBT tag attached out of your ME system.  