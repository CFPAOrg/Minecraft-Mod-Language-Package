# Collisions

There's an important limitation of the data system to be aware of: The cables can only carry one signal per tick.
If you have more than one device outputting into the network at the same time, the signal will be scrambled into gibberish for all receivers.

For example, if you have a serial bus on `get` mode and a script terminal outputting commands on the same network,
they will collide and cause the gibberish output. 

However, there is a way around this problem. Using the **Data Comparator** or **Data Combinator** you can process multiple different signal inputs on the same tick.

## Data Comparator

The Data Comparator is a somewhat primitive form of combining network outputs.

It takes in an input from both sides, and outputs redstone based on three modes: **Equal**, **Contains**, and **Greater Than**.
_(You can change the mode by shift-right-clicking the Data Comparator with an empty hand.)_

In the below example, the Data Comparator is set to "contains" mode, and the script terminal is reading its value using `redstone`.
If the text in the book on the right (green) is contained within the book on the left (yellow), the script terminal (red) will read a redstone value `>0`.

![Comparing of lecterns](zps:textures/gui/manual/comparator_example_step_1.png)

This is useful for simple comparisons between networks, but is limited by the fact it only outputs redstone.

## Data Combinator

The Data Combinator is a more advanced way of combining network outputs. It has two modes, **Append** and **Replace**.

When in **Append** mode, it will output from the <u>back</u> the value from the <u>left</u> input (if any) with the input from the <u>right</u> (if any) added to the end.

![Appending commands](zps:textures/gui/manual/combinator_example_step_1.png)

However this only works if you want to append directly to the end of a command. For a more precise combination, 
you can use the placeholder `%s` in the <u>left</u> input to specify where the <u>right</u> input should be inserted.

_(Make sure to shift-right-click the combinator with an empty hand to switch to replace mode)_

![Appending commands](zps:textures/gui/manual/combinator_example_step_2.png)