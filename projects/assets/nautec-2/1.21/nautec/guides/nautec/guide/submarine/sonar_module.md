---
navigation:
  title: Sonar Module
  icon: nautec:sonar_module
  position: 11
  parent: submarine/submarine-index.md
item_ids:
  - nautec:sonar_module
---

# <Color id="light_purple">Sonar Module</Color>

<Column alignItems="center" fullWidth={true}>
  <ItemImage id="sonar_module" scale="2"/>
  Ore and hostiles through rock.
</Column>

One Sonar Module ping marks every ore vein within 48 blocks and every hostile creature within 32 blocks, through solid rock, and gives the crew night vision.

***

## <Color id="gold">Using It</Color>

| | Default |
|---|---|
| Power per ping | 30,000 |
| Ore range | 48 blocks |
| Hostile range | 32 blocks |
| Cooldown | 45 seconds |

Fire it and a ring sweeps out from the hull through the terrain. Each ore vein is outlined as the ring reaches it, coloured by the kind of ore, and stays marked through the rock for 45 seconds, fading at the end. Anything that counts as ore in the common ore tag shows up, so ores from other mods appear too.

Hostile creatures within 32 blocks of the ping are outlined in red for the same 45 seconds, following them as they move, and also glow for 15 seconds.

Everyone aboard gets 45 seconds of night vision, which matters in deep water where little light reaches.

Both ranges are measured from where the hull was when it pinged, so ping again after moving to scan new ground. The power cost, hostile range and cooldown are configurable.

***

### <Color id="aqua">Sonar Module Recipe</Color>

<Recipe id="nautec:sonar_module"/>
