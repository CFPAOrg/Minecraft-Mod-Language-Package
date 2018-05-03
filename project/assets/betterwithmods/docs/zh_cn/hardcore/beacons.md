# Hardcore Beacons

This feature reworks how beacons function. Beacons no longer have any GUI, instead the effect of the beacon is dictated by the blocks under it.

With a few exceptions, beacons follow these tier rules:

`Tier         Total blocks  Radius`  
`1 (3x3) 9      9             20 blocks`  
`2 (5x5) 25    34            40 blocks`  
`3 (7x7) 49    83            80 blocks`  
`4 (9x9) 81    164          160 blocks`
  
A Beacon base must consist of all same block and depending on the block the effect will be different

* **Block** - **Effect**
* Glass or any unused modded beacon base - Activates the beacon with no effect, used for decoration
  
* Emerald Block -  Causes all death in the area to have the same effect as a Looting enchant, goes up to Looting 4
  
* Lapis Block - Gives True Sight, a potion effect that spawns particles on blocks with light levels lower than 8; Useful for lighting up an area.
   
* Diamond Block - Gives Fortune to all mining in an area, goes up to Fortune 4.
  
* Glowstone - Gives Players Night vision
  
* Gold Block - Gives Players Haste
  
* Slime Block - Gives Players Jump Boost  

* Concentrated Hellfire Block - Gives Players Fire Protection

* Prismarine - Gives Players Water Breathing

* Sponge - Suffocates all air breathers, unless wearing a [Plate Helmet](../items/plate_armor.md)

* Dung - Gives Players Nausea and Poison to all not wearing full [Plate Armor](../items/plate_armor.md)

* Coal Block - Gives Players Blindness to all not wearing a [Plate Helmet](../items/plate_armor.md)  

**Tier Exceptions**
* Soulforged Steel Beacon - This Beacons allows the Player to set their spawn by right-clicking it with an empty hand.  
  `Tier    :   Radius`   
  `1       :   40 Blocks`
    
  `2       :   80 Blocks`
    
  `3       :   Unlimited in the Overworld`
    
  `4       :   Unlimited across dimensions`  
  
  

* Ender Block - This Beacon changes how Ender Chests work. Any Ender Chest not placed on this beacon acts as a normal chest.
  Ender Chests placed on specific levels of the beacon have differet inventories
  `Tier    :   Access`  
  `1       :   Shared Inventory in that dimension`
    
  `2       :   Another Shared Inventory in that dimension`  
  
  `3       :   Global Shared Inventory`  
  
  `4       :   Private Player Inventory`
