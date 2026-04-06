---
id: thord_stack
---

# The Stack

The stack is how a PLC stores numbers that are currently in use by a program. It is a last-in-first-out data structure. This means that the last number to go on the stack will be the first one that can be taken off it. 

Consider it like a stack of papers. You can add more paper and take paper off, but you can't easily take or add paper from the middle or the bottom.

Arithmetic operations take their arguments from the stack. The following program will add the numbers 1 and 2: 

```
1 2 +
```

- First, the numbers 1 and 2 are put onto the stack. 
- The + word removes the two topmost stack elements and adds them.
- The result is put onto the stack.

For some words, such as the division operator, the order of stack elements is important.

The / word will take the second stack element and divide it by the first:

```
6 3 / # gives 2
3 6 / # gives 0 due to integer division
```