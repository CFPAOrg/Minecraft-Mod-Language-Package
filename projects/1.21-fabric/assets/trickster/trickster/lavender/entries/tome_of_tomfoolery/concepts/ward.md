```json
{
  "title": "Wards",
  "icon": "minecraft:shield",
  "category": "trickster:concepts"
}
```

Wards are defensive spells that are cast when you are the target of a ploy. 
Your ward receives the caster, and a list containing the inputs the caster is passing to the triggering glyph. 
The expected signature for a ward is the following: 

---

entity | vector, any[] ->

;;;;;

The ward used is retrieved from the combined maps of all charms worn by the target, where the key is the triggering glyph. 
The triggered ward requires an empty spell slot to be run, but begins prior to the execution of the triggering glyph.
