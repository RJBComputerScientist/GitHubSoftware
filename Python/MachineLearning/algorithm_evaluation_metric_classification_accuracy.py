#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import KFold
from sklearn.linear_model import LogisticRegression
filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

n_splits = 10
seed = 7

kfold = KFold(n_splits=n_splits)
model = LogisticRegression(solver="liblinear")
scoring = 'accuracy'

results = cross_val_score(model, X, Y, cv=kfold, scoring=scoring)
print("Accuracy: %.3f%% (%.3f%%) " % (results.mean()*100.0, results.std()*100.0))