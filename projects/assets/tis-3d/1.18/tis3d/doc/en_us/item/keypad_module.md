# Keypad Module
![Push the button!](item:tis3d:keypad_module)

The keypad module allows basic user-interfacing with a TIS-3D computer system. It permits the input of single digits, which are then written to the ports of the keypad module.

While a value was input and not read, the keypad module writes the last input value to all four of its ports until it was read.

An input value can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one [controller](../block/controller.md) cycle, only one will succeed. While a value is being transferred, no further values can be input, which is usually also visually indicated, but may vary based on vendor and series.
