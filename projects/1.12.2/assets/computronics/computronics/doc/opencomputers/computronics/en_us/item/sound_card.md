# Sound Card

![♩♫♩♫♩♫♫♫♩♫♩♫♩♫♫♩♩♪♩♩♪♩♪♩♩♪♩♪♩♩♪♩♪♩♩♪♩♫♩♫♩♫♫♫♩♫♩♫♩♫♫♫♩](item:computronics:oc_parts@9)

The sound card is a complex device allowing for high-resolution sound synthesis. Similarly to the [noise card](noise_card.md), it allows generating sound waves of various forms.

The sound card provides eight channels, each of which may generate a wave on its own. However, one can assign any channel to modulate frequency and amplitude of another. In this case, the channel will not generate sound itself but instead change the wave of the carrier channel.

The sound card works on an instruction-based system. Using the various functions provided by the card, one is able to add instructions to the internal queue. An instruction may change the wave form and the frequency of a channel's wave, it may assign one channel to modulate another, it may assign [ADSR](https://en.wikipedia.org/wiki/Synthesizer#Attack_Decay_Sustain_Release_.28ADSR.29_envelope) to a specific channel or it may simply change that channel's volume.
All channels are closed by default, and one needs to open them with the corresponding instructions. When closed, they will generally not generate sound (unless ADSR is assigned, in that case it will initiate the release phase).

To actually generate sound for a certain amount of time, a Delay instruction may be used, allowing all the settings changed through previous instructions to apply. All durations are given in milliseconds, allowing for high resolution synthesis. Once all the needed instructions are added to the queue, `process()` may be called to process all the instructions and generate sound.

Example:

`  local sound = require("component").sound`

`  sound.setWave(1, sound.modes.sine)`
`  sound.setFrequency(1, 440)`
`  sound.open(1)`
`  sound.delay(1000)`
`  sound.close(1)`
`  sound.process()`

This opens the first channel so it can generate sound during delays and makes it generate a sine wave at 440Hz (equating the note A4) before closing it again. 

`  sound.setWave(2, sound.modes.noise)`
`  sound.setFrequency(2, 440)`
`  sound.setVolume(2, 0.6)`
`  sound.setADSR(2, 0, 250, 0, 0)`
`  sound.open(2)`
`  sound.delay(1500)`
`  sound.close(2)`
`  sound.process()`

This opens the second channel and makes it produce white noise at 440Hz, with reduced volume and ADSR making the volume drop from the set volume to 0 within 250ms.  
