---
id: thord
---

# THORD

THORD is a progamming language for the IMC at a slightly higher level than NEEPASM, although all NEEPASM instructions are still available. It has a more concise syntax as well as constructs for loops and conditionals.

# Stack

Unlike NEEPASM, the syntax for stack manipulation is much simpler.

To push a number to the stack, it is simply stated. As Thord does not care about newlines or expression separators, multiple numbers can be pushed on the same line.

Consider the following program:

```
# Push the numbers 1, 2, 3 and 4 to the stack,
# Add them all together and print
1 2 3 4 + + + .
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

# Inline NEEPASM

THORD accepts inline NEEPASM instructions so that all the IMC's crafting operations are available. Instructions are prepended by a '.' as they are different to regular words. This can be omitted at the start of a line.

```
# Valid THORD
1 1 + .
combine @(1 2 3 U) @(4 5 6 D)
.combine @(2 2 3 U) @(4 5 6 D)
```
