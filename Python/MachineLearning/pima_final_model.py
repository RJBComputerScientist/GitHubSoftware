#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv

from sklearn.linear_model import LogisticRegression
from sklearn.model_selection import train_test_split
#from sklearn.externals.joblib import dump
#from sklearn.externals.joblib import load
#^^^since scikit-learn version 0.23, the package joblib is deprecated from sklearn, 
#^^^you can just import joblib individually.
from pickle import dump

filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

#kfold = KFold(n_splits=num_folds, random_state=seed)
#                 random_state is depreciated    
#ValueError: Setting a random_state has no effect since shuffle is False. 
#You should leave random_state to its default (None), or set shuffle=True.
#######     TESTING GOES HERE START       #######   
#test_size  = 0.33
#X_train, X_test, Y_train, Y_test = train_test_split(X, Y, test_size=test_size)
#num_folds = 10
#seed = 7
#######     TESTING GOES HERE END       #######   
model = LogisticRegression(solver="liblinear")
model.fit(X, Y)

#save this model to disk for reuse
filename = 'final_pima_indian.sav'
dump(model, open(filename, 'wb'))
