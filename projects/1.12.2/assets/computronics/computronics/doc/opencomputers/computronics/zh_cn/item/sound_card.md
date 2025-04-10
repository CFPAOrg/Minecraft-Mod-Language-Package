# 声卡

![♩♫♩♫♩♫♫♫♩♫♩♫♩♫♫♩♩♪♩♩♪♩♪♩♩♪♩♪♩♩♪♩♪♩♩♪♩♫♩♫♩♫♫♫♩♫♩♫♩♫♫♫♩](item:computronics:oc_parts@9)

声卡是一个复杂的设备，可用于合成高解析度音频。与[噪音卡](noise_card.md)类似，它也能发出多种类型的声波。

声卡提供了八个通道，每个通道都可独立产生一个波形。但是，用户也可以指定任意通道去调节其他通道的频率和振幅。在此状态下，这一通道不会由自身产生音频，而是会改变所负载通道的波形。

声卡工作于一套基于指令的系统上。通过调用声卡提供的各种函数，用户可以向内部队列中添加指令。指令可以修改某通道波形的种类或频率，也可以指定一条通道调节另一条通道，还可以将[ADSR](https://en.wikipedia.org/wiki/Synthesizer#Attack_Decay_Sustain_Release_.28ADSR.29_envelope)应用于某条通道上，又或者改变通道的音量。

默认情况下所有通道均为关闭状态，用户需要使用响应指令将其开启。在关闭状态下，通道通常而言不会产生音频（除非应用了ADSR，这种情况下通道会启用释音阶段）。

为了能实际发出储蓄一段时长的音频，需使用delay（延时）指令，这条指令会让先前所有指令作出的更改生效。用户提供的时长数值应为毫秒，这是为了能够进行高解析度的合成。在所需的一切指令都加入队列后，可调用`process()`函数来处理所有指令，并生成音频。

样例：

`  local sound = require("component").sound`

`  sound.setWave(1, sound.modes.sine)`
`  sound.setFrequency(1, 440)`
`  sound.open(1)`
`  sound.delay(1000)`
`  sound.close(1)`
`  sound.process()`

此样例开启了第一通道，此时第一通道可在延时期间发声。样例中产生了440Hz的正弦波（相当于A4音符），持续到通道被关闭为止。

`  sound.setWave(2, sound.modes.noise)`
`  sound.setFrequency(2, 440)`
`  sound.setVolume(2, 0.6)`
`  sound.setADSR(2, 0, 250, 0, 0)`
`  sound.open(2)`
`  sound.delay(1500)`
`  sound.close(2)`
`  sound.process()`

此样例开启了第二通道，令其发出440Hz的白噪音。其音量被设定为不全满，且使用了ADSR，令其音量在250ms内从设定值衰减到0.
