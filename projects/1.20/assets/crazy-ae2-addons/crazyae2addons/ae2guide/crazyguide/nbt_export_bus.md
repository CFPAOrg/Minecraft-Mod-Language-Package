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

The NBT Export Bus is an advanced version of the AE2 export bus that lets you filter and control access to storage **based on NBT data**.

---

## How to Use

1. **Place on a Storage Block**
    - Attach the NBT Export Bus to a chest, drawer, or any block with item inventory.

2. **Open Configuration GUI**
    - Right-click the part to configure its filter and behavior.
    - GUI allows you to:
        - Set read/write permissions
        - Toggle extract filters
        - Configure NBT match expressions

3. **Write NBT Filter**
    - Use the text area to enter **NBT match expressions**.
    - Examples:
        - {Enchantments:[{id:"minecraft:sharpness"}]} - matches only items with Sharpness enchant.
        - {display:{Name:My Sword}} - matches items with tag display value set to Name: My Sword
        - {*:"value"} - matches if *any* NBT value is "value"
        - {key:!"value"} - matches if the NBT named key value is not "value"
    - Supports logical expressions like &&, ||, !, nand, etc.

4. **Load NBT from Item** *(Optional)*
    - Place an item in the fake slot and press the **Load** button.
    - Automatically imports the item's NBT into the filter.

---

## Matching System

NBT expressions use a custom parser that supports:

- **Wildcard keys/values**: "*"
- **AND/OR/NAND/XOR logic**
- **Recursive key matching**
- **Negation with !value**

If an item matches the expression, it's exported.