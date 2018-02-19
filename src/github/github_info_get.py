import urllib.request
import urllib.error
import json


# 一个拥有全面功能的下载函数
def download(url, user_agent='baka943', num_retries=2):
    print('下载链接：' + url)
    headers = {'User-agent': user_agent}
    request = urllib.request.Request(url, headers=headers)
    try:
        html = urllib.request.urlopen(request).read()
    except urllib.error.URLError as e:
        print('错误：' + e.reason)
        html = None
        if num_retries > 0:
            if hasattr(e, 'code') and 500 <= e.code < 600:
                return download(url, user_agent, num_retries - 1)
    return html


USER = '3TUSK'
event = download('https://api.github.com/users/{}/events'.format(USER)).decode('utf-8')
event_json = json.loads(event)

for i in event_json:
    if i['type'] == 'PushEvent':
        for n in i['payload']['commits']:
            commit = download(n['url']).decode('utf-8')
            commit_json = json.loads(commit)
            for j in commit_json['files']:
                if 'zh_CN.lang' in j['filename'] or 'zh_cn.lang' in j['filename']:
                    print(j['filename'])
