```json
{
  "title": "世界储元",
  "icon": "minecraft:shulker_box",
  "category": "trickster:tricks"
}
```

每个世界内部都有一片所有人共享的存储空间，其中可以永久缓存法术片段。每个储元只可写入一次，但只要有对应的引用，便可由任何人无限次读取。

;;;;;

<|glyph@trickster:templates|trick-id=ram:acquire_cell,title=古玩家之技巧|>

-> cell

---

自世界中获取一个空储元。

;;;;;

<|glyph@trickster:templates|trick-id=ram:read_cell,title=档案员之辑流|>

cell -> any

---

返回储元中的值。

;;;;;

<|glyph@trickster:templates|trick-id=ram:write_cell,title=档案员之技巧|>

cell, any -> cell

---

将所给值写入储元。此后该储元*不可*再写入。