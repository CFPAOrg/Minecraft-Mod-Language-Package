\cat{utility}
# Utility

\cat{maths_operators}
# Maths Operators

## +-*/ 

Addition, subtraction, multiplication and division operators. Operators follow precedence. Expressions inside parentheses are evaluated first.

```
(1 + 1) * 10 / (13 - 3)
```

## %

Modulo operator. Divides second argument by the first and returns the remainder.

The result always has the same sign as the divisor.

```
13 % 10 -> 3
-13 % 10 -> 7
13 % -10 -> -7
-13 % -10 -> -3
```

## ==

Tests two values for equality.

```
4 == 4 -> true
```

## != 

Tests two values for inequality.

## <

Tests if the first value is less than the second.

## >

Tests if the first value is greater than the second.

## <=

Tests if the first value is less than or equal to the second.

## >=

Tests if the first value is greater than or equal to the second.

\cat{logical_operators}
# Logical Operators

## and

Tests if two arguments both evaluate to true.

```
true and true -> true
false and true -> false
```

## or

Tests if either of two arguments evaluate to true.

```
true and true -> true
false and true -> true
false and false -> false
```

## !

Inverts the boolean value of the following argument.

```
!true -> false
!false -> true
```

## bool(x)

Evaluates the boolean value of x (0 for false and -1 for true).

0 is considered false. Any number that is not 0 is considered true.

## unbool(x)

Evaluates the boolean value of x, but then maps it to -1 for false and 1 for true.

Can be used for increasing or decreasing a counter based on the position of a switch.

```
bool(123) -> 1
bool(0) -> 0
bool(-1) -> 1
```

\cat{special_functions}
# Special Functions

## oneshot(x)

Returns true if variable x was set via a NEEPBus input between the last scan cycle and this one, *and* x evaluates to true.

x must be the name of a variable.

```
# Toggle the value of out0 each time in0 is triggered.
out0 = oneshot(in0) and !out0 or !oneshot(in0) and out0
```

## trigger(x)

Like oneshot, but doesn't care about the variable's value. Will return true if the variable was changed externally since the last scan cycle regardless of its value.

## rising_edge(x)

Returns true if the value of x was false in the previous scan cycle, but is now true.

# Special Variables

## dt

A special variable that contains the number of ticks since the last scan cycle.

## clk_int

Contains whether the PFPLC is in internal clock mode. Change this variable's value to dynamically alter the clock mode.

- true: Clock mode is INT
- false: Clock mode is EXT


\cat{maths_functions}
# Maths Functions

## max(x, y)

Returns the value of the two arguments.

## min(x, y)

Returns the minimum of the two arguments.

## clamp(x, min, max)

Clamps x between min and max. Equivalent to `min(max(x, min), max)`

## abs(x)

Returns the absolute value of x.

```
abs(-1) -> 1
abs(1) -> 1
```

## floor(x)

Rounds x down to the nearest whole number.

```
floor(0.5) -> 0
```

## ceil(x)

Rounds x up to the nearest whole number.

```
ceil(0.5) -> 1
```

## sin(t)

Computes the sine of the given angle. The angle is in radians.

```
sin(pi/2) -> 1
```

## cos(t)

Computes the cosine of the given angle. The angle is in radians.

```
cos(pi/2) -> 0
```

## tan(t)

Computes the tangent of the given angle. The angle is in radians.

```
cos(pi/2) -> Infinity
```

## asin(x)

Computes the angle that is the arcsine of x.

## acos(x)

Computes the angle that is the arccosine of x.

## atan(x)

Computes the angle that is the arctangent of x.

## atan2(x, y)

Gives the angle in radians between the x axis and the ray from the origin to (x, y). Roughly equivalent to `atan(x / y)`.

Useful for converting cartesian coordinates to polar coordinates.

## rad(x)

Converts x from degrees to radians.

## deg(x)

Converts x from radians to degrees.

## pow(x, exponent)

Raises x to the given exponent.

```
pow(2, 2) -> 2*2
pow(2, 3) -> 2*2*2
```

## log(x)

Computes the natural logarithm of x.

## log10(x)

Computes the base 10 logarithm of x.

## sqrt(x)

Computes the square root of x.