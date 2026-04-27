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


While glyphs here may indicate they require a boolean input, 
it is worth noting that any fragment will be automatically coerced into a boolean value when required.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:if_else,title=Decision Distortion|>

(any, any)..., any -> any

---

Returns one of two provided options based on a boolean value. 
If true, the first option is returned. Otherwise, the second.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:equals,title=Parity Stratagem|>

any... -> boolean

---

Checks for equality between many inputs. Will only return true if all inputs are equal.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:not_equals,title=Disparity Stratagem|>

any... -> boolean

---

Checks for inequality between many inputs. Will return false if any input is equal to any other.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:all,title=Stratagem Bar None|>

boolean... -> boolean

---

Will only return true if all inputs are true.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:any,title=Stratagem In General|>

boolean... -> boolean

---

Will return true if any provided input is true.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:none,title=Stratagem In Absence|>

boolean... -> boolean

---

Will return true if none of the provided inputs are true.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:lesser_than,title=Lesser Distortion|>

number, number -> boolean

---

Returns whether the first number is lesser than the second.

;;;;;

<|glyph@trickster:templates|trick-id=trickster:greater_than,title=Greater Distortion|>

number, number -> boolean

---

Returns whether the first number is greater than the second.