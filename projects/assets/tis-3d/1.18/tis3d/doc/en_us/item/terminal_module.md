# Terminal Module
![I'm afraid it's terminal](item:tis3d:terminal_module)

The terminal module provides a more advanced form of input than the [keypad module](keypad_module.md) with a more specific form of output than the [display module](display_module.md).

The user may input a single line of text, which, when submitted, is written character by character to all of the ports of the terminal module. Characters are converted to numerical values according to codepage 437. Further input submissions are disabled until the full line has been transmitted. This indicated by the input line being greyed out, and the caret not blinking. It is however possible to input more text in this state to prepare for the moment submissions are enabled again.

Values are permanently read from all four ports of the terminal module. Received values are truncated to 8-bit values (0xFF masked), and interpreted as characters from codepage 437, with the exception of a few codes that are interpreted as control characters. These control characters include `\a` (bell, 0x07), `\b` (backspace, 0x08), `\t` (tab, 0x09) as well as `\n`  and `\r` (both resulting in a newline, 0x0A and 0x0D).

If the write index on the current line has reached the maximum line length and a value is read, an automatic newline will be enforced (automatic line-wrapping). If a newline occurs while on the last line of text that can be displayed, all lines will be scrolled up by one, dropping the first line.

A value from the currently processed input line can always only be transferred to one port, i.e. values will never be duplicated; even when multiple reads would occur in one [controller](../block/controller.md) cycle, only one will succeed.
