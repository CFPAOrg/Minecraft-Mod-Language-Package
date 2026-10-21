---
id: thord_data_types
---

# Data Types in THORD

The PLC's stack can hold various different data types. Some data types can be converted into other ones with special words.

## INT

Represents an integer, such as 0, 1, or -1. Also used for booleans, where -1 represents TRUE and 0 represents FALSE.

Conversion words:

- `>STR` (converts to string)

Common operators:

```
# Add and subtract
1 1 + # Gives 2
1 1 - # Gives 0

# Multiply and divide
2 10 * # Gives 20
10 5 / # Gives 2
```

## STRING

Represents a sequence of characters, such as "hello", or "how are you".

Conversion words:

- `>INT` (converts to int, will error if the string does not look like an int)

Mathematical operators:

```
# Add (concatenate)
"Hello " "there." + # Gives "Hello there."
```

## WORLD_TARGET

Represents a world target consisting of coordinates and a direction.

A few instructions (such as `BPLACE` and `BBREAK` can take world targets from the stack. Most instructions that interact with the world do not.

Conversion words:

- `>STR` (converts to string)

Mathematical operators:

```
# Multiply and divide by integer 
@(1 2 3) 10 * # Gives @(10 20 30)

# Add and subtract
@(1 2 3) @(10 10 10) + # Gives @(11 12 13)
```

## ADDRESS

Conversion words:

- `>STR` (converts to string)


Mathematical operators:

- Same as INT.