# Parser Module
![toNumber!](item:tisstring:parse_module)

The Parse Module takes a Null-Terminated string and returns a number
the valid types of strings are
* INT (signed 16-bit number)
* UINT (unsigned 16-bit number)
* FLT (16-bit float, do not need to be exact)
* HEX (16-bit hex value, can be upper/lower case)
these types can be scrolled through by right-clicking in the air with the module in hand

you can also specify what happens on a Parse Error
* NULL (returns 0x0000 from the module when parsing of value fails)
* HCF (crashes the entire machine, same as running `HCF` in a Execution Module)
can be changed by right-clicking in the air while pressing shift