---
navigation:
  parent: aae_intro/aae_intro-index.md
  title: Reaction Chamber
  icon: advanced_ae:reaction_chamber
categories:
  - advanced devices
item_ids:
  - advanced_ae:reaction_chamber
---

# Reaction Chamber

<BlockImage id="advanced_ae:reaction_chamber" scale="4"></BlockImage>

The reaction chamber is capable of accelerating chemical reactions by using a catalyst fluid and a great amount of
power. In doing so, reactions that naturally occur can be forced to happen inside the chamber, most of the time with
more efficient results, due to the controlled environment.

## Powering the Chamber

The reaction chamber can be quite power hungry when sped up. Using Acceleration Cards increases the rate at which the
total power cost is consumed, increasing the required power per tick. When using power straight through the ME system,
the chamber will try to draw the amount required for a tick of processing and if this fails you might experience
flickering, when the power of the system toggles on and off. To remedy this effect, the AE system needs to be equipped
with energy buffers in the form of <ItemLink id="ae2:dense_energy_cell" />s. The Chamber is also capable of pulling
energy directly from energy cells (from Applied Flux) if they are available in the drives, to recharge itself and craft
without consuming from ME power buffers. Reducing the amount of accelerations cards is also an option if there is no
more power generation available at the moment. To be able to power it properly, there are a few options.
* Note: Pattern Providers or Interfaces in part form (attached to a cable) do not provide a grid connection. To be able
to power the chamber with those you will also need to connect a fluix cable directly to it.

### Full Block Pattern Provider

A full block pattern provider is capable of connecting the Reaction Chamber directly to the AE2 grid, allowing power to
be extracted when needed and removed the needed for the chamber's internal buffer. If the total power stored in the grid
is lower than the required power per tick, progress will be slowed down and a warning will be displayed on the screen.
For this method it is recommended that the grid is connected to a few <ItemLink id="ae2:dense_energy_cell" />s.

### External Power

An alternative way of powering the Reaction Chamber is through the use of external power. Any source that can push
energy should be enough to fill its buffers and start processing. If the provided power is being received at an
insufficient rate, a warning will be displayed in the chamber's screen.

### Induction Cards (Extra Mod Required: Applied Flux)

Induction Cards can be inserted in cable part Pattern Providers or directional Pattern Providers, allowing them to
export power stored in Energy Cells. As long as it is set up properly, it should fill the energy storage of the Reaction
Chamber, allowing it to work. Do note, however, that Induction Cards, as well as some other AE2 components, have a
ramp-up timer, starting slow and increasing speed with time. This means that the crafting speed won't be maxed at first
due to lack of stored power, but as the crafting continues, the Induction Card should be able to provide enough power.