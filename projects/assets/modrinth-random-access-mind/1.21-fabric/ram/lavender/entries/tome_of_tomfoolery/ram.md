```json
{
  "title": "Random Access Mind",
  "icon": "minecraft:goat_horn",
  "category": "trickster:tricks"
}
```

The Random Access Mind, or RAM for short, 
is a way of storing arbitrary semi-persistent data alongside other unrelated arbitrary data, 
through the use of an allocation system.

;;;;;

<|glyph@trickster:templates|trick-id=ram:alloc,title=Allocator's Ploy|>

-> number

---

Attempts to allocate a RAM slot, blundering if there are none free. Returns the address of the allocated slot.

;;;;;

<|glyph@trickster:templates|trick-id=ram:free,title=Concierge's Ploy|>

number ->

---

Frees the RAM slot at the given address, permitting later re-allocation.

;;;;;

<|glyph@trickster:templates|trick-id=ram:read,title=Retrieval Ingress|>

number -> any

---

Returns the fragment stored within the RAM slot at the given address.

;;;;;

<|glyph@trickster:templates|trick-id=ram:write,title=Ploy of Caching|>

number, any -> any

---

Stores the given fragment in the RAM slot at the given address, overwriting what was there previously.
