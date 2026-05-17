```json
{
  "title": "进阶内容：递归",
  "icon": "minecraft:map",
  "ordinal": 100,
  "category": "trickster:tutorials"
}
```

通常情况下，尤其是在使用[法术组构台](^trickster:items/infrastructure/spell_construct)的情况下，让法术无限重复执行可以简化操作。


法术会在执行至根节点时终止。而避免法术终止的最简单方法，就是让法术在将要结束时施放其自身。

;;;;;

如此设计随后会使得法术第三次施放其自身（因为法术没有改变），而后是第四次、第五次，永远不会停止。


初看时，这种操作简直可以说是无法达成。法术该怎么访问其自身呢？但它实际上相当简单。


法术可作为[参数](^trickster:delusions_ingresses/arguments)传入其自身。

;;;;;

法术在参数处获取到其自身后，就可施放其自身，同时再次将其自身作为参数传入了。不过，这个循环必须通过启动法术“引导启动”。


启动法术需通过[记事员之辑流](^trickster:tricks/basic#3)获取输入法术，再将其置入内圆作为参数。内圆随后会使用[宏伟之转离](^trickster:tricks/functions#4)，将该参数利用两次——向法术传入其自身。

;;;;;

<|spell-preview@trickster:templates|spell=YxEpKcpMzi4uSS2yKi5IzcmJL0gsKsEqKIgQLEgsAVJ5G32YWJkYmRkYGECYgZERUwkDAxNIiomBWGX41TG6NLWC1QEAyzmT3rgAAAA=|>


法术施放其自身的操作称为“递归”。

;;;;;

注意：如果需要让递归法术能够终止，可以让在递归点处进行条件判断。

