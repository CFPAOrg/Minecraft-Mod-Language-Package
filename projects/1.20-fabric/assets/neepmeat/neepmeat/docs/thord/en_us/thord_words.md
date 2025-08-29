\cat{utility}
# Utility

## . ( n1 -- )

Prints the top stack entry.

## PC ( -- n1 )

Places the current value of the program counter (the address of the currently executed instruction) on the top of the stack.

\cat{words}
# Words

## : 

Starts definition of a new word. The word's name is given by the character sequence following :.

```
: aword 123 . ;
```

## :I

Starts definition of a new immediate word. The word's name is given by the character sequence following :I.

```
:I aword 123 . ;
```

## ; 

Terminates various constructs:

- Word definitions
- Immediate word definitions
- Inline NEEPASM instructions

## :NONAME

Starts definition of a new anonymous word. When the definition ends, the address of the word is placed on the stack.

```
:noname 123 . ;

execute
```

\cat{stack}
# Stack

## DUP ( n1 -- n1 n1 )

Duplicates the top stack entry. Equivalent to NEEPASM `DUP`.

## 2DUP ( n1 n2 -- n1 n2 n1 n2 )

Duplicates the top two stack entries. Equivalent to `OVER OVER`.

## SWP ( n1 n2 -- n2 n1 )

Swaps the last two stack entries. Equivalent to NEEPASM `SWP`.

## 2SWP ( n1 n2 n3 n4 -- n3 n4 n1 n2 )

Swaps the last two pairs of stack entries.

## PICK ( x -- nx )

Copies the entry x places from the top of the stack to the top of the stack. Equivalent to NEEPASM `PICK`.

## OVER ( n1 n2 -- n1 n2 n1 )

Copies the penultimate entry to the top of the stack. Equivalent to NEEPASM `OVER`.

## 2OVER ( n1 n2 n3 n4 -- n1 n2 n3 n4 n1 n2 )

Copies the penultimate pair of entries to the top of the stack.

## ROT ( n1 n2 n3 -- n2 n3 n1 )

Moves the third stack entry to the top of the stack. Equivalent to NEEPASM `ROT`.

## DROP ( n1 -- )

Removes the top stack entry. Equivalent to NEEPASM `POP`.

## 2DROP ( n1 n2 -- )

Removes the last two stack entries.

## BLANK ( -- )

\cat{return_stack}
# Return Stack

## >R ( n1 -- ) (R: -- n1 )

Moves the top stack entry to the top of the return stack.

## 2>R ( n1 n2 -- ) (R: -- n1 n2 )

Moves the top two entries to the top of the return stack.

## R> (-- n1 ) (R: n1 -- )

Moves the top return stack entry to the top of the data stack.

## 2R> (-- n1 n2 ) (R: n1 n2 -- )

Moves the top two return stack entries to the top of the data stack.

## R@ ( -- n1 ) (R: n1 -- n1 )

Copies the top return stack entry to the data stack.

\cat{flow_control}
# Flow Control

## END ( -- )

Emits the END instruction, which stops execution. Useful as a placeholder for backpatching. Equivalent to NEEPASM `END`.

## IF ( n1 -- ) (immediate)

Jumps to the next appropriate occurrence of `ELSE` or `THEN`.

```
1 if 
    say "yes"
else
    say "no"
endif
```

## ELSE ( -- ) (immediate)

Provides an alternative branch if the argument of `IF` was false.

## ENDIF ( -- ) (immediate)

Closes an if or if-then construct.

## THEN ( -- ) (immediate)

Same as `ENDIF`.

## BEGIN ( -- ) (immediate)

Marks the start of a begin-until construct.

```
begin
    say "loop forever"
1 until
```

## UNTIL ( n1 -- ) (immediate)

Marks the end of a begin-until construct. Consumes the last stack entry and branches back to the previous `BEGIN` if it is true.

## FOR ( n1 n2 -- ) (immediate)

Begins a do-loop construct. Terminated by `LOOP` or `+LOOP`.

Checks n1 and n2 for equality and branches to the end of the loop if this is the case. Otherwise, the values are moved to the return stack and the loop begins.

The following code section will repeat until loop index reaches n1, starting at n2.

```
10 0 do i . loop
```

## LOOP ( -- ) (immediate)

Increments loop index and branches to the start of the loop if it is lower than the upper bound.

## +LOOP ( n1 -- ) (immediate)

Adds the top stack entry to loop index and branches to the start of the loop if it is lower than the upper bound.

```
10 0 do i . 2 +loop
```

## I ( -- n1 )

Copies the loop index to the data stack. Identical to `R@` in this implementation.

\cat{arithmetic}
# Arithmetic

## + ( n1 n2 -- result )

Adds the top two stack entries. Equivalent to NEEPASM `ADD`.

## - ( n1 n2 -- result )

Subtracts n2 from n1. Equivalent to NEEPASM `SUB`.

## * ( n1 n2 -- result )

Multiplies n1 and n2. Equivalent to NEEPASM `MUL`.

## / ( n1 n2 -- result )

Divides n1 by n2. Equivalent to NEEPASM `DIV`. Produces incorrect results if n2 is 0.

## NEG ( n1 -- result )

Inverts the sign of the top stack entry.

## INVERT (n1 -- result )

Inverts all bits of the top stack entry.

\cat{comparison}
# Comparison

## = ( n1 n2 -- result )

Tests n1 and n2 for equality. Returns -1 if true and 0 if false. Equivalent to NEEPASM `EQ`.

## < ( n1 n2 -- result )

Tests if n1 is less than n2. Equivalent to NEEPASM `LT`.

## < ( n1 n2 -- result )

Tests if n1 is greater than n2. Equivalent to NEEPASM `GT`.

## <= ( n1 n2 -- result )

Tests if n1 is less than or equal to n2. Equivalent to NEEPASM `LTEQ`.

## >= ( n1 n2 -- result )

Tests if n1 is greater than or equal to n2. Equivalent to NEEPASM `GTEQ`.

\cat{memory}
# Memory

## VARIABLE ( "name" -- )

Allocates a new variable with the name that follows.

Invoking the variable's name pushes its address to the stack.

```
variable v

# Store 123
123 v !

v ? # result: 123
```

## ARRAY ( "name" size -- )

Allocates an array of the following name and size.

Note that size of the array follows the word, rather than preceding it. All elements are initialised to zero.

```
# Create an array of 6 elements
array a 6

# Set the third element to 123
123 a 2 + !

# Print the third element
a 2 + ?
```

## ! ( n1 addr -- )

Stores n1 at the given address.

## @ ( addr -- n1 )

Retrieves the data at the given address.

## ? ( addr -- )

Prints the data stored at the given address. Equivalent to @ .

## ' ( "word" -- addr )

Pushes the address of the following word to the stack.

```
: aword 1 + . ;

# Print the word's address
' aword .
```

## EXECUTE ( addr -- )

Branches to the instruction at the given address. Equivalent to NEEPASM `CALL`.

\cat{compiler_words}
# Compiler Words

## CPHEAD ( -- head )

Places the current number of emitted instructions onto the stack. This corresponds to the index of the next emitted instruction.

## CPJMP ( offset jump -- )

Emits a `JMP` instruction at offset n1 from the current head position. The instruction's argument is n2.

## CPBIF ( offset jump -- )

Emits a `BIF` instruction at offset n1 from the current head position. The instruction's argument is n2.

## CPBIT ( offset jump -- )

Emits a `BIT` instruction at offset n1 from the current head position. The instruction's argument is n2.
