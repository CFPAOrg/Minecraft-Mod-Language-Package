---
navigation:
  parent: lua-api/index.md
  title: VariableHandle
  icon: variable
categories:
  - api_types
description: reference to a <ItemLink id="variable" /> in a network
---

# VariableHandle

A `VariableHandle` is a reference to a <ItemLink id="variable" /> in the
network, returned by [`network:get(name)`](network.md#get) (the same accessor
used for cards). The handle tracks the variable's declared type. Each type of
variable gains specific helpers on top of the shared core API below.

<BlockImage scale="6" id="variable" />

> **Note:** All mutations are atomic. A second script calling `:set` or `:cas`
> on the same variable can never interleave mid-operation.

## Properties

- **`.name`**
  - the variable's alias (same label shown in the terminal sidebar)

## Core methods

### get / set

Retrieves and sets the variable's current value

<LuaCode>
```lua
local myNumericVar = network:get("myNumericVar")
print(myNumericVar:get())
myNumericVar:set(1)
print(myNumericVar:get())
-- "0"
-- "1"
```
</LuaCode>

### cas

Compare-and-swap. Sets the variable to `new` only if its current value equals
`expected`. Otherwise the current value is left untouched. Returns `true` if
the swap succeeded, `false` if something else had already changed the value.

Use this whenever the new value you want to write **depends on the current value**
and more than one script might touch the variable. `:set` will happily overwrite
whatever is there, so two scripts racing each other can stomp each other's work.
`:cas` refuses to write unless the variable still looks like the value you think it is.

<LuaCode>
```lua
-- claim a job slot: only the first script that reads "" wins
if slot:cas("", "worker_A") then
  print("i got the job")
else
  print("someone else already claimed it")
end
```
</LuaCode>

A typical read-modify-write loop when the value might change mid-flight:

<LuaCode>
```lua
-- decrement only while > 0, retrying on contention
while true do
  local current = counter:get()
  if current <= 0 then
    break -- nothing left to take
  end
  if counter:cas(current, current - 1) then
    break -- we got it
  end
  -- another script moved the value between :get and :cas, try again
end
```
</LuaCode>

> **Note:** For straightforward arithmetic, [`increment / decrement`](variable-handle.md#increment--decrement) are already
> atomic and simpler. Use `:cas` when the transition isn't just "+/-" n

### type

Returns a string that represents the "type" of this `VariableHandle`

- **`NumberVariableHandle`**
  - `"number"`
- **`BoolVariableHandle`**
  - `"bool"`
- **`StringVariableHandle`**
  - `"string"`

<LuaCode>
```lua
local numberVar = network:get("numberVar")
local boolVar = network:get("boolVar")
local stringVar = network:get("stringVar")
print(numberVar:type())
print(boolVar:type())
print(stringVar:type())
-- "number"
-- "bool"
-- "string"
```
</LuaCode>

## BoolVariableHandle

A [`VariableHandle`](./variable-handle.md) pointing at a <ItemLink id="variable" /> declared
with the type `bool`. Adds methods that only work on bool variables.

### toggle

Flips the current value. (`true` becomes `false`, `false` becomes `true`) and
returns the new value.

<LuaCode>
```lua
local lights = network:get("lights")
print(lights:get())
lights:toggle()
print(lights:get())
-- "false"
-- "true"
```
</LuaCode>

> **Note:** Useful as a "press to toggle" action wired to a redstone button via
> [`RedstoneCard:onChange`](./card-handle.md#onchange)

### tryLock / unlock

A bool variable doubles as a mutual-exclusion lock. `:tryLock()` atomically flips
the variable from `false` to `true` and returns `true` on success. If the bool variable
was already `true` (another script holds it), it returns `false` **without blocking**.
`:unlock()` flips it back to `false`.

<LuaCode>
```lua
local mutex = network:get("job_mutex") -- bool variable
if mutex:tryLock() then
  -- do job
  mutex:unlock()
end
```
</LuaCode>

> **Important:** `:tryLock` doesn't wait if the lock is held. It'll return `false` immediately instead. Design your script to either retry later ([`scheduler:delay`](scheduler.md#delay)) or skip the work if it can't claim the lock.
>
> Always pair a successful `:tryLock` with `:unlock`. Wrap the critical section in `pcall` as above so the lock doesn't get stuck if your code errors out.

## NumberVariableHandle

A [`VariableHandle`](./variable-handle.md) pointing at a <ItemLink id="variable" /> declared
with the type `number`. Adds methods that only work on number variables.

### increment / decrement

Adds or subtracts from the variable's current value. Both take an amount and returns
the new value.

<LuaCode>
```lua
local counter = network:get("counter")
counter:set(0)
counter:increment(1) -- +1 -> 1
counter:increment(5) -- +5 -> 6
counter:decrement(2) -- -2 -> 4
```
</LuaCode>

### min / max

- `:min(n)` sets the variable to whichever is smaller: the current value or `n`.
- `:max(n)` sets it to whichever is larger.

Both return the new value.

<LuaCode>
```lua
local best = network:get("best_score")
best:set(42)
best:max(50) -- 42 vs 50 -> 50 (new high)
best:max(35) -- 50 vs 35 -> 50 (unchanged)
best:min(10) -- 50 vs 10 -> 10 (capped)
```
</LuaCode>

## StringVariableHandle

A [`VariableHandle`](./variable-handle.md) pointing at a <ItemLink id="variable" /> declared
with the type `string`. Adds methods that only work on string variables.

### append / length / clear

- `:append(str)` adds `str` to the end of the current value and returns the new
string.
- `:length()` returns how many characters are in the current value.
- `:clear()` empties the variable (sets it to `""`).

<LuaCode>
```lua
local log = network:get("log")
log:clear()
log:append("start ")
log:append("middle ")
log:append("end")
print(log:get())
print(log:length())
-- "start middle end"
-- 16
```
</LuaCode>