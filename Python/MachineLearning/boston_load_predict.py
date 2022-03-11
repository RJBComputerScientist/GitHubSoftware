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
import numpy as np

#load this model for predicitons
filename = 'final_boston.sav'
loaded_model = load(open(filename, 'rb'))

#define one new data instance for predictions
Xnew = [
    [0.01965, 80, 1.76, "0", 0.385, 6.23, 31.5, 9.0892, 
     1, 241, 18.2, 341.6, 12.93]
    ]
#convert data type of array to float64
Xnew = np.array(Xnew, dtype=np.float64)

#make a prediction
Ynew = loaded_model.predict(Xnew)
print("Input = %s, Predicted = %s" % (Xnew[0], Ynew[0]))

# 1 means yes & 0 means no
