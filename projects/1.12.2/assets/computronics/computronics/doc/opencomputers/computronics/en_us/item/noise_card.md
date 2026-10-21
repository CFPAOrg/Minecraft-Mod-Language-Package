# Noise Card

![Boop. Beep. Bzzt.](item:computronics:oc_parts@8)

The noise card, akin to the [beep card](beep_card.md), provides the `play()` function. In addition, it also allows setting each of the eight separate channels' sound modes to make the card play square, sine, triangle or sawtooth waves.

Furthermore, the card also provides a small internal buffer, allowing up to eight entries of frequency-duration pairs with an optional initial delay to be specified per channel. Calling `process()` will then process the entire buffer at once.

Example code:
`  local card = require("component").noise`
`  card.setMode(1, card.modes.sawtooth)`
`  card.play({{440, 4}, {880, 2}})`
This plays 440 Hz for 4 seconds with a sawtooth wave form and 880 Hz for 2 seconds with a square wave form.

Example code using the buffer:
`  local card = component.noise`
`  card.setMode(1, card.modes.sawtooth)`
`  card.add(1, 440, 4)`
`  card.add(2, 880, 1, 2)`
`  card.add(2, 220, 1)`
`  card.process()`
