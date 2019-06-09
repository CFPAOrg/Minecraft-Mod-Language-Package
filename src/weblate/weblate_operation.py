import wlc

from src.baka_init import *


def main():
    # 首先登录 weblate
    weblate = wlc.Weblate(key=WEBLATE_TOKEN, url='https://weblate.exz.me/api')

    # pull、commit、push 一气呵成
    weblate.post('/projects/langpack/repository/', operation='pull')
    logging.info('Weblate all pull!')
    weblate.post('/projects/langpack/repository/', operation='commit')
    logging.info('Weblate all commit!')
    weblate.post('/projects/langpack/repository/', operation='push')
    logging.info('Weblate all push!')


if __name__ == '__main__':
    main()
