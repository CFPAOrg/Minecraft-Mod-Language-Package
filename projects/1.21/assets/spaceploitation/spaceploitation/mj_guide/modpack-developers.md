---
navigation:
  title: Modpack Developers
  icon: minecraft:writable_book
  position: 7
---

# Modpack Developer Guide

This guide is for modpack developers who want to customize SpacePloitation content, add custom recipes, create new planet types, or integrate SpacePloitation into their modpacks.

## Overview

SpacePloitation uses **datapack registries** for most of its content, making it highly customizable through datapacks or KubeJS. You can:

- Create custom planet types
- Add custom upgrade types
- Create new Planet Simulator recipes
- Add new Compressor recipes
- Modify existing recipes

## Custom Planet Types

Planet types define how planet cards link to dimensions and biomes. They're stored in `data/<namespace>/spaceploitation/planet_type/`.

### Planet Type Format

```json
{
  "texture": "minecraft:item/planet_card/planets/overworld",
  "projection_texture": "spaceploitation:textures/planet/earth.png",
  "dimension": "minecraft:overworld",
  "biome": "minecraft:deep_dark",
  "tint": 2763306,
  "is_black_hole": false,
  "display_name": "Earth Planet Card"
}
```

### Fields Explained

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `texture` | ResourceLocation | Yes | Card item texture path |
| `projection_texture` | ResourceLocation | No | 3D planet projection texture (for Planet Simulator display) |
| `dimension` | ResourceKey | No | Dimension where this card can be activated |
| `biome` | ResourceKey | No | Specific biome required for activation (overrides dimension) |
| `structure` | ResourceKey | No | Specific structure required for activation |
| `tint` | Integer | No | Color tint for the card (RGB hex as decimal) |
| `is_black_hole` | Boolean | No | Special rendering for black holes (default: false) |
| `display_name` | String | No | Custom display name for the planet card item |

### Linking Priority

When a player right-clicks a planet card, SpacePloitation searches for matching planet types:

1. **Non-tinted planet cards** take priority over tinted cards
2. If multiple match, the first registered wins
3. If a `biome` is specified, it checks biome first, then falls back to `dimension`
4. If a `structure` is specified, player must be inside that structure

### Example: Custom Planet

Create a custom Mars-like planet for a modded dimension:

**File:** `data/mypack/spaceploitation/planet_type/custom_mars.json`

```json
{
  "texture": "mypack:item/custom_mars_card",
  "projection_texture": "mypack:textures/planet/custom_mars.png",
  "dimension": "mymod:mars_dimension",
  "tint": 16744192,
  "display_name": "Custom Mars Planet Card"
}
```

## Custom Upgrade Types

Upgrade types define how upgrades affect machines. They're stored in `data/<namespace>/spaceploitation/upgrade_type/`.

### Upgrade Type Format

```json
{
  "effects": [
    {
      "target": "duration",
      "percent_per_upgrade": -10.0
    },
    {
      "target": "energy_usage",
      "percent_per_upgrade": 5.0
    }
  ]
}
```

### Effect Targets

| Target | Description | Example Use |
|--------|-------------|-------------|
| `DURATION` | Affects recipe processing time | Speed upgrades (-10% = faster) |
| `ENERGY_USAGE` | Affects energy consumption | Energy upgrades (-10% = less power) |
| `LUCK_CHANCE` | Affects bonus output chance | Luck upgrades (+20% = more loot) |

### Effect Calculation

Effects stack multiplicatively. Formula: `newValue = baseValue × (1 + (percent / 100) × upgradeCount)`

**Example:** 2 Speed Upgrades with -10% duration each:
- Base duration: 1000 ticks
- Effect: 1000 × (1 + (-10 / 100) × 2) = 1000 × 0.8 = 800 ticks

### Example: Custom Upgrade

Create a balanced upgrade that reduces both time and energy:

**File:** `data/mypack/spaceploitation/upgrade_type/efficiency.json`

```json
{
  "effects": [
    {
      "target": "duration",
      "percent_per_upgrade": -5.0
    },
    {
      "target": "energy_usage",
      "percent_per_upgrade": -5.0
    }
  ]
}
```

## Planet Simulator Recipes

Planet Simulator recipes define space missions. They're stored in `data/<namespace>/recipe/` with type `spaceploitation:planet_simulator`.

### Recipe Format

```json
{
  "type": "spaceploitation:planet_simulator",
  "planet_type": "spaceploitation:earth",
  "catalysts": [
    {
      "ingredient": {
        "item": "minecraft:elytra"
      },
      "count": 1
    }
  ],
  "inputs": [
    {
      "ingredient": {
        "item": "minecraft:cobblestone"
      },
      "count": 64
    }
  ],
  "fluid_input": {
    "fluid": "minecraft:water",
    "amount": 1000
  },
  "energy_per_tick": 120,
  "duration": 800,
  "outputs": [
    {
      "item": {
        "id": "minecraft:diamond",
        "count": 1
      },
      "chance": 0.02
    },
    {
      "fluid": {
        "fluid": "minecraft:lava",
        "amount": 1000
      },
      "chance": 0.1
    }
  ]
}
```

### Fields Explained

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `planet_type` | ResourceKey | Yes | Which planet card is required (e.g., `spaceploitation:earth`) |
| `catalysts` | List | No | Items consumed once per recipe unlock (returned after) |
| `inputs` | List | No | Items consumed every recipe run |
| `fluid_input` | FluidIngredient | No | Fluid consumed per run |
| `energy_per_tick` | Integer | Yes | FE consumed per tick |
| `duration` | Integer | Yes | Recipe duration in ticks |
| `outputs` | List | Yes | Weighted outputs (items or fluids) |

### Output Chances

The `chance` field is the **probability per output** (0.0 to 1.0):

- `0.02` = 2% chance per item
- `1.0` = 100% guaranteed output
- Luck upgrades increase these chances by their percentage

### Catalyst System

Catalysts are special inputs that:
- Are consumed when the recipe starts
- Are returned when the recipe completes
- Act as "keys" for expensive/rare recipes (e.g., Elytra duplication)

### Example Recipes

**Simple Resource Generation:**

```json
{
  "type": "spaceploitation:planet_simulator",
  "planet_type": "spaceploitation:earth",
  "inputs": [
    {
      "ingredient": { "item": "minecraft:dirt" },
      "count": 64
    }
  ],
  "energy_per_tick": 100,
  "duration": 1000,
  "outputs": [
    {
      "item": { "id": "minecraft:clay", "count": 4 },
      "chance": 0.25
    }
  ]
}
```

**Advanced Catalyst Recipe:**

```json
{
  "type": "spaceploitation:planet_simulator",
  "planet_type": "spaceploitation:venus",
  "catalysts": [
    {
      "ingredient": { "item": "minecraft:nether_star" },
      "count": 1
    }
  ],
  "inputs": [
    {
      "ingredient": { "item": "minecraft:end_stone" },
      "count": 64
    }
  ],
  "energy_per_tick": 2000,
  "duration": 6000,
  "outputs": [
    {
      "item": { "id": "minecraft:dragon_egg", "count": 1 },
      "chance": 0.001
    }
  ]
}
```

## Compressor Recipes

Compressor recipes compress items into sheets. They're stored in `data/<namespace>/recipe/` with type `spaceploitation:compressing`.

### Recipe Format

```json
{
  "type": "spaceploitation:compressing",
  "ingredient": {
    "ingredient": {
      "item": "spaceploitation:tantalum_ingot"
    },
    "count": 1
  },
  "duration": 200,
  "result": {
    "id": "spaceploitation:tantalum_sheet",
    "count": 1
  }
}
```

### Fields Explained

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `ingredient` | IngredientWithCount | Yes | Input item and count |
| `duration` | Integer | Yes | Processing time in ticks (affected by upgrades) |
| `result` | ItemStack | Yes | Output item |

### Example: Compress Modded Items

```json
{
  "type": "spaceploitation:compressing",
  "ingredient": {
    "ingredient": {
      "item": "mymod:steel_ingot"
    },
    "count": 2
  },
  "duration": 300,
  "result": {
    "id": "mymod:steel_plate",
    "count": 1
  }
}
```

## Planet Power Recipes

Planet Power recipes generate energy from items. They're stored in `data/<namespace>/recipe/planet_power/` with type `spaceploitation:planet_power`.

### Recipe Format

```json
{
  "type": "spaceploitation:planet_power",
  "planet_type": "spaceploitation:mars",
  "input": {
    "ingredient": {
      "item": "minecraft:redstone"
    },
    "count": 1
  },
  "energy_per_tick": 500,
  "duration": 100
}
```

### Fields Explained

| Field | Type | Required | Description |
|-------|------|----------|-------------|
| `planet_type` | ResourceKey | Yes | Which planet card is required |
| `input` | IngredientWithCount | Yes | Input item consumed |
| `energy_per_tick` | Integer | Yes | FE generated per tick |
| `duration` | Integer | Yes | Duration in ticks |

**Total Energy Generated:** `energy_per_tick × duration`

### Example: Custom Power Generation

```json
{
  "type": "spaceploitation:planet_power",
  "planet_type": "spaceploitation:blackhole",
  "input": {
    "ingredient": {
      "tag": "c:ender_pearls"
    },
    "count": 1
  },
  "energy_per_tick": 2000,
  "duration": 200
}
```

This generates **400,000 FE total** (2000 × 200) per ender pearl!

## KubeJS Integration

SpacePloitation is compatible with KubeJS! Here's how to add recipes via KubeJS:

### Planet Simulator Recipe

```javascript
ServerEvents.recipes(event => {
  event.custom({
    type: 'spaceploitation:planet_simulator',
    planet_type: 'spaceploitation:earth',
    inputs: [
      {
        ingredient: { item: 'minecraft:oak_log' },
        count: 16
      }
    ],
    energy_per_tick: 50,
    duration: 400,
    outputs: [
      {
        item: { id: 'minecraft:charcoal', count: 8 },
        chance: 1.0
      }
    ]
  })
})
```

### Compressor Recipe

```javascript
ServerEvents.recipes(event => {
  event.custom({
    type: 'spaceploitation:compressing',
    ingredient: {
      ingredient: { item: 'minecraft:iron_ingot' },
      count: 1
    },
    duration: 200,
    result: {
      id: 'minecraft:iron_block',
      count: 1
    }
  })
})
```

## Integration Tips

### Balancing Recipes

- **Early Game:** 50-200 FE/tick, 400-1000 duration, 0.01-0.05 chance
- **Mid Game:** 200-500 FE/tick, 1000-2000 duration, 0.05-0.15 chance
- **Late Game:** 500-2000 FE/tick, 2000-6000 duration, 0.001-0.01 chance (rare items)
- **Endgame:** 2000+ FE/tick, 6000+ duration, 0.0001-0.001 chance (ultra-rare)

### Catalyst Usage

Use catalysts for:
- Item duplication (Elytra, Dragon Eggs, Nether Stars)
- Gated progression (require a rare item to unlock powerful recipes)
- Expensive recipes (e.g., creative-only items)

### Planet Type Guidelines

- Link planets to thematic dimensions (lava planets → Nether)
- Use biome-specific planets for rare content (Deep Dark → Black Hole)
- Consider progression: Overworld → Nether → End → Modded dimensions

## Troubleshooting

### Recipe Not Showing in JEI

1. Check recipe JSON syntax with a validator
2. Ensure `planet_type` exists in `spaceploitation/planet_type/`
3. Restart the game after adding datapacks
4. Check logs for recipe parsing errors

### Planet Card Not Linking

1. Verify the dimension/biome exists in the world
2. Check that `texture` path is valid
3. Ensure no conflicting planet types (non-tinted takes priority)
4. Try unlinking/relinking the card

### Upgrade Not Working

1. Verify `target` is one of: `DURATION`, `ENERGY_USAGE`, `LUCK_CHANCE`
2. Check that the upgrade item references the correct upgrade type
3. Ensure the upgrade is properly installed in the machine

## Additional Resources

- **Recipe Viewer:** Use JEI/REI to view all recipes in-game
- **DataPack Guide:** See Minecraft's official datapack documentation
- **Examples:** Check `data/spaceploitation/recipe/` in the mod JAR for examples

## Questions?

For modpack support, visit the SpacePloitation GitHub issues page or Discord server!
