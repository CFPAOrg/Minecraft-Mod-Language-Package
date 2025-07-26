# Yaw Controller
![Yawwwwwr!](block:createbigcannons:yaw_controller)

The serial port module is capable of interacting with a yaw controller to report the yaw of the attached cannon. A read operation will return the yaw of the cannon as an integer **measured in tenths of a degree**, in the range [0,3600]. This interface does not support write operations. Attempting to read from a yaw controller without an attached cannon may result in undefined behavior.