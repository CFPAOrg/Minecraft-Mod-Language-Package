---
id: fluid_pipe
---

# Fluid Pipes

Fluid pipes are a simple way of transferring fluids from one block to another.

## Usage

Pipes connect to any block that can accept fluids, although some blocks only allow connections in certain directions.

For fluids to move through pipes, there must be a height difference or an active pump. Fluids obey gravity, so they will naturally flow from containers at higher elevations to lower ones. Flow can also be induced by placing Redstone Pumps along the desired path of flow.

Pipes on the underside of containers will passively extract fluid. Pumps are required to extract fluid from the container's other sides.

Pumps are enabled with redstone by default, but this behaviour can be inverted by sneak-clicking with an empty hand.

# Placement

To prevent unwanted connections, fluid pipes follow certain rules when they are placed,

- 
- If placed beween two pipes of matching colour, the pipe will connect to both of them.

## Behaviour

Pipes have a maximum flow rate of 10125d (1/8 buckets) per tick. When no pumps are present, fluids can move downwards and horizontally. Pipes will only fill up when all paths are blocked.
