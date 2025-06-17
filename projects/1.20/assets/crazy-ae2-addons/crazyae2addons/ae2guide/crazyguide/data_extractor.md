---
navigation:
  parent: crazyae2addons_index.md
  title: Data Extractor
  icon: crazyae2addons:data_extractor
categories:
  - Data Variables
item_ids:
  - crazyae2addons:data_extractor
---

# Data Extractor

The Data Extractor is a specialized part that reads numeric data from the adjacent block entity and sends these values into your ME network as variables. It works together with the ME Data Controller to store dynamic data like machine progress, energy levels, or anything else.

## How to Use

1. **Place the part**: Attach the Data Extractor to an ME cable on the side facing the block entity you want to monitor.
2. **Ensure a Data Controller**: Your network needs a [ME Data Controller](me_data_controller.md) somewhere in the same network to receive extracted variables.
3. **Open its GUI**: Right click the part to view the available data paths.
4. **Fetch available data**: Click the **Fetch** button to scan the target block entity. The top list will show all numeric fields.
5. **Select data**: Use the numbered buttons to choose which data value to extract.
6. **Name your variable**: Enter a variable name (ASCII only, and must start with a `&`) in the text field and click **Save**. This will label the data inside the ME Data Controller.
7. **Set extraction delay**: Enter the number of ticks between reads in the **Delay** field (default 20) and save.

Once configured, the Data Extractor will periodically read the chosen value and send it (with a unique identifier) to the ME Data Controller, where you can later use it in your various logic systems.