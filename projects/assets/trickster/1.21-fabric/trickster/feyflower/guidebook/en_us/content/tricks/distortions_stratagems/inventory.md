```json
{
  "title": "Containers and Slots",
  "icon": "minecraft:barrel"
}
```

Tricks which construct or modify $$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$s directly.


As these tricks are distortions, they do not validate created 
$$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$s. 
Invalid $$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$s will only blunder on use.

;;;;;

Many entities, like dropped items, minecarts, and donkeys can be interacted with as $$trickster:container$$s. 
This is not the case for players, however.


Remember: Creating a $$dev.enjarai.trickster.spell.fragment.storage.StorageFragment$$ comes at no cost. However, 
moving the contained resources will always have a cost of (distance * amount * 0.5G). 
**Move costs are NOT noted as part of the cost of any ploy.**

;;;;;

#<trickster:trick id="trickster:create_item_container" />

;;;;;

Constructs an item container of the given fragment, or of the caster.


If the container is a block, an additional vector can be provided to define the side from which to interact with it.

;;;;;

#<trickster:trick id="trickster:create_fluid_container" />

Constructs a fluid container of the given fragment.

;;;;;

#<trickster:trick id="trickster:create_accessories_container" />

Constructs a container containing all of the caster's accessory slots which are capable of holding items of the given type.

;;;;;

#<trickster:trick id="trickster:create_slot" />

Constructs a slot from a container and the given index.

;;;;;

#<trickster:trick id="trickster:filter_container" />

Filters a container by the given resource types. Note that the returned container will **not** support slots.
