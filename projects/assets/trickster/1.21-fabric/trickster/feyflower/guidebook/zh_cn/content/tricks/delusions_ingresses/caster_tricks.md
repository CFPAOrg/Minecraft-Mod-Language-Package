```json
{
  "title": "施法上下文",
  "icon": "trickster:wand"
}
```

*“在绝大多数情况下，法术的施放始于自我。*


*“无论施法者是人类，是组构台，还是与前两者完全不同的事物，自我都是我们认识世界的手段。因此，自我也是我们观察魔法的切入口。”*


——摘自黄水晶教授的讲座

;;;;;

#<trickster:trick id="trickster:reflection" />

返回法术施放的位置。

;;;;;

#<trickster:trick id="trickster:facing_reflection" />

将施法者的朝向返回为单位向量。

;;;;;

#<trickster:trick id="trickster:caster_reflection" />

若可行，返回施放法术的实体。

;;;;;

#<trickster:trick id="trickster:mana_reflection" />

返回法术直接可用的魔力的量。

;;;;;

这则错觉术会统计施法者持有和佩戴的所有魔力存储物品，如[晶结](*trickster:items/mana/knots)和[充能腰带](*trickster:items/mana/charging_belt)。


若由[法术组构台](*trickster:items/infrastructure/spell_construct)施放，则只统计组构台中的晶结。

;;;;;

#<trickster:trick id="trickster:max_mana_reflection" />

返回施法者最多能持有的魔力量，具体判断流程与前一则错觉术类似。

;;;;;

#<trickster:trick id="trickster:current_thread" />

返回运行此法术的法术槽；若不在法术槽中运行，则返回void。

;;;;;

#<trickster:trick id="trickster:read_macro_ring" />

获取施法者所佩戴所有戒指上的映射，将其合并为单个映射后返回。不是有效宏的键值对会被移除。

;;;;;

此戏法的输出与判定宏用到的映射一致。


更多细节参见[宏](*trickster:concepts/macro)页面。

;;;;;

#<trickster:trick id="trickster:hotbar_reflection" />

若可行，返回施法者选中的快捷栏槽位。

;;;;;

#<trickster:trick id="trickster:check_hat" />

返回施法者[帽子](*trickster:items/writing_casting/hats)的所选槽位。

;;;;;

#<trickster:trick id="trickster:other_hand" />

返回施法者副手中物品的类型。

;;;;;

#<trickster:trick id="trickster:other_hand_slot" />

返回施法者副手的槽位引用。

;;;;;

#<trickster:trick id="trickster:get_dimension" />

返回施法位置所处的维度。
