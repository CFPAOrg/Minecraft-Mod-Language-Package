# Syntax

The Script Terminal lets you automate blocks using a simple, line-based scripting language.

Each line is a command. When the terminal receives a redstone signal, it dispatches each command in order.

---

## How It Works

Commands are built up of chainable parts:

| Part       | Purpose                                                                       |
| ---------- | ----------------------------------------------------------------------------- |
| `Executor` | Performs an action on the target block. Always takes an argument.             |
| `Getter`   | Reads a value from the world or target block. Never takes an argument.        |
| `Mapper`   | Transforms the current value into another value. Sometimes takes an argument. |

The simplest valid command is an executor with its associated argument:

```
set_redstone 15
```

Here `set_redstone` is the executor and `15` is its argument.

---

## Conditionals

Use `if` or `unless` before an executor to make it conditional:

```
if <condition> <executor>
unless <condition> <executor>
```

The `condition` is a getter → mapper chain that produces a Boolean value (`true` or `false`).

- `if` runs the executor when the condition is `true`
- `unless` runs the executor when the condition is `false`

Example:

```
if redstone > 7 set_redstone 0
```

Here, `redstone > 7` is the condition.  
If it evaluates to `true`, the executor `set_redstone` runs with argument `0`.

I.e. this command sets redstone to 0 only if the target block is receiving a signal strength of 8 or higher.

---

## Conditionals with alternatives

Add `else` to provide an alternative if the condition fails:

```
if <condition> <executor> else <executor>
unless <condition> <executor> else <executor>
```

- For `if`:
    - If the condition is `true`, the first executor runs
    - If the condition is `false`, the second executor runs

- For `unless`:
    - If the condition is `false`, the first executor runs
    - If the condition is `true`, the second executor runs

Example:

```
if redstone > 7 set_redstone 0 else set_redstone 15
```

Here, `redstone > 7` is the condition.

- If it evaluates to `true`, `set_redstone 0` runs
- If it evaluates to `false`, `set_redstone 15` runs

This command sets redstone to 0 when the signal strength is 8 or higher, and 15 otherwise.

---

## Wait

Use `wait <cycles>` to pause execution for a number of cycles:

Example:

```
set_redstone 15
wait 2
set_redstone 0
```

`wait` behaves like an executor, but cannot be used with `if`, `unless`, or `else`.

It always runs when reached, and delays the dispatch of following commands.

---

> The remaining concepts are more advanced and are not required to get started. It is recommended to become familiar 
> with the above material before continuing, and return to these topics as needed.

---

## Coordinate Types

Arguments support Minecraft's relative (`~`) and local (`^`) coordinate syntax, resolved relative to the terminal's position.

Examples

```
if pos == ~ ~1 ~ set_redstone 15
if pos == ^3 ^ ^-12 set_redstone 0
```

The coordinates are resolved when the command is dispatched, not when it's executed.

---

## Addresses

Typing out coordinates by hand is error-prone, especially when using many positions at once. The **Address Pad** lets you save block positions under memorable names and refer to them in scripts with a `@name` token.

**Saving addresses** — hold an Address Pad and:

- **Right-click a block** to save its position as a new address (up to 15 per pad).
- **Right-click the air** to open a screen for renaming and removing saved addresses.

Address names may contain letters, digits, `.`, and `_`.

**Using addresses** — right-click a Script Terminal with the Address Pad to attach it. Once attached, any of its saved addresses can be used wherever a coordinate argument is expected, by writing `@` followed by the name:

```
take_items @input_chest
put_items @furnace
if block == minecraft:lava_cauldron use @bucket_dropoff
```

Each `@name` is substituted with the saved position's absolute `x y z` coordinates when the command is dispatched, exactly as if you had typed them out.

> **Addresses only work from a Script Terminal with an attached Address Pad.** They are resolved by the terminal using its pad, so a `@name` token will *not* resolve from other command sources such as command blocks or chat — only literal coordinates and the `~` / `^` syntax work there.

---

## value_of()

Use `value_of(...)` in place of a literal argument to compute a value at runtime:

Example:

```
set_redstone value_of(pos y - 50)
```

The expression inside can be any getter → mapper chain, so long as it returns the required argument type.

---

## Expression Aliases

Use `#def <name> = <expression>` at the top of a script to give a reusable name to a getter → mapper chain:

```
#def first_line = read_page get_line 1

write_page value_of(first_line)
```

Alias names may contain letters, digits, and `_`, and cannot start with a digit.

Declarations are read from the top of the script. Blank lines are ignored while reading declarations, and the first nonblank line that does not start with `#` ends the declaration section.

Aliases may reference aliases declared earlier:

```
#def line_1 = read_page get_line 1
#def line_2 = read_page get_line 2
#def combined = line_2 + "\n" + value_of(line_1)

write_page value_of(combined)
```

Later aliases with the same name replace earlier aliases for following declarations and commands.

Alias bodies must start with a getter or an earlier alias, then may continue with mappers.

---
