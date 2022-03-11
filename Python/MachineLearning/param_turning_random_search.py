#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from sklearn.model_selection import RandomizedSearchCV
from sklearn.linear_model import Ridge
from scipy.stats import uniform

filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

#using numpy

param_distributions = {'alpha': uniform()}
model = Ridge()
rSearch = RandomizedSearchCV(estimator=model, param_distributions=param_distributions, cv=3, 
 n_iter=100)
rSearch.fit(X, Y)
print(rSearch.best_score_)
print(rSearch.best_estimator_.alpha)