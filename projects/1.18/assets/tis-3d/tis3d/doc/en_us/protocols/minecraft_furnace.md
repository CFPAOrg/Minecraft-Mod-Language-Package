# Furnace
![Something smells burned...](block:minecraft:furnace)

Exploiting the undocumented photo-sensitivity of the serial port module, it is possible to access some basic information on the processes occurring in a common furnace. The protocol for interacting with a furnace supports both read and write operations.

When writing to the serial interface of a furnace, two values are legal: `0` and `1`. Providing other values leads to undefined behavior. A value `0` sets the interface to the mode returning information on the remaining fuel in the furnace, a value of `1` sets the interface to the mode returning information on the current smelting or cooking progress.

When reading from the serial interface of a furnace, a value in the range of [0, 100] is returned. When in the mode returning information on the remaining fuel in the furnace, 0 means no fuel and 100 means fully fueled. This value is relative to the burn time of the currently burning fuel. It stands in no correlation to the amount of fuel items remaining in the furnace. When in the mode returning information on the current smelting or cooking progress, 0 means no progress, 100 means fully processed and just about to finish.
