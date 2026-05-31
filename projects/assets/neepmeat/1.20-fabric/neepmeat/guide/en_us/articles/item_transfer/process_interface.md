---
id: process_interface
lookup: neepmeat:process_interface, neepmeat:process_card
---

# Process Interface

The Process Interface allows integrating any machine into a recursive crafting system.

It has slots for multiple Process Cards, each which records the ingredients and result of a specific recipe.

For example, a Process Interface can be connected to a furnace. The interface can contain cards for many different smelting recipes, which will be made available in the item network.

## Usage

To use a Process Interface to integrate a machine, place it facing the machine's input storage. It is recommended to use a hopper or some other intermediate storage that can hold multiple stacks if the interface is likely to process multiple items at once.

The rear side of the Process Interface is where ingredients will be requested to, so it must be connected to the pipe network. It is also where the outputs will be ejected from.

When a requested ingredient enters the rear face, it will be ejected into the storage on the front face.

Inserting an item into any other side of the Process Interface will put it into result storage. When a request is active, the return storage will be periodically checked for the request's result.

How a Process Interface spends its time:

1. Wait for a craft request.
2. Wait for the ingredients to arrive via the rear face.
3. When all ingredients have arrived, emit a PLC interrupt.
4. Wait for the result to arrive via a side face.
5. Eject the result via the rear face.

## PLC Interaction

The Process Interface can emit interrupt requests that can be listened for by a PLC.

For a recipe, an interrupt will be emitted after *all the ingredients for a recipe have arrived*.

The following program registers an interrupt for the Process Interface at (1, 2, 3) and waits for an interrupt to be emitted. As no label is provided to `IHANDLER` (note the _), the PLC will not branch to another position when an interrupt is received.

```
ihandler @(1 2 3 U) _
iwait

# Fetch the data ( -- batches id)
extfetch @(1 2 3 U)
# your code here

restart
```

### Memory

When PLC interrupts and the request queue are enabled, a Process Interface records and queues the batch size and requested item ID. These can be accessed with the `EXTFETCH` instruction.

Make sure to use `EXTFETCH` each time an interrupt is emitted, otherwise the queue will fill up.

## Example