---
navigation:
  parent: enderdrives_intro/enderdrives_intro-index.md
  title: Tape Disk Item Storage Cell
  icon: enderdrives:tape_disk
categories:
  - tapedrives
item_ids:
  - enderdrives:tape_disk
---

# Tape Disk Drives

Tape Drives are powerful AE2-compatible storage cells designed to handle **NBT-heavy items**, such as tools, armor, enchanted gear, or any uniquely tagged items that normally fill type space with traditional ME drives.

Unlike typical AE2 drives, Tape Disks bytes used scale dynamically based on the actual **NBT size** of items stored — giving you fine-grained control over your system.  Tape Drives will **NOT** tell AE2 that it is preferred for any item that would match its filter, please use ME Drive priority.

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:tape_disk" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:tape_disk" />
  </Column>
</Row>

---

## How It Works

Each Tape Disk will only allow items to be stored with non-standard NBT, armor, tools, or non-stackable items.

---

## Byte & Type Limits

Tape Disks enforce both a **type limit** and a **byte usage limit**:

- **Type Limit** – Maximum number of unique item types stored (e.g. enchanted books, custom armor).
- **Byte Limit** – Based on the **NBT data size** of each item. Items with lots of tags (like Apotheosis gear) use more space due to the quantity of NBT.

Tape Disks are designed to **favor NBT-heavy items**, making them perfect for storing equipment or one-off items without polluting traditional drive space.

---


## When to Use a Tape Disk

Use a Tape Disk instead of a traditional drive when:

- You’re storing **non-stackable items** like armor, tools, or gear.
- You need room for **NBT-heavy modded items**.
- You want to keep special items out of your normal ME drives.

Tape Drives shine where normal drives struggle — taking up type limit space on your giant drives.

---

## IO Port Transfers

A tape disk will auto-throttle itself doing transfers from or to it using an IO Port.  This is due to potentially handling NBT heavy items so it doesn't dump it all in one go and freeze up you game.

---

## What Can Be Stored?

Tape Disks are specialized for **NBT-heavy**, **non-stackable**, or **customized** items — not general bulk storage.

---

### Accepted Items

| Item                                | Example                                  |
|-------------------------------------|------------------------------------------|
| <ItemImage id="minecraft:diamond_chestplate" /> | **Diamond Chestplate** with enchantments |
| <ItemImage id="minecraft:enchanted_book" />     | **Enchanted Book** with an enchantment   |
| <ItemImage id="minecraft:splash_potion" />      | **Potions** with effects                 |
| <ItemImage id="minecraft:netherite_pickaxe" />  | **Tools** with durability                |

---

### Not Accepted

| Item                              | Reason                         |
|-----------------------------------|--------------------------------|
| <ItemImage id="minecraft:cobblestone" /> | No NBT, Stackable              |
| <ItemImage id="minecraft:wheat" />       | No NBT, Stackable  |
| <ItemImage id="minecraft:oak_log" />     | No NBT, Stackable             |
| <ItemImage id="minecraft:apple" />       | No NBT, Stackable    |
| <ItemImage id="minecraft:iron_ingot" />  | No NBT, Stackable    |

---

