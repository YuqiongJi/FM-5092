#HW1

import numpy as np
import scipy.stats as si

 
#S: Underlying price 
#K: Strike price
#sigma: Volatility of underlying asset
#r: Risk free rate
#T: Tenor,time to maturity

#call price
def call_option_price (S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    callprice = (S*si.norm.cdf(d1)- K*np.exp(-r*T)*si.norm.cdf(d2))
    return(callprice)

#put price
def put_option_price(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    putprice = K*np.exp(-r*T)*si.norm.cdf(-d2) - S*si.norm.cdf(-d1)
    return(putprice)

#call delta
def call_delta(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    return si.norm.cdf(d1)

#put delta
def put_delta(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    putdelta = si.norm.cdf(d1)-1
    return (putdelta)

#gamma
def gamma(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    gamma_value = si.norm.pdf(d1)/(S*sigma*np.sqrt(T))
    return(gamma_value)

#Vega
def vega(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    vega_value = S*si.norm.pdf(d1)*np.sqrt(T)
    return (vega_value)

#call theta
def call_theta(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    calltheta = -((S*si.norm.pdf(d1)*sigma)/(2*np.sqrt(T))) - r*K*np.exp(-rT)*si.norm.cdf(d2)
    return(calltheta)

#put theta
def put_theta(S,K,r,T,sigma)
    d1 = (np.log(S/K)+(r+0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    puttheta = -((S*si.norm.pdf(d1)*sigma)/(2*np.sqrt(T))) + r*K*np.exp(-rT)*si.norm.cdf(-d2)
    return(puttheta)

#call rho
def call_rho(S,K,r,T,sigma)
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    callrho = K*T*np.exp(-rT)si.norm.cdf(d2)
    return(callrho)

#put rho
def put_rho(S,K,r,T,sigma)
    d2 = (np.log(S/K)+(r-0.5*sigma**2)*T)/(sigma*np.sqrt(T))
    putrho = -K*T*np.exp(-rT)si.norm.cdf(-d2)
    return(putrho)




