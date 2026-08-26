---
id: power_flower
lookup: neepmeat:power_flower_seeds, neepmeat:power_flower_growth, neepmeat:power_flower_controller, neepmeat:power_flower_fluid_port
---

# Power Flower

\columns[fit=second]{The Power Flower is an organism that can synthesise Transient Ichor from sunlight and by reconstituted food.
}{\item_render[height=50]{neepmeat:power_flower_controller}}

## Usage

Power Flower Seeds can be placed on any dirt-like block and will eventually mature into a larger growth with one controller block somewhere inside it.

When a growth block has air above it and one or more growth blocks below it, it will specialise into a photosynthetic organ and produce 10eJ/t constantly. Otherwise, it will increase the rate at which foods are digested and metabolised.

Water inserted through a Power Flower Fluid Port is necessary for photosynthesis.

\columns{\item_render[height=30]{neepmeat:power_flower_seeds}}{\item_render[height=30]{neepmeat:power_flower_fluid_port}}

## Foods

Each non-photosynthetic organ (full block) will consume 1d of food per tick. Consumption and generation rate therefore depend on the number of full blocks.

- Meat: 3eJ/t per droplet consumed
- Animal Feed: 4eJ/t per droplet consumed
- Food: (1 + ceil(hunger)) eJ/t per droplet consumed
