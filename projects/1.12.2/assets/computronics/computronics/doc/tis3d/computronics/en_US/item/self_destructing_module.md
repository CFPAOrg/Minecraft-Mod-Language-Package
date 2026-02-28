# Self-Destructing Module

![Highly convenient.](item:computronics:modules.tis3d@2)

This module allows for convenient explosive disposal of your [casing](/%LANGUAGE%/block/casing.md) and its surroundings. While active, it will continuously read values from all four of its ports. If it receives a number greater than or equal to zero, it will set its timer to that value and start ticking down. The speed it ticks away at depends on the speed of the [controller](/%LANGUAGE%/block/controller.md). If it receives a value while ticking and that value is smaller than the current timer, it will set the timer to that new value.

Once the timer reaches zero, the module and the [casing](/%LANGUAGE%/block/casing.md) will self-destruct. Devices are completely and irreversibly destroyed.
