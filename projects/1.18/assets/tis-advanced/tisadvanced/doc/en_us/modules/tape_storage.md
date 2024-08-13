# Tape Storage Module

![Just tape it together!](item:tisadvanced:tape_storage)

The tape storage module provides an 8 KiB tape that can be used to store data. The tape is readable and writeable, and the data and head location will persist across reboots. It can also be removed and reinserted into another computer, and its state will persist.

Read operations will return the byte value at the read/write head's current position. Write operations can be used to overwrite the data at the head's current position, or to wind the tape in either direction. Write operations take a single 16 bit value, of which the higher 8 bits are interpreted as a control code that directs the tape's behavior, and the lower 8 bits are an additional data value used by the control code. Below is the documentation for each control code:

## Control Codes

- `0`: Write the data value to the head's current position
- `1`: Wind the tape one byte forward. The data value will be discarded.
- `2`: Wind the tape one byte backwards. The data value will be discarded.
- `3`: Wind the tape a number of bytes forward equal to the data value
- `4`: Wind the tape a number of bytes backward equal to the data value
- `5`: Wind the tape to the beginning. The data value will be discarded.
- `6`: Wind the tape to the end. The data value will be discarded.
