# 获取器

获取器（getter）会从世界或执行上下文中获取值。它们不接受参数，且必定是条件和`value_of()`表达式中的首个元素。

部分获取器只有特定类型的方块可用。

---

## 所有方块

可用于：任意目标方块

| 获取器      | 输出       | 描述                                                          |
| ----------- | ---------- | ------------------------------------------------------------- |
| `pos`       | BlockPos   | 目标方块的位置。                                              |
| `block`     | BlockState | 目标方块的方块状态。                                          |
| `dimension` | Dimension  | 目标方块所在的维度，形式为形如`minecraft:overworld`的维度键。 |
| `redstone`  | Int        | 目标方块从所有相邻位置处收到的红石信号中强度最强者。          |

例如：

```
if pos == 0 64 0 set_redstone 15
set_redstone value_of(pos x & 15)
```

```
if block == minecraft:piston[facing=up] set_redstone 15
```

```
if dimension == minecraft:the_nether set_redstone 15
```

```
if redstone > 7 set_redstone 15 else set_redstone 0
set_redstone value_of(redstone + 1)
```

---

## 数据讲台 / 讲台

下方获取器需要目标方块为放有书的`数据讲台`或原版`讲台`。

| 获取器          | 输出   | 描述                                                             |
| --------------- | ------ | ---------------------------------------------------------------- |
| `page_number`   | Int    | 书当前页的页码，从1起始。未放置书则返回`0`。                     |
| `page_contents` | String | 当前页的文本内容，包括换行。未放置书或当前页为空则返回空字符串。 |

例如：

```
if page_number > 3 set_redstone 15
set_page value_of(page_number + 1)
```

```
if page_contents == "打开" set_redstone 15
write_page value_of(page_contents + "（已编辑）")
```

---

## 脚本终端

下方获取器需要目标方块为`脚本终端`。

| 获取器            | 输出   | 描述                                                                                                          |
| ----------------- | ------ | ------------------------------------------------------------------------------------------------------------- |
| `script_contents` | String | 终端的脚本内容，和`.mungus`的保存格式一致：形如`# 4t REPEAT`的头部行，然后再接脚本。`load_script`可原样读回。 |

例如：

```
if script_contents lines > 20 set_redstone 15
write_page value_of(script_contents)
```

---

## 机械臂

下方获取器需要目标方块为`机械臂`。

| 获取器           | 输出 | 描述                                                          |
| ---------------- | ---- | ------------------------------------------------------------- |
| `held_item`      | Item | 机械手当前持有的物品。手中无物品则返回空堆叠。                |
| `transfer_count` | Int  | `take_items`、`put_items`、`drop_items`能移动的最大堆叠数量。 |

所得的Item可用`==`与物品谓词比较，可用`count`读取堆叠的数量，也可用`id`将其ID读取为文本。

例如：

```
if held_item == minecraft:lava_bucket use 6 1 4
```

```
if held_item count > 0 put_items 0 1 2 else take_items 1 3 5
```

```
if transfer_count < 16 set_transfer_count 16
```

---

## 无线电发射器 / 无线电接收器

下方获取器需要目标方块为`无线电发射器`或`无线电接收器`。

| 获取器      | 输出 | 描述                                    |
| ----------- | ---- | --------------------------------------- |
| `frequency` | Int  | 该方块所在的无线电频道（1到64的整数）。 |

例如：

```
if frequency == 10 set_redstone 15
set_frequency value_of(frequency + 1)
```

---

## 能量单元

下方获取器需要目标方块为`能量单元`或`创造能量单元`。

| 获取器          | 输出 | 描述                                                                                               |
| --------------- | ---- | -------------------------------------------------------------------------------------------------- |
| `stored_energy` | Int  | 能量单元结构中存有的FE量。多方块中的所有单元都会返回结构的总存量。`创造能量单元`会返回最大整数值。 |

例如：

```
if stored_energy < 100000 set_redstone 15 else set_redstone 0
```

---

## 气体仪表

下方获取器需要目标方块为`气体仪表`。

| 获取器        | 输出   | 描述                                                                                                                     |
| ------------- | ------ | ------------------------------------------------------------------------------------------------------------------------ |
| `gauge_value` | Double | 仪表的读数：压力单位为帕斯卡，温度单位为开尔文。所得值不会缩放，也不会根据仪表数据范围截断。更改仪表模式会改变所读数据。 |

例如：

```
if gauge_value > 8000000 set_redstone 15 else set_redstone 0
```

---

## 额外获取器

- [Sable](sable.md)：`sublevel`
