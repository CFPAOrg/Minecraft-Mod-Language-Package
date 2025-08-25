---
id: thord_variables
---

# Variables

Variables can be created with the `VARIABLE` word.

Stating a variable's name puts its address on the stack. This can be taken as an argument by any word. 

- ! is used to assign the second stack entry to a variable on top of the stack.
- @ gets the value of the variable.
- ? prints the value of the variable.
- +! adds the second stack entry to the variable.

Examples

```
# Create the variable
variable count

# Print the variable's address
count .

# Assign 123 to the variable
123 count !

# Add 1 to the variable
1 count +!

# Print the variable's value
count @ .

# Shorthand for @ .
count ?
```

# Arrays

Arrays are created with the `ARRAY` word.

Stating the array's name puts the first element's address on the stack. Successive elements are accessed by incrementing the address and using `@`.

```
# Create an array with 5 elements
array a 5

# Value to put in the array
123

# Get the address of the second element
a 1 + 

# Store it
!
```

Arrays and noname words can do many interesting things. The following program stores the addresses three noname words in an array. It then loops through the array and executes the words.

```
# Create an array of three elements
array a 3

# Count represents the current element of the array to fill
variable count

# Create a noname word
:noname 
  .say "Look at me" ; 
; 

# Stored it using a word we defined
sto

# More compact syntax for the same thing
:noname .say "I'm a word" ; ; sto
:noname .say "Boiled in oil" ; ; sto

# Values of i: 0 1 2
3 0 for 
  # Get the value at i
  i at execute
loop 

# Stores top stack entry in the array and increments count.
: sto ( addr -- )
  count @ a + ! 
  1 count +!
;

# Retrieves the element at idx
: at ( idx -- addr ) 
  a + @ 
;
```