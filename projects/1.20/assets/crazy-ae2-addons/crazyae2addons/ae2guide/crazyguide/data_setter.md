---
navigation:
  parent: crazyae2addons_index.md
  title: Data Setter
  icon: crazyae2addons:data_setter
categories:
  - Data Variables
item_ids:
  - crazyae2addons:data_setter
---

# Data Setter

<BlockImage id="crazyae2addons:data_setter" scale="4"></BlockImage>

The **Data Setter** is a simple redstone-driven block that sets a specific **data variable** to a chosen value when it receives a redstone pulse.

## How to Use

1. **Place the block** and connect it to an ME network with a Data Controller.
2. **Right-click** to open the GUI.
3. Enter:
    - The name of the **variable** to set.
    - The **value** to assign (must be an integer).
4. Provide a **redstone pulse** to the block.
    - On the rising edge of the pulse, the variable will be stored in the controller with your value.

## Example Use Cases

- Triggering logic chains using buttons or levers.
- Sending state signals like "armed" = 1 to Displays or Processors.
- Timed logic using clocks and counters.

Only works when a valid ME Data Controller is present in the network.