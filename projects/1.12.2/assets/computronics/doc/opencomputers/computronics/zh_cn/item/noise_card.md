# 噪音卡

![哔...滴...滋...](item:computronics:oc_parts@8)

噪音卡类似于[蜂鸣卡](beep_card.md)也提供了`play()`函数。此外，它还可以分别设定其八个通道的发声模式，以发出方波、正弦波、三角波或锯齿波音频。

另外，此扩展卡还带有一个小型的内部缓存，可为每个通道分别存储至多八个频率-时长组合，以及一个可选的初始延时。调用`process()`函数后会一次性处理播放缓存内的全部内容。

示例代码：
`  local card = require("component").noise`
`  card.setMode(1, card.modes.sawtooth)`
`  card.play({{440, 4}, {880, 2}})`
这段代码会播放4秒的440Hz锯齿波，同时播放2秒的880Hz方波。

使用了缓存的示例代码：
`  local card = component.noise`
`  card.setMode(1, card.modes.sawtooth)`
`  card.add(1, 440, 4)`
`  card.add(2, 880, 1, 2)`
`  card.add(2, 220, 1)`
`  card.process()`
