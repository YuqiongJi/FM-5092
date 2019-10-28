
#Calculate implied volatility
import numpy as np
from scipy.stats import norm

d1 = lambda S, K, r, T, vol: (np.log(S/K) + (r + 0.5*vol**2)*T)/(vol*np.sqrt(T))
d2 = lambda S, K, r, T, vol: (np.log(S/K) + (r - 0.5*vol**2)*T)/(vol*np.sqrt(T))
call= lambda S, K, r, T, vol: S*norm.cdf(d1(S, K, r, T, vol)) - K*np.exp(-r*T)*norm.cdf(d2(S, K, r, T, vol)) 
put= lambda S, K, r, T, vol: K*np.exp(-r*T)*norm.cdf(-d2(S, K, r, T, vol)) - S*norm.cdf(-d1(S, K, r, T, vol)) 
vega = lambda S, K, r, T, vol: S*np.sqrt(T)*norm.pdf(d1(S, K, r, T, vol)) 

#bisection method
def bisection_method(S,K,r,T,type,marketprice):
    #set precision and maxsteps 
    size = len(S)
    precision=0.00000001
    maxsteps=1000    
    # set lower and upper bounds  
    lowervol=0.00001 *np.ones(size)
    uppervol=3* np.ones(size)
    m=(lowervol+uppervol)/2
    count = np.zeros(size)
    
    if type == 'call':
        while all(count<=maxsteps) and any((np.abs(call(S,K,r,T,m)-marketprice)) >= precision):
            uppervol[(call(S,K,r,T,lowervol)-marketprice)*(call(S,K,r,T,m)-marketprice)<0]=m[(call(S,K,r,T,lowervol)-marketprice)*(call(S,K,r,T,m)-marketprice)<0]
            lowervol[(call(S,K,r,T,lowervol)-marketprice)*(call(S,K,r,T,m)-marketprice)>=0]=m[(call(S,K,r,T,lowervol)-marketprice)*(call(S,K,r,T,m)-marketprice)>=0]
            m=(lowervol+uppervol)/2
            count= count + (np.abs(call(S,K,r,T,m)-marketprice) >= precision)
    else:
        while all(count<=maxsteps) and any((np.abs(call(S,K,r,T,m)-marketprice)) >= precision):    
            uppervol[(put(S,K,r,T,lowervol)-marketprice)*(put(S,K,r,T,m)-marketprice)<0]=m[(put(S,K,r,T,lowervol)-marketprice)*(put(S,K,r,T,m)-marketprice)<0]
            lowervol[(put(S,K,r,T,lowervol)-marketprice)*(put(S,K,r,T,m)-marketprice)>=0]=m[(put(S,K,r,T,lowervol)-marketprice)*(put(S,K,r,T,m)-marketprice)>=0]
            m=(lowervol+uppervol)/2
            count= count + (np.abs(np.abs(call(S,K,r,T,m)-marketprice)) >= precision)
    return m, count

#Use Newton's method     
def newton_method(S,K,r,T,type,marketprice):
    size=len(S)
    precision=0.00000001
    maxsteps=1000
    sigma=0.2*np.ones(size)
    count = np.zeros(size)
    
    if type =='call':
        while all(count<=maxsteps) and any((np.abs(call(S,K,r,T,sigma)-marketprice)) >= precision):
             sigma=sigma-(call(S,K,r,T,sigma)-marketprice)/(vega(S,K,r,T,sigma))
             count = count +(np.abs(call(S,K,r,T,sigma)-marketprice) >= precision)
    else:       
        while all(count<=maxsteps) and any((np.abs(call(S,K,r,T,sigma)-marketprice)) >= precision):
             sigma=sigma-(put(S,K,r,T,sigma)-marketprice)/(vega(S,K,r,T,sigma))
             count = count +(np.abs(call(S,K,r,T,sigma)-marketprice) >= precision)
    return sigma,count

#test1 
size = 30
S = 50 * np.ones(size)      #S: Underlying price 
K = 50 * np.ones(size)      #K: Strike price
r = 0.05 * np.ones(size)    #r: Risk free rate
T = 1 * np.ones(size)       #T: Tenor,time to maturity
marketprice = np.linspace(10, 30, size) 

bisection_method(S, K, r, T, 'call', marketprice)   
newton_method(S, K, r, T, 'call', marketprice)










