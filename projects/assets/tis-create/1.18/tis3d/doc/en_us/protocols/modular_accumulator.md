# Accumulator
![Unlimited Power!](block:createaddition:modular_accumulator)

The serial port module is capable of interacting with an Accumulator to report the quantity of energy stored within. The protocol does not support write operations.

Reading from the interface will return the energy stored within the accumulator **measured in Kfe**. Reading a quantity greater than 32,768 kFE will lead to vendor implementation-specific behavior.