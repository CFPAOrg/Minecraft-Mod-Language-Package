---
navigation:
  title: Osmosis Filter
  icon: nautec:osmosis_filter
  position: 5
  parent: laser_chemistry/laser_chemistry-index.md
item_ids:
  - nautec:osmosis_filter
---

# <Color id="light_purple">Osmosis Filter</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="osmosis_filter" scale="2"/>
  Makes Water on its own, with no fuel, inputs or beam.
</Column>

## <Color id="gold">Using It</Color>

Place it anywhere and it starts filling its tank with 1,000 mB (1 bucket) of Water each second. It stops when the tank holds 16,000 mB (16 buckets, configurable), and the panel on its front glows while it is filtering.

* Right-click with an empty Bucket to take 1,000 mB out. Other fluid containers work too.
* Pipes can pull Water out of any face. Nothing can be put in.
* Every face gives Water by default. [Side Configuration](nautec:getting_started/utilities.md) turns faces off or on separately.

Right-click it with an empty hand to see the tank, how much Water it makes each second and the AP arriving. Jade shows the tank and the rate too.

Feed the Water to a [Mixer](mixer.md) with Salt to make Salt Water, or to a [Combustion Dynamo](nautec:getting_started/combustion_dynamo.md).

***

## <Color id="gold">Stronger Beams</Color>

The Osmosis Filter needs no beam, but a laser beam into any face makes it faster: every 40 AP doubles its output, up to 1,024,000 mB each second (both configurable).

| Beam | Water each second |
|---|---|
| none | 1,000 mB |
| 40 AP | 2,000 mB |
| 80 AP | 4,000 mB |
| 160 AP | 16,000 mB |
| 320 AP | 256,000 mB |
| 400 AP | 1,024,000 mB |

On a beam that makes more than 16,000 mB each second, the tank fills to one second of output instead, so it never stalls between pulls. If the beam weakens, Water already in the tank stays there; it only stops making more until you take some out.

See [Stronger Beams](nautec:getting_started/stronger_beams.md) for every machine a stronger beam speeds up.

<RecipeFor id="osmosis_filter"/>
