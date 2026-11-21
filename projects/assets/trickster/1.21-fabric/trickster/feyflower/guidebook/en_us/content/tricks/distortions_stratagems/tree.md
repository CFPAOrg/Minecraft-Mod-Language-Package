```json
{
  "title": "Spells",
  "icon": "minecraft:oak_sapling"
}
```

Although [Scribing Patterns](*trickster:editing) allow for spells to be edited before they are cast, 
the following tricks allow for a spell to modify other spells *during* the cast.

;;;;;

#<trickster:trick id="trickster:supplier" />

Creates a new spell fragment which returns the previously provided fragment when executed.

;;;;;

#<trickster:trick id="trickster:closure" />

Replaces the keys of the map that are in the given spell with the value they map to.

;;;;;

Any values anywhere in the given spell will be replaced. 
This could be constants in glyphs, patterns, and inner circles,
but also entire subtrees of the spell.


Values that are a part of inner circles or subspells will *also* be replaced.

;;;;;

#<trickster:note title="Addresses" />

Just as elements of a list are accessed by their index, 
parts of a spell are accessed by their address. 
An address is a list of integers that forms a path to a specific circle in a spell.


Addresses can be found using [Address Revision](*trickster:editing@revision&trickster:write_path).


To manually find the address of a circle, start at the central circle in the spell.

;;;;;

Next, find the sub-circle attached to the central circle that is in the
path to the circle you are finding the address of. Take the index of that circle, which is the number of circles that come before it, counterclockwise. 


Repeat this process, adding each index to the list until you reach the circle you are finding the address of. The list you constructed is the address to
that circle.

;;;;;

#<trickster:trick id="trickster:locate_glyph" />

Returns the address of the first circle in the given spell with a glyph matching the given fragment. 
The spell is searched using [BFS](https://en.wikipedia.org/wiki/Breadth-first_search).

;;;;;

#<trickster:trick id="trickster:locate_glyphs" />

Returns a list of all the addresses of circles in the given spell with a glyph matching the given fragment.

;;;;;

#<trickster:trick id="trickster:retrieve_glyph" />

Returns the glyph of the circle at the given address.

;;;;;

#<trickster:trick id="trickster:set_glyph" />

Replaces the glyph of the circle at the given address with the given fragment.

;;;;;

#<trickster:trick id="trickster:get_subparts" />

Returns the branches of a spell as a list.

;;;;;

#<trickster:trick id="trickster:retrieve_subtree" />

Returns the circle (and its branches) at the given address.

;;;;;

#<trickster:trick id="trickster:set_subtree" />

Grafts the latter spell into the former, replacing the circle at the given address.

;;;;;

#<trickster:trick id="trickster:add_subtree" />

Attaches the latter spells to the circle at the given address as new branches.

;;;;;

#<trickster:trick id="trickster:remove_subtree" />

Removes the circle at the given address. Returns void if the root node is removed.

