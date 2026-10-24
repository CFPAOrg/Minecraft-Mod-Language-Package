---
navigation:
  title: 基因筛选器
  icon: appliedforestry:genetic_export_bus
  parent: index.md
---

# 基因筛选器参考

空格分隔的各项形成**与**分组。在分组间使用`|`代表**或**逻辑。反相会对语义筛选器整体取反，但不会因此允许不具备基因的无关物品通过。

| 示例                          | 意义                          |
| ----------------------------- | ----------------------------- |
| `species:common`              | 活跃或非活跃品种基因为寻常    |
| `active_species:common`       | 活跃品种基因为寻常            |
| `inactive_species:cultivated` | 非活跃品种基因为田野          |
| `stage:drone`                 | 生命阶段为雄蜂                |
| `analyzed:true`               | 仅限经过分析的生物体          |
| `purebred:true`               | 活跃基因和非活跃基因匹配      |
| `fertility>=3`                | 生育能力等位基因数值至少为3   |
| `active.fertility>=3`         | 活跃的生育能力等位基因至少为3 |
| `inactive.species:cultivated` | 非活跃的品种基因中包含田野    |
| `category:bee`                | 仅限蜜蜂                      |

上方的示例可以组合：

```text
category:bee stage:drone purebred:true
```

```text
active_species:common inactive_species:cultivated | active_species:cultivated inactive_species:common
```

总线和发信器中的精确匹配按钮可额外将所给的ItemStack整体作为匹配需求。此类需求会匹配林业和Minecraft的所有数据组件。

