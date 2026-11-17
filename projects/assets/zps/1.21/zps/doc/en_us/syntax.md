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

`<cycles>` is a whole number from 1 to 64. Anything else, or no number at all, waits one cycle.

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
#def first_line = page_contents get_line 1

write_page value_of(first_line)
```

Alias names may contain letters, digits, and `_`, and cannot start with a digit.

Declarations are read from the top of the script. Blank lines are ignored while reading declarations, and the first nonblank line that does not start with `#` ends the declaration section.

Aliases may reference aliases declared earlier:

```
#def line_1 = page_contents get_line 1
#def line_2 = page_contents get_line 2
#def combined = line_2 + "\n" + value_of(line_1)

write_page value_of(combined)
```

Later aliases with the same name replace earlier aliases for following declarations and commands.

Alias bodies must start with a getter or an earlier alias, then may continue with mappers.

---

## Variables

A variable is a value the Script Terminal keeps between lines. A Serial Bus can be asked for a value, and the terminal stores it for later lines to use, at any bus on the network.

Declare one with `#var <name> = <literal>`:

```
#var page = 1
```

- The value must be a literal: a number, `true` or `false`, or a string. Use `#def` for getters and mappers.
- A variable has no fixed type: like a literal alias, it is whatever its current value reads as. A value that does not suit the place it is used fails on that line, like any other command.
- Names follow the alias rules. A variable cannot be declared twice, and cannot share a name with an alias: whichever is lower in the script is an error.

A variable is used like an alias, wherever an expression starts. Each line carries the variable's value as it stands when the line is sent, so every bus sees the same value. An alias may use a variable declared above it, and takes its value the same way.

```
set_redstone value_of(page)
if page > 8 set_redstone 15 else set_redstone 0
```

### Asking a Serial Bus for a value

Every command the terminal sends stays on the Data Cable for one tick, then the cable goes blank until the next command. A bus can answer while it is blank:

- `request_value <value>` is an executor. The bus that runs it puts the value on the cable when the cable goes blank, for one tick. Use `if pos == ...` to pick which bus answers.
- `receive_value <name>` stores the answer to the last command sent in a variable declared above it. The terminal keeps that answer until it sends another command. Like `wait`, it works only on the Script Terminal and cannot be used with `if`, `unless` or `else`. Unlike `wait`, it takes no time: the line after it runs straight away. A looping script still takes at least 2 ticks per pass, however many free lines it has.

```
#var page = 1
if pos == @lectern request_value value_of(page_number)
receive_value page
if pos == @lamp set_redstone value_of(page)
```

`wait` and `receive_value` send nothing, so a `wait` between a `request_value` and its `receive_value` does not lose the answer.

`receive_value` stores whatever value was answered. It leaves the variable unchanged only if there is no answer, or if more than one bus answered: two answers at once are two senders, which garble the cable like any others.

Variables keep their values across loop passes, and go back to their declared literals when the script is edited and at the start of each new powered run.

---