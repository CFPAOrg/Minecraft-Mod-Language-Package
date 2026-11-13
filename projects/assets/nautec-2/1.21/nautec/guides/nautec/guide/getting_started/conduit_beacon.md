---
navigation:
  title: Conduit Beacon
  icon: nautec:conduit_beacon
  position: 19
  parent: getting_started/getting_started-index.md
item_ids:
  - nautec:conduit_beacon
---

# <Color id="light_purple">Conduit Beacon</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="conduit_beacon" scale="2"/>
  A laser powered Conduit that also keeps mobs from spawning around your base.
</Column>

Build it the way you build a vanilla Conduit: the beacon sits in water, with the 3 x 3 x 3 space around it all water, inside a frame of Prismarine, Prismarine Bricks, Dark Prismarine or Sea Lanterns. It needs at least 16 frame blocks to start, and a full frame is 42.

While it runs, it does two things:

* It gives Conduit Power to players in water or rain, the same as a Conduit with the same frame. A 16 block frame reaches 32 blocks, and a full frame reaches 96.
* No hostile, passive or ambient mob spawns naturally within 128 blocks of it, horizontally, at any height. Spawners, spawn eggs, breeding, raids and water creatures such as fish and squid are not affected.

***

## <Color id="gold">Power</Color>

Point a laser beam at the beacon. Every frame position in line with it is part of the frame, so leave one gap for the beam: a frame slot with a beam coming through it counts as filled, so a full frame still reaches 96 blocks.

The beacon stores up to 5,000 AP. Incoming power fills the store, and the beacon runs from it at 50 AP per tick, so it keeps going for about 5 seconds after the beam stops. Any purity works.

A redstone signal on the beacon or on any of its frame blocks turns it off. Since the beacon is always surrounded by water, put a lever or a redstone line on a frame block.

Look at it through a <ItemLink id="prism_monocle"/> to see its status, frame size, reach and stored power.

The power use, the store and the spawn radius are `conduitBeaconPowerUsage`, `conduitBeaconBuffer` and `conduitBeaconSpawnRadius` in `config/nautec-common.toml`.

<RecipeFor id="conduit_beacon"/>
