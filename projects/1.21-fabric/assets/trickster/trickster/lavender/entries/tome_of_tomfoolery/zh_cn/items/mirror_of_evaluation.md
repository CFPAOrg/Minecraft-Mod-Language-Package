```json
{
  "title": "执行手镜",
  "icon": "trickster:mirror_of_evaluation",
  "category": "trickster:items",
  "ordinal": 35
}
```

执行手镜和实用的[卷轴与笔](^trickster:items/scroll_and_quill)极为相似。两者的主要区别在于：在使用手镜的过程中，它会贪婪地执行法术中的任意部件，只要可以执行就执行。


比如说，你编写了一个子圆，又为其加上了两个子圆，再在这两个子圆里都画上[基础之错觉](^trickster:constants#1)。

;;;;;

绘制时，这两个子圆的符记就会变成数“2”字面量。


然后又比如说，在这两个子圆的父圆里画上[吞并之谋略](^trickster:distortions/arithmetic#2)。如此操作会立刻删去两个子圆，父圆的符记也会变为数“4”字面量。

;;;;;

理解这些机制的最好方式，莫过于亲手实践：

<recipe;trickster:mirror_of_evaluation>

有一点需要注意。手镜虽然会尽其所能执行，但存储在其中的法术依然被视为“抄入”的法术。

;;;;;

也即，手镜可通过所有常规的法术读写方法交互。
