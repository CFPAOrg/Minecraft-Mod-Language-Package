```json
{
  "title": "Boolean Logic",
  "icon": "minecraft:comparator",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Decision Stratagem",
    "Parity Stratagem",
    "Disparity Stratagem",
    "Stratagem Bar None",
    "Stratagem In General",
    "Stratagem In Absence",
    "Lesser Distortion",
    "Greater Distortion"
  ]
}
```

This chapter describes a few tricks that can be used to perform boolean logic operations.


While tricks here indicate they require a boolean as input, 
it is worth noting that any fragment will be automatically coerced into a boolean value when required.

;;;;;

Boolean values are created from any fragment based on the following logic:

- If the fragment is {#4400aa}Void{}, it is false.
- If the fragment is {#444444}##Zalgo##{}, it is false.
- If the fragment is {#aa3355}False{}, it is false.
- Otherwise, it is true.

;;;;;

<|trick@trickster:templates|trick-id=trickster:if_else|>

This trick allows spells to use different fragments or even branch their behaviour based on certain criteria.

;;;;;

Decision Stratagem takes one or multiple pairs of booleans and values.
The value after the first boolean that is true will be returned.
If all booleans are false, a fallback value that *must* be specified at the end is returned instead.


For example:


Giving this trick the inputs of {#33ab89}True{}, {#ddaa00}1{}, {#ddaa00}2{} will make it return {#ddaa00}1{}, 
as the boolean forms a pair with {#ddaa00}1{}, and {#33ab89}True{} is true.

;;;;;

Alternatively:


Giving Decision Stratagem the inputs of {#aa3355}False{}, {#ddaa00}1{}, {#aa3355}False{}, {#ddaa00}2{}, {#ddaa00}3{} is also valid, 
and will see it return the fallback value, which is {#ddaa00}3{}.


And since any fragment counts as a boolean, giving it {#4400aa}Void{}, {#ddaa00}1{}, {#ddaa00}2{}, {#ddaa00}3{}, {#ddaa00}4{} will have it return {#ddaa00}3{}, 
since the {#ddaa00}2{} and {#ddaa00}3{} form a pair where the {#ddaa00}2{} gets coerced into to being true.

;;;;;

<|trick@trickster:templates|trick-id=trickster:equals|>

Checks for equality between many inputs. Will only return true if all inputs are equal.

;;;;;

<|trick@trickster:templates|trick-id=trickster:not_equals|>

Checks for inequality between many inputs. Will return false if any input is equal to any other.

;;;;;

<|trick@trickster:templates|trick-id=trickster:all|>

Will only return true if all inputs are true.

;;;;;

<|trick@trickster:templates|trick-id=trickster:any|>

Will return true if any provided input is true.

;;;;;

<|trick@trickster:templates|trick-id=trickster:none|>

Will return true if none of the provided inputs are true.

;;;;;

<|trick@trickster:templates|trick-id=trickster:lesser_than|>

Returns whether the first number is lesser than the second.

;;;;;

<|trick@trickster:templates|trick-id=trickster:greater_than|>

Returns whether the first number is greater than the second.
