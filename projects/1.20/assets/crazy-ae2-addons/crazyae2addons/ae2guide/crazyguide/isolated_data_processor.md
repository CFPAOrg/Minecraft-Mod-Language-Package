---
navigation:
  parent: crazyae2addons_index.md
  title: Isolated Data Processor
  icon: crazyae2addons:isolated_data_processor
categories:
  - Data Variables
item_ids:
  - crazyae2addons:isolated_data_processor
---

# Isolated Data Processor

<BlockImage id="crazyae2addons:isolated_data_processor" scale="4"></BlockImage>

The Isolated Data Processor is a high-speed logic block that works similarly to the standard Data Processor but executes its logic continuously every tick on its own without waiting for external triggers.

## How to Use

1. **Place the block**: Connect the Isolated Data Processor to your ME network.
2. **Insert cards**:
    - Put [Logic Cards](logic_cards.md) into the processor.
3. **Configure operations**:
    - Use the wrench button next to each slot to open the settings.
    - Assign inputs (registers, constants, or variables) and define the output.
4. **Registers**:
    - Four internal temporary registers (`&&0` to `&&3`) are available for intermediate results.
5. **Looping logic**:
    - Every tick, the processor automatically reads the next card and executes the associated operation.
    - Conditional jump cards (HIT, HIF) allow skipping to other slots dynamically.
6. **Multiple writes**: It wont stop on a write to [ME Data Controller](me_data_controller.md).

Because it runs independently and constantly, the Isolated Data Processor is perfect for creating always-on logic like counters or timers.