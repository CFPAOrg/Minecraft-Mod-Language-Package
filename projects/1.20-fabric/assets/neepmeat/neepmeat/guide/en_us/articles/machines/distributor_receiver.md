---
id: distributor_receiver
lookup: neepmeat:distributor_point
---

# Distributor Receiver

The Distributor Receiver summons Distributor Organisms to transport items and fluids to other receivers on the same channel. Transport can occur to unloaded chunks and across dimensions.

# Usage

Only one Distributor Receiver can be part of a machine. The receiver can be configured to send resources, receive them, or both. Send mode requires an item input to be part of the machine, and receive mode requires an item output.

Right-clicking on the receiver opens a GUI with configuration options:

- Channel: Receivers with the same channel will be able to send and receive from each other.
- Mode: Whether to send, receive, or both.
- Cooldown: How long to wait between sends.
- Auto send: Whether to automatically send resources when they are available, or wait for a NEEPBus signal.

For transport to occur, only the sender chunks need to be loaded.

# NEEPBus Support

NEEPBus can be used to set a receiver's channel or trigger it to send.