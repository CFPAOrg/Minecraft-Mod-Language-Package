import csv
import yaml
import os
import github
import re


# 将二维数组写成 csv 文件，所以需要传入一个二维数组
def log_write(info_list=None):
    # 如果传入数据为空，虽然理论上不可能
    if info_list is None:
        info_list = [["TartaricAcid", "999999999"]]
    # 开始写入文件
    with open('../../logs/github/github.csv', 'w') as file:
        csv_writer = csv.writer(file)
        csv_writer.writerow(["User Name", "Push ID"])
        for line in info_list:
            csv_writer.writerow(line)


# csv 日志读取，不需要传入数据
# 但是会返回一个二维数组
def log_read():
    with open('../../logs/github/github.csv', 'r') as file:
        csv_list = list(csv.reader(file))
        csv_list.remove(csv_list[0])  # 裁切头文件
        return csv_list


# 获取 GitHub 的 access token
def access_token():
    # 是的，open 函数不能识别 linux 下的 ～ 符号！
    path_ = os.popen('echo $HOME').read().replace('\n', '')
    with open('{}/.ssh/token.yml'.format(path_), 'r') as f:
        config = yaml.load(f)
        token = config['token']
        print(token)
        return token


# 用来判定是否应当发送邮件的函数
# 传入 github 的用户名、事件 id
def should_email(user, event_id):
    # 首先读取日志中
    csv_list = log_read()
    for log_event in csv_list:
        if user in log_event and event_id <= log_event[1]:
            return False
    return True


# 配置文件读取用户名
# 返回值为 list
def get_user():
    with open('../../config.yml', 'r') as f:
        config = yaml.load(f)
        return config['github_user']


"""
信息抓取主体
返回一个 list（如下所示），描述探知的仓库名
[{
    'user': '3TUSK',
    'repos_name':[
        'Railcraft-Localization',
        'Forestry-Localization'
    ]
}],
[{
    'user': 'J-swl',
    'repos_name':[
        'thaumcraft-beta'
    ]
}]
"""


def github_info_get_main():
    info_list = []  # 总信息初始化
    info_id = []  # 用户名，事件 id 初始化
    token = access_token()  # token 获取
    # 遍历所有用户
    for user_name in get_user():
        repos_name_list = []  # 仓库信息初始化
        events_list = github.Github(token).get_user(user_name).get_events()  # 获取指定用户信息
        first_event_id = re.findall(r'id="(.*)"', str(events_list[0]))[0]  # 获取第一个 event id
        info_id.append([user_name, first_event_id])  # 装入 id 信息中
        for events in events_list:
            events_id = re.findall(r'id="(.*)"', str(events))[0]  # 先获取 id 吧
            # 判定是不是 push 事件，并且事件 id 大于先前数值
            if 'PushEvent' in str(events) and should_email(user_name, events_id):
                try:
                    # 找到 commit 信息
                    for commits_info in events.payload['commits']:
                        # 正则匹配 repos 名称
                        repos_name = \
                            re.findall(r'https://api.github.com/repos/.*?/(.*?)/commits/', commits_info['url'])[0]
                        # 如果名称不为空才装入
                        if len(repos_name) > 0:
                            repos_name_list.append(repos_name)
                except KeyError:
                    pass
        # 经典的冗余剔除方案
        repos_name_list = list(set(repos_name_list))
        # 用户信息生成
        user_info = {
            'user': user_name,
            'repos_name': repos_name_list
        }
        # 仓库信息不为空才装入
        if len(repos_name_list) > 0:
            info_list.append(user_info)
    log_write(info_id)  # 别忘了写入日志中
    return info_list


print(github_info_get_main())
