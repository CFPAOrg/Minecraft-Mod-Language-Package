---
id: implanter
---

# Implanter

The Implanter is used for implanting implants into implantees.

It can be controlled manually or automatically by a PLC.

Under manual control, no extra infrastructure is required. With a PLC, the target entity must be standing on a Surgery Platform.

## Manual Control

Using the main block gives direct control over the Implanter. The head can be repositioned with the normal movement keys. 

To apply an implant, the head must be positioned correctly.

When the head facing an entity, it will be highlighted and a cross marking the implant site will become visible. When the cross is in the centre of the head's camera, the operation can be performed using the APPLY button.

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/implanter_manual.png}
\centering{View through an Implanter's camera in manual mode.}

## PLC Automation

The `IMPLANT` instruction is responsible for controlling an Implanter automatically. `IMPLANT` takes two arguments:

1. The item inventory to take the implant from
2. The Surgery Platform that the target entity is standing on.

Example:

```
# Using aliases for readability
%a input = @(2 3 4) # Input inventory
%a platform = @(3 3 4) # Platform

robot @(1 2 3) # Implanter's position
implant $input $platform
```

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/implanter.png}
\centering{A PLC controlling an Implanter. An Implant Manager is attached to the Surgery Platform on which a player stands.}
