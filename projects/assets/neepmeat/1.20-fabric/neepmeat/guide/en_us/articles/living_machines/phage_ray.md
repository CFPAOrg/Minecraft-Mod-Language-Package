---
id: phage_ray
lookup: neepmeat:phage_ray, neepmeat:extractor
---

# Phage Ray

\columns[fit=second]{The Phage Ray unleashes a concentrated beam of destruction that can rapidly destroy many blocks.
}{\item_render{neepmeat:phage_ray}}

## Usage

The Phage Ray is a machine component, so it requires a connected Machine Controller before it can run. When a valid structure is formed, 100eJ/t [note: this will change] must be supplied to the base using a vascular network. 

The machine can be controlled manually by right-clicking. Sneak-clicking the base allows the range and NEEPBus configuration to be specified.

With no extra components, the beam will destroy blocks completely. Installing a Harvest Extractor causes drops to be deposited into a connected Item Output. Installing a Silky Extractor allows blocks to be harvested with silk touch.

Required components:

- Phage Ray

Optional components:

\columns[fit=first]{\item_render[height=18]{neepmeat:extractor}}{Harvest Extractor}
\columns[fit=first]{\item_render[height=18]{neepmeat:silky_extractor}}{Silky Extractor}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_output_port}}{Item Output Port}

# NEEPBus

\columns[fit=second]{The aiming direction and firing status of the Phage Ray can be controlled via NEEPBus. There are input ports for pitch, yaw, firing status and target position.
}{\item_render[height=30]{neepmeat:data_cable}}

The pitch and yaw ports expect a number in degrees that corresponds to the desired angle.

Yaw: 0° is north, 90° is west, -90° is east.
Pitch: 0° is horizontal, -90° is straight up, 90° is straight down.

It is often more convenient to use the `target position` port, rather than setting pitch and yaw manually. This port expects a string containing coordinates of the form `@(X Y Z)`, the same format used by the PLC. When one is received, the Phage Ray will aim towards that position.

\columns[fit=second]{Using the PLC and the `AREA3` instruction, a Phage Ray can be made to automatically mine a large area of land.
}{\item_render[height=30]{neepmeat:plc}}

## Quarry Example

```
# Callback that sends each block position to the phage ray
:noname "target pos" .nbwrite ; ;

# Bounding coordinates
@(1 0 0) @(100 100 100)

# Fire the beam
-1 "fire" .nbwrite

# Run the callback for each block in the region
area3

# Swich off the beam
0 "fire" .nbwrite
```

# Meatgun Module

A handheld version of the Phage Ray is also available. Its less intense beam can harvest blocks and its speed can be increased with drill speed modifiers. It runs on energy units.
\columns{\item_render[height=30]{meatweapons:short_phage_ray}}{\item_render[height=30]{meatweapons:phage_ray_speed_modifier}}
