```json
{
  "title": "随机存取意识",
  "icon": "minecraft:goat_horn",
  "category": "trickster:tricks"
}
```

随机存取意识（Random Access Mind），简称“RAM”，是一种通过分配系统，以任意的布局半持久性地存储任意数据的方式。

;;;;;

<|glyph@trickster:templates|trick-id=ram:alloc,title=分配器之技巧|>

-> number

---

尝试分配一个RAM槽，若无空槽则导致失策，成功则返回分配的槽地址。

;;;;;

<|glyph@trickster:templates|trick-id=ram:free,title=看守者之技巧|>

number ->

---

释放所给地址处的RAM槽，以供后续再分配。

;;;;;

<|glyph@trickster:templates|trick-id=ram:read,title=取存之辑流|>

number -> any

---

返回给定地址的RAM槽中存储的法术片段。

;;;;;

<|glyph@trickster:templates|trick-id=ram:write,title=缓存之技巧|>

number, any -> any

---

将所给法术片段存入给定地址的RAM槽。会覆盖其中原有的值。
