# Controller
![I have control](item:tis3d:controller)

The controller block is the core of any TIS-3D computer. It provides power to all connected [casings](casing.md) and advances the state of the TIS-3D computer. A controller can be powered using common redstone signals, with higher input values resulting in faster execution speed. As a special case, an input strength of one (1) will result in the TIS-3D computer entering a paused state, i.e. its state will not be advanced, but it will also not be powered down and therefore reset.

A single controller block can support up to sixteen (16) [casing](casing.md) blocks. If more casing blocks are connected to a controller, the controller will perform an emergency shutdown and cease operation until the number of connected [casings](casing.md) is sufficiently reduced.

Controllers may not be connected to each other. If multiple controllers are connected, directly or indirectly through a series of [casings](casing.md), all controllers will perform an emergency shutdown and cease operation until they are no longer connected to any other controllers.

Connections are established by a controller and a [casing](casing.md) or a [casing](casing.md) and another [casing](casing.md) sharing a face.
