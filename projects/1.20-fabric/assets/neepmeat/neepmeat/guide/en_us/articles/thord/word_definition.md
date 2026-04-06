---
id: word_definition
---

# Defining THORD Words

Words are the equivalent of functions. Most character sequences form a valid word name.

A word definition starts with ':' followed by the word's name. The definition is terminated with a ';'.

```
# Adds one to the previous stack entry and prints it.
: aword 1 + . ;

# Definitions can span multiple lines
: another
  2
  +
  .
;

# Invoke the word
1 aword
1 another
```

Words take arguments from the stack can return multiple values by putting them on the stack:

```
: dupadd1 ( n1 -- n1 n2 ) 
    dup 1 + 
;

123 dupadd1 . .
# 123 124
```

Optionally, the name of a word can be followed by any comment within brackets () for documenting the word's stack effects.

The format is ( items taken from stack -- items put on stack ). 

For multiple elements, the rightmost is the top of the stack:

( n1 n2 n3 -- )
 n1 n2 n3 <- top of stack

```
# Takes two elements and returns one
: sum ( n1 n2 -- sum )
    +
;

1 2 sum .
```

# Immediate Words

Immediate words can be used to change the state of the compiler or as macros. They are invoked by the compiler as soon as they are seen. 

An immediate word definition starts with ':i' and ends with ';'.

```
# This will push 123 to the COMPILER'S data stack.
:i imm1 123  . ;

: word1 imm1 ; 

# Does nothing as imm was invoked during compilation
word1
```

# POSTPONE

The `POSTPONE` directive is used within immediate words. It indicates that the following sequence of words will be compiled and executed at runtime, rather than immediately during compilation.

POSTPONE will apply to everything between it and the next ';'.

This allows the creation of macros without the (minor) runtime overhead of a normal word.

```
# This will push 123 to the PLC'S data stack.
:i imm2 postpone 123 ; ;

: word2 imm2 ;

# Pushes 123 and prints it at runtime
word2
```

# :NONAME

`:NONAME` allows the creation of a word that is not referenced with by a name. Instead, its address is put on the stack. The word can be executed using `EXECUTE`.

```
:noname 123 . ;

execute
```