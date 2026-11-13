# 映射器

映射器（mapper）必定跟随在获取器或其他映射器后方，会将先前值变换为新值。它们有时会接受一个参数，可以是字面量，也可以是`value_of()`表达式。

可用映射器由先前值的类型决定。

---

## BlockPos

获取自：`pos`、`string as_block_pos`、`vec_pos rounded_down`

| 映射器           | 输出     | 描述                                                |
| ---------------- | -------- | --------------------------------------------------- |
| `x`              | Int      | X坐标                                               |
| `y`              | Int      | Y坐标                                               |
| `z`              | Int      | Z坐标                                               |
| `center`         | Vec Pos  | 中央的浮点数位置（`x + 0.5`、`y + 0.5`、`z + 0.5`） |
| `offset_x <int>` | BlockPos | 在X轴上偏移所给数后，返回所得位置                   |
| `offset_y <int>` | BlockPos | 在Y轴上偏移所给数后，返回所得位置                   |
| `offset_z <int>` | BlockPos | 在Z轴上偏移所给数后，返回所得位置                   |
| `offset <坐标>`  | BlockPos | 根据所给坐标各分量偏移后，返回所得位置              |
| `== <坐标>`      | Boolean  | 若等于所给位置，则返回True                          |
| `as_string`      | String   | 格式化为`"x y z"`                                   |

例如：

```
if pos x > 0 set_redstone 15
set_redstone value_of(pos y & 15)
```

---

## BlockState

获取自：`block`

| 映射器          | 输出    | 描述                                           |
| --------------- | ------- | ---------------------------------------------- |
| `== <方块谓词>` | Boolean | 若方块状态匹配谓词（支持方块属性），则返回True |
| `id`            | String  | 形如`"minecraft:stone"`的方块ID，不带其属性    |

例如：

```
if block == minecraft:stone set_redstone 15
if block == minecraft:piston[facing=up] set_redstone 15
if block id == value_of(page_contents) set_redstone 15
```

---

## Item

获取自：`held_item`

| 映射器          | 输出    | 描述                                                       |
| --------------- | ------- | ---------------------------------------------------------- |
| `== <物品谓词>` | Boolean | 若物品匹配谓词，则返回True                                 |
| `count`         | Int     | 堆叠数量；空手返回`0`                                      |
| `id`            | String  | 形如`"minecraft:stone"`的物品ID，空手返回`"minecraft:air"` |

`==`只接受脚本中写明的物品。如需比较脚本的读取和接收值，应比较`id`：

```
if held_item == minecraft:lava_bucket use 6 1 4
if held_item id == value_of(page_contents get_line 0) use 6 1 4
```

---

## Vec Pos

浮点数位置。获取自：`pos center`、`ship pos`、`sublevel pos`

| 映射器                | 输出     | 描述                         |
| --------------------- | -------- | ---------------------------- |
| `x`                   | Double   | X分量                        |
| `y`                   | Double   | Y分量                        |
| `z`                   | Double   | Z分量                        |
| `distance_to <坐标>`  | Double   | 与所给位置间的距离           |
| `direction_to <坐标>` | Vec Dir  | 指向所给位置的归一化方向向量 |
| `rounded_down`        | BlockPos | 向下取整各分量，得到方块位置 |

例如：

```
if ship pos distance_to 0 0 0 > 100 set_redstone 15
```

---

## Vec Box

尺寸向量（宽、高、深）。获取自：`ship bounding_box`、`sublevel bounding_box`

| 映射器   | 输出   | 描述                |
| -------- | ------ | ------------------- |
| `x`      | Double | 宽度                |
| `y`      | Double | 高度                |
| `z`      | Double | 深度                |
| `volume` | Double | 总体积（x × y × z） |

---

## Vec Dir

方向向量。获取自：`vec_pos direction_to`、`ship world_vel`、`ship local_vel`、`ship dir`、`sublevel world_vel`、`sublevel local_vel`、`sublevel dir`、`vec_dir normalize`、`vec_dir cross`

| 映射器         | 输出    | 描述                   |
| -------------- | ------- | ---------------------- |
| `x`            | Double  | X分量                  |
| `y`            | Double  | Y分量                  |
| `z`            | Double  | Z分量                  |
| `length`       | Double  | 向量的长度             |
| `normalize`    | Vec Dir | 指向相同方向的单位向量 |
| `cross <方向>` | Vec Dir | 与另一个方向的叉积     |
| `dot <方向>`   | Double  | 与另一个方向的点积     |

---

## Int

获取自：`pos x/y/z`、`redstone`、`page_number`、`double rounded_down/rounded_up`、`ship id`、`dimension index`、`string as_int`

| 映射器       | 输出    | 描述                                                              |
| ------------ | ------- | ----------------------------------------------------------------- |
| `== <int>`   | Boolean | 等于                                                              |
| `> <int>`    | Boolean | 大于                                                              |
| `< <int>`    | Boolean | 小于                                                              |
| `+ <int>`    | Int     | 加法                                                              |
| `- <int>`    | Int     | 减法                                                              |
| `% <int>`    | Int     | 取模                                                              |
| `& <int>`    | Int     | 按位与                                                            |
| `\| <int>`   | Int     | 按位或                                                            |
| `<< <int>`   | Int     | 左移                                                              |
| `>> <int>`   | Int     | 右移                                                              |
| `* <double>` | Double  | 乘法                                                              |
| `/ <double>` | Double  | 除法                                                              |
| `as_string`  | String  | 转换为字符串                                                      |
| `as_char`    | String  | 编号为该数的字符（`65 as_char`为`A`）；不对应字符的编号转换为空格 |

例如：

```
if redstone > 7 set_redstone 15
set_redstone value_of(page_number - 1)
set_redstone value_of(pos x & 15)
```

---

## Double

获取自：`pos x/y/z`（Vec Pos）, `vec_dir length/dot`、`vec_box volume`、`int * / `、`ship mass`

| 映射器         | 输出    | 描述         |
| -------------- | ------- | ------------ |
| `== <double>`  | Boolean | 等于         |
| `> <double>`   | Boolean | 大于         |
| `< <double>`   | Boolean | 小于         |
| `+ <double>`   | Double  | 加法         |
| `- <double>`   | Double  | 减法         |
| `* <double>`   | Double  | 乘法         |
| `/ <double>`   | Double  | 除法         |
| `rounded_down` | Int     | 向下取整     |
| `rounded_up`   | Int     | 向上取整     |
| `as_string`    | String  | 转换为字符串 |

---

## String

获取自：`page_contents`、`script_contents`、`pos as_string`、`dimension as_string`、`int as_string`、`int as_char`、`double as_string`、`boolean as_string`、`ship slug`、`sublevel name`、`sublevel id`

| 映射器              | 输出      | 描述                                         |
| ------------------- | --------- | -------------------------------------------- |
| `== <string>`       | Boolean   | 相等                                         |
| `+ <string>`        | String    | 拼接至结尾                                   |
| `<+ <string>`       | String    | 拼接至开头                                   |
| `lines`             | Int       | 按换行分割，返回行数                         |
| `get_line <int>`    | String    | 按换行分割，返回所给索引处的行，越界返回`""` |
| `remove_line <int>` | String    | 按换行分割，移除所给索引处的行，越界不修改   |
| `split <string>`    | String    | 将每一处所给分隔符替换为换行                 |
| `as_int`            | Int       | 解析为整数                                   |
| `as_double`         | Double    | 解析为双精度浮点数                           |
| `as_block_pos`      | BlockPos  | 按`"x y z"`格式解析                          |
| `as_boolean`        | Boolean   | 解析`"true"`/`"false"`（大小写不敏感）       |
| `as_dimension`      | Dimension | 视作维度键                                   |

在引号字符串中，换行写为`\n`，`"`写为`\"`，`\`写为`\\`。仅需转义脚本文：字符串的值中包含的是真正的换行，获取器、执行器、变量则会原样传递它们。

例如：

```
if page_contents == "打开" set_redstone 15
write_page value_of(pos as_string)
write_page value_of(pos as_string <+ "位置：")
set_redstone value_of(page_contents lines)
write_page value_of(page_contents remove_line 1)
write_page value_of(page_contents split ", ")
```

---

## Boolean

获取自：任意`==`、`>`、`<`比较，`string as_boolean`

| 映射器           | 输出    | 描述                |
| ---------------- | ------- | ------------------- |
| `&& <boolean>`   | Boolean | 逻辑与              |
| `\|\| <boolean>` | Boolean | 逻辑或              |
| `as_string`      | String  | `"true"`或`"false"` |

例如：

```
if pos x > 0 && value_of(pos z > 0) set_redstone 15
if page_contents == "打开" || value_of(redstone > 0) set_redstone 15
write_page value_of(redstone > 7 as_string)
if page_contents as_boolean set_redstone 15
```

---

## Dimension

获取自：`dimension`、`string as_dimension`

| 映射器           | 输出    | 描述                                         |
| ---------------- | ------- | -------------------------------------------- |
| `== <dimension>` | Boolean | 若与所给维度相等，则返回True                 |
| `index`          | Int     | 稳定的维度整数索引（各服务端会话中恒定不变） |
| `as_string`      | String  | 维度的资源位置（如`minecraft:overworld`）    |

例如：

```
if dimension == minecraft:the_nether set_redstone 15
set_redstone value_of(dimension index & 15)
```
