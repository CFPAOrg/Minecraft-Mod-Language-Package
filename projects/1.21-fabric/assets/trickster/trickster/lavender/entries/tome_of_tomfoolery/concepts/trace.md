```json
{
  "title": "Stack Traces",
  "icon": "minecraft:tripwire_hook",
  "category": "trickster:concepts"
}
```

Spell failures are referred to as *blunders*. When a spell blunders, a stack trace is printed out, 
signifying *where* in the spell the failure occurred. Stack traces are colon-separated lists of characters of three varieties: 

- # (pound/hashtag) 
- \> (chevron/angle bracket)
- any number

;;;;;

The numbers are input indexes, 
while both the chevrons and hashtags indicate a change of context into a different spell fragment.
The former indicates a fragment provided by the current spell, 
while the latter means the fragment came from elsewhere.

;;;;;

<|page-title@lavender:book_components|title=Note: Indexes|>Each circle in a spell has a number, an *index*, 
that states its position relative to its parent. The purple pin on the parent circle is always counter-clockwise of the first subcircle, 
which has an index of zero. Each subcircle clockwise of the first subcircle has an index one greater than the one before it.