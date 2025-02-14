---
id: interrupts
---
# 中断

中断可让PLC在外部事件出现时暂停当前工作。


```
%alias redstone = @(1 2 3 N)

ihanlder $redstone handler
iwait
restart

handler:
    rread $redstone
    say
    
    # Return to the saved position [1]
    ret
```
 [1] 返回保存的位置
