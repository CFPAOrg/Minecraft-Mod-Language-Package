---
navigation:
  parent: crazyae2addons_index.md
  title: Display Monitor
  icon: crazyae2addons:display_monitor
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:display_monitor
---

# Display Monitor — User Guide

![Display](../img/display.png)

This guide explains how to install, configure, format text, and build multi‑block walls with the
**Display Monitor** part in CrazyAE2Addons.

---

## What it is

The Display Monitor is a flat AE2 part you place on a cable face. When powered, 
it renders text (with simple formatting and colors) and can **subscribe to variables**
from the **ME Data Controller** to show live values.

**Power:** idle draw is minimal (about 1 AE/t). The monitor must be **powered and active** on your AE network to render.

---

## Quick Start

1. **Place** the Display Monitor on the desired cable face.
2. **Right‑click** it to open the **Display menu**.
3. In the text box, type your message (see formatting below). Example:
   - **System Online**&nl* Crafting active&nl* Stock: &s^minecraft:iron_ingot
4. **Apply/Save**. If the monitor is powered, the text appears.

---


## ME Stock Tokens (Auto‑count from Storage)

You can display **current item amounts in your ME storage** with special tokens:

**Syntax**

&s^namespace:item
&s^namespace:item%N

* `&s^minecraft:oak_log` — shows the total count of that item in ME.
* Optional `%N` scales the number by **10^N** with rounding:

  * `%1` → tens
  * `%2` → hundreds
  * `%3` → thousands
  * `%4` → ten‑thousands, etc.

**Examples**

| Token                       | Meaning                 | Example value (if ME has 64)      |
| --------------------------- | ----------------------- |-----------------------------------|
| `&s^minecraft:oak_log`      | exact amount            | `64`                              |
| `&s^minecraft:oak_log%1`    | amount / 10 (rounded)   | `6`                               |
| `&s^minecraft:oak_log%2`    | amount / 100 (rounded)  | `1` if 120 → `1`, 150 → `2`       |
| `&s^minecraft:iron_ingot%3` | amount / 1000 (rounded) | `0` for values < 500, 1 if >= 500 |

> You can mix stock tokens with colors and other formatting, e.g.:
> `&b101010&cE0E0E0**Logs:** &s^minecraft:oak_log%3 k`

## Text Formatting Cheat Sheet

You can mix several lightweight formatting features directly in the monitor’s text field.

### New lines

* Use enter or &nl where you want a line break.

### Inline styles (Markdown‑like)

* `**bold**` → bold
* `*italic*` → italic
* `__underline__` → underlined
* `~~strikethrough~~` → strikethrough

### Colors

* **Text color:** `&cRRGGBB` (hex)
    * Example: `&cFF0000` makes following text red until you change it again or until a line break. 
* **Background color:** `&bRRGGBB` (hex)
    * Example: `&b001122` sets the whole panel background to an opaque dark blue.
    * Background is global per display array (set it once anywhere in the text).

### Bullets and indentation

* Start a line with `* ` or `- ` to get a bullet `•`.
* Begin a line with one or more `>>` to add visual indent markers.

---

## Variables (Live Values)

You can insert **live variables** by writing `&name` in your text. The monitor will auto‑subscribe to each variable it sees and render the latest value pushed by the **ME Data Controller**.

* Syntax: `&` followed by letters/digits/underscore (e.g., `&A1`).
* Variables are **case‑sensitive**.
* You’ll need a **CrazyAE2Addons ME Data Controller** on the same AE grid, with variable capacity available, and something in your Data Flow
  (nodes) producing the values.

**Example**

&b101010&cE0E0E0**Stock**&nl
Iron: &iron&nl
Gold: &gold&nl
Circuits: &circuits

> The monitor automatically registers/unregisters variables when you change its text or when the grid/controller state changes.

---

## Font Size and Auto‑Fit

* **Auto‑fit:** set font size to **0** (or leave at default). The text scales to fit the available area.
* **Fixed size:** set a **positive** font size value in the menu for consistent sizing across monitors.

> If text doesn’t fit at a fixed size, it will clip. Use `&nl` to add lines or reduce the size.

---

## Multi‑Monitor Walls (Linked Mode)

You can stitch several monitors into a **single large display** on a wall (N/E/S/W facing).

### Requirements

* All monitors must:

    * Be on the **same wall face** (same side/facing).
    * Be **powered and active**.
    * Have **Linked Mode** enabled (toggle in each monitor’s menu).
* The group of monitors must form a **solid rectangle** (no gaps/holes).
* **Ceiling/Floor** monitors (UP/DOWN) **do not** link into walls; they render as single tiles.

### How rendering works

* Only **one** monitor in the rectangle actually draws the text; the rest provide surface area.
* The renderer chooses an internal **origin** tile (typically the **upper‑right** of the rectangle, from the wall’s perspective).
* Put your text on **that one** monitor, and it will appear across the whole wall (auto‑fit works across the combined size).

> If you edit a monitor and nothing appears on the wall, try editing the tile at the **top‑right corner** of the rectangle.

### Building steps

1. Place your monitors in a perfect rectangle on a wall.
2. Power the cable(s) behind them.
3. Enable **Linked Mode** on each.
4. Open the **top‑right** monitor and configure the text/size.

---

## Placement & Rotation

* On walls (N/E/S/W): the text follows the wall orientation. Use the part’s facing to change direction.
* On floor/ceiling (UP/DOWN): the monitor stores a **spin** captured from your facing at placement. To change it, break and place again while facing a different direction.

---

## Tips & Troubleshooting

* **No text shows:** ensure the monitor is **powered and active**; for walls, edit the **top‑left** tile of the rectangle.
* **Variables show as `&name`:** your **ME Data Controller** may be missing, out of capacity, or the variable isn’t being produced. Fix the controller/nodes; the monitor will re‑register automatically.
* **Wall not linking:** check that every tile has **Linked Mode** enabled, all are on the **same facing**, and the shape is a **perfect rectangle** with no gaps.
* **Clipped text:** switch to **Auto‑fit (size 0)** or reduce your fixed font size. Use `&nl` to split long lines.

---

## Reference (All Tokens)

* `&nl` — new line
* `&cRRGGBB` — text color (affects following text)
* `&bRRGGBB` — background color (applies to the whole panel)
* `&name` — variable placeholder (letters/digits/underscore)
* Line starts with `* ` or `- ` — bullet `•`
* Line starts with `>>` (repeat) — visual indentation
* `**bold**`, `*italic*`, `__underline__`, `~~strikethrough~~`
* &s^namespace:item — ME item amount
* &s^namespace:item%N — ME amount scaled by 10^N (rounded)

---

Happy building! If you have ideas for additional formatting tokens,
let me know on discord (link is on the main wiki page)
so I can consider adding them for future versions.
