---
id: macros
---

# Macros

Macros are sections of code that can be inserted into the program where they are referenced as an instruction. Unlike a function, the entire macro is expanded and inserted into the program whenever it is referenced. Macros can also have any number of parameters that are substituted for the given arguments on expansion.

A macro is declared by surrounding instructions with %macro and %end directives:

```
%macro a_macro
    say "This is a macro"
%end
a_macro  # Expand the macro
```

Arguments are defined with a space-separated list after the macro's name. They can be referenced within the macro by prefixing their names with %:

```
%macro a_macro message something_else
    say "The message: %message"  # Replace %message
    say "%something_else"
%end
a_macro Hello there, Something else
```

As shown above, arguments supplied when expanding the macro must be separated by commas. This allows spaces in the arguments you provide. Any text can be a macro argument, including aliases.

The above example will say: 
```
The message: Hello there.
Something else
```

## More Complex Example

This example will check whether the input slots of two furnaces have less than 8 items in and will transfer 8 items from the input storage if this is the case.

```
%alias input = @(1 2 1 U)
%alias furn1 = @(1 2 3 U)
%alias furn2 = @(1 2 4 U)
%macro check_furnace furnace
    count %furnace
    push 8; gteq
    bit continue f
    move $input %furnace 8
    continue:
%end
check_furnace $furn1
check_furnace $furn2
restart
```