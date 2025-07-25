---
navigation:
  parent: enderdrives_intro/enderdrives_intro-index.md
  title: Ender Item Storage Cell
  icon: enderdrives:ender_disk_1k
categories:
  - enderdrives
item_ids:
  - enderdrives:ender_disk_1k
  - enderdrives:ender_disk_4k
  - enderdrives:ender_disk_16k
  - enderdrives:ender_disk_64k
  - enderdrives:ender_disk_256k
  - enderdrives:ender_disk_creative
---

# Ender Drives

Ender Drives are powerful drives that allow for global synchronized storage across ME systems, dimensions, and even different players through frequencies.  

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_1k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_1k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_4k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_4k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_16k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_16k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_64k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_64k" />
  </Column>
</Row>

<Row gap="10">
  <Column>
    <ItemImage id="enderdrives:ender_disk_256k" />
  </Column>
  <Column>
    <ItemLink id="enderdrives:ender_disk_256k" />
  </Column>
</Row>

---

## How it Works
Each EnderDrive is configured with a frequency, scope, and mode.
- A **Frequency**: Drives with the same frequency share the same inventory.
- A **Scope**: Determines who can access the drive (Global, Private, or Team).
- A **Mode**: Controls how items flow (Bidirectional, Input, Output). 

All drives with the same frequency and scope will access the **same virtual inventory**, no matter where they are located.

---

## Type Limits
Unlike traditional AE2 drives, EnderDrives limit is only based off of types.  Due to the nature of how items are stored on the back end, the only hard limitation is the amount of types.  You can quite literally store up to 2^63 - 1 or 9,223,372,036,854,775,807 items for each type.  But be careful, the power cost will increase with the amount of items stored on the drive at that frequency!

Each server will have a different type count where it will start to stress.  You can test your server by using the autobenchmark command.  You will need to have a terminal open with a drive on Private with the selected frequency for accurate results.  The benchmark will keep going until TPS drops below 18.  This can take a few minutes.

My personal average is about 275,000 types.  275,000/255 ≈ 1078.  This means that I would have to fill 107.8 ME Drives with 256k Ender Drives and typed items before I started seeing performance issues.  I've seen higher and lower suggested max types.  This limit is shared between all parties utilizing the drives on the same world.

---

## Drive Modes
Each drive can be set to one of three **transfer modes**:

- ![PEGui1](../pic/transport_bidirectional_alt.png) **Bidirectional** _(Default)_  
  Standard ME drive behavior. Insert and extract items freely.


- ![PEGui1](../pic/transport_input_alt.png) **Input-Only**  
  Items can be inserted, but not removed. Useful for buffers or syncing inputs.


- ![PEGui1](../pic/transport_output_alt.png) **Output-Only**  
  Items can be extracted, but not inserted. Great for output buffers or read-only access.

---

## Scope & Privacy

Each drive also has a **scope**, which controls who can access the inventory:
-  **Global** _(Default)_  
   Public! Any player using the same frequency can access this shared inventory.


-  **Private**  
  Tied to your UUID. Only you can create drives to access this frequency.  Any other user of your ME system can still access this storage


-  **Team**  
  Shared with your FTB Team. All members can create drives with access to the same frequency.

