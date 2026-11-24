# Create Integration

When [Create](https://modrinth.com/mod/create) is loaded, ZPS adds extra executors for supported blocks in Create or Create addons.

These executors allow automating behaviors in Create which usually require a player to tweak, such as speed, mode, range, or stack size.

Use tab-completion in the Script Terminal to see which `set_*` commands are available for the block you are targeting. The list of options depends on which blocks are targeted and which Create addons are loaded.

---

## Common Commands

| Executor | Argument | Description |
|----------|----------|-------------|
| `set_filter` | `<item>` | Sets the item filter on supported Create blocks. |
| `set_rpm` | `<int>` | Sets a block's speed in RPM. |
| `set_rotation_mode` | `<mode>` | Changes the mode used by a Mechanical Bearing. |
| `set_clock_hand` | `<mode>` | Changes the hand arrangement of a Clockwork Bearing. |
| `set_sticky_range` | `<int>` | Sets how many sticky sides a chassis uses. |
| `set_stack_size` | `<int>` | Sets the ejected stack size of a Weighted Ejector. |

Examples:

```
set_filter minecraft:iron_ingot
set_rpm 64
set_rotation_mode ROTATE
set_sticky_range 4
set_stack_size 16
```

---

## Where They Apply

Some commonly supported blocks include:

- `set_filter`: Mechanical Saw, Deployer, Track Observer, Stockpile Switch, Item Hatch, Brass Funnel, Smart Fluid Pipe, Smart Observer, Smart Chute, Mechanical Roller, Basin
- `set_rpm`: Creative Motor, Rotation Speed Controller
- `set_rotation_mode`: Mechanical Bearing
- `set_clock_hand`: Clockwork Bearing
- `set_sticky_range`: Linear Chassis, Secondary Linear Chassis, Radial Chassis
- `set_stack_size`: Weighted Ejector

If a command does not appear in tab-completion for the current target block, that block does not support it.

---

## Using Create Commands in Scripts

Create executors work like any other executor, so you can use literals, `value_of(...)`, and conditionals:

```
set_rpm value_of(redstone * 8)
```

```
if redstone > 7 set_rotation_mode ROTATE_PLACE
```

```
if block == create:weighted_ejector set_stack_size 16
```
