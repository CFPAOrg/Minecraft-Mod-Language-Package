# Rotation Speed Controller
![I swear it's under control...](block:create:rotation_speed_controller)

The serial port module is capable of interacting with a Rotation Speed controller to read and write its target speed. Reading from the rotation speed controller will return its current target RPM. Writing to it will overwrite its target RPM with the value specified. Attempting to read RPM values greater than 32,767 may result in vendor-specific behavior.
