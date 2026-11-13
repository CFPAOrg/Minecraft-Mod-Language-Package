---
navigation:
  title: Confined Spawner
  icon: nautec:spawner_confinement_matrix
  position: 12
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:spawner_confinement_matrix
  - nautec:confined_spawner
  - nautec:mob_sampler
  - nautec:mob_sample
---

# <Color id="light_purple">Confined Spawner</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="spawner_confinement_matrix" scale="2"/>
  Turns a mob spawner into a machine that makes the mob's drops straight into its own storage, without spawning a single mob.
</Column>

## <Color id="gold">Confining a Spawner</Color>

Use a Spawner Confinement Matrix on a spawner. The cage gains a band of glowing runes and a metal frame, and becomes a Confined Spawner. It keeps everything about the original spawner: the mob, how many it spawns at once, how often, and any upgrades. Spawners improved with Apothic Spawners keep their spawn count and delay and run faster for them.

Sneak and use the Confined Spawner with an empty hand, or with a Matrix, to release it. The cage returns to an ordinary spawner with its current mob and upgrades, and the Matrix returns to your inventory. It only releases once the storage and the experience tank are both empty; until then a message says to empty them first.

Breaking a Confined Spawner with a pickaxe drops the Confined Spawner itself, with or without Silk Touch. It keeps the mob, the spawner's settings and upgrades, and the filter, so you can move it and place it back exactly as it was. The stored drops and experience go with it too, so nothing spills on the ground. To get a plain spawner back instead, empty it and release it.

## <Color id="gold">Changing the Mob</Color>

Make a <ItemLink id="mob_sampler"/> in the Mixer with one Glass Vial, two Aquarine Copper Ingots, a diamond and 250 mB of Electrolyte Algae Serum. Each recipe makes one sampler.

Use the sampler on a living mob to collect a <ItemLink id="mob_sample"/>. The creature stays alive and in place. The sampler is consumed, and the sample's tooltip names the mob it came from. Creatures added by other mods work too.

Use the sample on a Confined Spawner to change its mob. The sample is consumed. Spawn count, delay, upgrades, filters, stored drops and experience are kept; progress toward the next cycle starts over. Breaking and replacing the spawner keeps the new mob, as does releasing it back into an ordinary spawner. Samples cannot be applied directly to ordinary spawners.

Players, dead creatures and entities marked with the `c:capturing_not_supported` entity type tag cannot be sampled. The tag is checked again when applying a sample, so packs can also block samples that were collected before their rules changed.

<RecipeFor id="mob_sampler"/>

### <Color id="aqua">Guardian Materials</Color>

Guardians are a useful first target for sampling. A Guardian Confined Spawner supplies renewable Prismarine Shards and Prismarine Crystals for [Aquatic Catalyst fuel](nautec:getting_started/laser_power.md) and NauTec crafting, including Aquarine Copper Compound.

It also has a chance to produce <ItemLink id="ancient_valve"/>, <ItemLink id="burnt_coil"/> and <ItemLink id="guardian_eye"/>. This gives you an automated supply of salvage parts and Guardian Eyes for augments and Impulse Laser Modules. See [Salvage](nautec:getting_started/salvage.md) for the extra mob drops and [Crates and Etching](nautec:getting_started/etching.md) for cleaning salvage parts.

## <Color id="gold">Power</Color>

Aim a laser beam into any face. The spawner holds up to 500 AP and spends 50 AP each tick while it runs, so a beam of 50 AP or more keeps it running nonstop. A weaker beam still works, in bursts, as the buffer refills. See [Laser Power](nautec:getting_started/laser_power.md) for ways to supply it.

It runs whenever it has power and a free storage slot, with no player needed nearby and no light or space rules. The runes brighten and the mob inside spins faster while it is working.

## <Color id="gold">Drops</Color>

Each cycle takes as long as the spawner's own spawn delay. At the end of it, the spawner rolls the mob's loot once for every mob it would have spawned, counted as a player kill, so drops that need a player kill are included. The results go into 54 slots of storage, the same as a double chest.

When every slot is taken, the spawner pauses and keeps its buffer full until a slot opens up. Any part of a roll that does not fit is lost.

Hoppers and pipes pull drops out, from any face by default ([Side Configuration](nautec:getting_started/utilities.md)). Only the spawner puts items in.

## <Color id="gold">Experience</Color>

The spawner also keeps the experience its mobs would drop, as liquid experience in a tank of 16,000 mB. Each experience point becomes 20 mB, the rate most mods use for liquid experience. Once the tank is full, new experience is lost; the spawner keeps running.

By default the liquid is Experience Algae, a glowing green fluid. If your pack has another mod's liquid experience, list its fluid id first in `confinedSpawnerXpFluids` in `config/nautec-common.toml` and the spawner makes that instead. Experience Algae is in the `c:experience` fluid tag, so mods that accept liquid experience by tag take it too.

Pipe the experience out of any face (fluids follow [Side Configuration](nautec:getting_started/utilities.md) separately from items), or right-click the spawner with an empty bucket. Pipes can only drain the tank. The third bar on the screen's left tab shows how full it is. Breaking the spawner keeps the experience in the dropped item.

## <Color id="gold">The Screen</Color>

Right-click the spawner to see its storage and take items out. The tab on the left has three bars: stored AP, the progress of the current cycle, and liquid experience. Hover over a bar for its numbers. The status beside the title says why it is stopped when it is not running.

## <Color id="gold">Filtering Drops</Color>

The funnel button beside the title opens the filter panel, with 18 filter slots.

* Click a slot while holding an item to filter that item. You can also drag an item in from JEI.
* Right-click a filled slot to step through the item's tags, then back to the exact item. A tag filter matches every item in that tag and shows a gold **#**.
* Click a slot with an empty hand to clear it.

The button at the top switches between two modes:

* **Blacklist** makes everything except the filtered drops.
* **Whitelist** makes only the filtered drops.

Filtered drops are never made, so they never take up storage. A whitelist with nothing in it stops the spawner until you add a filter.

## <Color id="gold">Jade</Color>

Looking at a Confined Spawner with Jade shows its mob, whether it is running, its stored AP and what is in its storage.

***

### <Color id="aqua">Spawner Confinement Matrix Recipe</Color>

<RecipeFor id="spawner_confinement_matrix"/>
