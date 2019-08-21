import csv
import struct


opdata = """00,nop,,perform no operation
01,aconst_null,,push a null reference onto the stack
02,iconst_m1,,load the int value -1 onto the stack
03,iconst_0,,load the int value 0 onto the stack
04,iconst_1,,load the int value 1 onto the stack
05,iconst_2,,load the int value 2 onto the stack
06,iconst_3,,load the int value 3 onto the stack
07,iconst_4,,load the int value 4 onto the stack
08,iconst_5,,load the int value 5 onto the stack
09,lconst_0,,push the long 0 onto the stack
0a,lconst_1,,push the long 1 onto the stack
0b,fconst_0,,push 0.0f on the stack
0c,fconst_1,,push 1.0f on the stack
0d,fconst_2,,push 2.0f on the stack
0e,dconst_0,,push the constant 0.0 onto the stack
0f,dconst_1,,push the constant 1.0 onto the stack
10,bipush,1,push a byte onto the stack as an integer value
11,sipush,2,push a short onto the stack
12,ldc,1,"push a constant #index from a constant pool (String, int or float) onto the stack"
13,ldc_w,2,"push a constant #index from a constant pool (String, int or float) onto the stack (wide index is constructed as indexbyte1 << 8 + indexbyte2)"
14,ldc2_w,2,push a constant #index from a constant pool (double or long) onto the stack (wide index is constructed asindexbyte1 << 8 + indexbyte2)
15,iload,1,load an int value from a local variable #index
16,lload,1,load a long value from a local variable #index
17,fload,1,load a float value from a local variable #index
18,dload,1,load a double value from a local variable #index
19,aload,1,load a reference onto the stack from a local variable#index
1a,iload_0,,load an int value from local variable 0
1b,iload_1,,load an int value from local variable 1
1c,iload_2,,load an int value from local variable 2
1d,iload_3,,load an int value from local variable 3
1e,lload_0,,load a long value from a local variable 0
1f,lload_1,,load a long value from a local variable 1
20,lload_2,,load a long value from a local variable 2
21,lload_3,,load a long value from a local variable 3
22,fload_0,,load a float value from local variable 0
23,fload_1,,load a float value from local variable 1
24,fload_2,,load a float value from local variable 2
25,fload_3,,load a float value from local variable 3
26,dload_0,,load a double from local variable 0
27,dload_1,,load a double from local variable 1
28,dload_2,,load a double from local variable 2
29,dload_3,,load a double from local variable 3
2a,aload_0,,load a reference onto the stack from local variable 0
2b,aload_1,,load a reference onto the stack from local variable 1
2c,aload_2,,load a reference onto the stack from local variable 2
2d,aload_3,,load a reference onto the stack from local variable 3
2e,iaload,,load an int from an array
2f,laload,,load a long from an array
30,faload,,load a float from an array
31,daload,,load a double from an array
32,aaload,,load onto the stack a reference from an array
33,baload,,load a byte or Boolean value from an array
34,caload,,load a char from an array
35,saload,,load short from array
36,istore,1,store int value into variable #index
37,lstore,1,store a long value in a local variable #index
38,fstore,1,store a float value into a local variable #index
39,dstore,1,store a double value into a local variable #index
3a,astore,1,store a reference into a local variable #index
3b,istore_0,,store int value into variable 0
3c,istore_1,,store int value into variable 1
3d,istore_2,,store int value into variable 2
3e,istore_3,,store int value into variable 3
3f,lstore_0,,store a long value in a local variable 0
40,lstore_1,,store a long value in a local variable 1
41,lstore_2,,store a long value in a local variable 2
42,lstore_3,,store a long value in a local variable 3
43,fstore_0,,store a float value into local variable 0
44,fstore_1,,store a float value into local variable 1
45,fstore_2,,store a float value into local variable 2
46,fstore_3,,store a float value into local variable 3
47,dstore_0,,store a double into local variable 0
48,dstore_1,,store a double into local variable 1
49,dstore_2,,store a double into local variable 2
4a,dstore_3,,store a double into local variable 3
4b,astore_0,,store a reference into local variable 0
4c,astore_1,,store a reference into local variable 1
4d,astore_2,,store a reference into local variable 2
4e,astore_3,,store a reference into local variable 3
4f,iastore,,store an int into an array
50,lastore,,store a long to an array
51,fastore,,store a float in an array
52,dastore,,store a double into an array
53,aastore,,store into a reference in an array
54,bastore,,store a byte or Boolean value into an array
55,castore,,store a char into an array
56,sastore,,store short to array
57,pop,,discard the top value on the stack
58,pop2,,"discard the top two values on the stack (or one value, if it is a double or long)"
59,dup,,duplicate the value on top of the stack
5a,dup_x1,,insert a copy of the top value into the stack two values from the top. value1 and value2 must not be of the type double or long.
5b,dup_x2,,"insert a copy of the top value into the stack two (if value2 is double or long it takes up the entry of value3, too) or three values (if value2 is neither double nor long) from the top"
5c,dup2,,"duplicate top two stack words (two values, if value1 is not double nor long; a single value, if value1 is double or long)"
5d,dup2_x1,,duplicate two words and insert beneath third word (see explanation above)
5e,dup2_x2,,duplicate two words and insert beneath fourth word
5f,swap,,swaps two top words on the stack (note that value1 and value2 must not be double or long)
60,iadd,,add two ints
61,ladd,,add two longs
62,fadd,,add two floats
63,dadd,,add two doubles
64,isub,,int subtract
65,lsub,,subtract two longs
66,fsub,,subtract two floats
67,dsub,,subtract a double from another
68,imul,,multiply two integers
69,lmul,,multiply two longs
6a,fmul,,multiply two floats
6b,dmul,,multiply two doubles
6c,idiv,,divide two integers
6d,ldiv,,divide two longs
6e,fdiv,,divide two floats
6f,ddiv,,divide two doubles
70,irem,,logical int remainder
71,lrem,,remainder of division of two longs
72,frem,,get the remainder from a division between two floats
73,drem,,get the remainder from a division between two doubles
74,ineg,,negate int
75,lneg,,negate a long
76,fneg,,negate a float
77,dneg,,negate a double
78,ishl,,int shift left
79,lshl,,bitwise shift left of a long value1 by int value2positions
7a,ishr,,int arithmetic shift right
7b,lshr,,bitwise shift right of a long value1 by int value2positions
7c,iushr,,int logical shift right
7d,lushr,,"bitwise shift right of a long value1 by int value2positions, unsigned"
7e,iand,,perform a bitwise and on two integers
7f,land,,bitwise and of two longs
80,ior,,bitwise int or
81,lor,,bitwise or of two longs
82,ixor,,int xor
83,lxor,,bitwise exclusive or of two longs
84,iinc,2,increment local variable #index by signed byte const
85,i2l,,convert an int into a long
86,i2f,,convert an int into a float
87,i2d,,convert an int into a double
88,l2i,,convert a long to a int
89,l2f,,convert a long to a float
8a,l2d,,convert a long to a double
8b,f2i,,convert a float to an int
8c,f2l,,convert a float to a long
8d,f2d,,convert a float to a double
8e,d2i,,convert a double to an int
8f,d2l,,convert a double to a long
90,d2f,,convert a double to a float
91,i2b,,convert an int into a byte
92,i2c,,convert an int into a character
93,i2s,,convert an int into a short
94,lcmp,,compare two longs values
95,fcmpl,,compare two floats
96,fcmpg,,compare two floats
97,dcmpl,,compare two doubles
98,dcmpg,,compare two doubles
99,ifeq,2,"if value is 0, branch to instruction at branchoffset(signed short constructed from unsigned bytesbranchbyte1 << 8 + branchbyte2)"
9a,ifne,2,"if value is not 0, branch to instruction at branchoffset(signed short constructed from unsigned bytesbranchbyte1 << 8 + branchbyte2)"
9b,iflt,2,"if value is less than 0, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
9c,ifge,2,"if value is greater than or equal to 0, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
9d,ifgt,2,"if value is greater than 0, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
9e,ifle,2,"if value is less than or equal to 0, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
9f,if_icmpeq,2,"if ints are equal, branch to instruction at branchoffset(signed short constructed from unsigned bytesbranchbyte1 << 8 + branchbyte2)"
a0,if_icmpne,2,"if ints are not equal, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a1,if_icmplt,2,"if value1 is less than value2, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a2,if_icmpge,2,"if value1 is greater than or equal to value2, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a3,if_icmpgt,2,"if value1 is greater than value2, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a4,if_icmple,2,"if value1 is less than or equal to value2, branch to instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a5,if_acmpeq,2,"if references are equal, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a6,if_acmpne,2,"if references are not equal, branch to instruction atbranchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)"
a7,goto,2,goes to another instruction at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2)
a8,jsr,2,jump to subroutine at branchoffset (signed short constructed from unsigned bytes branchbyte1 << 8 + branchbyte2) and place the return address on the stack
a9,ret,1,continue execution from address taken from a local variable #index (the asymmetry with jsr is intentional)
aa,tableswitch,-1,continue execution from an address in the table at offset index
ab,lookupswitch,-1,a target address is looked up from a table using a key and execution continues from the instruction at that address
ac,ireturn,,return an integer from a method
ad,lreturn,,return a long value
ae,freturn,,return a float
af,dreturn,,return a double from a method
b0,areturn,,return a reference from a method
b1,return,,return void from method
b2,getstatic,2,"get a static field value of a class, where the field is identified by field reference in the constant pool index(index1 << 8 + index2)"
b3,putstatic,2,"set static field to value in a class, where the field is identified by a field reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
b4,getfield,2,"get a field value of an object objectref, where the field is identified by field reference in the constant poolindex (index1 << 8 + index2)"
b5,putfield,2,"set field to value in an object objectref, where the field is identified by a field reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
b6,invokevirtual,2,"invoke virtual method on object objectref, where the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
b7,invokespecial,2,"invoke instance method on object objectref, where the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
b8,invokestatic,2,"invoke a static method, where the method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
b9,invokeinterface,4,"invokes an interface method on object objectref, where the interface method is identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
ba,invokedynamic,4,invokes a dynamic method identified by method reference index in constant pool (indexbyte1 << 8 + indexbyte2)
bb,new,2,create new object of type identified by class reference in constant pool index (indexbyte1 << 8 + indexbyte2)
bc,newarray,1,create new array with count elements of primitive type identified by atype
bd,anewarray,2,create a new array of references of length count and component type identified by the class reference index(indexbyte1 << 8 + indexbyte2) in the constant pool
be,arraylength,,get the length of an array
bf,athrow,,"throws an error or exception (notice that the rest of the stack is cleared, leaving only a reference to the Throwable)"
c0,checkcast,2,"checks whether an objectref is of a certain type, the class reference of which is in the constant pool atindex (indexbyte1 << 8 + indexbyte2)"
c1,instanceof,2,"determines if an object objectref is of a given type, identified by class reference index in constant pool (indexbyte1 << 8 + indexbyte2)"
c2,monitorenter,,"enter monitor for object (""grab the lock"" - start of synchronized() section)"
c3,monitorexit,,"exit monitor for object (""release the lock"" - end of synchronized() section)"
c4,wide,-1,"execute opcode, where opcode is either iload, fload, aload, lload, dload, istore, fstore, astore, lstore, dstore, or ret, but assume the index is 16 bit; or execute iinc, where the index is 16 bits and the constant to increment by is a signed 16 bit short"
c5,multianewarray,3,"create a new array of dimensions dimensions with elements of type identified by class reference in constant pool index (indexbyte1 << 8 + indexbyte2); the sizes of each dimension is identified by count1, [count2, etc.]"
c6,ifnull,2,"if value is null, branch to instruction at branchoffset(signed short constructed from unsigned bytesbranchbyte1 << 8 + branchbyte2)"
c7,ifnonnull,2,"if value is not null, branch to instruction at branchoffset(signed short constructed from unsigned bytesbranchbyte1 << 8 + branchbyte2)"
c8,goto_w,4,goes to another instruction at branchoffset (signed int constructed from unsigned bytes branchbyte1 << 24 +branchbyte2 << 16 + branchbyte3 << 8 + branchbyte4)
c9,jsr_w,4,jump to subroutine at branchoffset (signed int constructed from unsigned bytes branchbyte1 << 24 + branchbyte2 << 16 + branchbyte3 << 8 + branchbyte4) and place the return address on the stack
ca,breakpoint,,reserved for breakpoints in Java debuggers; should not appear in any class file
fe,impdep1,,reserved for implementation-dependent operations within debuggers; should not appear in any class file
ff,impdep2,,reserved for implementation-dependent operations within debuggers; should not appear in any class file)"""

opcodes = {int('0x' + hcode, 0): {"name": name, "params": int(params) if params else 0, "desc": desc} for hcode, name, params, desc in csv.reader(opdata.split('\n'))}


def decode(ba):
    out = []
    bs = enumerate(ba)
    while True:
        try:
            i, b = next(bs)
        except StopIteration:
            break
        opc = opcodes[b]
        if opc['params'] == 0:
            out.append(opc['name'])
        elif opc['params'] > 0:
            att = [next(bs)[1] for _ in range(opc['params'])]
            out.append([opc['name'], att])
        elif opc['params'] < 0:
            if b == 170:
                padd = [next(bs)[1] for _ in range(i % 4)]
                default = struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0]
                low = struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0]
                high = struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0]
                offsets = [bs.next()[1] for _ in range(high - low + 1)]
                out.append([opc['name'], padd + [default, low, high] + offsets])
            elif b == 171:
                padd = [next(bs)[1] for _ in range(i % 4)]
                default = struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0]
                npairs = struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0]
                match_offsets = [struct.unpack('>l', bytes([next(bs)[1] for _ in range(4)]))[0] for _ in range(npairs * 2)]
                out.append([opc['name'], padd + [default, npairs] + match_offsets])
            elif b == 196:
                op1 = next(bs)
                if op1 == 84:
                    att = [next(bs)[0] for _ in range(4)]
                else:
                    att = [next(bs)[0] for _ in range(2)]
                out.append([opc['name'], [op1] + att])
            else:
                raise Exception('cannot decode bytecode %s %s' % (b, opc))
        else:
            raise Exception('cannot decode bytecode')

    return out

if __name__ == '__main__':
    print(opcodes)
