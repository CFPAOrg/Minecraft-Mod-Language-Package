# Digital Cart Detector

![Detects digitally.](block:computronics:digital_detector)

The Digital Cart Detector detects when a minecart passes adjacent to the block, firing a `minecart` lua event, which can be detected by a computer. The digital detector must be connected to a computer from the correct side.

The `minecart` event looks like the following, refer to [this guide](http://ocdoc.cil.li/component:signals) if you don't understand the signal syntax.

`minecart(detectorAddress:string, minecartType:string, minecartName:string [, primaryColor:number, secondaryColor:number, destination:string, ownerName:string])`

`minecartName` may be an empty string if it has not been given a name. If the cart is a locomotive, the locomotive's colors will be provided as well as the destination (or an empty string if it does not have a destination) and the name of the owner (or an empty string if it does not have an owner).
