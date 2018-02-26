import wlc
import os
import yaml


# 获取 Weblate 的 access key
def access_token():
    # 是的，open 函数不能识别 linux 下的 ～ 符号！
    path_ = os.popen('echo $HOME').read().replace('\n', '')
    with open('{}/.ssh/token.yml'.format(path_), 'r') as f:
        config = yaml.load(f)
        weblate_key = config['weblate_key']
        return weblate_key


def weblate_operation():
    # 首先登录 weblate
    weblate_key = access_token()  # 获取 access key
    weblate = wlc.Weblate(key=weblate_key, url='https://weblate.exz.me/api')

    # pull、commit、push 一气呵成
    pull = weblate.post('/projects/langpack/repository/', operation='pull')
    print('Weblate all pull!')
    commit = weblate.post('/projects/langpack/repository/', operation='commit')
    print('Weblate all commit!')
    push = weblate.post('/projects/langpack/repository/', operation='push')
    print('Weblate all push!')

    # 接下来返回操作情况
    if pull['result'] and commit['result'] and push['result']:
        return True
    else:
        return False
