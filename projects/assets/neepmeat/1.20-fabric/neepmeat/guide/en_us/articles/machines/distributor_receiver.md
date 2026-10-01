---
id: distributor_receiver
lookup: neepmeat:distributor_point
---

# Distributor Receiver

\columns[fit=second]{The Distributor Receiver summons Distributor Organisms to transport items and fluids to other receivers on the same channel. As long as the sender is loaded, transfer can occur to unloaded chunks and across dimensions.A

It is part of the living machine system.
}{\item_render{neepmeat:distributor_point}}


## Usage

Only one Distributor Receiver can be part of a machine. The receiver can be configured to send resources, receive them, or both. Send mode requires an item or fluid input port to be part of the machine, and receive mode requires an output port.

Right-clicking on the receiver opens a GUI with configuration options:

- Channel: Receivers with the same channel will be able to send and receive from each other.
- Mode: Whether to send, receive, or both.
- Cooldown: How long to wait between sends.
- Auto send: Whether to automatically send resources when they are available, or wait for a NEEPBus signal.

For transport to occur, sender chunks need to be loaded. 

Senders will check whether the receiver has space for the resources.

## Required Components

\columns[fit=first]{\item_render[height=18]{neepmeat:distributor_point}}{Distributor Receiver}
\columns[fit=first]{\item_render[height=18]{neepmeat:fluid_input_port}}{Fluid Input Port (Optional)}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_input_port}}{Item Input Port (Optional)}
\columns[fit=first]{\item_render[height=18]{neepmeat:fluid_output_port}}{Fluid Output Port (Optional)}
\columns[fit=first]{\item_render[height=18]{neepmeat:item_output_port}}{Item Output Port (Optional)}

# NEEPBus Support

NEEPBus can be used to set a receiver's channel or trigger it to send.