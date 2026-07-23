---
id: neepbus
lookup: neepmeat:data_cable, neepmeat:slider, neepmeat:slanted_slider, neepmeat:vertical_gauge, neepmeat:single_button, neepmeat:redstone_transducer
---
# NEEPBus

NEEPBus is a multi-controller serial bus. It consists of multiple participants connected via data cables.

Participants in a network can exchange integer data using alphanumeric addresses.

Strings and numbers can be sent in NEEPBus messages.

## Description

Data is exchanged between ports. Participants can have multiple ports.

- Each port has its own alphanumeric address.
- Output ports will send data to input ports with a matching address.
- Multiple input ports can share the same address, and will all receive the same data.

A participant can have input and output ports.

- Input ports are written to (receive data).
- Output ports can write (send data) to input ports. They can also be read from.

## Reads and Writes

Unlike redstone, a read or write operation is necessary for data to propagate.

For example, a slider will write its value to the target address when the value is changed by a player. It will not perform a write operation when a new port with a matching address is connected to the network.

# Examples

## Slider -> Redstone

\image[scale=0.5]{neepmeat:guide/images/neepbus_slider_redstone.png}

In this example, a slanted slider is sending values to a redstone interface. When the slider's value changes, it will send a message to the transducer. The transducer will then emit a redstone signal corresponding to the received number.

\columns{\item_render[height=30]{neepmeat:slanted_slider}}{\item_render[height=30]{neepmeat:redstone_transducer}}

The slider's maximum value has been set to 15 in its GUI. The 'Output' address of the slider is set to match the 'Redstone write' address in the Redstone Transducer.

\image[scale=0.9,width=253,height=58]{neepmeat:guide/images/neepbus_ex1_slider.png}

\image[scale=0.9,width=253,height=58]{neepmeat:guide/images/neepbus_ex1_redstone.png}

\centering{Above: Address configurations for the Slanted Slider and Redstone Transducer respectively. Both are set to the address 'redstone'.}
