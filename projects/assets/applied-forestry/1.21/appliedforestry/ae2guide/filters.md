---
navigation:
  title: Genetic Filters
  icon: appliedforestry:genetic_export_bus
  parent: index.md
---

# Genetic Filter Reference

Terms separated by spaces form an **AND** group. Use `|` between groups for **OR**. The invert control negates the complete semantic filter but never allows unrelated non-genetic items.

| Example | Meaning |
|---|---|
| `species:common` | Active or inactive species is Common |
| `active_species:common` | Active species is Common |
| `inactive_species:cultivated` | Inactive species is Cultivated |
| `stage:drone` | Drone life stage |
| `analyzed:true` | Analyzed organisms only |
| `purebred:true` | Active and inactive species match |
| `fertility>=3` | Numeric fertility allele is at least 3 |
| `active.fertility>=3` | Active fertility allele is at least 3 |
| `inactive.species:cultivated` | Inactive species chromosome contains Cultivated |
| `category:bee` | Bees only |

Examples can be combined:

```text
category:bee stage:drone purebred:true
```

```text
active_species:common inactive_species:cultivated | active_species:cultivated inactive_species:common
```

Use the exact-stack button in a bus or emitter to add the complete carried ItemStack as an additional requirement. This includes every Forestry and Minecraft Data Component.

