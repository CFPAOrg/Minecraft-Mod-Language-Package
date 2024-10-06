# Content Observer
![Let's get a better look...](block:create:content_observer)

The serial port module is capable of interacting with a Content Observer to report quantities of stored items and fluids in attached inventories and fluid tanks. Quantities returned will take into account the filtering setting configured on the content observer. The protocol supports both read and write operations.

When writing to the serial interface of a content observer, two values are legal: `0` and `1`. Providing other values leads to undefined behavior. Writing a `0` will place the interface in `LOW` mode, and writing a `1` will place the interface in `HIGH` mode.

When reading from inventories, `LOW` mode  will cause it to return the lower 15 bits of the number of matching items in the attached inventory. `HIGH` mode causes it to return the upper 15 bits. Reading a quantity that cannot be stored in 30 bits will result in vendor implementation-specific behavior.

When reading from fluid tanks, `LOW` mode will return the quantity in mB of fluid in the tank that does not sum up to one full bucket. `HIGH` mode will return the quantity of full buckets of fluid in the attached tank. Reading a quantity greater than 32,767 buckets of fluid will result in vendor implementation-specific behavior.

Attempting to read from a content observer that does not have an attached inventory or fluid tank is considered undefined behavior.