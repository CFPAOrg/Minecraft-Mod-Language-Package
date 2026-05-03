---
navigation:
  parent: crazyae2addons_index.md
  title: Display
  icon: crazyae2addons:display
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:display
---

# Display

The **Display** is a cable part that shows text, images, item/fluid icons, and
live ME network data directly on a cable bus.

It can be used for labels, storage counters, machine status panels, production
monitors, or large wall-mounted dashboards. Adjacent Displays can merge into one
larger screen.

---

## Placement

Place the Display on any face of an AE2 cable bus.

The Display needs a working ME network channel to show live network data.
Without a channel, text and images still render, but stock and delta values show
0.

On floors and ceilings, the Display rotation follows the player's facing
direction when placed.

---

## Interaction

Right-click opens the Display GUI.

If Merge Mode is enabled, right-click edits the whole merged screen.

Shift + right-click opens the GUI for only the selected Display part.

---

## Text

The Display supports multiline text with basic formatting.

Examples:

# Heading

**Bold text**

*Italic text*

__Underlined text__

~~Strikethrough text~~

Monospace text can be created with the monospace formatting button in the GUI.

Text can also be colored with hex colors:

&cFF0000Red text

Normal &c00FF00(green word) normal

---

## Live ME data

Displays can show live ME network values using tokens.

You usually do not need to type tokens manually. Use the token builder in the
Display GUI to insert them.

The token builder can insert:

- stock counters
- production and consumption rate counters
- item and fluid icons

Examples:

&i^item:minecraft:diamond Diamonds: &s^minecraft:diamond

Iron/min: &d^minecraft:iron_ingot%1m@5m

Stock tokens start with &s^.

Delta/rate tokens start with &d^.

Icon tokens start with &i^.

---

## Images

Use the Images button in the Display GUI to open the image screen.

From there, you can upload PNG images and set their position and size on the
Display.

Images render behind text, so they can be used as backgrounds, logos, icons, or
decorative panels.

---

## Merge Mode

When Merge Mode is enabled, adjacent Displays on the same plane and facing the
same direction automatically join into one larger screen.

Normal right-click edits the whole merged screen.

Shift + right-click edits only the selected Display part.

Merged Displays work best when they form a complete rectangle.

Disable Merge Mode if you want a Display to stay separate even when touching
other Displays.

---

## Examples

### Simple storage counter

&i^item:minecraft:diamond Diamonds: &s^minecraft:diamond

&i^item:minecraft:iron_ingot Iron: &s^minecraft:iron_ingot

### Production monitor

# Factory Line A

Iron/min: &d^minecraft:iron_ingot%1m@5m

Copper/min: &d^minecraft:copper_ingot%1m@5m

### Storage dashboard

# Storage Status

| Resource                          | Stored                  |
|-----------------------------------|-------------------------|
| &i^item:minecraft:diamond Diamond | &s^minecraft:diamond    |
| &i^item:minecraft:iron_ingot Iron | &s^minecraft:iron_ingot |
| &i^fluid:minecraft:lava Lava      | &s^fluid:minecraft:lava |

---

## Tips

- Use the token builder instead of typing long tokens by hand.
- Use Merge Mode for large status screens.
- Use Shift + right-click when you only want to edit one Display.
- If live values show 0, check that the Display has a network channel.