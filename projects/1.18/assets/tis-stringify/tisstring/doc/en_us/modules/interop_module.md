# The Interop Module
![Cross Platform!](item:tisstring:interop_module)

(Warnind: this module may not exist, do not be afraid it just means you dont have ComputerCraft installed)

The interopmodule allows you to interact with TIS-3D within CC
just wrap a casing with this module installed via `peripheral.find("casing")`
and enjoy the functions, the module is always reading/writing
the CC-side functions provided are
`casing.popInt(): Number|nil` pops a number from the interop module (signed integer) returns nil if empty
`casing.popUint(): Number|nil` pops a unsinged number from the interop module (unsingned int) returns nil if empty
`casing.popFloat(): Number|nil` pops a 16-bit float from the interop module, returns nil if empty
`casing.pushInt(Number)` pushes a Int, determines signed or not if it is positive above Short.MAX_VALUE
`casing.pushFloat(Number)` pushes a Float, expect loss in prescition
`casing.getLen():Number` returns the current number of values avaliable to be popped from the interop module

Notice: installing mutiple interop modules on the same casing is useless, it will only pick one 
(and it is "random" as to which)