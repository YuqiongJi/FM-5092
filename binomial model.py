# -*- coding: utf-8 -*-
"""
Created on Fri Oct 11 16:55:15 2019

@author: Yuqiong Ji
"""
#The binomial model (CRR model)

#S: Underlying price ;
#K: Strike price;
#sigma: Volatility of underlying asset;
#r: Risk free rate;
#T: Tenor,time to maturity;
#N:Number of steps;
#q:Dividend;
#side:call or put;
#style:European or American;

import numpy as np

delta=0
theta=0
gamma=0

def binomalmodel (S,K,r,sigma,T,N,q,side,style):
    t=T/N
    u=np.exp(sigma*np.sqrt(t))
    d=1/u
    p=(np.exp((r-q)*t)-d)/(u-d)
    
    # build underlying  tree---stock value
    stockvalue = np.zeros((N+1,N+1))
    stockvalue[0,0]=S
    for i in range(1,N+1):
        for j in range(0,i+1):
            stockvalue[j,i] = S*(u**(i-j))*(d**j)

    #option value at final node
    optionvalue = np.zeros((N+1,N+1))
    for j in range(0,N+1):
        if side =="Call": 
            optionvalue[j,N] = np.maximum(0, stockvalue[j,N]-K)
        elif side =="Put": 
            optionvalue[j,N] = np.maximum(0, K-stockvalue[j,N])
     
    # build option value tree
    for i in range(N-1,-1,-1):
        for j in range(N-1, i-1, -1):
            if style =="European":
                optionvalue[i,j] = np.exp(-r*t)*(p*optionvalue[i,j+1]+(1-p)*optionvalue[i+1,j+1])            
            elif style =="American":
                if side =="Call":
                    optionvalue[i,j] = np.maximum(stockvalue[i,j]-K, np.exp(-r*t)*(p*optionvalue[i,j+1]+(1-p)*optionvalue[i+1,j+1]))
                elif side=="Put":
                    optionvalue[i,j] = np.maximum(K-stockvalue[i,j], np.exp(-r*t)*(p*optionvalue[i,j+1]+(1-p)*optionvalue[i+1,j+1])) 
    #Greek values
    #calculate Delta
    global delta
    delta = (optionvalue[0,1]-optionvalue[1,1])/(stockvalue[0,1] - stockvalue[1,1])  
    #calculte gamma
    global gamma
    gamma = (((optionvalue[0,2]-optionvalue[1,2])/(stockvalue[0,2] - stockvalue[1,2]))-((optionvalue[1,2]-optionvalue[2,2])/(stockvalue[1,2] - stockvalue[2,2])))/(0.5*(stockvalue[0,2] - stockvalue[2,2]))
    #calculte Theta
    global theta
    theta = (optionvalue[1,2]-optionvalue[0,0])/(2*t)

    
    return optionvalue[0,0]
  
#calculte vega
def vega(S,K,r,sigma,T,N,q,side,style):
       vega_value = (binomalmodel(S,K,r,sigma+0.00001,T,N,q,side,style)-binomalmodel(S,K,r,sigma-0.00001,T,N,q,side,style))/0.00002 
       return vega_value 

#calculate Rho
def rho(S,K,r,sigma,T,N,q,side,style):
       rho_value = (binomalmodel(S,K,r+0.00001,sigma,T,N,q,side,style)-binomalmodel(S,K,r-0.00001,sigma,T,N,q,side,style))/0.00002
       return rho_value 

#output values
def output(S,K,r,sigma,T,N,q,side,style):    
    print('optionprice=',binomalmodel (S,K,r,sigma,T,N,q,side,style),'\ndelta=',delta,'\ngamma=',gamma,'\ntheta=',theta)    
    print('vega=',vega(S,K,r,sigma,T,N,q,side,style),'\nrho=',rho(S,K,r,sigma,T,N,q,side,style))

#test
output(100,105,0.06,0.2,1,100,0.05,'Call','American')
output(100,105,0.06,0.2,1,100,0.05,'Call','European')

    
   
    