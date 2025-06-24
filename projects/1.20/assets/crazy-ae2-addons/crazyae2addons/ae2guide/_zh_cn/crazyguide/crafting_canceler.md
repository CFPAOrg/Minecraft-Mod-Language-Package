---
navigation:
  parent: crazyae2addons_index.md
  title: 合成取消器
  icon: crazyae2addons:crafting_canceler
categories:
  - Monitoring and Automation
item_ids:
  - crazyae2addons:crafting_canceler
---

# 合成取消器

<BlockImage id="crazyae2addons:crafting_canceler" scale="4"></BlockImage>

合成取消器可辅助你监控ME网络中停滞的合成任务。如果某配方在超出给定时限后仍无进展，取消器会将其取消并立即重启，无需手动修复也可让自动合成系统流畅运转。

将设备连接至网络并右击打开其界面。界面中有一个开关，用于控制取消器启用与否；还有一个输入字段，用于配置最长停滞时限（15秒至360秒）。点击“保存”/“Save”可应用配置。

设备启用时会检查网络中正在进行的合成任务。如果某个任务在超过时限后没有变化，则取消器会取消该任务并立即重新规划之。
