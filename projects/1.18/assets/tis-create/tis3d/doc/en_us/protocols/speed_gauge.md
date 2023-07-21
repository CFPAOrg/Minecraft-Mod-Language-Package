# Speedometer
![Need for Speed!](block:create:speedometer)

The serial port module is capable of interacting with a Speedometer to report the measured RPM. A read operation will return the RPM measured by the Speedometer. This interface does not support write operations. Reading an RPM value outside the range [-32768,32767] will result in vendor implementation-specific behavior.