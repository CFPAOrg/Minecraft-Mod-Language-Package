# Mappers

Mappers always follow a getter or another mapper, and transform the previous value into a new value. 
They sometimes take an argument, which can be a literal or a `value_of()` expression.

The available mappers depend on the type of the preceding value.

---

## BlockPos

Produced by: `pos`, `string as_block_pos`, `vec_pos rounded_down`

| Mapper | Output | Description |
|--------|--------|-------------|
| `x` | Int | X coordinate |
| `y` | Int | Y coordinate |
| `z` | Int | Z coordinate |
| `center` | Vec Pos | The centered floating-point position (`x + 0.5`, `y + 0.5`, `z + 0.5`) |
| `offset_x <int>` | BlockPos | Returns a new position offset by the given amount on the X axis |
| `offset_y <int>` | BlockPos | Returns a new position offset by the given amount on the Y axis |
| `offset_z <int>` | BlockPos | Returns a new position offset by the given amount on the Z axis |
| `offset <coords>` | BlockPos | Returns a new position offset by the given coordinate components |
| `== <coords>` | Boolean | True if equal to the given position |
| `as_string` | String | Formats as `"x y z"` |

Examples:

```
if pos x > 0 set_redstone 15
set_redstone value_of(pos y & 15)
```

---

## BlockState

Produced by: `block`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <block predicate>` | Boolean | True if the block state matches the predicate (supports block properties) |
| `id` | String | The block's id, such as `"minecraft:stone"`, without its properties |

Examples:

```
if block == minecraft:stone set_redstone 15
if block == minecraft:piston[facing=up] set_redstone 15
if block id == value_of(page_contents) set_redstone 15
```

---

## Item

Produced by: `held_item`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <item predicate>` | Boolean | True if the item matches the predicate |
| `count` | Int | The stack size; `0` for an empty hand |
| `id` | String | The item's id, such as `"minecraft:stone"`; `"minecraft:air"` for an empty hand |

`==` only takes an item written in the script. To compare against text the script reads or receives, compare the `id`:

```
if held_item == minecraft:lava_bucket use 6 1 4
if held_item id == value_of(page_contents get_line 0) use 6 1 4
```

---

## Vec Pos

A floating-point position. Produced by: `pos center`, `ship pos`, `sublevel pos`

| Mapper | Output | Description |
|--------|--------|-------------|
| `x` | Double | X component |
| `y` | Double | Y component |
| `z` | Double | Z component |
| `distance_to <coords>` | Double | Distance to the given position |
| `direction_to <coords>` | Vec Dir | Normalized direction vector toward the given position |
| `rounded_down` | BlockPos | Rounds each component down to get a block position |

Examples:

```
if ship pos distance_to 0 0 0 > 100 set_redstone 15
```

---

## Vec Box

A size vector (width, height, depth). Produced by: `ship bounding_box`, `sublevel bounding_box`

| Mapper | Output | Description |
|--------|--------|-------------|
| `x` | Double | Width |
| `y` | Double | Height |
| `z` | Double | Depth |
| `volume` | Double | Total volume (x × y × z) |

---

## Vec Dir

A direction vector. Produced by: `vec_pos direction_to`, `ship world_vel`, `ship local_vel`, `ship dir`, `sublevel world_vel`, `sublevel local_vel`, `sublevel dir`, `vec_dir normalize`, `vec_dir cross`

| Mapper | Output | Description |
|--------|--------|-------------|
| `x` | Double | X component |
| `y` | Double | Y component |
| `z` | Double | Z component |
| `length` | Double | Magnitude of the vector |
| `normalize` | Vec Dir | Unit vector in the same direction |
| `cross <direction>` | Vec Dir | Cross product with another direction |
| `dot <direction>` | Double | Dot product with another direction |

---

## Int

Produced by: `pos x/y/z`, `redstone`, `page_number`, `double rounded_down/rounded_up`, `ship id`, `dimension index`, `string as_int`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <int>` | Boolean | Equality |
| `> <int>` | Boolean | Greater than |
| `< <int>` | Boolean | Less than |
| `+ <int>` | Int | Addition |
| `- <int>` | Int | Subtraction |
| `% <int>` | Int | Modulo |
| `& <int>` | Int | Bitwise AND |
| `\| <int>` | Int | Bitwise OR |
| `<< <int>` | Int | Left shift |
| `>> <int>` | Int | Right shift |
| `* <double>` | Double | Multiplication |
| `/ <double>` | Double | Division |
| `as_string` | String | Converts to string |
| `as_char` | String | The character with that code (`65 as_char` is `A`); a space for a code no character has |

Examples:

```
if redstone > 7 set_redstone 15
set_redstone value_of(page_number - 1)
set_redstone value_of(pos x & 15)
```

---

## Double

Produced by: `pos x/y/z` (Vec Pos), `vec_dir length/dot`, `vec_box volume`, `int * / `, `ship mass`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <double>` | Boolean | Equality |
| `> <double>` | Boolean | Greater than |
| `< <double>` | Boolean | Less than |
| `+ <double>` | Double | Addition |
| `- <double>` | Double | Subtraction |
| `* <double>` | Double | Multiplication |
| `/ <double>` | Double | Division |
| `rounded_down` | Int | Floor |
| `rounded_up` | Int | Ceiling |
| `as_string` | String | Converts to string |

---

## String

Produced by: `page_contents`, `script_contents`, `pos as_string`, `dimension as_string`, `int as_string`, `int as_char`, `double as_string`, `boolean as_string`, `ship slug`, `sublevel name`, `sublevel id`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <string>` | Boolean | Equality |
| `+ <string>` | String | Concatenation |
| `<+ <string>` | String | Prepends the given string |
| `lines` | Int | Splits at line breaks and returns the number of lines |
| `get_line <int>` | String | Splits at line breaks and returns the line at that index, or `""` if out of bounds |
| `remove_line <int>` | String | Splits at line breaks and removes the line at that index; unchanged if out of bounds |
| `split <string>` | String | Replaces every occurrence of the given delimiter with a line break |
| `as_int` | Int | Parse as integer |
| `as_double` | Double | Parse as double |
| `as_block_pos` | BlockPos | Parse as `"x y z"` format |
| `as_boolean` | Boolean | Parse `"true"` / `"false"` (case-insensitive) |
| `as_dimension` | Dimension | Treat as a dimension key |

In a quoted string, write a line break as `\n`, a `"` as `\"` and a `\` as `\\`. Escapes belong only to script text: a string's value holds real line breaks, and getters, executors and variables pass them on unchanged.

Examples:

```
if page_contents == "open" set_redstone 15
write_page value_of(pos as_string)
write_page value_of(pos as_string <+ "Pos: ")
set_redstone value_of(page_contents lines)
write_page value_of(page_contents remove_line 1)
write_page value_of(page_contents split ", ")
```

---

## Boolean

Produced by: any `==`, `>`, `<` comparison, `string as_boolean`

| Mapper | Output | Description |
|--------|--------|-------------|
| `&& <boolean>` | Boolean | Logical AND |
| `\|\| <boolean>` | Boolean | Logical OR |
| `as_string` | String | `"true"` or `"false"` |

Examples:

```
if pos x > 0 && value_of(pos z > 0) set_redstone 15
if page_contents == "open" || value_of(redstone > 0) set_redstone 15
write_page value_of(redstone > 7 as_string)
if page_contents as_boolean set_redstone 15
```

---

## Dimension

Produced by: `dimension`, `string as_dimension`

| Mapper | Output | Description |
|--------|--------|-------------|
| `== <dimension>` | Boolean | True if equal to the given dimension |
| `index` | Int | A stable integer index for this dimension (consistent per server session) |
| `as_string` | String | The dimension's resource location (e.g. `minecraft:overworld`) |

Examples:

```
if dimension == minecraft:the_nether set_redstone 15
set_redstone value_of(dimension index & 15)
```
