# Camera

![Does not make photographs.](block:computronics:camera)

The camera block adds ray casting functionality to computers. The `'distance()` function calculates the distance to the nearest block along the specified ray, which is defined by angles `x` and `y`; if no angle is specified, the angle values default to 0. Both angles form a frontal cone in front of the camera, with `x` being the angle on a horizontal plane parallel to the ground, and `y`, the angle on a vertical plane perpendicular to the ground. If no block exists in the path of the ray, a value of `-1` is returned.
