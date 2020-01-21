from .config import del_key

def process_string(ps_str_in):
    "返回剔除 \\n, \\r 和空格的字符串"
    return ps_str_in.replace('\n', '').replace('\r', '').replace('\u0020', '')

def is_properties_language_file(path):
    with open(path, "r", encoding="utf-8", errors="replace") as f:
        for i in f.readlines():
            if "#PARSE_ESCAPES" in i:
                return True
        return False

def language_file_delete_and_fix(path):
    l = []
    with open(path, "r", encoding="utf-8", errors="replace") as f:
        for i in f.readlines():
            if all([
                    (i is not None),
                    (not i.startswith('#')),
                    ('=' in i)
                ]):
                il = i.split('=', 1)
                if il[0] in del_key or process_string(il[1]) == '':
                    print(f'删除了不符合的空行或黑名单键：["{il[0]}"]')
                    continue
            elif all([
                    (i is not None),
                    (not i.startswith('#')),
                    (process_string(i) != '')
                ]):
                i = '# ' + i
                i = i.replace("\n", "\\n").replace("\r", "\\r")
                print(f'处理了不规范注释：["{i}"]')

            l.append(i)

    with open(path, "w", encoding="utf-8", errors="replace") as f:
        for i in l:
            f.writelines(i)

