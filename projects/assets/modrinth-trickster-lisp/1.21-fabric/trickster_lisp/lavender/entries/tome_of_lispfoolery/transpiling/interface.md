```json
{
  "title": "Interface",
  "icon": "minecraft:black_stained_glass_pane",
  "category": "trickster_lisp:transpiling",
  "ordinal": 0
}
```

Transpiler interface contains 2 text boxes and 3 buttons.


Text box in the middle is the code editor.


Text box on the bottom is for validation messages.

;;;;;

**Load** button overrides contents of code editor with spell or code found in offhand.


To successfully load a spell, hold a scroll in your offhand, 
open the transpiler and click **Load** button.
<item;trickster:scroll_and_quill>

To load code from paper, you do same thing as above.
<item;trickster_lisp:paper_and_pencil>

;;;;;

**Validate** button parses, validates and formats you code.
You can use this to check if your code has any syntax mistakes.


**Store** button stores code on paper, or converts code into a spell and puts it onto any item.

You must hold an item in offhand for this to work.

If any error happens during conversion, validation text box will let you know about it.

;;;;;

Try experimenting with loading spells and see how spells look like in LISP!