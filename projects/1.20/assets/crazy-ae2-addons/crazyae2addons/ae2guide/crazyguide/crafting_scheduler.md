---
navigation:
  parent: crazyae2addons_index.md
  title: Crafting Scheduler
  icon: crazyae2addons:crafting_scheduler
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:crafting_scheduler
---

# Crafting Scheduler

<BlockImage id="crazyae2addons:crafting_scheduler" scale="4"></BlockImage>

The Crafting Scheduler is a redstone-triggered crafting block that queues and submits crafting jobs to your system when powered. It allows you to automate specific crafting requests with redstone

---

## How to Use

1. **Place the Block**
    - Connect it to your ME network.
    - Ensure it has access to at least one available CPU.

2. **Insert the Item to Craft**
    - Open the GUI.
    - Use the slot to choose the item you want to schedule.

3. **Set the Amount**
    - Enter the quantity you want crafted each time it triggers.
    - Use the text field and confirm with the green button.

4. **Trigger with Redstone**
    - Apply a redstone pulse to the block.

5. **Repeatable Usage**
    - Each new pulse triggers a new job if a CPU is available.
