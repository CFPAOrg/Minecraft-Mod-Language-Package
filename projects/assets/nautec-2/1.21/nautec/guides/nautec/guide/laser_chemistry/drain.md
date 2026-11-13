---
navigation:
  title: Deep Sea Drain
  icon: nautec:deep_sea_drain
  position: 5
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:deep_sea_drain
  - nautec:deep_sea_drain_wall
---

# <Color id="light_purple">Deep Sea Drain</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="deep_sea_drain" scale="2"/>
  A 3x3 multiblock that pumps Salt Water out of the ocean.
</Column>

## <Color id="gold">Building It</Color>

Lay a flat 3x3: the Deep Sea Drain in the middle and eight Deep Sea Drain Walls around it. Right-click the Deep Sea Drain with an <ItemLink id="aquarine_steel_wrench"/> to form it.

<GameScene zoom="4" background="#333333" interactive={true}>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="1" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="0"/>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain" x="1" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="1"/>
  <Block id="nautec:deep_sea_drain_wall" x="0" y="0" z="2"/>
  <Block id="nautec:deep_sea_drain_wall" x="1" y="0" z="2"/>
  <Block id="nautec:deep_sea_drain_wall" x="2" y="0" z="2"/>
  <IsometricCamera yaw="225" pitch="30"/>
</GameScene>

It pumps in an ocean-like biome with all nine blocks directly above it water. Building it on the sea floor covers both. Any biome tagged as an ocean or sea counts, including modded ones, and it is enough for either the drain or the top of the water above it to be in one, so a sea floor that a worldgen mod gives a cave or trench biome still works.

***

## <Color id="gold">Powering It</Color>

The drain needs more than 20 AP per tick (configurable). An <ItemLink id="aquatic_catalyst"/> gives:

| Fuel | AP per tick |
|---|---|
| Prismarine Crystals | 6 |
| Prismarine Shard | 12 |
| Prismarine Crystal Shard | 12 |

Two catalysts burning shards, merged in a [Laser Junction](laser_manipulation.md), give 24 and run the drain. Four are needed on Prismarine Crystals. A junction splits its power evenly between its outputs, so give it a single output toward the drain.

The beam goes in through a laser port. With the wrench, right-click one of the four middle wall pieces (not a corner). Any face works: the port always faces outward, away from the drain, and a message confirms it. Aim the beam at that wall's outer side. The drain has one port at a time, so wrenching another middle wall moves it, and wrenching the same wall again sets it afresh.

***

## <Color id="gold">Running It</Color>

Shift-right-click the drain with both hands empty to open it. It opens once it has enough power. The valve turns, then the lid swings open over a few seconds. Shift-right-click again to close it.

If it does not open, a message says how much power it is receiving against what it needs. If it opens but something will stop it pumping, such as missing water or the wrong biome, the message says that too.

While open and powered it pumps Salt Water into a 128,000 mB tank. A beam just over 20 AP pumps 500 mB every second, and a stronger beam pumps more in direct proportion with no upper limit: every AP pumps 25 mB a second, so four times the beam pumps four times as much.

| Beam | Salt Water per second |
|---|---|
| just over 20 AP | about 500 mB |
| 80 AP | 2,000 mB |
| 320 AP | 8,000 mB |
| 2,000 AP | 50,000 mB |
| 20,000 AP | 500,000 mB |

Jade shows the drain's current rate. The base rate, the power it needs, how fast the rate grows with the beam (`drainPowerScaling`) and the tank size are all configurable. It is the steady source of Salt Water for the [Mixer](mixer.md), since ocean water in a Bucket stays plain water unless a pack has turned on `collectSaltWater` in `config/nautec-common.toml`.

* Take Salt Water out with a pipe on the bottom of the centre block.
* Or right-click any part of the drain with a Bucket or other fluid container. A Bucket fills once the tank holds at least 1,000 mB.

Look at a wall piece with the <ItemLink id="prism_monocle"/> to see how much fluid is stored. With Jade, looking at any part of the drain shows its state (Closed, Opening, Pumping Salt Water, Not enough power, No water above, Not in an ocean, or Tank full) and the power it receives.

<Color id="gold">Careful</Color>: an open, powered drain pulls everything above it down in a bubble column. Anything that gets into the drain takes drowning damage, dropped items included. Close it before you swim over it.

***

### <Color id="aqua">Recipes</Color>

***

## <Color id="gold">Stronger Beams</Color>

The Deep Sea Drain pumps more Salt Water on a stronger beam, in direct proportion rather than by the square root rule the machines follow: four times the beam pumps four times as much. The table above lists the rates. A pack can change this with `drainPowerScaling` in `config/nautec-common.toml`; 0.5 gives the square root rule.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for the rule and every machine it applies to.

<RecipeFor id="deep_sea_drain"/>

<RecipeFor id="deep_sea_drain_wall"/>
