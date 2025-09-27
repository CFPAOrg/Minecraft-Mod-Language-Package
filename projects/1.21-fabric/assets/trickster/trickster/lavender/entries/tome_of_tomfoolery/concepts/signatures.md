```json
{
  "title": "Trick Signatures",
  "icon": "minecraft:writable_book",
  "category": "trickster:concepts"
}
```

The Tricks section of this book contains descriptions and usage details of all operations that spells can perform.
These details include so-called Signatures. 


Signatures are short and standardized descriptions of the inputs and outputs a certain trick may take and provide.

;;;;;

An example Signature might look like this:


{#aa7711}Vector{}, {#ddaa00}Number{} -> {#aa3355}Boolean{}


This describes a trick that expects a {#aa7711}Vector{} as the first argument and a {#ddaa00}Number{} as the second,
as counted clockwise from the circle's Divider Pin.


This trick would also provide a {#aa3355}Boolean{} as output, potentially for its parent circle to use.

;;;;;

Aside from commas (,) to separate arguments, and the arrow (->) to distinguish input from output,
a few other symbols might show up in signatures, as outlined below:


{#ddaa00}Number?{} -> {#aa4444}Any{}


A question mark (?) after an argument indicates that providing the value is optional.
One can either leave the argument out completely, or provide void.

;;;;;

{#ddaa00}Number{} | {#aa7711}Vector{} -> {#aa4444}Any{} | {#4400aa}Void{}


Often times, one may see two argument or return types being separated by a pipe symbol. (|)


For arguments, these indicate that either of the two types may be used in that position.
In return types, it means the trick may return either of the given types, depending on the situation.

;;;;;

[{#aa4444}Any{}], {#ddaa00}Number{} -> [{#aa3355}Boolean{}]


Some inputs or outputs may be wrapped in square brackets. ([]) 
These indicate that the trick expects or returns a list of exclusively this type of fragment.

;;;;;

{{#aa4444}Any{}: {#aa3355}Boolean{}}, {#aa4444}Any{} -> {#aa3355}Boolean{}


In other cases, signatures will have two types wrapped in curly braces ({}) and split by a colon. (:)
This represents a map with keys of the first type, and values of the second.

;;;;;

{#aa44aa}Spell{}, {#aa4444}Any{}... -> {#aa4444}Any{}


Sometimes, three trailing periods (...) will be used after a type.
This indicates that after the previous argument, 
the trick will accept *any number of additional arguments* of this type.
