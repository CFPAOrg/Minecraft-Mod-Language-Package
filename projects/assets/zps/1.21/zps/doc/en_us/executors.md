# Executors

Executors perform an action on the target block. Each takes one argument, which can be a literal or a `value_of()` expression.

Some executors are only available for specific block types. If the target block is not compatible, the executor is silently skipped.

---

## All Blocks

Available on: any target block

| Executor       | Argument | Description                                     |
|----------------|----------|-------------------------------------------------|
| `set_redstone` | `<0-15>` | The Serial Bus emits a redstone signal into the target block, like a repeater facing it. |
| `request_value` | `<value>` | The Serial Bus answers with the value, for a Script Terminal's `receive_value`. See [Variables](syntax.md#variables). |

Examples:

```
set_redstone 15
set_redstone value_of(page_number - 1)
if pos == @lectern request_value value_of(page_number)
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

## Script Terminal

The following command requires the target block to be a `Script Terminal`.

| Executor      | Argument   | Description |
|---------------|------------|-------------|
| `load_script` | `<string>` | Replaces the terminal's script, as if a player loaded it from a `.mungus` file. |

The string's lines are the script's lines; in a quoted string, write a line break as `\n`. If the first line is a header such as `# 4t REPEAT` or `# 8t IMPULSE`, it sets the terminal's delay and mode and is not part of the script. Without a header, the terminal keeps its current delay and mode. A header delay other than 2, 4, 8 or 16 keeps the current delay.

Inside a quoted string, write `"` as `\"` and `\` as `\\`, so an escape inside the loaded script is written `\\n`. A value from `value_of()` needs no escaping: its line breaks and backslashes arrive as they are. Loading the script the terminal already has, with the same delay and mode, changes nothing. Scripts over 32500 characters are skipped, and one line on the cable holds at most 3600 characters.

Examples:

```
load_script "# 4t REPEAT\nif redstone > 0 set_redstone 15"
load_script "write_page \"hi (there)\""
load_script value_of(code)
```

Copying one terminal to another, with a Serial Bus facing each:

```
#var code = none
if pos == @source request_value value_of(script_contents)
receive_value code
if pos == @copy load_script value_of(code)
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
| `break`       | `<x y z>` | Breaks the target block at once, as if mining it with an iron pickaxe. Drops go into the hand.     |
| `silk_break`  | `<x y z>` | Like `break`, but with a silk touch iron pickaxe, so the block itself drops (glass, stone, ores).  |
| `set_transfer_count` | `<int>` | Sets the maximum stack size moved by `take_items`, `put_items`, and `drop_items` (1-64). |

`take_items`, `put_items`, and `drop_items` move at most the **transfer amount** configured in the arm's GUI (1–64) per instruction; any remainder stays in the arm's hand. `use` and `shift_use` interact with the held item and do not transfer a quantity.

`break` and `silk_break` only break blocks an iron pickaxe can mine; the hand still moves to anything else but leaves it. Drops that don't fit in the hand fall into the world.

Examples:

```
take_items 1 3 5
put_items 0 1 2
set_transfer_count 16
drop_items 0 2 2
break 1 1 3
silk_break 1 2 3
```

```
use 0 1 2
use value_of(pos offset_y 1)
```

---

## Additional Executors

- [Create](create.md) — auto-generated executors for Create mod blocks (`set_rpm`, `set_filter`, `set_rotation_mode`, ...)
