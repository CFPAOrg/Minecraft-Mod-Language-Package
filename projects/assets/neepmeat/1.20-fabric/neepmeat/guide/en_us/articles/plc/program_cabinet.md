---
id: program_cabinet
lookup: neepmeat:program_cabinet, neepmeat:program_card
---

# Program Disks

Program disks can be used to transfer programs (and source code) form one PLC to another.

To save a PLC's current program to a disk, click on the PLC while holding the disk.

To load a disk's program onto a PLC, sneak-click the PLC while holding it.

Clicking anywhere else while holding a disk allows changing the program's name. The program's name can be used to look up and run the entire program.

# Program Cabinet

A program cabinet is a program memory module. It provides some memory segments that can contain executable instructions for the PLC.

PLCs can access program disks stored in adjacent cabinets, and can execute their contents.

Each cabinet has 30 slots, each of which can hold a single program. Each slot takes up a single memory segment.

When using multiple cabinets, it is important to configure their memory offsets so that they do not overlap. Each segment must be uniquely addressable, and problems will arise if a PLC encounters multiple segments with the same offset.

# Executing Programs in a Cabinet

In this context, a *symbol* is an execution address that can be looked up from its name. 

When a program is stored in a cabinet, all the words defined in that program (and the program's name) become accessible symbols to the connected PLC. The execution address of a word can be looked up using that word's name.

The list of symbols that a program contains can be seen in the tooltip of the program card.

To execute a program stored in a cabinet, the `'` or `DYCALL` words can be used.

- ' takes a string from the stack and finds the address of the corresponding symbol.
- DYCALL takes a string from the stack, locates the symbol and calls it as though it were a word.

## Example 1

The following program defines the word `PRINT_HELLO`. It has been saved to a program card and is stored in a cabinet

```
: print_hello "Hello" . ; 
```

`print_hello` can be executed by a PLC's main program like this:

```
"print_hello" dycall
```

This is equivalent to

```
"print_hello" ' .call
```

## Example 2

As a program's name is also an exported symbol, an entire program can be executed like a word. The following program is stored on a disk and its name has been set to `print_hello`.

```
"Hello there" .
ret
```

Note the `RET` instruction at the end of the program. This will instruct the PLC to return to the original point where the program was *called*.

Now the PLC's main program can locate and call the symbol in the same way as the previous example:

```
"print_hello" dycall
```