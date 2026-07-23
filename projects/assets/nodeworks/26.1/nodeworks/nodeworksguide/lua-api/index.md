---
navigation:
  title: Nodeworks Scripting API
  position: 40
---

# Nodeworks Scripting API

<BlockImage scale="6" id="terminal" float="left" />

Nodeworks uses [Lua](https://www.lua.org/docs.html) as its scripting language,
with a few quality-of-life extensions the editor handles before the script runs:

- **Type annotations:** ( `local x: CardHandle`, `function(xs: { CardHandle }): ItemsHandle`, etc. )
  - Tells the editor what a variable, parameter, or return value is. In return you get accurate hover tooltips, better autocompletion, and element-type inference inside for-loops

## Built-ins

<CategoryIndexDescriptions category="api_builtin" />

- [clock()](): fractional seconds elapsed since the script started running
- [print(...)](): log to terminal output
- [require(name)](): load another script tab from the same terminal by name

## Presets

Declarative builders that wrap common scheduler loops in one-line chains. See
[Presets](presets.md) for the shared pattern.

<CategoryIndexDescriptions category="api_preset" />

## Types

<CategoryIndexDescriptions category="api_types" />
