```json
{
  "title": "栈追踪",
  "icon": "minecraft:tripwire_hook",
  "category": "trickster:concepts"
}
```

法术中产生的故障称作“失策”。失策的法术会打印栈追踪，以标明故障出现的*位置*。栈追踪是由冒号分隔的字符列表，各段可分为三类：

- #（井号）
- \>（角括号、尖括号）
- 任意数

;;;;;

其中，数是输入的索引，尖括号和井号则表示上下文切换到了另一个法术片段中去。尖括号指新片段由当前法术提供，井号指片段来自其他地方。

;;;;;

<|page-title@lavender:book_components|title=笔记：索引|>法术中的所有圆都有其对应的数，即*索引*。此数用于说明圆相对其父圆的位置。父圆上的紫色销永远位于第一子圆的逆时针方向，第一子圆的索引为0。后续所有子圆的索引都比前一子圆多1。