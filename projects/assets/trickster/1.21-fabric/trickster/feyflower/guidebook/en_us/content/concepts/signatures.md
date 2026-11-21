```json
{
  "title": "Trick Signatures",
  "icon": "minecraft:writable_book"
}
```

The Tricks section of this book contains descriptions and usage details of all operations that spells can perform.
These details include so-called Signatures. 


Signatures are short and standardized descriptions of the inputs and outputs a certain trick may take and provide.


An example Signature might look like this:


$$trickster:vector$$, $$trickster:number$$ -> $$trickster:boolean$$

;;;;;

This describes a trick that expects a $$trickster:vector$$ as the first input and a $$trickster:number$$ as the second,
as counted clockwise from the circle's Divider Pin.


This trick would also provide a $$trickster:boolean$$ as output, potentially for its parent circle to use.


Aside from commas (,) to separate different inputs, and the arrow (->) to distinguish input from output,
a few other symbols might show up in signatures, as outlined below:


$$trickster:number$$? -> $$dev.enjarai.trickster.spell.Fragment$$

;;;;;

A question mark (?) after an input indicates that providing the value is optional.
One can either leave the input out completely, or provide void.


$$trickster:number$$ | $$trickster:vector$$ -> $$dev.enjarai.trickster.spell.Fragment$$ | $$trickster:void$$


Often times, one may see two inputs or return types being separated by a pipe symbol. (|)


For inputs, these indicate that either of the two types may be used in that position.
In return types, it means the trick may return either of the given types, depending on the situation.

;;;;;

[$$dev.enjarai.trickster.spell.Fragment$$], $$trickster:number$$ -> [$$trickster:boolean$$]


Some inputs or outputs may be wrapped in square brackets. ([]) 
These indicate that the trick expects or returns a list of exclusively this type of fragment.


{$$dev.enjarai.trickster.spell.Fragment$$: $$trickster:boolean$$}, $$dev.enjarai.trickster.spell.Fragment$$ -> $$trickster:boolean$$


In other cases, signatures will have two types wrapped in curly braces ({}) and split by a colon. (:)
This represents a map with keys of the first type, and values of the second.

;;;;;

$$trickster:spell_part$$, $$dev.enjarai.trickster.spell.Fragment$$... -> $$dev.enjarai.trickster.spell.Fragment$$


Sometimes, three trailing periods (...) will be used after a type.
This indicates that after the previous input, 
the trick will accept *any number of additional inputs* of this type.
