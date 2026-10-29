# Executors

Executors perform an action on the target block. Each takes one argument, which can be a literal or a `value_of()` expression.

Some executors are only available for specific block types. If the target block is not compatible, the executor is silently skipped.

---

## All Blocks

Available on: any target block

| Executor       | Argument | Description                                     |
|----------------|----------|-------------------------------------------------|
| `set_redstone` | `<0-15>` | Provides a redstone signal to the target block. |

Examples:

```
set_redstone 15
set_redstone value_of(get_page - 1)
```

---

## Data Lectern / Lectern

The following commands require the target block to be a `Data Lectern` or a regular `Lectern` with a book.

| Executor     | Argument   | Description                                                          |
|--------------|------------|----------------------------------------------------------------------|
| `set_page`   | `<1-100>`  | Sets the current page of the book in the lectern. Pages are 1-based. |
| `write_page` | `<string>` | Writes text to the current page, replacing its existing content.     |

Examples:

```
set_page 1
set_page value_of(redstone + 1)
```

```
write_page "Hello, world!"
write_page value_of(dimension as_string)
```

---

## Radio Transmitter / Radio Receiver

The following command requires the target block to be a `Radio Transmitter` or `Radio Receiver`.

| Executor        | Argument      | Description                                   |
|-----------------|---------------|-----------------------------------------------|
| `set_frequency` | `<frequency>` | Sets the radio channel the block is tuned to (an integer from 1 to 64). |

Example:

```
set_frequency 10
```

---

## Robotic Arm

The following commands require the target block to be a `Robotic Arm`.

Unlike other executors, the argument is a **block position** (`x y z`) telling the arm which block to act on, not a value applied to the arm itself. The arm first swings its hand to that position, then performs the action. The target must be within 4 blocks of the arm; positions out of range are skipped. The arm can only accept commands that require it to move `once every 16 ticks`.

| Executor      | Argument  | Description                                                                                       |
|---------------|-----------|---------------------------------------------------------------------------------------------------|
| `take_items`  | `<x y z>` | Pulls items from the inventory at the target position into the arm's hand.                         |
| `put_items`   | `<x y z>` | Deposits the arm's held items into the inventory at the target position.                           |
| `use`         | `<x y z>` | Right-clicks the target with the held item (place a block, fill/empty a bucket, use an item, ...). |
| `shift_use`   | `<x y z>` | Sneak right-clicks the target with the held item.                                                  |
| `drop_items`  | `<x y z>` | Drops held items into the world at the target position as item entities.                           |
| `set_transfer_count` | `<int>` | Sets the maximum stack size moved by `take_items`, `put_items`, and `drop_items` (1-64). |

`take_items`, `put_items`, and `drop_items` move at most the **transfer amount** configured in the arm's GUI (1–64) per instruction; any remainder stays in the arm's hand. `use` and `shift_use` interact with the held item and do not transfer a quantity.

Examples:

```
take_items 1 3 5
put_items 0 1 2
set_transfer_count 16
drop_items 0 2 2
```

```
use 0 1 2
use value_of(pos offset_y 1)
```

---

## Additional Executors

- [Create](create.md) — auto-generated executors for Create mod blocks (`set_rpm`, `set_filter`, `set_rotation_mode`, ...)
