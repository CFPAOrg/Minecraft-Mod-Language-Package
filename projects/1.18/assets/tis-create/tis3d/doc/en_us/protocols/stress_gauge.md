# Stressometer
![This is stressing me out... :(](block:create:stressometer)

The serial port module is capable of interacting with a Stressometer to report either the current network stress, or total network stress capacity.

When writing to the serial interface of a Stressometer, two settings may be changed: Writing a `0` or `1` to the first bit will switch the serial port to `LOW` and `HIGH` modes, respectively. When writing to the second bit, writing a `0` or a `1` will switch the serial port to reading the current network stress, or total network stress capacity, respectively. For example, writing `3` to the serial port will place it in `HIGH` mode, and read subsequent reads would return the upper 15 bits of the total network stress capacity.

When reading from the serial interface, the value returned represents the lower 15 bits of the requested data when in `LOW` mode, and the upper 15 bits when in `HIGH` mode. Reading values that cannot be represented in 30 bits will result in vendor implementation-specific behavior.