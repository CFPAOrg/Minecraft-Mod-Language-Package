---
id: fluid_drain
lookup: neepmeat:fluid_drain
---

# Fluid Drain

\columns[fit=second]{
The Fluid Drain consumes fluid from the world and stores them in an internal buffer. It also collects blood and meat from entities disassembled above it with a Tissue Operator.
}{\item_render{neepmeat:fluid_drain}}

## Usage

Every 16 ticks, the drain will consume a source block that is directly above it or is connected via flowing blocks.The internal buffer holds eight buckets.

When a mob is killed with a Tissue Operator above a drain, 250mb of blood will be collected.

Fluid can be extracted from a drain using pipes or with a bucket.
