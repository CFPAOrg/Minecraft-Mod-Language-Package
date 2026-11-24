# Genesis Integration

When [Genesis](https://modrinth.com/mod/genesis) is loaded, commands for querying celestial bodies become available.

---

## Getter

| Getter      | Output     | Description                                                   |
|-------------|------------|---------------------------------------------------------------|
| `celestial` | Celestials | This is the starting point for all Genesis celestial queries. |

---

## Celestials Mappers

Produced by: `celestial`

| Mapper | Output | Description |
|--------|--------|-------------|
| `current` | Celestial | Returns the celestial body associated with the current dimension, or null if the current dimension is not a celestial surface. |
| `nearest` | Celestial | Returns the nearest celestial body to the target block's position. Useful in the space dimension, where `current` returns null. |
| `of <celestial_id>` | Celestial | Returns a specific celestial body by its resource location. |

Examples:

```
if celestial current == genesis:moon set_redstone 15
```

```
if celestial nearest size > 0 set_redstone 15
```

```
if celestial of genesis:moon gravity < 0.5 set_redstone 15
```

---

## Celestial Mappers

Produced by: `celestial current`, `celestial nearest`, `celestial of <celestial_id>`

| Mapper | Output | Description |
|--------|--------|-------------|
| `gravity` | Double | Surface gravity of the celestial body, as a multiplier on vanilla gravity (the overworld is 1) |
| `size` | Double | Diameter of the celestial body in blocks |
| `is_visitable` | Boolean | True if the body has a dimension of its own to arrive in |
| `pos` | Vec Pos | The celestial body's current position in the space dimension |
| `as_string` | String | The resource location of the celestial body |
| `== <celestial_id>` | Boolean | True if equal to the given celestial |

Examples:

```
if celestial current gravity < 0.5 set_redstone 15
if celestial current is_visitable set_redstone 15
```

---

## Null Safety

If `current` or `nearest` returns null (e.g. no celestial is associated with the current dimension), all subsequent celestial mappers return safe defaults:
- Numeric mappers return `0` or `0.0`
- Boolean mappers return `false`
- String mappers return an empty string
- `pos` returns `Vec3.ZERO`
