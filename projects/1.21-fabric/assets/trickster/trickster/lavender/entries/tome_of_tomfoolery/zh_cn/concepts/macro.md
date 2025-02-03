```json
{
  "title": "宏",
  "icon": "trickster:macro_ring",
  "category": "trickster:concepts"
}
```

宏可用来新造修订术，以协助法术抄绘。


宏是图案到法术的[映射](^trickster:distortions/map)。将此类映射抄入任意戒指并佩戴；后续在编写法术时，就会检索其中有无键与绘制的图案一致。

;;;;;

如果没有其他戒指，有简易的[宏戒指](^trickster:items/ring)可供使用。


如果找到了对应的宏键，即会执行对应的法术，并传入绘制处圆的副本作为唯一参数。该法术应当返回一个新法术片段，用以替代传入的片段。


每一位戏法师都能借此制造他们自己的修订术。

;;;;;

注意：宏法术无法[长时施法](^trickster:concepts/multi_tick)。也即，它们不会占用法术槽，因此无法包含超过64个圆。
