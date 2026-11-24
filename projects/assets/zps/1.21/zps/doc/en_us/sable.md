# Sable Integration

These values become meaningful when [Sable](https://github.com/ryanhcode/sable) is present.

---

## Getter

| Getter | Output | Description |
|--------|--------|-------------|
| `sublevel` | SubLevel | Returns the sublevel containing the target block's position. If the target is not inside a sublevel, a sentinel value is returned. |

---

## Sublevel Mappers

Produced by: `sublevel`

| Mapper | Output | Description |
|--------|--------|-------------|
| `name` | String | The sublevel's display name. Returns `""` if unnamed or not inside a sublevel. |
| `id` | String | The sublevel UUID as a string. Returns `""` if not inside a sublevel. |
| `pos` | Vec Pos | The sublevel pose position in global space. Returns the target block's own centered position if not inside a sublevel. |
| `world_vel` | Vec Dir | The target block's global velocity, accounting for sublevel motion. Returns zero if not inside a sublevel. |
| `local_vel` | Vec Dir | The target block's velocity rotated into the sublevel's local frame. Returns zero if not inside a sublevel. |
| `bounding_box` | Vec Box | The sublevel bounding box dimensions in local space, in blocks. Does not change as the sublevel rotates. Returns zero if not inside a sublevel. |
| `dir <direction>` | Vec Dir | A cardinal direction (`north`, `south`, `east`, `west`, `up`, `down`) rotated to match the sublevel's current orientation. Returns the unrotated direction if not inside a sublevel. |

---

## Examples

Check if the block is in a sublevel:

```
if sublevel id == "" set_redstone 0 else set_redstone 15
```

Set redstone based on upward sublevel motion:

```
if sublevel world_vel y > 0 set_redstone 15
```

Check which way the sublevel's north is pointing:

```
if sublevel dir north y < 0 set_redstone 15
```

Activate when the sublevel is large:

```
if sublevel bounding_box volume > 1000 set_redstone 15
```
