# Cannon Mount
![Fire in the hole!](block:createbigcannons:cannon_mount)

The serial port module is capable of interacting with a cannon mount to report the cannon's pitch. A read operation will return the pitch of the cannon as an integer **measured in tenths of a degree**, in the range [-90,90]. `0` represents a horizontally level cannon. This interface does not support write operations.