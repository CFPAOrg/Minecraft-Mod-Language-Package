# 开关面板

![咔哒咔哒。](item:computronics:oc_parts@13)

此面板可被装入服务器机架内。面板正前方有四个可点击的开关，开关可通过`switch_board`组件检查状态或激活。此外，当开关手动或自动改变状态时，面板会触发一个`switch_flipped`事件。

`switch_flipped`事件的格式如下所示。如果你不理解信号格式，可参考[这篇指南](http://ocdoc.cil.li/component:signals:zh)。

`switch_flipped(boardAddress:string, index:number, newState:boolean)`
