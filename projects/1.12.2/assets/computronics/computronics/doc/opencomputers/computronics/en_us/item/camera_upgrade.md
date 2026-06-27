# Camera Upgrade

![Still doesn't make photographs.](item:computronics:oc_parts@0)

The Camera upgrade can be placed in robots and drones with a tier 2 upgrade slot or higher, and provide identical functionality as the [camera](../block/camera.md) block. However, the camera upgrade has the added functionality of having two extra functions, namely `distanceUp()` and `distanceDown()` which behave as a camera pointed directly up or down, respectively. This allows robots and drones to create height maps, for instance. Both functions take the same `x` and `y` parameters, and define an upward or downward facing cone similarly to the frontal cone created by the camera block.
