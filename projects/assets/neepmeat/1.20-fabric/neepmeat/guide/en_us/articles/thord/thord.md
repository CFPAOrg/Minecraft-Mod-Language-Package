---
id: thord
---

# THORD

THORD is a progamming language for the PLC at a slightly higher level than NEEPASM. It has a more concise syntax as well as constructs for loops and conditional statements.

# Stack

Unlike NEEPASM, the syntax for stack manipulation is much simpler.

To push a number to the stack, it is simply stated. As Thord does not care about newlines or expression separators, multiple numbers can be pushed on the same line.

Consider the following program:

```
# Push the numbers 1, 2, 3 and 4 to the stack,
# Add them all together and print
1 2 3 4 + + + .
```

In NEEPASM, the above program would look like this:

```
push 1
push 2
push 3
push 4
add
add
add
say
```

# Words

Words are Thord's equivalent of functions. They contain a sequence of operations that can be reused.

A word definition starts with ':' followed by the word's name. The definition is terminated with a ';'.

```
# Adds one to the previous stack entry and prints it.
: aword 1 + . ;

# Invoke the word
1 aword
```