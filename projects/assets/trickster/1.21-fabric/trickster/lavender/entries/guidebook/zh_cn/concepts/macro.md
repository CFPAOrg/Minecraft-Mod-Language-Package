```json
{
  "title": "宏",
  "icon": "trickster:macro_ring",
  "category": "trickster:concepts"
}
```

宏可用来新造修订术，以协助法术抄绘。


宏是图案到法术的[映射](^trickster:distortions/map)。将此类映射抄入任意戒指并佩戴；后续在编写法术时，就会检索其中有没有和所绘制图案一致的键。

;;;;;

如果没有其他戒指，有简易的[宏戒指](^trickster:items/writing_casting/ring)可供使用。


所绘制图案若与某个宏键对应，绘制后即会执行对应的法术，并传入绘制处圆的副本作为唯一[参数](^trickster:delusions_ingresses/arguments)。该法术应当返回一个新法术片段，用以替代传入的片段。


创建映射时，可使用[图案字面量](^trickster:editing#25)指定图案。
