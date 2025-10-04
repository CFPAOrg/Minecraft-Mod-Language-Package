```json
{
  "title": "Boolean Logic",
  "icon": "minecraft:comparator",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "Decision Distortion",
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

This chapter describes a few patterns that can be used to perform boolean logic operations.


While glyphs here indicate they require a boolean input, 
it is worth noting that **any fragment will be automatically coerced into a boolean value** when required.

;;;;;

Boolean values are created from any fragment based on the following logic:

- If the fragment is {#4400aa}Void{}, it is **false**.
- If the fragment is {#444444}##Zalgo##{}, it is **false**.
- If the fragment is **false**, it is **false**.
- Otherwise, it is **true**.

;;;;;

<|trick@trickster:templates|trick-id=trickster:if_else|>

This trick allows spells to use different fragments or even branch their behaviour based on certain criteria.

;;;;;

Decision Distortion takes one or multiple pairs of booleans and values.
The value after the first boolean that is true will be returned.
If all booleans are false, a fallback value that *must* be specified at the end is returned instead.


For example:


Giving this trick the arguments of **true, 1, 2** will make it return **1**, 
as the boolean forms a pair with **1**, and evaluates to **true**.

;;;;;

Alternatively:


Giving Decision Distortion the arguments of **false, 1, false, 2, 3** is also valid, 
and will see it return the fallback value, which is **3**.


And since any fragment counts as a boolean, giving it **void, 1, 2, 3, 4** will have it return **3**, 
since the **2** and **3** form a pair where the **2** evaluates to **true**.

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
