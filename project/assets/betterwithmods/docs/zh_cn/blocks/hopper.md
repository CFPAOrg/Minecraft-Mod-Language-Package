# Filtered Hopper

![Hopper](block:betterwithmods:single_machine@2)

漏斗会根据过滤槽中的物品来吸收其上方的物品。
可以通过将某个物品放入上方的过滤器槽中来进行过滤。
如果没有物品在过滤器槽中，则任何物品都可以通过。
如果任何非过滤器的物品被放入，则只有这种物品可以通过。
;The Hopper will pick up items above it based on its filter. 
;It can be filtered by putting an item in the top slot.
;If no item is in the filter slot then any item can pass.
;If any non-filtering item is placed in the slot only that item can pass.

漏斗接收到机械动力后，它会将其内部缓存的物品输出到下面的库存容器中; 如果下面没有任何方块，它只会将物品放在地上。
;When the Hopper receives mechanical power, it will output it's content to the inventory below it be that be a block or an entity; if there is no block below it will simply drop the items on the ground.

## 过滤器

如果任何以下物品在槽中，只有其指定的类型可以通过。
;If any of the follow items are in the slot only its specified types can pass.

![梯子](block:minecraft:ladder)
梯子只允许物品，不允许方块通过。

![活板门](block:minecraft:trapdoor)
活板门允许任何方块通过。

![板条栅栏](block:betterwithmods:slats)
板条只允许扁平的物品通过，包括纸张，皮革，绳子和羊毛。

![Wicker](block:betterwithmods:wicker)
Wicker允许任何尘状物通过，比如沙子，种子或者小堆粉通过。
这也可以用来分离燧石和砂砾。

![Grate](block:betterwithmods:grate)
Grate将只允许最大堆叠为1的物品或方块通过。

![铁栅栏](block:minecraft:iron_bars)
铁栅栏将只允许最大堆叠大于1的物品或方块通过。

![灵魂沙](block:minecraft:soul_sand)
灵魂沙将只允许灵魂通过它，包括灵魂沙。
充满灵魂的物质将不会通过，但里面的灵魂将被虹吸出来并储存在漏斗中，并多虹吸后的物质进行细化。
例如[地狱岩渣](../items/ground_netherrack.md)会给漏斗增加一个灵魂，并被精炼成[炼狱火之烬](../items/hellfire.md)。

一个没有动力的漏斗只能存储7个灵魂，如果再次灌入灵魂，将有不好的事发生。

这些存储的灵魂被用于制作[灵魂陶瓮](soul_urn.md)
此外，在过滤槽放置了灵魂沙的情况下，它还可以储存经验球，它可以存储多达1000点的经验;如果想取回它，你必须提供机械动力
，经验球将在下方漏出。

;![Ladder](block:minecraft:ladder)
;The Ladder allows only Item types, no Blocks allowed.
;
;![Trapdoor](block:minecraft:trapdoor)
;The Trapdoor allows any Block through.
;
;![Slats](block:betterwithmods:slats)
;Slats allow only flat items through, including paper, leather, strings and wool.
;
;![Wicker](block:betterwithmods:wicker)
;Wicker will allow any dust, sand, seeds, or piles through.
;This can also be used to separate the Flint and Sand out of Gravel.
;
;![Grate](block:betterwithmods:grate)
;The Grate will only allow Items or Blocks with a max stack size of 1.
;
;![Iron Bars](block:minecraft:iron_bars)
;Iron Bars will only allow Items or Blocks with a stack size greater than 1.
;
;![Soul Sand](block:minecraft:soul_sand)
;Soul Sand will only allow Souls to pass through it, including Soul Sand itself. 
;Soul filled material will not pass through, yet the souls inside will be siphoned out and stored in the Hopper and refine the material.
;For example [Ground Netherrack](../items/ground_netherrack.md) will add one soul to the Hopper and be refined into [Hellfire Dust](../items/hellfire.md).
;
;An unpowered Hopper can only sustain 7 souls on its own, if it receives any more bad things will occur.
;
;These contained souls are used for the creation of [Soul Urns](soul_urn.md) 
;Additionally, it will also store experience orbs in the hopper, it can store up to 1000 experience; to retrieve it supply the hopper with mechanical power.
; 
; 
