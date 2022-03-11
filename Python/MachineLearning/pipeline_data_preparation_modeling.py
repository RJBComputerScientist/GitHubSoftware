#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from sklearn.model_selection import cross_val_score
from sklearn.model_selection import KFold
from sklearn.discriminant_analysis import LinearDiscriminantAnalysis
from sklearn.preprocessing import StandardScaler
from sklearn.pipeline import Pipeline

filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

# creating the pipline
estimators = []
estimators.append(('standardize', StandardScaler()))
estimators.append(('1ad', LinearDiscriminantAnalysis()))
model = Pipeline(estimators)

num_folds = 10
seed = 7

#kfold = KFold(n_splits=num_folds, random_state=seed)
#                 random_state is depreciated    
#ValueError: Setting a random_state has no effect since shuffle is False. 
#You should leave random_state to its default (None), or set shuffle=True.   
kfold = KFold(n_splits=num_folds)

results = cross_val_score(model, X, Y, cv=kfold)
print("Mean Estimated Accuracy Linear Discrimant With Pipeline: %f " % (results.mean()))