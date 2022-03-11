#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import KFold
from sklearn.linear_model import Lasso
filename = 'BostonHousing.csv'
names = ['CRIM', 'ZN', 'INDUS', 'CHAS', 'NOX', 'RM', 'AGE', 'DIS', 'RAD', 'TAX',
         'PTRATIO', 'B', 'LSTAT', 'MEDV']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:13] 
Y = array[:, 13] 

seed = 7
test_size = 0.33

kfold = KFold(n_splits=10)
model = Lasso()
scoring = 'neg_mean_squared_error'

results = cross_val_score(model, X, Y, cv=kfold, scoring=scoring)

print("Mean Squared Error Lasso: %f" % (results.mean()))