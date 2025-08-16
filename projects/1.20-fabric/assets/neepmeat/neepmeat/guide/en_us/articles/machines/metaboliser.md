---
id: metaboliser
lookup: neepmeat:metaboliser_segment, 
---

# Metaboliser

The Metaboliser consumes liquid foods to provide a power source.

It consists of a Stomach and multiple Metaboliser Segments. Each extra segment increases the rate at which food is consumed and energy is released. Power is injected directly into a vascular network via the segments.

Each segment consumes 4 droplets of fluid per tick and must be individually connected to the vascular network.

Output power depends on the number of segments and the energy density of the input food.

## Energy Densities

- Meat: 40eJ / d
- Animal Feed: 60eJ / d
- Food: (1 + 9 * hunger) / d

## Example

\image[width=332,height=321,scale=0.5]{neepmeat:guide/images/metaboliser.png}