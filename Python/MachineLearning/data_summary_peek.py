#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
data = read_csv(filename, names=names)
# print quick preview of rows
peek = data.head(20)
print(peek)