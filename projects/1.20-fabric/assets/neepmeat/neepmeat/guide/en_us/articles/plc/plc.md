---
id: plc
---

# Programmable Logic Controller

The PLC is a computer specialised for industrial automation. It can run user-defined programs or run instructions one by one in an interactive mode. Its clock speed is a lightning fast 20Hz.

A PLC interacts with the world via 'actuators'. Each PLC has a robot which functions as its default actuator.

Right-clicking the PLC gives control over its robot.

\image[width=854,height=480,scale=0.6]{neepmeat:guide/images/plc_interactive.png}
\centering{A PLC in interactive mode with two display plates that can be used for recipes.}

## Interactive Mode

When controlling the robot, movement is accomplished using the normal keys. Middle click-dragging rotates the camera.

The PLC has two modes: interactive mode and edit mode. The current mode can be switched using the button on the top right of the screen.

To execute an instruction in Interactive Mode, select the desired operation from the bottom right panel. Then, click blocks in the world to add them as arguments. When sufficient arguments are provided, an instruction emitted and executed.

## Edit Mode

In Edit Mode, the program is written in the left panel. More instructions are available in this mode. These are outlined in the bottom right panel.

The buttons at the top right of the screen allow programs to be compiled, started and stopped.

### Programming Languages

The PLC can be programmed in two languages:

NEEPASM: A simple assembly language.
THORD: A higher level language than NEEPASM that has convenient flow control constructs.
 
The language can be switched with a button on the top right. 

CTRL-clicking the button opens the documentation for the selected language.

THORD is recommended due to its convenience over NEEPASM.

### Edit Mode Key Shortcuts

CTRL+R: Run or pause the program
CTRL+S: Compile the current code
CTRL+E: Compile the current code and run immediately
CTRL+T: Stop the program
CTRL+F: Execute the current instruction but pause before the next