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

Cable part that renders text, icons, and live ME data on its face.
Adjacent Displays can merge into one big screen.

Needs a channel for live data. Without it, text shows but all counts read 0.

Right-click opens the GUI. In Merge Mode, that edits the whole merged group.
Shift + right-click always opens just the one Display you clicked.

---

## Formatting

Headings: start a line with \# through \###### - six levels, scaling from 1.6x down to 0.95x.

Bullet list: start a line with \* or - followed by a space.

Indent a line with >> at the start (stack for deeper levels, e.g. >>>> for two levels).

Standard Markdown syntax for emphasis:

\*\*text\*\* is bold, \*text\* is italic, \_\_text\_\_ is underlined, \~\~text\~\~ is struck through.

---

## Colors and background

&cRRGGBB sets the text color from that point to the end of the line.

&cRRGGBB(text here) scopes the color - resets at the closing parenthesis. Can span multiple lines.

&bRRGGBB sets a fill color for the entire Display face. Only the last one in the text applies.

---

## Math expressions

&(expression) evaluates and inserts the result inline. It runs on the same
[Math Parser](./math_parser.md) as the number fields in other GUIs, so operators, parentheses,
suffixes like 5k, and scientific notation all work the same way here.

Expressions are evaluated after all token substitution, so you can do arithmetic on live counts.

Example: &(&s^minecraft:diamond \* 100 / &s^minecraft:iron_ingot)

---

## Tables

Standard Markdown table syntax. Column alignment via the separator row:
\|---\| left, \|:---:\| center, \|---:\| right.

Cells can contain tokens, icons, and colors.

---

## Icons

&i^item:mod:name - item icon inline with text.

&i^fluid:mod:name - fluid icon.

&i^mod:name - tries item first, then fluid.

---

## Stock tokens

&s^mod:name shows how much of that item or fluid is stored in the ME network.

&s^mod:name%N divides the count by 10^N before displaying it.
For example, %3 divides by 1000, so 12345 becomes 12.

---

## Delta (rate) tokens

&d^mod:name@30s shows how much the stored amount changed per second, averaged over 30 seconds.
Positive = net inflow, negative = net outflow.

Default display unit is per second. Change it with a %Nu prefix before the @:

&d^minecraft:iron_ingot%1m@5m - per minute, averaged over 5 minutes

&d^minecraft:iron_ingot%1t@1m - per tick, averaged over 1 minute

Time units: t = ticks, s = seconds, m = minutes. Window minimum is 1 second, maximum 30 minutes.

---

## Tag expressions

Both stock and delta tokens accept a tag expression instead of a single item ID:

&s^tag{forge:ingots}

&s^tag{forge:ingots && !forge:ingots/iron}

&d^tag{forge:ingots}%1m@5m

See the [Tag Matcher](./tag_matcher.md) page for full syntax.

---

## Display Database variables

The **Display Database** block (a separate block, not a cable part) connects to your ME network
and holds named text variables you define, like factoryName = Reactor Hall.

Any Display on the same network can insert a variable with &varname:

\# &factoryName

Variables are expanded before tokens, up to 8 levels deep, so a variable can itself contain
tokens or other variables. Useful for shared labels across many Displays.

---

## Mod compat types

With supported mods installed, use their resources in tokens and icons:

| Prefix | Mod |
|---|---|
| flux: | AppFlux |
| mana: | Applied Botania |
| source: | Ars Energistique |
| gas: | Mekanism |
| infusion: | Mekanism |
| pigment: | Mekanism |
| slurry: | Mekanism |

---

## Images

A Display can show pictures behind its text. Open the Images tab in the GUI to manage them.

**Adding one.** Use the Pick File button, drag a file onto the GUI, or press Ctrl+V to take
whatever is on your clipboard, screenshots included.

Common formats work (PNG, JPEG and anything else Java can read). Everything is converted to PNG
before upload. Pictures wider or taller than 512 pixels are scaled down, and if the result still
does not fit the 32 kB upload budget it is shrunk further. A picture that cannot be squeezed under
that limit is rejected with a message instead of being uploaded.

Uploaded pictures live on the server, saved with the world, and are sent to players who need to
render them. One Display holds up to 50 of them. Copying a Display with a Memory Card copies its
pictures along with its text.

**Placing one.** Selecting an entry in the list gives you three numbers, each with a slider and a
text field:

* Scale, 1 to 100 percent. 100 means the picture is fitted to the face as large as it goes without
  changing its proportions, and smaller values shrink it from there.
* X, 0 to 100 percent. It moves the picture through the space left over next to it: 0 is flush
  left, 100 is flush right, 50 is centered. At scale 100 there is no leftover space, so X does
  nothing.
* Y, 0 to 100 percent, the same thing vertically: 0 is top, 100 is bottom.

**Stacking.** Pictures are drawn in list order, so an entry further down the list covers the ones
above it. The up and down buttons move the selected entry. Text is always drawn in front of every
picture.

In Merge Mode the pictures belong to the top left Display of the group and are laid out across the
whole merged screen, exactly like the text.

Servers can turn the whole feature off in the config.

---

## Merge Mode

With Merge Mode on, neighbouring Displays stop being separate screens and render one picture
together, spread across all of them.

Two Displays join only if all of this holds:

* they sit on the same side of their blocks, and on floors and ceilings they also share the same
  rotation
* both have Merge Mode on
* both are powered
* the toggle for the edge where they touch is on for both of them

A group is always a full rectangle. The mod takes the largest complete rectangle it can build from
the connected Displays. A ragged shape, or one with a hole in it, does not merge. Cut the power and
the group falls apart into single screens until it comes back.

**The top left Display owns the content.** Its text, images, colors, and settings are what the
whole group shows. The others only draw their part of it, and their own text is ignored while they
are in the group. Left is left as you look at the screen from the front.

Because of that, right-clicking anywhere on a merged group opens the GUI of that top left Display.
Shift + right-click always opens the exact Display you clicked, which is how you get at its edge
toggles.

**Per-edge connect toggles** - each Display has four on and off switches, one per edge. Turning one
off blocks merging across that edge, so a whole wall of Displays can be split into several screens
without taking anything down.

---

## Center text and margin

Two toggles in the GUI change how the text sits on the screen. They work on a single Display and on
a merged group alike. In a group the setting comes from the Display that owns the content.

**Center text** - horizontally centers every line instead of aligning it to the left.

**Add margin** - keeps the text away from the edges instead of letting it run to the border.