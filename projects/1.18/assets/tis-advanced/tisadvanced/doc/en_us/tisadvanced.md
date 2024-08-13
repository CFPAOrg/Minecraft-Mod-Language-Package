# TIS Advanced

TIS Advanced features include five new modules, and twelve new instructions for the Execution Module. Several times throughout the module documentation, the bits of a 16-bit number are referred to by their position. In these cases, they are numbered according to Msb0 convention, where the most significant bit is bit 0, and subsequent bits are numbered in order of decreasing significance.

## New Modules

- [ASIC Module](modules/asic_module.md)
- [Tape Storage Module](modules/tape_storage.md)
- [Radio Module](modules/radio_module.md)
- [Seven Segment Display](modules/seven_segment_display.md)
- [Radar Module](modules/radar_module.md)

## New Instructions for Execution Module

### Floating Point Arithmetic Instructions

`ADDF`, `SUBF`, `MULF`, and `DIVF` behave like their integer counterparts, however, they operate on `ACC` as though the data contained within represents an IEEE-754 compliant half-precision floating point number.

Note that it is possible to store an integer value in `ACC` and attempt floating point calculations on it, and vice versa. This is likely to produce incorrect values. It is the user's responsibility to ensure that operations are only performed on the correct data representation.

### Floating Point Flow Control Instructions

The `JEZF`, `JNZF`, `JGZF`, and `JLZF` instructions behave like their integer counterparts `JEZ`, `JNZ`, `JGZ`, and `JLZ`, however, like the floating point arithmetic operations above, they operate on `ACC` as though the value contained within is an IEEE-754 half-precision float.

Additionally, the `JIN` instruction will jump to the given label if the value stored in `ACC` is a `NaN` value per the IEEE-754 half-precision floating point specification. The `JNN` instruction acts as an inverse, and will jump to the given label if the value of `ACC` is not a `NaN` value.

### Floating Point Conversion Instructions

The `FLT` instruction will convert an integer value stored in `ACC` to a IEEE-754 half-precision floating point representation. The `INT` instruction will convert a floating point value stored in `ACC` to the 16-bit signed two's complement integer representation used by standard TIS-3D arithmetic operations. Converting to integer representation will round the floating point value to the nearest whole number, with ties rounding upwards.

### `MOV` Instruction Changes

The `MOV` instruction has been extended to support handling floating point literals. For example, the instruction `MOV 0.25 ACC` will no longer be a compiler error, and will now load the floating point value `0.25` into the `ACC` register as expected.
