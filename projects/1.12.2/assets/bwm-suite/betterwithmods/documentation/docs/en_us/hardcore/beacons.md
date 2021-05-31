# Hardcore Beacons

This feature reworks how beacons function. Beacons no longer have any GUI, instead the effect of the beacon is dictated by the blocks under it.

With a few exceptions, beacons follow these tier rules:


| Tier | Size| Total Blocks | Range (Radius)|
| ---- | ------------ | ------------ |---------- |
|  1   |   9 (3x3)    | 9            | 20 blocks | 
|  2   |   25 (5x5)   | 34           | 40 blocks |
|  3   |   49 (7x7)   | 83           | 80 blocks |
|  4   |   81 (9x9)   | 164          | 160 blocks|

*The range of all beacons, exlcuding the Ender and Spawn Beacons, are configurable on a beacon by beacon basis*

A Beacon base must consist of all same block and depending on the block the effect will be different

|Base Block | Effect |
| ---- | ------------ |
|Glass | No Effect, Cosmetic Only |
|Concrete | No Effect, Cosmetic Only |
|Terracota | No Effect, Cosmetic Only |
|Wool | No Effect, Cosmetic Only |
|Iron | Gives all hostiles in range have [Glowing](https://minecraft.gamepedia.com/Status_effect#Glowing) for 30 seconds every 3 minutes|
|Emerald | All mob deaths are under the effect of [Looting](https://minecraft.gamepedia.com/Enchanting#Looting) |
|Lapis | All players in range have True Sight |
|Diamond | All players in range have [Fortune](https://minecraft.gamepedia.com/Enchanting#Fortune) |
|Glowstone | All players in range have [Night Vision](https://minecraft.gamepedia.com/Status_effect#Night_Vision) |
|Gold | All players in range have [Haste](https://minecraft.gamepedia.com/Status_effect#Haste) |
|Slime | All players in range have [Jump Boost](https://minecraft.gamepedia.com/Status_effect#Jump_Boost) |
|Hellfire | All players in range have [Fire Protection](https://minecraft.gamepedia.com/Status_effect#Fire_Resistance) |
|Prismarine | All players in range have [Water Breathing](https://minecraft.gamepedia.com/Status_effect#Water_Breathing) |
|Dung | All players in range have [Nausua](https://minecraft.gamepedia.com/Status_effect#Nausea) and [Poison](https://minecraft.gamepedia.com/Status_effect#Poison) unless wearing full [Plate Armor](../items/plate_armor.md) |
|Coal | All players in range have [Blindness](https://minecraft.gamepedia.com/Status_effect#Blindness) unless wearing full [Plate Armor](../items/plate_armor.md)|

# Tier Exceptions

### Soulforged Steel 

This Beacons allows the Player to set their spawn by right-clicking it with an empty hand.

| Tier | Radius           |
| ---- | ---------------- | 
| 1    | 40 meters        |
| 2    | 80 meters        |
| 3    | Entire Overworld |
| 4    | Interdimensional |
 
  
### Ender Block

This Beacon changes how Ender Chests work. Any Ender Chest not placed on this beacon acts as a normal chest. Ender Chests placed on specific levels of the beacon have different inventories.
  
| Tier | Access                                     |
| ---- | ------------------------------------------ | 
| 1    | Shared Inventory in that dimension         |
| 2    | Another Shared Inventory in that dimension |
| 3    | Globally Shared Inventory                  | 
| 4    | Private Player Inventory                   |

