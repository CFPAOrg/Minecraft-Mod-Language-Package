---
id: plc_neepbus_interface
---

# NEEPBus PLC Interface

PLCs can directly read and write to NEEPBus components, but they cannot be written to. The NEEPBus PLC Interface emits interrupt requests that allow a PLC to immediately respond when a write occurs

This block has one input port and one output port. When the input is written to, it will emit an interrupt request to any PLCs that have registered an interrupt handler using `IHANDLER`.

The current value of the input port can be read using `EXTFETCH`.

Sending a memory entry to this block using `EXTSTORE` will cause the output port to write the value to all matching addresses.

## THORD Example:

```
begin
    # Target is a NEEPBus interface
    ihandler @(-19 -60 5 U) handler
    iwait
-1 until

: handler
  idisable
  say "NEEPBus changed"
  
  # Retrieve the current value of the input port.
  # (this goes onto the stack)
  extfetch @(-19 -60 5 U); 
  
  dup . # Say the result
  
  # Store the result in memory
  store
  
  # Duplicate the pointer
  dup
  
  # Send the memory entry to the interface
  extstore @(-19 -60 5 U)
  
  # Free the memory
  free
;
```
