---
navigation:
  title: 模组包开发者
  icon: minecraft:writable_book
  position: 7
---

# 模组包开发者指南

本篇指南可帮助模组包开发者自定义SpacePloitation的游戏内容，加入自定义配方，创建新行星类别，或是将SpacePloitation整合到模组包中。

## 概览

SpacePloitation的大多数内容都使用**数据包注册**，因此可用数据包和KubeJS进行高度自定义。你可以：

- 创建自定义行星类别
- 添加自定义升级类别
- 创建新行星模拟器配方
- 添加新压缩器配方
- 修改已有配方

## 自定义行星类别

行星类别定义了行星卡与维度及生物群系的连接方式，相关文件需存储于`data/<命名空间>/spaceploitation/planet_type/`。

### 行星类别格式

```json
{
  "texture": "minecraft:item/planet_card/planets/overworld",
  "projection_texture": "spaceploitation:textures/planet/earth.png",
  "dimension": "minecraft:overworld",
  "biome": "minecraft:deep_dark",
  "tint": 2763306,
  "is_black_hole": false,
  "display_name": "地球行星卡"
}
```

### 字段解释

| 字段                 | 类别             | 必需与否 | 描述                                        |
| -------------------- | ---------------- | -------- | ------------------------------------------- |
| `texture`            | ResourceLocation | 是       | 行星卡物品纹理路径                          |
| `projection_texture` | ResourceLocation | 否       | 3D行星投影纹理（供行星模拟器展示使用）      |
| `dimension`          | ResourceKey      | 否       | 可激活此卡的维度                            |
| `biome`              | ResourceKey      | 否       | 激活时需身处的生物群系（会覆盖`dimension`） |
| `structure`          | ResourceKey      | 否       | 激活时需身处的结构                          |
| `tint`               | Integer          | 否       | 行星卡的着色（十进制形式的RGB十六进制编码） |
| `is_black_hole`      | Boolean          | 否       | 黑洞的特殊渲染效果（默认：false）           |
| `display_name`       | String           | 否       | 行星卡物品的自定义显示名称                  |

### 连接优先级

玩家手持行星卡右击时，SpacePloitation会按此搜索匹配的行星类别：

1. **未着色的行星卡**优先于有着色的
2. 多个类别匹配时，选取最先注册的
3. 若指定`biome`，则优先检查生物群系，未成功则检查`dimension`
4. 若指定`structure`，则玩家必须身处该结构

### 示例：自定义行星

为模组维度创建一个自定义类火行星：

**文件**：`data/mypack/spaceploitation/planet_type/custom_mars.json`

```json
{
  "texture": "mypack:item/custom_mars_card",
  "projection_texture": "mypack:textures/planet/custom_mars.png",
  "dimension": "mymod:mars_dimension",
  "tint": 16744192,
  "display_name": "自定义火星行星卡"
}
```

## 自定义升级类别

升级类别定义了升级影响机器性能的方式，相关文件需存储于`data/<命名空间>/spaceploitation/upgrade_type/`。

### 升级类别格式

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

### 效果目标

| 目标           | 描述               | 使用示例                      |
| -------------- | ------------------ | ----------------------------- |
| `DURATION`     | 影响配方的处理时间 | 速度升级（-10% = 加快）       |
| `ENERGY_USAGE` | 影响能量消耗       | 能量升级（-10% = 少耗能）     |
| `LUCK_CHANCE`  | 影响额外产出概率   | 幸运升级（+20% = 更多战利品） |

### 效果的计算

效果会乘算叠加。公式为`新值 = 基础值 × (1 + (百分比 / 100) × 升级数量)`

**示例**：2张速度升级，每张-10%处理时间：
- 基础处理时间：1000刻
- 效果：1000 × (1 + (-10 / 100) × 2) = 1000 × 0.8 = 800刻

### 示例：自定义升级

创建一张同时减少处理时间和能量消耗的均衡升级：

**文件**：`data/mypack/spaceploitation/upgrade_type/efficiency.json`

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

## 行星模拟器配方

行星模拟器配方定义了航天任务的种类，相关文件需存储于`data/<命名空间>/recipe/`，`type`使用`spaceploitation:planet_simulator`。

### 配方格式

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

### 字段解释

| 字段              | 类别            | 必需与否 | 描述                                        |
| ----------------- | --------------- | -------- | ------------------------------------------- |
| `planet_type`     | ResourceKey     | 是       | 需要哪张行星卡（如`spaceploitation:earth`） |
| `catalysts`       | List            | 否       | 每次解锁配方所需的物品（会返还）            |
| `inputs`          | List            | 否       | 每次执行配方消耗的物品                      |
| `fluid_input`     | FluidIngredient | 否       | 每次执行配方消耗的流体                      |
| `energy_per_tick` | Integer         | 是       | 每刻消耗的FE                                |
| `duration`        | Integer         | 是       | 配方的处理时间，以刻计                      |
| `outputs`         | List            | 是       | 带权重的产出（物品或流体）                  |

### 输出概率

`chance`字段代表**每次产出有该产物的概率**（0.0到1.0）：

- `0.02` = 每物品2%概率
- `1.0` = 100%必定产出
- 幸运升级会依照其百分比增加此概率

### 催化剂系统

催化剂是一类特殊的输入，它们的行为如下：
- 会在配方开始时消耗
- 会在配方结束时返还
- 相当于昂贵/稀有配方（如鞘翅复制配方）的“钥匙”

### 示例配方

**简单资源生成：**

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

**高级催化剂配方：**

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

## 压缩器配方

压缩器配方能将物品压制为板材，相关文件需存储于`data/<命名空间>/recipe/`，`type`使用`spaceploitation:compressing`。

### 配方格式

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

### 字段解释

| 字段         | 类别                | 必需与否 | 描述                           |
| ------------ | ------------------- | -------- | ------------------------------ |
| `ingredient` | IngredientWithCount | 是       | 输入物品及其数量               |
| `duration`   | Integer             | 是       | 处理时间，以刻计（受升级影响） |
| `result`     | ItemStack           | 是       | 输出物品                       |

### 示例：压缩模组物品

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

## 行星能量产出配方

行星能量产出配方可消耗物品产出能量，相关文件需存储于`data/<命名空间>/recipe/planet_power/`，`type`使用`spaceploitation:planet_power`。

### 配方格式

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

### 字段解释

| 字段              | 类别                | 必需与否 | 描述             |
| ----------------- | ------------------- | -------- | ---------------- |
| `planet_type`     | ResourceKey         | 是       | 需要哪张行星卡   |
| `input`           | IngredientWithCount | 是       | 消耗的输入物品   |
| `energy_per_tick` | Integer             | 是       | 每刻的FE产量     |
| `duration`        | Integer             | 是       | 持续时间，以刻计 |

**能量总产量**：`energy_per_tick × duration`

### 示例：自定义能量产出

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

此配方可让每颗末影珍珠产出**总共400000 FE**（2000 × 200）！

## KubeJS兼容

SpacePloitation与KubeJS兼容！下方是通过KubeJS添加配方的方法：

### 行星模拟器配方

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

### 压缩器配方

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

## 兼容提示

### 配方平衡性

- **游戏前期**：50-200 FE/刻，持续时间400-1000，概率0.01-0.05
- **游戏中期**：200-500 FE/刻，持续时间1000-2000，概率0.05-0.15
- **游戏后期**：500-2000 FE/刻，持续时间2000-6000，概率0.001-0.01（稀有）
- **游戏末期**：2000+ FE/刻，持续时间6000+，概率0.0001-0.001（极其稀有）

### 催化剂的使用

使用催化剂的合适场景：
- 物品复制（鞘翅、龙蛋、下界之星）
- 带锁的推进（如需要稀有物品解锁强大的配方）
- 昂贵的配方（如仅限创造模式的物品）

### 行星类型指导条例

- 根据维度主题建立关联（熔岩行星 → 下界）
- 稀有内容应使用限制生物群系的行星（深暗之域 → 黑洞）
- 将游戏内容的推进纳入考量：主世界 → 下界 → 末地 → 模组维度

## 问题检修

### 配方未在JEI中显示

1. 使用验证器检查配方JSON的语法
2. 确保`spaceploitation/planet_type/`中有对应的`planet_type`
3. 添加数据包后重启游戏
4. 检查日志中的配方解析错误

### 行星卡无法建立连接

1. 确认世界中存在对应的维度/生物群系
2. 检查`texture`路径是否有效
3. 确保没有冲突的行星类别（未着色的优先选取）
4. 尝试断开连接/重新进行连接

### 升级无效

1. 确认`target`为以下值之一：`DURATION`、`ENERGY_USAGE`、`LUCK_CHANCE`
2. 检查升级物品是否引用了正确的升级类别
3. 确保机器正确安装了升级

## 额外资源

- **配方查看器**：使用JEI/REI在游戏内查看所有配方
- **数据包指南**：见Minecraft的官方数据包文档
- **示例**：可查阅模组JAR文件中的`data/spaceploitation/recipe/`

## 还有疑问？

如有关于模组包支持的事项，欢迎访问SpacePloitation的GitHub议题页面，也欢迎加入Discord服务器！
