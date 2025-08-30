---
navigation:
  parent: crazyae2addons_index.md
  title: Data Variables
  icon: crazyae2addons:data_processor
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:data_processor
  - crazyae2addons:dataflow_pattern
---

# Guide: How the Data Flow System Works

The **Data Flow System** in CrazyAE2Addons lets you connect special "nodes" together to create small logic programs inside your ME network.
Think of it like Redstone, but for data: values travel between nodes, get converted, and trigger actions such as setting variables or emitting redstone.

This guide explains how it works in practice.

---

## Starting the Flow

Every graph begins with an **Entrypoint Node**.
This node provides the first value (usually a string) that starts the whole chain.

From there, the value flows into other nodes you connect.

---

## How Nodes Work

Each node has:

* **Inputs** – slots where it waits for values.
* **Outputs** – paths that send values forward.

A node will not run until **all of its required inputs** are filled.
Once ready, it processes the data and pushes results out.

---

## Connecting Nodes

When a node outputs a value, it can send it to other nodes.
There are two ways this happens:

1. **Automatic matching**

    * The runner looks at the next node’s inputs.
    * If one is empty and its type matches (or can be converted), the value goes there.

2. **Explicit routing**

    * You can force a value to go into a specific input using the `^` symbol.
    * Example:
    - outputName^inputName
    - means *“send this value into the input called `inputName`”*.

This is useful if a node has multiple inputs and you want full control.

---

## Type Conversion

Not every node speaks the same "language".
To fix that, the system automatically converts values when possible:

* String ↔ Int
* Int ↔ Bool
* Bool ↔ String

For example:

* If a node outputs `"42"` (string) but the next one expects an `int`, the system will try to convert it into the number `42`.
* If conversion fails (like `"apple"` to int), the value is dropped.

---

## Example Flow

Let’s say you want to read a variable and use it to control redstone:

1. **EntrypointNode**: provides `"1"` as a string.
2. **ReadVariableNode**: looks up the variable, outputs a number.
3. **SetRedstoneEmitterNode**: takes the number, converts it into a boolean (`>0 = ON`), and powers connected emitters.

Result: when the variable is non-zero, your emitter turns on.

---

## Important Things to Know

* **Each node runs once per cycle.**
  When it’s executed, it will not run again until the whole flow restarts.

* **Explicit routing beats automatic matching.**
  If you use `^inputName`, the system ignores all other possible matches.

* **Failed conversions stop the value.**
  Nothing breaks, but the value will not reach the next node.

---

## Quick Tips

* Use **explicit routes** (`^input`) when in doubt – it avoids confusion.
* If your flow stops working, check if the value type is what you expect. The system might be dropping it if conversion fails.
* Keep chains small and test step by step to avoid debugging issues.
* Use the variable terminal or display monitor to see what is happening

---

With these rules in mind you can build small logic circuits inside your ME network – from simple redstone toggles to advanced variable-driven automation.
