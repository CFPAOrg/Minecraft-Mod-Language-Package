---
navigation:
   parent: crazyae2addons_index.md
   title: Portable Builder
   icon: crazyae2addons:portable_builder
categories:
   - Monitoring and Automation
item_ids:
   - crazyae2addons:portable_builder
---

# Portable AutoBuilder

<ItemImage id="crazyae2addons:portable_builder" scale="4"></ItemImage>

The **Portable AutoBuilder** is a handheld **copy & paste** builder tool that integrates with **Applied Energistics 2**.

It stores a structure **program**, shows a **3D preview** in its GUI, can **rotate/flip** the build, and will pull required blocks directly from your connected **ME network** before placing.

## [Video Tutorial](https://youtu.be/2cKivPmxZ0w&list=PLB8Rr5Xojkr5T1qoPr_4JdETiBkF4qF6r)

---

## Connecting to your ME network

This gadget behaves like a wireless AE2 tool, link it to your network via a **Wireless Access Point**.

---

## Copying a structure

### 1) Select corners

Use **Sneak + Right‑Click** on blocks to define the copy region:

1. First sneak-click sets **Corner A**.
2. Second sneak-click sets **Corner B**.
   * The **second click also becomes the structure origin**.
3. If you sneak-click again after both corners are set, it starts a **new selection** (Corner A is replaced, Corner B cleared).

### 2) Finalize the copy

After both corners are set, **Right‑Click (not sneaking) air** to generate the program and store it in the gadget.

Copying costs power based on the blocks inside the region (air is ignored).

---

## Pasting a structure

### Placement

You can paste in two convenient ways:

* **Right‑Click something**: it raytraces up to **50 blocks**; if you’re pointing at a block, it pastes next to it.

### Collision safety

Before placing anything, the gadget checks every target position:

* If any block would be placed into something that **cannot be replaced**, the paste aborts with a collision message.

### Materials

Before building, the gadget computes a full **block requirement list**:

* It then attempts to **extract** the needed items from your ME network.
* If anything is missing, the paste won’t start (you’ll get a “Missing: ...” message).
* Creative players skip the ME extraction.

---

## GUI and preview

Open the GUI with **Sneak + Right‑Click in air**.

Inside the GUI you can:

* View a **3D preview** of the stored structure.
* **Drag** to rotate the camera.
* **Scroll** to zoom.
* Use buttons to:
   * **Flip Horizontal**
   * **Flip Vertical**
   * **Rotate**
   * **Clear** the stored structure
---

## Crafting Card: requirements panel

If you install an **AE2 Crafting Card**, the GUI shows a requirements panel:

* Displays items as **have / need**.
* Marks whether each missing item is **craftable**.
* For craftable entries, you can click the button to send a **craft request** for the missing amount.
* The list is scrollable with the mouse wheel.

---

## Energy system (AE power)

The gadget uses **AE2’s internal tool power**, shown via the item’s durability-style energy bar.

* **Base capacity:** 200,000
* **Upgrade slots:** 4
* **Energy Cards:** each card increases max power by **+100% of base**

---

## Tips

* If paste keeps failing with “Missing ...”, open the GUI (with a Crafting Card installed) to see exactly what’s short and request crafts.
* If paste fails with a collision, clear the area first - this tool refuses to overwrite non-replaceable blocks.
