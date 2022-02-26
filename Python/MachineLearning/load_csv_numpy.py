#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:29:45 2022

@author: kingbrooks
"""

# Load CSV File With Numpy 
from numpy import loadtxt
filename = 'pima-indians-diabetes.csv'
raw_data = open(filename, 'rb')
data = loadtxt(raw_data, delimiter=",")
print(data.shape)
