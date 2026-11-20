---
id: item_pipe
lookup: neepmeat:storage_driver, neepmeat:merge_item_pipe, neepmeat:item_pipe, neepmeat:speed_item_pipe
---

# Item Pipes

Item pipes swiftly transport stacks of items between inventories.

## Usage

These pipes cannot be inserted into through regular means. Instead, Items must be injected using an Item Pump or an Ejector. 

Some other blocks, such as the Jaw Crusher and the Item Output Port, can eject items directly into pipes. Pipes can insert items into any valid inventory and can drop items into the world if an end is left open.

Right-clicking a pipe's connection with an empty hand will toggle that connection.

# Simple Routing 

Items ejected through normal means will choose random directions at junctions, travelling until they reach a valid inventory or an open pipe. If an item reaches a dead end it will bounce back into the network.

Most ejecting blocks will check ahead for a valid destination before ejecting items into pipes. However, items ejected in this way will still choose random directions at junctions.

An exception to the random junction behaviour occurs if a junction connects directly to an inventory (or a filter pipe). In this case, items will prioritise that inventory before moving on to other connected pipes.

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_junction_priority.png}
\centering{Above: A pipe network with two junctions, one with a filter pipe and another with a barrel. Items leaving the ejector will try to enter the filter pipe before moving on. When they reach the second junction, items will attempt to enter the barrel before moving on.}

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_storage_line.png}
\centering{Above: Due to junction priority, this line of barrels will fill up gradually from left to right as items are sent.}
