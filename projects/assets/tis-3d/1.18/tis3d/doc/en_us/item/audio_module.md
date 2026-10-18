# Audio Module
![Beep boop](item:tis3d:audio_module)

The audio module synthesizes sounds based on numeric triggers. The emitted sound is defined by the value transmitted to the audio module as defined below. If a volume of zero is specified the signal will be discarded.

The audio module continuously reads values from all four of its ports and emits a sound based on the read value. The read value is a packed value consisting of the properties of the sound to generate. This compact representation allows triggering sounds in a very responsive fashion.

## Signal Specification
Each value received by the audio module is interpreted as a packed value with the components: instrument, volume and pitch. The corresponding masks are as follows:
- `0xFF00` contains the pitch.
- `0x00F0` contains the volume, clamped to [0, 5].
- `0x000F` contains the instrument, one of {0, 1, 2, 3, 4}.

When generating sounds the bitwise operations of the [execution module](execution_module.md) will prove useful in combining the individual values into one.
