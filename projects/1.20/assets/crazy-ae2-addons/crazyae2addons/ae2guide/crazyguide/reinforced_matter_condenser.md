---
navigation:
  parent: crazyae2addons_index.md
  title: Reinforced Matter Condenser
  icon: crazyae2addons:reinforced_matter_condenser
categories:
  - Crafting and Patterns
item_ids:
  - crazyae2addons:reinforced_matter_condenser
---

# Reinforced Matter Condenser

<Row>
    <BlockImage id="crazyae2addons:reinforced_matter_condenser" scale="4"></BlockImage>
    <ItemImage id="crazyae2addons:super_singularity" scale="4"></ItemImage>
</Row>

The Reinforced Matter Condenser is an upgraded singularity generator that transforms regular AE2 singularities into a powerful item: the **Super Singularity**.

This block accumulates energy over time from inserted singularities and requires a full 64-stack of **256k Cell Components** to function. Once it reaches its energy cap, it produces a Super Singularity into its output slot.

---

## How to Use

1. **Insert a Full Stack of 256k Cell Components**
   - Required to activate the condenser.
   - The block will not accept singularities until this condition is met.

2. **Insert AE2 Singularity Items**
   - The block consumes singularities to charge its internal power.
   - Once it reaches 8192 charge, it produces one Super Singularity.

3. **Output**
   - The generated Super Singularity appears in the output slot.

4. **GUI Info**
   - Progress bars show:
     - Energy progress toward next Super Singularity.
     - Count of stored 256k cells.

---

## Automation & Integration

- Compatible with item handlers on all sides.
- Exporters or pipes can automate singularity insertion.
