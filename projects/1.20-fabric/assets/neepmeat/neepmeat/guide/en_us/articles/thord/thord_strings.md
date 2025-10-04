---
id: thord_strings
---

# Strings

Strings can be pushed to the stack much like integers:

```
"I am a string" .
# Prints 'I am a string'
```

It is important to note that what is stored on the stack is not the string, but a pointer to the string in the PLC's random access memory. Allocated memory is automatically freed when no references to it exist in the stack, so strings do not need to be manually freed.

# Relevant Instructions

Some instructions can differentiate between pointers and normal stack entries and modify their behaviour. For example, NBWRITE can send integers from the stack, but can also send strings from memory via a pointer on the stack using the same syntax:

```
1234
nbwrite "the address" 

"I am a string"
nbwrite "the address"
```