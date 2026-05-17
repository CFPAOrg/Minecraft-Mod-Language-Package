---
navigation:
  parent: crazyae2addons_index.md
  title: Display Database
  icon: crazyae2addons:me_display_database
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:me_display_database
---


# ME Display Database

The **ME Display Database** stores named text values for Displays.

All databases connected to the same ME grid share the same values.
Displays can read those values with simple tokens like &status, &fuel_name, or &storage_pct.

---

## Usage

Place the block on an ME network and right-click it to open the database GUI.

Add entries as key/value pairs:

| Key           | Value     |
| ------------- | --------- |
| status      | Running |
| fuel_name   | Diesel  |
| storage_pct | 82.50   |

Use them on a Display by writing & followed by the key:

Status: &status
Fuel: &fuel_name
Storage: &storage_pct%

---

## Grid Behavior

Databases are shared per ME grid.

When grids merge, database values merge too. If an old database is connected later, its saved values may return during merge.

If no ME Display Database is currently connected to the grid, database tokens do not resolve.

---

## ComputerCraft

With CC:Tweaked installed, the block can be used as a peripheral:

local db = peripheral.find("crazyae2addons:me_display_database")
db.add("status", "Running")
db.add("fuel_name", "Diesel")
print(db.list().status)
db.remove("status")

Methods:

| Method            | Description              |
| ----------------- | ------------------------ |
| add(key, value) | Adds or updates a value. |
| remove(key)     | Removes a value.         |
| list()          | Returns all values.      |

---

## Config

The feature can be disabled in the common config.

When disabled, the GUI does not open, Display database tokens do not resolve, and ComputerCraft methods do not work.

---

## Tips

Use the database for values that cannot be read directly by normal Display tokens, such as ComputerCraft status text, selected fuel names, calculated runway time, or controller state.

For normal ME item/fluid amounts, use stock tokens. For rates, use delta tokens.
