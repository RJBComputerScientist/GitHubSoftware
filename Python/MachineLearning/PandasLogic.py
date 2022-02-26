#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 15:22:17 2022

@author: kingbrooks
"""

# series
import numpy
import pandas

myarray1 = numpy.array([1, 2, 3])
rownames = ['a', 'b', 'c']
myseries = pandas.Series(myarray1, index=rownames)
print(myseries)

print(myseries[0])
print(myseries['a'])

#Data Frame
myarray2 = numpy.array([[1, 2, 3], [4, 5, 6]])
rownames2 = ['a', 'b']
colnames2 = ['one', 'two', 'three']
mydataframe = pandas.DataFrame(myarray2, index=rownames2, columns=colnames2)
print(mydataframe)

print("method 1: printing column one %s" % mydataframe['one'])
print("method 2: printing column one %s" % mydataframe.one)
