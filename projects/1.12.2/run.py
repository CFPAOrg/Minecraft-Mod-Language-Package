import os

def get_name(path, list):
    if os.path.isdir(path):
        for file in os.listdir(path):
            get_name(path+"/"+file, list)
    elif path.endswith("en_US.lang"):
        list.append(path)


if __name__ == "__main__":
    l = []
    get_name("./", l)
    print(l)
    for f in l:
        os.rename(f, f.replace("en_US.lang", "en_us.lang"))
