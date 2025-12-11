# Queue Module
![Very British](item:tis3d:queue_module)

The queue module is capable of storing up to sixteen (16) values. It can act as expanded memory for [execution modules](execution_module.md), for example.

While not full, the queue module reads values from all four of its ports and pushes read values to the end of the list of stored values. While not empty, the queue module writes the head value, i.e. the value that was first pushed to the internal list of values, to all four of its ports. In other words, the queue module is FIFO buffer.

A value from the queue can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one [controller](../block/controller.md) cycle, only one will succeed. Unlike the [stack module](stack_module.md), the queue module does not reset its write operations when a value is written to it.
