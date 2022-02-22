#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Mon Feb 21 14:52:55 2022

@author: kingbrooks
"""

data = "Hello Universe";
print(data[0]);
print(len(data));
print(data);

number = 123.4;
print(number);
number = 432.1;
print(number);

# Boolean
a = True
b = False
print(a, b)
# Multiple Assignment

c, d, e = 1, 2, 3

print(c, d, e)

# None Value
f = None
print(f)

# FLOW CONTROL
# IF STATEMENT
value = 201
if value == 99:
    print ("That Is Fast")
elif value > 200:
    print ("That Is Too Fast")
else:
    print ("That Is Safe")
    
# FOR LOOP
for i in range(10):
    print(i)     
    
# while loop
i=0
while i < 10:
    print (i)
    i += 1
    
# Sum Funciton
def mysum(x, y):
    return x + y

#test function
result = mysum(3, 3)
print(result)

#DATA STRUCTURES
#TUPLES
a = (1, 2, 3)
print(a)

#list
mylist = [1, 2, 3]
print("Zeroth Value: %d" % mylist[0]) 
mylist.append(4)
print("List Length: %d" % len(mylist))
for value in mylist:
    print(value)

#Dictionary
mydict = {'a': 1, 'b': 2, 'c': 3}
print("A Value: %d" % mydict['a'])
mydict['a'] = 11
print("A Value: %d" % mydict['a'])
print("Keys: %s" % mydict.keys())
print("values: %s" % mydict.values())
for key in mydict.keys():
    print (mydict[key])
























