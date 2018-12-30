import copy
import logging


# 切片函数，传入等待切片的 list 和切片数量
# 返回切片好的 list
def list_slice(list_slice_list_in, list_slice_num):
    logging.info("开始进行模组列表切片……")

    list_slice_count = 1  # 计数器
    list_slice_list_out = []  # 放置所有切片好的 list
    list_slice_sublist_out = []  # 切片

    # 循环遍历装填满切片
    for list_slice_i in list_slice_list_in:
        # 判定是否达到切片值上限
        if list_slice_count > list_slice_num:
            # 如果达到，就放置切片（list 需要深拷贝）
            list_slice_list_out.append(copy.deepcopy(list_slice_sublist_out))
            # 计数器清空
            list_slice_count = 1
            # 切片清空
            list_slice_sublist_out.clear()
        else:
            # 否则，往切片中放置数据（此时放置的是字符串，不需要深拷贝）
            list_slice_sublist_out.append(list_slice_i)
            # 计数器自加
            list_slice_count = list_slice_count + 1

    # 尾部未满切片装填
    if len(list_slice_sublist_out) > 0:
        list_slice_list_out.append(copy.deepcopy(list_slice_sublist_out))

    # 返回装填好的切片 list
    logging.info("模组切片已完成")
    return list_slice_list_out
