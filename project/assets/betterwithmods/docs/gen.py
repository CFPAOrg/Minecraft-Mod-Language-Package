import os

lang={}
dic=[('Gearbox','变速箱'),
        ('Millstone','磨石'),
        ('Wind Chime','风铃'),
        ('Decorative Blocks','装饰方块'),
        ('Handcrank','手推曲柄'),
        ('Lens','镜头聚焦器'),
        ('Minimized Wood','切割木料'),
        ('Tables','木桌'),
        ('Benches','木凳'),
        ('wood','木'),
        ('Block Detector','探测器')]

lang_en=open('../lang/en_us.lang')
lang_cn=open('../lang/zh_cn.lang')
for line in lang_en:
    line=line.strip()
    pair=line.split('=')
    if len(pair)!=2:
        continue
    lang[pair[0]]=pair[1]
lang_en.close()
for line in lang_cn:
    line=line.strip()
    pair=line.split('=')
    if len(pair)!=2:
        continue
    en=lang[pair[0]]
    cn=pair[1]
    flag=True
    for i in range(len(dic)):
        if dic[i][0] in en:
            dic.insert(i,(en,cn))
            flag=False
            break
    if flag:
        dic.append((en,cn))

lang={}
lang_cn.close()
#print(dic['Bellows'])
l=os.listdir(os.path.join('zh_cn_raw','blocks'))
for filename in l:
    filepath=os.path.join('zh_cn_raw','blocks',filename)
    f=open(filepath)
    inputstr=''
    for line in f:
        if line.startswith(';'):
            continue
        inputstr+=line
    f.close()
    #key='Bellows'
    #print(inputstr.replace(key,dic[key]))
    for pair in dic:
#        #print((pair))
        inputstr=inputstr.replace(pair[0],pair[1])
    #print(inputstr)
    f=open(filepath.replace('zh_cn_raw','zh_cn'),'w')
    f.write(inputstr)
    f.close()
