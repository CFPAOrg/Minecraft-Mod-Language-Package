# Stack Module
![Stack overflow](item:tis3d:stack_module)

The stack module is capable of storing up to sixteen (16) values. It can act as expanded memory for [execution modules](execution_module.md), for example.

While not full, the stack module reads values from all four of its ports and pushes read values on top of the list of stored values. While not empty, the stack module writes the topmost value, i.e. the value that was last pushed to the internal list of values, to all four of its ports. In other words, the queue module is LIFO buffer.

A value on the stack can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one [controller](../block/controller.md) cycle, only one will succeed. Whenever a value is stored on the stack, the stack module resets its write operations to ensure the correct value is being transferred. The specific timings resulting from this are vendor specific and an implementation detail. 
