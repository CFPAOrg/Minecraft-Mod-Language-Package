# Infrared Module
![Seeing red](item:tis3d:infrared_module)

The infrared module provides short range, line-of-sight wireless transmission of values, either inside an appropriately structured TIS-3D computer, or between different TIS-3D computers. This allows fast communication between multiple systems, avoiding the generally lossy alternative of transferring data over redstone. The maximum reliable distance between paired modules is vendor specific, but is usually close to 50 meters.

The infrared module reads values from all four of its ports and emits an infrared packet with the read value as its payload. The infrared module writes the value of the last received infrared packet to all four of its ports.

The infrared module holds a small queue containing the list of values of the last received packets. The exact length of this list is vendor specific. If a packet is received but the list is already full, the packet will be ignored. The list will be written to infrared module's ports in the order in which the values were received.

A value in the queue of received values can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one [controller](../block/controller.md) cycle, only one will succeed.
