---
id: vascular_condenser
lookup: neepmeat:vascular_condenser
---

# Vascular Condenser

\columns[fit=second]{A Vascular Condenser works to maintain a constant power capacity in a vascular network by automatically absorbing or injecting power. It can store energy and release it later.
}{\item_render{neepmeat:vascular_condenser}}

## Usage

A Vascular Condenser uses a setpoint (configured inside the GUI) as the desired network capacity. When the network's capacity exceeds the setpoint, a Vascular Condenser will absorb and store power from the network. When capacity falls below the setpoint, the condenser will try to make up for the missing power by injecting stored power back into the network.

Like a flex tank or a flex silo, energy capacity can be extended by adding more blocks.

More dynamic behaviour can be achieved by varying the setpoint using NEEPBus.

## Example

Consider a Vascular Condenser with its target power set to 200eJ/t. An unreliable generator is injecting 300eJ/t into the network. 

In this case, the condenser will absorb 100eJ/t from the network so that the available power becomes 200eJ/t. It will store the energy inside itself.

If the generator stops producing energy, the condenser will take over and will start injecting 200eJ/t into the network. It will do this until it runs out of stored energy or the generator starts again.

## NEEPBus

A Vascular Condenser can be controlled with NEEPBus. There are three ports:

- TARGET (input): Sets the setpoint for the network
- ACTIVE (input): Sets whether the condenser is active.
- STORED (output): Gives the amount of energy currently store in eJ.
