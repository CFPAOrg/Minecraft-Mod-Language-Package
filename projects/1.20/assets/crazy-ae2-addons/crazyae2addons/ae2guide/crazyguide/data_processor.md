---
navigation:
  parent: crazyae2addons_index.md
  title: Data Processor
  icon: crazyae2addons:data_processor
categories:
  - Data Processor
item_ids:
  - crazyae2addons:data_processor
---

# Data Processor

<BlockImage id="crazyae2addons:data_processor" scale="4"></BlockImage>

The Data Processor is an advanced block that allows you to perform basic logical and mathematical operations on variables from your ME Data Controller, creating a new variable based on formula you design.

## How to Use

1. **Place the block**: Connect the Data Processor to your ME network.
2. **Input a variable**: Right click the block and type in the name of a variable you want to operate on. Must start with a `&`.
3. **Insert cards**:
    - Place [Logic Cards](logic_cards.md) into the slots.
    - Each card represents an operation that will be performed.
4. **Configure operations**:
    - Click the wrench button next to a card slot to open detailed settings.
    - Assign input values (direct numbers, other variables, or registers) and specify where the result should go.
5. **Registers**:
    - Use temporary registers (`&&0`, `&&1`, `&&2`, `&&3`) for intermediate results between operations.
6. **Outputs**:
    - You can write results into new variables inside the [ME Data Controller](me_data_controller.md). The operation will terminate on any write to the Controller's storage.
7. **Loops**:
    - The system prevents infinite loops automatically.
8. **Speed**: The system is not tick based. All updates/calculations/reads/writes happen instantly.

Use the Data Processor to create dynamic calculations, conditional outputs, and complex processing chains entirely within your ME network.