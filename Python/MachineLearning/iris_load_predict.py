#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Created on Fri Feb 25 16:42:07 2022

@author: kingbrooks
"""

#from sklearn.externals.joblib import dump
#from sklearn.externals.joblib import load
#^^^since scikit-learn version 0.23, the package joblib is deprecated from sklearn, 
#^^^you can just import joblib individually.
from pickle import load

#load this model for predicitons
filename = 'iris.sav'
loaded_model = load(open(filename, 'rb'))

#define one new data instance for predictions
Xnew = [[6.2, 3.1, 5.2, 2.4]]

#make a prediction
Ynew = loaded_model.predict(Xnew)
Ynew_prob = loaded_model.predict(Xnew)
print("Input = %s, Predicted = %s" % (Xnew[0], Ynew[0]))

# 1 means yes & 0 means no
