---
id: living_machines
---

# Living Machines

## Usage

A living machine consists of a controller and set of functional components that are connected together with machine blocks. The process that a machine performs is determined by its functional components. For example, a crusher needs an item input, an item output, one or more crusher segments and a motor port. Some processes can use extra components to achieve different effects.

The operating parameters of a machine are determined by the machine blocks it is composed of.

## Ageing

Machines have a maximum rated power and operating a machine above 75% of this value will cause gradual degradation over time, which will eventually result in **CRITICAL FAILURE**.

To mitigate the effects of ageing, machine blocks with self-repair capabilities can be used.

A machine must have one or more machine blocks. A machine without any will have zero rated power, which will cause it to die instantly when powered.
