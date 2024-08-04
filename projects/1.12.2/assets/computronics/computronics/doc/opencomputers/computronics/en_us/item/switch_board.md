# Switch Board

![Clickety Clack.](item:computronics:oc_parts@13)

This Board can be put into Server Racks. It has got four clickable switches in the front which may be checked and activated using the `switch_board` component. In addition, it fires a `switch_flipped` event whenever a switch is manually or automatically flipped.

The `switch_flipped` event looks like the following, refer to [this guide](http://ocdoc.cil.li/component:signals) if you don't understand the signal syntax.

`switch_flipped(boardAddress:string, index:number, newState:boolean)`
