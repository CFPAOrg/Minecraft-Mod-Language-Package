# Timer Module
![Hell, it's about time](item:tis3d:timer_module)

The timer module uses a high precision quartz to allow consistent and reliably timed wait operations. Its hardware runs on a 20 Hz clock, meaning one timer step will take exactly 50 milliseconds. The timer is configured using these clock cycles.

The timer module continuously reads values from all four of its ports. When a value is read, the internal timer state is set to the specified value, and will be decremented by one in each future clock cycle, until it reaches zero. Once it has reached zero, the timer module continuously writes a constant, implementation specific value to all four of its ports.

As the timer module only writes to its ports when the timer has elapsed, it is therefore possible to wait for a specific amount of time, by setting up the timer and then trying to read a value from it. Due to the blocking nature of port I/O in TIS-3D computers, this will pause exectution until the timer has elapsed.

An interrupt may be implemented by having an [execution module](execution_module.md) read from the timer module using the virtual `ANY` port, therefore allowing concurrent programs to end the read by pushing a value to that [execution module](execution_module.md).

## Time conversion table
For the simpl- for simplicity, we provide a lookup table of commonly used times to the value the timer module has to be configured with to wait for that amount of time.

Half a second: 10
One second: 20
Five seconds: 100
Ten seconds: 200
One minute: 1200
Fifteen minutes: 18000
Half an hour: 36000

The maximum timer value is limited by the bandwidth of the ports in TIS-3D computers, which is 16 bit. Therefore, the maximum configurable timer value is 0xFFFF, which results in a wait of 54 minutes 36 seconds and 750 milliseconds.
