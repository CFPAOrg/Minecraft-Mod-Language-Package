---
id: thord_inline
---

# Inline NEEPASM

As not all operations that a PLC can perform are covered in THORD's base dictionary, NEEPASM instructions can also be executed.

This gives access to crafting operations such as `COMBINE`, `IMPLANT` and `MOVE`.

The inline operation must be the first thing on that line, or be prefixed with a '.'.

```
label l

.jmp l ; # valid

jmp l # also valid
```

Unlike Thord words, the operation's arguments are parsed until the line ends or a ';' is encountered.

```
# Inline NEEPASM
robot @(-10 -60 11 U)

# Thord while loop
begin
  # Thord words can be referenced like NEEPASM labels.
  ihandler @(-12 -60 14 U) request
  iwait
-1 # Push -1 (true) to loop endlessly 
until 

# Define the word 'request'
: request
  route @(-12 -60 12 W) @(-10 -60 13 E) "*:stone"  
  .
;
```