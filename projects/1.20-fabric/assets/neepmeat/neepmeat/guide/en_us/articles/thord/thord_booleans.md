---
id: thord_booleans
---

# Booleans

THORD has no boolean type, but any value that is not 0 is considered true.

The standard value that represents true is -1. This is returned by all comparison operations.

Inverting each bit (`NOT` in NEEPASM, `INVERT` in THORD) converts -1 to 0 and vice versa due to the two's complement representation of integers.


```
-1 invert . # becomes 0

0 invert . # becomes -1
```

Inverting the bits of any other non-zero number will produce a nonzero result. Hence, boolean logic only works consistently with the values -1 and 0.
