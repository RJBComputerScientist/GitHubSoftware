#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 15:13:12 2022

@author: kingbrooks
"""

#basic line plot
import matplotlib.pyplot as plt
import numpy

myarray = numpy.array([1, 2, 3])
plt.plot(myarray)
plt.xlabel('x axis')
plt.ylabel('y axis')
plt.show()

#scatter plot
myarray1 = numpy.array([1, 2, 3])
myarray2 = numpy.array([1, 2, 3])
plt.scatter(myarray1, myarray2)
plt.xlabel('x axis')
plt.ylabel('y axis')
plt.show()