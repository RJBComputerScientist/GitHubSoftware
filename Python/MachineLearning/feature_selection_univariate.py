#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from numpy import set_printoptions
from sklearn.feature_selection import SelectKBest
from sklearn.feature_selection import chi2
filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

# feature selection 
test = SelectKBest(score_func=chi2, k=4)
fit = test.fit(X, Y)

# print the scores for the features
set_printoptions(precision=3)
print(fit.scores_)

# print the first five rows of the best 4 features (Columns) Selected
features = fit.transform(X)
print(features[0:5,:])
#           ^^^^ from zero to five