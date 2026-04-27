# Stringify Module
![Stringy!](item:tisstring:string_module)

The Stringify module turns the input into a null-terminated string

- name (string version of 0xFFFF) (mode name)

- Signed 16 (-1) (INT)
- Unsigned 16 (65535) (UINT)
- Half-Prescision Float (NaN) (FLT)
- Hexidecimal (ffff) (HEX)
- Uppercase Hexidecimal (FFFF) (UHEX)

Cycling through the selected functions is done by holding the item in your hand and right-clicking. Cycling backwards can be done by right-clicking while sneaking. 

the module can only accept one value at a time so a program like
`MOV 15 UP`
`MOV 25 UP #this halts since you can only stringify one number at a time`