```json
{
  "title": "声音",
  "icon": "minecraft:music_disc_5",
  "category": "trickster:tricks",
  "additional_search_terms": [
    "麦克风之辑流",
    "警笛之技巧",
    "消音耳罩之技巧"
  ]
}
```

*“常有人问：‘若森林中有一颗树倒下了，但倒下时周围没人，无人听见它倒下，那它还算发出了声音吗？’这个问题的答案不重要，重要的是如何获取这个声音。魔法没有耳朵，也没有其他感知声音的途径。它实际上会借用一个人类，利用他的感知能力。”*

——喝醉的巫师在凌晨两点解释声音（派对戏法，Party Trick）

;;;;;

<|trick@trickster:templates|trick-id=partytrick:get_sound|>

返回先前一段时间抵达所给玩家鼓膜的声音列表。输出每刻更新一次。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:play_sound,cost=2G|>

在给定位置播放声音，可选择指定音量、音调，以及可听见该声音的玩家。

;;;;;

<|ploy@trickster:templates|trick-id=partytrick:muffle_sound,cost=10G|>

改变对给定声音的音量的感知，未指定则改变所有声音的。所给数用作修正乘数。