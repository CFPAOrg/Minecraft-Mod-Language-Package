---
id: automatic_mouth
lookup: neepmeat:mouth
---
# 自动口舌

自动口舌会念出给定的消息，可由红石或NEEP总线触发。

## 界面

界面中还有其他若干配置项：

- 自动念出：经由NEEP总线修改消息会自动触发念出。
- 音标模式：启用时，使用SAM音标解析消息文本。
- 发声半径：玩家能听见消息的最远距离。

## NEEP总线输入

- 念出（Say）：接收的值不为0时触发。
- 设置音标模式（Set phonetic）：应将消息视作音标，还是视作英文。
- 设置消息（Set message）：设置消息文本。

## SAM音标

由于英语在拼写与语音间的对应关系上有许多不统一之处，同时因为自动口舌的发音规则集相对较小，大量单词无法完美转换为音频。

为此，可选择按照语音转写系统根据发音写出消息。此转写系统以Software Automatic Mouth计划所用体系为基础。

hello there -> HEHLOW DHEHR

```
Vowels              Diphthongs [1]

IY  feet            EY made
IH  pin             AY high
EH  beg             OY boy
AE  Sam             AW how
AA  pot             OW slow
AH  budget          UW crew
AO  talk
OH  cone
UH  book
UX  loot
ER  bird
AX  gallon
IX  digit

Voiced Consonants   Unvoiced Consonants [2]

R   red             S sam
L   allow           SH fish
W   away            TH thin
WH  whale           P poke
Y   you             T talk
M   Sam             K cake
N   man             CH speech
NX  song            H ahead
B   bad
D   dog
G   again
J   judge
Z   zoo
ZH  pleasure
V   seven
DH  then
```
 [1] 元音、双元音
 [2] 浊辅音、清辅音