# RAM Module
![Not for the daft.](item:tis3d:random_access_memory_module)

The random access memory module (RAM module) permits storing a massive total of 256 values for later retrieval. Each stored value can be accessed individually, hence the name. Note that unlike the TIS-3D computer itself, which sports an impressive 16-Bit value support, the RAM module is limited to 8-Bit values due to the high storage density.

The RAM module follows a simple protocol for reading and writing individual cells: it will first read a single value from any of its ports. This value defines the *address* the read or write operation will be performed on. Providing values that exceed the 8-Bit width is undefined behavior. Whether the specified address will be written to or read from is defined by which of the operations happens first.
- When any one of the RAM module's ports completes a read operation, the read value will be stored at the address.
- When any one of the RAM module's ports completes a write operation, the value stored at the address will be transferred.
After the address was either read from or written to, the RAM module will then return to reading another address to allow the next read or write operation.

Example for reading a value from address `8` into the accumulator, assuming the RAM module is on the `LEFT` port of an [execution module](execution_module.md):
`MOV 8 LEFT`
`MOV LEFT ACC`

Example for writing a value to address `8`, same scenario:
`MOV 8 LEFT`
`MOV 0x42 LEFT`