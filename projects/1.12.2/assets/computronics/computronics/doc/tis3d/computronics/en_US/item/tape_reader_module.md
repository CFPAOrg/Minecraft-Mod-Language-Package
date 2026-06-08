# Tape Reader Module

![Storage issues no more.](item:computronics:modules.tis3d@1)

The Tape Reader Module can interface with an adjacent Tape Drive, allowing data to be written to and read from the Cassette Tape inside. It also allows playing music from the tape provided the data on the tape is encoded as [DFPWM](http://wiki.vex.tty.sh/dfpwm).

Tapes come in varying lengths from 2 to 128 minutes, and can be used to store any type of information (storage space is roughly the number of minutes of DFPWM-encoded sound the tape can record divided by 4, in megabytes).

The way the module receives commands is as follows: It continuously reads values from all four of its ports. Once it receives a value, it checks if it is the index of a valid command. If it is, it proceeds to the next stage of that command, either waiting for further input (a parameter) on all ports or beginning to write the returned data to all four ports. Once the command has been processed, it starts reading on all ports again, waiting for a command.

The following commands exist:

* `0`: isEnd - Returns 1 if the tape drive is empty or the inserted tape has reached its end, 0 otherwise.
* `1`: isReady - Returns 1 if there is a tape inserted, 0 otherwise.
* `2`: getState - Returns the state the drive is currently in, as a number. Returned numbers are `0` if Tape Drive has stopped, `1` if the Tape Drive is currently playing, `2` if the Tape Drive is rewinding and `3` if the Tape Drive is forwarding.
* `3`: getSize - Returns the size of the tape in bytes modulo 1024.
* `4`: getSize in kibibytes - Returns the size of the tape in kibibytes as an integer, rounded down. 
* `5`: setSpeed - Sets the speed the drive plays at to the next value the module reads, in percent. Values between 25 and 200 are valid.
* `6`: setVolume - Sets the volume of the Tape Drive to the next value the module reads, in percent. Values between 0 and 100 are valid.
* `7`: seek - Seeks the next value the module reads (in bytes) on the tape. Negative values will seek backwards (i.e. rewind).
* `8`: seek in kibibytes - Seeks the next value the module reads (in kibibytes) on the tape. Negative values will seek backwards (i.e. rewind).
* `9`: read - Reads a single byte from the tape and returns it.
* `10`: read multiple bytes - Reads the next value the module receives in bytes from the tape and returns them, one by one. Example: Passing a `4` as the parameter will make the module write to all its ports 4 times, returning one byte read each.
* `11`: write - Writes the next value the module receives to the tape.
* `12`: write multiple bytes - The next value the module reads will represent the number of bytes it will write to the tape. Every successively read value will then be written to the tape until the number of bytes to write has been reached.
* `13`: switchState - Sets the state of the drive to the next value the module receives. See command 2 (getState) for valid numbers to pass.
