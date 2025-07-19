---
id: interrupts
---

# Interrupts

Interrupts allow a PLC to stop its current activity when a certain external event happens.


```
%alias redstone = @(1 2 3 N)

ihanlder $redstone handler
iwait
restart

handler:
    rread $redstone
    say
    
    # Return to the saved position
    ret
```
