---
navigation:
  parent: crazyae2addons_index.md
  title: Display Monitor
  icon: crazyae2addons:display_monitor
categories:
  - Data Variables
item_ids:
  - crazyae2addons:display_monitor
---

# Display

The Display is a visual part you can attach to any ME cable to show text or network variables directly in the world. It is updating dynamically as variables change.

## How to Use

1. **Place the part**: Attach the Display to an ME cable.
2. **Configure text**: Right-click to open its screen and input the text you want to display.
    - Use `&NAME` to insert a variable’s value.
    - Use `&nl` to create a new line.
3. **Variable linking**:
    - When you reference `&NAME`, the Display automatically subscribes to that variable from your ME Data Controller.
    - When the variable changes, the Display updates instantly.
4. **Rendering**: Display scales text to fit the available space.

Use Displays to create dashboards, monitoring walls, or just to decorate your ME network with dynamic, informative text.