---
id: thord_macros
---

# Macros in THORD

Unlike normal or immediate words, macros are expanded before any parsing takes place. This allows arbitrary text substitution with no runtime overhead.

A macro definition starts with '%:' followed by the macro's name. It is terminated with '%;'.

```
%: macro1 r1
    1 2 3 %r1 + + +
%;

macro1 4
.
# 1+2+3+4
```

## Arguments

A list of space-separated arguments can be given after the macro's name. Within the macro's text, an argument can be accessed by prepending %.

When expanding a macro, arguments are given in a comma-separated list. Spaces can be present in an argument.

```
:% macro1 arg1 arg2
    say %arg1
    %arg2
%;

# Any text can be passed as an argument. 
macro1 "something to say", 123 .
```

## Expansion

When a macro is expanded, it is inserted directly into the source code.

```
%: macro1
    1 + .
%;

1
macro1
```

Is equivalent to:

```
1
1 + .
```

## Complex Example

This example will keep more than eight items in each of the target blocks.

```
%: check side 
  count %side
  8 <
  if
    move @(-28 -60 -20 U) %side 8
  endif
%;

robot @(-27 -60 -18 U)

begin
  check @(-28 -60 -16 N)
  check @(-27 -60 -16 N)
  check @(-26 -60 -16 N)
  
  delay 20
-1 until
```