---
navigation:
  title: ME Requester
  icon: requester
  position: 100
item_ids:
  - merequester:requester
  - merequester:requester_terminal
---

# ME Requester

<Row>
  <ItemImage id="requester" scale="3"/>
  <ItemImage id="requester_terminal" scale="3"/>
</Row>

An add-on mod allowing you to keep items and fluids in your [ME System](ae2:getting-started.md#your-very-first-me-system) in stock.
<br/>

## Getting Started

To get started, place a <ItemLink id="requester"/> and connect it to your network. Make sure to connect it to the same network your
[Autocrafting](ae2:ae2-mechanics/autocrafting.md) logic is located in. It should host your
[Crafting CPU](ae2:ae2-mechanics/autocrafting.md#the-crafting-cpu)s and <ItemLink id="ae2:pattern_provider"/>s.

<RecipeFor id="requester"/>

In order for the <ItemLink id="requester"/> to function, you need to make sure that items or fluids you want to keep in stock have a pattern
and can also be crafted if you request them as a player. It will only automate the requesting itself. Crafting is handled by the
[ME System](ae2:getting-started.md#your-very-first-me-system).
<br/>

<FloatingImage src="assets/gui.png" align="right"/>

## Configuration

When opening the <ItemLink id="requester"/> for the first time, you will see an overview of request settings. The number of slots a single
block can host is adjustable in the config. Each row of the GUI represents an individual request.
<br/>

### Toggle Switch

The checkbox to the left toggles the request configured on that row. When a request is disabled, no checks will run and the stock of your
request will not be maintained.<br/>
This can be used to temporarily disable a specific request or to prevent the <ItemLink id="requester"/> from emitting crafting jobs while
you are still making changes to a row.
<br/>

### What to Stock

In the second column, you can specify what you want to keep in stock. The slots are ghost slots and will not hold actual items. When
dragging an item to the slot, you can use right click to set the amount to 1 or left click to use the amount the stack you are dragging has.
When dragging a bucket with a fluid to the slot, you can use right click to set the contained fluid or left click to set the bucket itself.
You can also shift-click items to quickly set the item type. If you don't have the desired item in your inventory, you can also drag and
drop it from recipe viewers that are supported by Applied Energistics.
<br/>

### Amount to Stock

The Amount to Stock field indicates how much to stock. Specify what to stock first and then enter your desired value. For non-item requests,
the field will adapt to the type. For example, showing a `B` to indicate buckets for fluid.<br/>
When the current stock falls below the specified amount, the <ItemLink id="requester"/> will request more.
<br/>

### Batch Size

The next input field specifies the batch size that will be requested once the current stock falls below the threshold specified in the
Amount to Stock field.<br/>
This can be used to put less stress on [Crafting CPU](ae2:ae2-mechanics/autocrafting.md#the-crafting-cpu)s and machines used in the craft
since the full amount will be requested at once, rather than as many individual jobs.
<br/>

### Submit Button

To apply changes to the request, enter the desired values in the Amount to Stock and Batch Size fields and then either press Enter or click
the submit button to the right on the current row. Clicking into any other row will reset the values to their previous state.
<br/>

### Status Bar

The bar below the input boxes and the submit button reflects the current status of the request.
<br clear="all" />
<br/>

## Statuses

The following statuses are displayed in the status bar for each request.
<br/>

### Gray - Empty

The current row is disabled or nothing to stock has been specified.
<br/>

### Green - Idling

The target amount to stock is already reached or there is no pattern for the configured request.
<br/>

### Red - Missing Ingredients

The system is missing the required ingredients to emit the current job. It will continue as soon as enough ingredients are found in the
system.
<br/>

### Yellow - Crafting

The desired request is currently being crafted. The requester is waiting for the job to finish.<br/>
While this status is active, the settings for the respective request inside the <ItemLink id="requester"/> are locked and can't be changed.
<br/>

### Purple - Exporting

The <ItemLink id="requester"/> received all results from the current job and is trying to export them into the storage system.<br/>
This status is usually not visible. If it's active for too long, it means there is not enough space in your storage system.
<br/>

### Block Appearance

If any request in a <ItemLink id="requester"/> has any status except idle or empty, it will change its appearance.

<Row>
  <Column>
    Inactive
    <BlockImage id="requester" scale="3" p:active="false"/>
  </Column>
  <Column>
    Active
    <BlockImage id="requester" scale="3" p:active="true"/>
  </Column>
</Row>
<br/>

## Terminal

The mod also provides a new terminal called the <ItemLink id="requester_terminal"/>. It allows you to access all <ItemLink id="requester"/>s
in the same network from a central point.

The terminal has the same features as the <ItemLink id="ae2:pattern_access_terminal"/> and allows you to search for a specific request.
Since all <ItemLink id="requester"/>s have the same name by default, all requests will be grouped under the
same header. If you want a separate group of <ItemLink id="requester"/>s in the <ItemLink id="requester_terminal"/>, you can rename them in
an anvil or with the <ItemLink id="ae2:name_press"/>.
