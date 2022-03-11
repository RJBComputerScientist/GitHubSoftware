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
from sklearn.tree import DecisionTreeClassifier
from sklearn.svm import SVC
from sklearn.ensemble import VotingClassifier

filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

# creating the pipline
estimators = []
model1 = LogisticRegression(solver='liblinear')
estimators.append(('logistic', model1))
model2 = DecisionTreeClassifier()
estimators.append(('CART', model2))
model3 = SVC()
estimators.append(('svm', model3))

num_folds = 10
seed = 7

#kfold = KFold(n_splits=num_folds, random_state=seed)
#                 random_state is depreciated    
#ValueError: Setting a random_state has no effect since shuffle is False. 
#You should leave random_state to its default (None), or set shuffle=True.   
kfold = KFold(n_splits=num_folds)
ensemble = VotingClassifier(estimators)

results = cross_val_score(ensemble, X, Y, cv=kfold)
print((results.mean()))