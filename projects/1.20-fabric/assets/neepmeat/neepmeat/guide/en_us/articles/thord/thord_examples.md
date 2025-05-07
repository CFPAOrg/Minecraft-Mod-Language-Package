---
id: thord_examples
---

# General

## Variables

```
variable v

# Assign
123 v !

# Get and print
v @ .
```

## Fibonacci Sequence

```
: fibonacci
  0
  0 1
  2swp
  
  do
    dup
    rot
    add
    dup .
  loop

  2drop
;

100 fibonacci
```

# Logistics

## Waiting for 10 bones in a container

```
begin
    delay 10
    count @(1 2 3 U) "minecraft:bone"
    10 <= invert 
until
    say "done"
```

## A macro that waits for a number of items in a container

```
%: wait_item container item amount
begin
    count %container %item
    %amount <= invert
until
%;

wait_item @(1 2 3 U), "minecraft:bone", 10
;
```

# Compile Time Words

## Defining if-else

THORD's compile time evaluation allows the creation of custom flow control constructs. 

This program demonstrates how THORD's if-else-then construct is implemented.

```
:i pcphead
  postpone cphead ;
;

:i if1
  postpone cphead blank ; # bif placeholder
;

:i endif1
  dup -1 = .bif ifend ; # -1 indicates else
  label ifelse
    drop # get rid of -1 
    postpone cphead ; 
    - dup neg 
    postpone cpjmp ;
    .jmp end f ;
  label ifend
    postpone cphead ; 
    - dup neg 
    postpone cpbif ;
  label end 
;

:i else1
  postpone cphead ;
  - dup neg .inc ; 
  postpone cpbif ; # backpatch bif
  postpone cphead blank ; # jmp placeholder
  -1 # tell then to backpatch jmp
;

# Test the words
1
if1
  .say "yes" ; 
else1
  .say "no" ;
endif1g
```