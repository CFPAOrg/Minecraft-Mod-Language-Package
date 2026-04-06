---
id: automatic_mouth
lookup: neepmeat:mouth
---

# Automatic Mouth

The Automatic Mouth speaks aloud any message. It can be triggered by redstone or via NEEPBus. 

## Interface

Other configuration options are available:

- Auto say: Changing the message via NEEPBus will trigger speech.
- Phonetic mode: The message text will be parsed using SAM's phonetic alphabet if true.
- Sound radius: The maximum distance for players to hear speech.

## NEEPBus Inputs

- Say: Triggers speech when the received value != 0
- Set phonetic: Changes whether the message will be parsed phonetically or as english.
- Set message: Sets the message text.

## SAM Phonetic Alphabet

Due to the vast phonetic inconsistency of the English language, many words will not be perfectly phonemised due to the Mouth's limited set of rules.

Instead, messages can be written phonetically using an easy to write phonetic transcription scheme, based on the one used by the Software Automatic Mouth program.

hello there -> HEHLOW DHEHR

```
Vowels              Diphthongs

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

Voiced Consonants   Unvoiced Consonants

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