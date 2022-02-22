#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Mon Feb 21 20:08:21 2022

@author: kingbrooks
"""

# Define An NumPy Array
import numpy
mylist = [1, 2, 3]
# converting this array^^ to numpy array
myarray = numpy.array(mylist)
print(myarray)
print(myarray.shape)

mylist = [[1, 2, 3], [3, 4, 5]]
myarray = numpy.array(mylist)
print(myarray)
print(myarray.shape)
#contents of numpy array
print("First Row: %s" % myarray[0])
print("Last Row: %s" % myarray[-1])
# A specific value
print("specific row and col: %s" % myarray[0, 2])
# the whole column
print("whole column: %s" % myarray[:, 2]) 