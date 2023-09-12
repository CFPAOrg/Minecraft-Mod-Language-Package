# Casing
![In case of logic](item:tis3d:casing)

The casing block houses up to six (6) modules, one on each of its faces. Because a casing must be connected to a [controller](controller.md) to function, generally only up to five (5) faces per module are usable; faces between casings or between a casing and a [controller](controller.md) are required for internal communication and cannot contain modules. If a module is present on a face in front of which another casing or a [controller](controller.md) is being placed, the module will automatically be ejected from its casing.

Casings provide four ports for each installed module, which can be used to transfer data across an edge of the casing block. If there is another casing block in the direction of the edge, the data will be transferred through the connecting face and to the adjacent port of the neighboring casing block. Otherwise the port will connect to the module around the respective edge of the casing.

This means there is always a slot for a module behind a port. However, if no module is installed in such a slot, reading from the port leading to it will not succeed, nor will writing to it.

Casings can be locked using a [key](../item/key.md). Once locked, modules can no longer be added or removed. Useful for preventing manipulation by others, or simply to prevent accidentally removing modules.

Furthermore, while sneaking, [keys](../item/key.md) can be used to close/open the receiving ports of each casing's faces. Closing a receiving port on a face will cause writing operations to that port from the adjacent module to stall, and will prevent omnidirectional writes to output to the port. This allows for more compact builds, and can save you a few [execution modules](../item/execution_module.md) otherwise needed for making a connection directional (e.g. only forwarding received data from an [infrared module](../item/infrared_module.md) to a [redstone module](../item/redstone_module.md)).