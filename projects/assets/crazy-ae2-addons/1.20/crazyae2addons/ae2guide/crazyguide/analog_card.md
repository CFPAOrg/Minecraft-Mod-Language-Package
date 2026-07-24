---
navigation:
  parent: crazyae2addons_index.md
  title: Analog Card
  icon: crazyae2addons:analog_card
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:analog_card
---

# Analog Card

The **Analog Card** is an upgrade card that changes compatible level emitters from binary redstone output to analog redstone output.

Instead of only outputting 0 or 15, the emitter can output a signal from 0 to 15 based on the monitored amount and threshold.

---

## Compatible hosts

The Analog Card can be installed in:

* ME Level Emitter
* Tag Level Emitter

---

## Output invariant

With the Analog Card installed, the signal is based on amount compared to threshold.

Amount 0 produces signal 0.

Amount greater than or equal to the threshold produces signal 15.

Amounts between 0 and the threshold produce a signal between 1 and 14, depending on the selected scaling mode.

If the threshold is 0, the output is always 15.

---

## Scaling modes

Installing the card adds an analog mode toggle to the emitter GUI. The toggle switches between linear and logarithmic scaling.

---

## Linear mode

Linear mode scales evenly across the whole range.

The signal is calculated as: signal = floor(amount × 15 / threshold)

---

## Logarithmic mode

With this mode, the signal roughly means:

- full threshold: 15
- 1/2 threshold: 14
- 1/4 threshold: 13
- 1/8 threshold: 12
- 1/16 threshold: 11
- and so on...
- empty: 0

---

## Redstone mode interaction

The emitter's Redstone Mode still applies to the analog signal.

Low Signal inverts it as: 15 - calculated signal

---