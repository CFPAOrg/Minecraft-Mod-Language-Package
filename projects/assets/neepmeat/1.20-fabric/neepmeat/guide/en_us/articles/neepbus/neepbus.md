---
id: neepbus
---
# NEEPBus

NEEPBus is a multi-controller serial bus. It consists of multiple participants connected via data cables.

Participants in a network can exchange integer data using alphanumeric addresses.

## Description

Data is exchanged between ports. Participants can have multiple ports.

- Each port has its own alphanumeric address.
- Output ports will send data to input ports with a matching address.
- Multiple input ports can share the same address, and will all receive the same data.

A participant can have input and output ports.

- Input ports are written to (receive data).
- Output ports can write (send data) to input ports. They can also be read from.

## Reads and Writes

Unlike redstone, a read or write operation is necessary for data to propagate.

For example, a slider will write its value to the target address when the value is changed by a player. It will not perform a write operation when a new port with a matching address is connected to the network.