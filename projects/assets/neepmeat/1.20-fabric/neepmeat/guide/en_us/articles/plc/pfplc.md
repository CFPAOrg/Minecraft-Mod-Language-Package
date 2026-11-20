---
id: pfplc
lookup: neepmeat:pfplc
---

# PFPLC

\centering{*Programmable Floating Point Logic Controller*}

\columns[fit=second]{The PFPLC performs logic and floating point maths using NEEPBus inputs and outputs. Unlike the PLC, the PFPLC can respond to inputs in real time. However, lacks the ability to interface directly with manufacturing systems. 
It is useful as a replacement for large amounts of redstone logic, or to perform complex calculations.
}{\item_render{neepmeat:pfplc}}

## Language

The PFPLC is programmed in a fairly simple programming language. It has all the basic maths operators (+ - /), boolean operators (and, or, not) and some useful mathematical functions (min, max, sin, cos, tan). Each program is split into *statements* that change the value of a variable according to other variables.

```
out0 = 4 * 8
out1 = out1 + 1
```

The PFPLC accepts infix notation, where the operator comes between operands. If your brain runs Forth, postfix notation (where the operator comes after the operands) is also accepted.  `out0 = min(in0, in1)` is valid as well as `out0 in0 in1 min() =`. 

## Variables

A PFPLC supports user-defined variables as well as special variables for receiving inputs and sending outputs.

- Special variables beginning with `in` (`in0` and `in1`) connect directly to the PFPLC's NEEPBus input ports.

- Special variables beginning with `out` (`out0` and `out1`) connect directly to the PFPLC's output ports. At the end of each scan cycle, the output ports will write their new values over the NEEPBus network.

New variables can be created by simply assigning to them. For example, 
```
my_var = 1
``` 
will create a new variable called `my_var` and set it to 1.

## Scan Cycles

When a PFPLC program runs, input variables are first updated from the NEEPBus ports, the statements within the program are evaluated, then the output ports write their new values. This is called a 'scan cycle'. 

Scan cycles can either occur constantly at regular intervals (if the clock mode is set to INT) or whenever a NEEPBus input is written to (when clock mode is set to EXT).

PFPLC code is split into statements. Each statement can assign to *one* variable.

For example, the following statement changes the value of `out0`.

```
out0 = 2 * in0 + 1
```

## Booleans

The canonical value of 'true' in the PFPLC is 1, unlike in the PLC which uses -1.

Similar rules to the PLC apply though. Anything that is not 0 is considered 'true', and 0 is considered 'false'.

A number can be converted to its boolean equivalent using the `bool` function.

```
bool(1234) -> 1
bool(-1) -> 1
bool(0) -> 0
bool(true) -> 1
bool(false) -> 0
```

# Examples

### Multiplying Two Inputs

```
out0 = in0 * in1
```

### Counters

Increment out0 every scan cycle

```
out0 = out0 + 1
```

Increment out0 when a button connected to in0 is pressed

```
out0 = out0 + oneshot(in0) * 1

# Reset out0 when another button is pressed
out0 = out0 * !oneshot(in1)
```

Increment out0 when in0 is triggered, decrement when in1 is triggered.

```
out0 = out0 + oneshot(in0) - oneshot(in1)
```

### Toggle Switch

Toggle the value of out0 each time in0 is triggered.

```
out0 = oneshot(in0) and !out0 or !oneshot(in0) and out0
```

### Sine Wave

`ctr` is increased every scan cycle. It is then converted to radians using the `rad` function and used as the argument for `sin`. Multiplying by 8 increases the frequency of the wave 8 times.
This would work best with clock mode set to INT. The output could be viewed on a gauge.

```
ctr = ctr + 1
out0 = 10 * cos( 8 * rad(ctr))
```
Note that `ctr` will eventually run out of precision when reaching very large numbers. 
Adding the line

```
ctr = ctr % 360
```
will wrap the variable back to 0 after 360 degrees, allowing the program to run forever without precision loss.
