---
lookup: neepmeat:storage_bus, neepmeat:pipe_driver, neepmeat:item_requester
id: item_pipe_routing
---

# Advanced Routing

\columns[fit=second]{Advanced routing capabilities in a pipe network are provided by a Pipe Driver. This machine handles route finding between pipes, and manages deferred item requests.

Only one Pipe Driver can be present within a network.
}{\item_render{neepmeat:pipe_driver}}

Advanced routing is typically done with *requests*. A request contains three pieces of information:

- The type of item to be requested.
- The number of items to be requested.
- The destination pipe of the request.

Some blocks that can send requests include the Requester and the PLC (via various instructions);.

\columns{\item_render[height=30]{neepmeat:requester}}{\item_render[height=30]{neepmeat:plc}}

## Storage Driver

\columns[fit=first]{\item_render[height=50]{neepmeat:storage_bus}}{Storage Drivers make the items in adjacent inventories visible to a Pipe Driver, allowing them to be extracted remotely via requests.}

If an inventory is to be accessible to requests, it must be connected via a Storage Driver.

## Manual Requester

A Manual Requester displays all available items within a network in its GUI, and allows them to be requested to its own position. Clicking on an item requests a stack of items an shift-clicking requests a single item.

The Manual Requester also has a return slot, which asks the Pipe Driver to store the given item in an empty space in a connected inventory.

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/pipe_routing_network.png}
Above is a simple routing network that allows items to be requested and returned to two inventories. On the left is a Metal Barrel and on the right is a Flex Silo. Both are connected to the network with Storage Drivers, which allows their inventories to be accessed by the Pipe Driver on the bottom left.

The Manual Requester (on the bottom right) has access to the inventories of the barrel and the flex silo. After receiving a request, the Pipe Driver determines a route from the storage to the Manual Requester and the item is dispatched.
