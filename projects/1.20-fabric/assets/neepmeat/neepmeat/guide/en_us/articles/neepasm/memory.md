---
id: memory
---
# Memory

```
# Put 123 on the variable stack
push 123 

dup; say # 123

# Store the top stack value in memory.
# The address of the stored entry is put on the stack.
store

dup; say # > 1

# Retrieve the value at the address and put it onto the stack.
dup
fetch
swp
free # Free the memory

dup; say # > 123
```