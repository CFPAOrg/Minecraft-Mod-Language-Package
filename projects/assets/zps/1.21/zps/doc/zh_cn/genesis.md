# Genesis兼容

安装有[Genesis](https://modrinth.com/mod/genesis)时，可以使用请求天体的命令。

---

## 获取器

| 获取器      | 输出       | 描述                          |
| ----------- | ---------- | ----------------------------- |
| `celestial` | Celestials | 所有Genesis天体请求的起手式。 |

---

## Celestials映射器

获取自：`celestial`

| 映射器        | 输出      | 描述                                                                      |
| ------------- | --------- | ------------------------------------------------------------------------- |
| `current`     | Celestial | 返回与当前维度相关的天体，若当前维度不是天体表面则返回null。              |
| `nearest`     | Celestial | 返回距目标方块位置最近的天体。在太空维度（`current`会返回null）中很有用。 |
| `of <天体ID>` | Celestial | 根据资源位置返回天体。                                                    |

例如：

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

## Celestial映射器

获取自：`celestial current`、`celestial nearest`、`celestial of <天体ID>`

| 映射器         | 输出    | 描述                                              |
| -------------- | ------- | ------------------------------------------------- |
| `gravity`      | Double  | 天体的表面重力，形式为原版重力的乘数（主世界为1） |
| `size`         | Double  | 天体的直径，以格计                                |
| `is_visitable` | Boolean | 若天体有可造访的维度，返回true                    |
| `pos`          | Vec Pos | 太空维度中天体当前的位置                          |
| `as_string`    | String  | 天体的资源位置                                    |
| `== <天体ID>`  | Boolean | 若与所给天体相等，返回true                        |

例如：

```
if celestial current gravity < 0.5 set_redstone 15
if celestial current is_visitable set_redstone 15
```

---

## 空值安全

若`current`或`nearest`返回了null（比如没有天体与当前维度相关），后续的所有Celestial映射器都会返回安全的默认值：
- 返回数的映射器会返回`0`或`0.0`
- 返回布尔值的映射器会返回`false`
- 返回字符串的映射器会返回空字符串
- `pos`会返回`Vec3.ZERO`
