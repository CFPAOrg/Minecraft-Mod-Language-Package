# Getters

Getters retrieve a value from the world or context. They take no arguments and are always the first element in a condition or `value_of()` expression.

Some getters are only available for specific block types.

---

## All Blocks

Available on: any target block

| Getter | Output | Description |
|--------|--------|-------------|
| `pos` | BlockPos | The position of the target block. |
| `block` | BlockState | The block state at the target position. |
| `dimension` | Dimension | The dimension the target block is in, as a dimension key such as `minecraft:overworld`. |
| `redstone` | Int | The strongest redstone signal received by the target block from any neighbor. |

Examples:

```
if pos == 0 64 0 set_redstone 15
set_redstone value_of(pos x & 15)
```

```
if block == minecraft:piston[facing=up] set_redstone 15
```

```
if dimension == minecraft:the_nether set_redstone 15
```

```
if redstone > 7 set_redstone 15 else set_redstone 0
set_redstone value_of(redstone + 1)
```

---

## Data Lectern / Lectern

The following getters require the target block to be a `Data Lectern` or a vanilla `Lectern` with a book.

| Getter | Output | Description |
|--------|--------|-------------|
| `get_page` | Int | The current page number of the book, 1-based. Returns `0` if there is no book. |
| `read_page` | String | The text content of the current page. Returns an empty string if there is no book or the page is blank. |

Examples:

```
if get_page > 3 set_redstone 15
set_page value_of(get_page + 1)
```

```
if read_page == "open" set_redstone 15
write_page value_of(read_page + " (edited)")
```

---

## Robotic Arm

The following getter requires the target block to be a `Robotic Arm`.

| Getter      | Output | Description                                                                |
|-------------|--------|----------------------------------------------------------------------------|
| `held_item` | Item   | The item currently held in the arm's hand. Returns an empty stack if the hand is empty. |
| `transfer_count` | Int | The maximum stack size moved by `take_items`, `put_items`, and `drop_items`. |

The resulting Item can be compared against an item predicate with `==`, or its stack size read with `count`.

Examples:

```
if held_item == minecraft:lava_bucket use 6 1 4
```

```
if held_item count > 0 put_items 0 1 2 else take_items 1 3 5
```

```
if transfer_count < 16 set_transfer_count 16
```

---

## Radio Transmitter / Radio Receiver

The following getter requires the target block to be a `Radio Transmitter` or `Radio Receiver`.

| Getter      | Output | Description                                                       |
|-------------|--------|-------------------------------------------------------------------|
| `frequency` | Int    | The radio channel the block is tuned to (an integer from 1 to 64). |

Examples:

```
if frequency == 10 set_redstone 15
set_frequency value_of(frequency + 1)
```

---

## Power Cell

The following getter requires the target block to be a `Power Cell` or `Creative Power Cell`.

| Getter          | Output | Description                                                                 |
|-----------------|--------|-----------------------------------------------------------------------------|
| `stored_energy` | Int    | The FE stored in the power cell structure. Every cell of a multiblock reads the same pooled total. A `Creative Power Cell` reads as the largest Int. |

Examples:

```
if stored_energy < 100000 set_redstone 15 else set_redstone 0
```

---

## Gas Gauge

The following getter requires the target block to be a `Gas Gauge`.

| Getter        | Output | Description                                                                 |
|---------------|--------|-----------------------------------------------------------------------------|
| `gauge_value` | Double | The reading the gauge's dial is set to show: pressure in Pascals or temperature in Kelvin. The value is not scaled or clamped to the dial's range. Changing the gauge's mode changes what this reads. |

Examples:

```
if gauge_value > 8000000 set_redstone 15 else set_redstone 0
```

---

## Additional Getters

- [Sable](sable.md) — `sublevel`
