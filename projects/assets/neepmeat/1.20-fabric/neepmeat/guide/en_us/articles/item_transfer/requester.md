---
id: requester
lookup: neepmeat:requester
---

# Requester

\columns[fit=second]{The Requester uses a configurable item filter to request a number of matching items from a pipe network. These items are routed to the Requester and ejected from the front face.
}{\item_render{neepmeat:requester}}

## Usage

Right-clicking a Requester opens its GUI. There, an item filter can be configured based on a tag or item types. The number of items to be requested can be set on the right.

To operate, the rear face needs to connect to a pipe network that contains a Pipe Driver. When a request is triggered, the Pipe Driver will search through all routable pipes (such as Storage Drivers) and will attempt to fulfil the request. Resulting items will be ejected from the front of the Requester.

\columns{\item_render[height=30]{neepmeat:pipe_driver}}{\item_render[height=30]{neepmeat:storage_bus}}

## Control

Requests can be triggered either with a redstone signal, or by sending any message to the Input port.

NEEPBus inputs can be configured by clicking the 'configure NEEPBus' button in the GUI.