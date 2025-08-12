---
navigation:
  parent: crazyae2addons_index.md
  title: ME Data Controller
  icon: crazyae2addons:me_data_controller
categories:
  - Data Variables
item_ids:
  - crazyae2addons:me_data_controller
---

# ME Data Controller

<BlockImage id="crazyae2addons:me_data_controller" scale="4"></BlockImage>

The ME Data Controller is the heart of Crazy AE2 Addons data system. It stores network variables extracted by [Data Extractor](data_extractor.md) and allows other blocks (like [Display](display.md), [Data Tracker](data_tracker.md) or [Data Processor](data_processor.md)) to use them.

## How to Use

1. **Place the block**: Connect the ME Data Controller to your ME network.
2. **Expand storage**:
    - Insert AE Cell Components into the controllers slots.
    - Each 1K of a Cell Component equals 1 variable of storage (16K = 16 variables, etc.).
3. **Automatic Management**:
    - Some blocks on your network send variables into the controller.
    - All blocks monitoring that variable get instantly updated when the value changes.

Keep exactly one ME Data Controller in your network if you want to use data variable feature of Crazy AE2 Addons.