```json
{
  "title": "杂项技巧术",
  "icon": "minecraft:iron_ingot"
}
```

没法分进其他章节的若干杂项技巧术。

;;;;;

#<trickster:trick id="trickster:summon_lightning" cost="5kG + 1.1G ^ 距离" mana-type="trickster:storm" />

尝试向给定位置落雷。

;;;;;

#<trickster:trick id="trickster:pin_chunk" cost="4G" />

将包含所给位置的区块完全加载4秒。

;;;;;

#<trickster:note title="条栏" />

法术可在施法者的视野中将任意值显示为条栏。


条栏由数标识，且可借此数随时修改。条栏的颜色由其标识符决定，同样的标识符必定产生同样的颜色。

;;;;;

可向条栏传入一个数，视作0到1之间的比例；也可传入两个数，第一个数为当前量，第二个为最大量。


清晰之技巧会向父圆返回其值，方便链式执行。

;;;;;

#<trickster:trick id="trickster:show_bar" />

在施法者的视野中显示一个条栏，使用第一个数作为标识符，并显示第二个数。

;;;;;

#<trickster:trick id="trickster:clear_bar" />

立即清除施法者视野中标识符为所给数的条栏。
