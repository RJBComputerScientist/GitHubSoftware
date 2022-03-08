#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

from pandas import read_csv
from sklearn.feature_selection import RFE
from sklearn.linear_model import LogisticRegression
filename = 'pima-indians-diabetes.csv'
names = ['preg', 'plas', 'pres', 'skin', 'test', 'mass', 'pedi', 'age', 'class']
dataframe = read_csv(filename, names=names)

array = dataframe.values

# splitting the array to input to output
X = array[:, 0:8] 
Y = array[:, 8] 

#RFE feature using logistic regression
model = LogisticRegression(solver="liblinear")
rfe = RFE(model, 3)
fit = rfe.fit(X, Y)

print("Number Of Features: %d" % fit.n_features_)
print("Selected Features: %s" % fit.support_)
print("Features Ranking: %s" % fit.ranking_)