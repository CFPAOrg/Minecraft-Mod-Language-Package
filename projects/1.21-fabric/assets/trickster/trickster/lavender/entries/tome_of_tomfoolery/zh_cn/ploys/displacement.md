```json
{
  "title": "漂泊人",
  "icon": "minecraft:ender_pearl",
  "category": "trickster:ploys",
  "additional_search_terms": [
    "获权者之技巧",
    "篡夺者之技巧",
    "暴君之辑流",
    "维度之辑流",
    "位置之辑流"
  ]
}
```

*“他们会讲些小故事。*


*“他们说，它能穿墙，能让你凭空消失，不留一点痕迹。*


*“他们会跟自己的孩子讲这些。他们觉得这很有意思。他们不相信这是真的。*

;;;;;

*“但我遇到过一次。我说实话，这就是真的。你要是遇到了，你只会希望它不是真的。”*


——某位匿名受访者

---

;;;;;

<|ploy@trickster:templates|trick-id=trickster:prepare_displace,cost=120G + 1.35G^距离|>

以某实体为基础，创建暂时性的位移片段。此类片段只能在创建后维持五秒。

;;;;;

<|ploy@trickster:templates|trick-id=trickster:displace,cost=20G + 1.35G^偏移量 + 距离 * 3G|>

消耗一个位移片段，将对应实体传送至相对于施法者的给定位置。若该实体不是施法者自己，则附加一段延时。

;;;;;

几则注意事项：


位移的距离取受影响对象当前位置与施法者当前位置的间距，若两者不在同一维度，还会附加1000甘道夫的消耗。


每五秒内，以同一实体为基础，最多只可创建三个位移片段，且所有片段均会在使用一次后失效。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_displacements|>

给定实体，立即返回当前其可用位移片段的数量。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_position|>

给定位移片段，返回其对应实体的位置。

;;;;;

<|trick@trickster:templates|trick-id=trickster:get_dimension|>

返回位移片段起点所在的维度。

