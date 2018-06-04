import os
import yaml


# 定义一个能够初始化的函数，检验 list 数据
# config_var：传入的配置文件参数
# top_var：配置文件上限
def list_config_init(config_var):
    # 判定是不是 list
    if str(type(config_var)) != '<class \'list\'>':
        config_var = ['baka943']
    # list 是不是为空
    elif len(config_var) == 0:
        config_var = ['baka943']
    # list 里面每个元素是不是都是 str
    else:
        for i in range(len(config_var)):
            if str(type(config_var[i])) != '<class \'str\'>':
                config_var[i] = 'baka943'
    return config_var


# 开始检索 del list 删除
# 读取配置文件
with open('config.yml', 'r') as f:
    config = yaml.load(f)
    DEL_LIST = list_config_init(config['del_list'])

# 开始强制删除对应文件夹
for i in DEL_LIST:
    os.system('rm -rf ./project/assets/' + i)
