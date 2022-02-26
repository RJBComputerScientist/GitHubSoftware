#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:05:22 2022

@author: kingbrooks
"""

# Load CSV using standard python library
import csv
import numpy

#                   NOTES
# With the open function for the second arguement ...
#'r' means Read-Only
#'b' means Binary
#'t' means Text

filename = 'pima-indians-diabetes.csv'
raw_data = open(filename, 'rt')
reader = csv.reader(raw_data, delimiter=',', quoting=csv.QUOTE_NONE)
x = list(reader)
# converting list to python list
data = numpy.array(x).astype('float')
# converting python list to numpy array with type float
print(data.shape)
# printing shape of float