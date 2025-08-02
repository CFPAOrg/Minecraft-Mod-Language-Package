```json
{
  "title": "法术",
  "icon": "minecraft:oak_sapling",
  "category": "trickster:distortions",
  "additional_search_terms": [
    "供给之曲变",
    "闭包之谋略",
    "定址之曲变",
    "发现之曲变",
    "检索之曲变",
    "替换之曲变",
    "扎束之曲变",
    "伐树之曲变",
    "嫁接之曲变",
    "分枝之曲变",
    "剪枝之曲变"
  ]
}
```

[抄绘图案](^trickster:editing)能在法术施放前更改法术，而本节中的图案能在法术施放*中*修改。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:supplier,title=供给之曲变|>

any -> spell

---

创建一个新法术片段，其执行结果即是所给参数。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:closure,title=闭包之谋略|>

spell, {any: any} -> spell

---

将所给法术中与所给映射键对应的符记换成其映射的值。

;;;;;

<|page-title@lavender:book_components|title=笔记：地址|>正如列表中的元素可通过索引访问，法术的部件也可由其地址访问。地址是一个整数列表，用以表示法术中前往该圆的路径。

;;;;;

得出圆地址的步骤如下：在根节点处开始；找到前往该圆所需经过的子圆；找出该子圆的索引，即顺时针方向上在该子圆前面的子圆的数目；重复前三步，直至抵达目的圆。所得的列表即是目的圆的地址。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:locate_glyph,title=定址之曲变|>

spell, any -> number[] | void

---

返回所给法术中、符记为所给参数的第一个圆的地址。搜索时使用[广度优先搜索（BFS）](https://en.wikipedia.org/wiki/Breadth-first_search)。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:locate_glyphs,title=发现之曲变|>

spell, any -> number[][]

---

返回所给法术中、符记为所给参数的所有圆的地址组成的列表。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:retrieve_glyph,title=检索之曲变|>

spell, number[] -> any

---

返回所给法术中给定地址处的圆的符记。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_glyph,title=替换之曲变|>

spell, number[], any -> spell

---

将所给法术中给定地址处的圆的符记替换为所给片段。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:get_subparts,title=扎束之曲变|>

spell -> spell[]

---

将法术的各支返回为列表。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:retrieve_subtree,title=伐树之曲变|>

spell, number[] -> spell | void

---

返回给定地址处的圆及其各支。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:set_subtree,title=嫁接之曲变|>

spell, number[], spell -> spell

---

将后一法术嫁接到前一法术中给定地址处，替代该处的圆。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:add_subtree,title=分枝之曲变|>

spell, number[], spell -> spell

---

将后一法术接到前一法术中给定地址处，作为该处圆的子支。

;;;;;

<|glyph@trickster:templates|trick-id=trickster:remove_subtree,title=剪枝之曲变|>

spell, number[] -> spell | void

---

移除给定地址处的圆。若移除的是根节点，返回void。
