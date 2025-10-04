---
id: thord_constructs
---

# Constructs

## IF-ELSE-THEN

Conditional execution is more streamlined in THORD than in NEEPASM.

`IF` consumes the last stack entry. If it is true (not 0), execution will continue. Otherwise, execution will branch forwards to the next occurrence of `ELSE` or `ENDIF`.

If constructs must be terminated with the word `ENDIF` or `THEN`.

```
-1 # -1 is true
if
    say "yes"
endif
```

`ELSE` is used to create a branch that will be executed only if the condition is false.

```
0
if
    say "yes"
else
    say "no"
endif

```

## BEGIN-UNTIL (while loop)

The begin-until construct is like a while loop in C-style languages. It executes a section of code repeatedly while a condition is true.

```
begin
    say "loop"
# -1 means true
-1 until
```

## DO-LOOP (for loop)

The do-loop construct approximates a for loop in C-style languages. It is used for executing a section of code a specified number of times.

`DO` takes two parameters: the number of loops and the loop index's initial value. It stores these values on the control stack, not the data stack.

The word `I` copies the loop index to the top of the stack.

`LOOP` increments the loop index by one and branches to the beginning of the loop if loop index < number of loops.

```
10 0 do i . loop
# prints 0 1 2 3 4 5 6 7 8 9
```

`+LOOP` can be used instead of `LOOP`. It adds the last value on the stack to the loop index.

```
10 0 do i . 2 +loop
# prints 0 2 4 6 8
```
