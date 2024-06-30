# Beep Card

![Beep. Beep. Beep.](item:computronics:oc_parts@5)

This card provides the `beep()` function, which takes a table of frequency-duration pairs as an input, up to eight entries at once. The card plays each frequency of beeps for the specified duration. Once one frequency has finished playing, it is possible to give a new frequency-duration pair to the card. You can never play more than eight frequencies simultaneously.

Example code:
`  local card = component.beep`
`  card.beep({[440]=4, [880]=2})`
