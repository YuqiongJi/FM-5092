# -*- coding: utf-8 -*-
"""
Created on Fri Nov  1 15:21:53 2019

@author: Yuqiong Ji
"""

##############use python to populate database
import pyodbc
import pandas as pd

conn = pyodbc.connect ('Driver={SQL Server};'
                       'Server=LAPTOP-NQ3OM9PL;'
                       'Database=MFM_Financial;'
                       'Trusted_Connection = yes;')
cursor = conn.cursor()
    
def add_name (company, ticker,market,sector):
    
    cursor.execute("insert into [MFM_Financial].[FinData].[Instrument] values ('" + company + "','"+ ticker + "','" + market  + "','" + sector +"')")
    conn.commit()

add_name('Microsoft','MSFT','NASDAQ','Technology')
add_name('Alphabet','GOOG','NASDAQ','Technology')
add_name('Apple','AAPL','NASDAQ','Technology')
add_name('Amazon','AMZN','NASDAQ','Technology')
add_name('General Electric','GE','NYSE','Industrial Goods')
add_name('Coca-Cola','KO','NYSE','Consumer Defensive')
add_name('Valero Energy','VLO','NYSE','Energy')


def get_name_id (ticker):
    
    cursor.execute("select ID from [MFM_Financial].[FinData].[Instrument] where StockTicker ='" + ticker + "'")
    return cursor.fetchone()

def add_timeseries_from_csv(ticker, filepath):
    tickerid = get_name_id(ticker)[0]

    df = pd.read_csv(filepath)
    #print(type(df.iloc[0]['Volume']))
    for i in range(len(df)):
        cursor.execute("insert into [MFM_Financial].[FinData].[HistPrice] \
                        values ('" + str(tickerid) +"',\
                        CONVERT(DATETIME,'" + str(df.iloc[i]['Date']) + "', 102),\
                        '" + str(df.iloc[i]['Open']) + "',\
                        '" + str(df.iloc[i]['High']) + "',\
                        '" + str(df.iloc[i]['Low']) + "',\
                        '" + str(df.iloc[i]['Close']) + "',\
                        '" + str(int(df.iloc[i]['Volume'])) + "',\
                        '" + str(df.iloc[i]['Adj Close']) + "')")
    conn.commit()

add_timeseries_from_csv ('MSFT','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/MSFT.csv')        
add_timeseries_from_csv ('GOOG','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/GOOG.csv')
add_timeseries_from_csv ('AAPL','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/AAPL.csv')                          
add_timeseries_from_csv ('AMZN','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/AMZN.csv')    
add_timeseries_from_csv ('GE','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/GE.csv')    
add_timeseries_from_csv ('KO','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/KO.csv')    
add_timeseries_from_csv ('VLO','C:/Users/Yuqiong Ji/Desktop/Courses 2019 Fall/5091/hw/VLO.csv')




#####################Use python to do PCA Analysis

import numpy as np
##############step1: construct two data set(one sector & four sector)
#MSFT,Technology
cursor.execute("SELECT P.ClosePrice as MSFT_Close, Date \
                INTO MSFT FROM MFM_Financial.FinData.HistPrice P\
                join MFM_Financial.FinData.Instrument I on I.ID = P.InstID \
                WHERE I.StockTicker = 'MSFT'")
#GOOG, Technology
cursor.execute("SELECT P.ClosePrice as GOOG_Close, Date\
               INTO GOOG\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'GOOG'")
#AAPL, Technology
cursor.execute("SELECT P.ClosePrice as AAPL_Close, Date\
               INTO AAPL\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'AAPL'")
#AMZN,Technology
cursor.execute("SELECT P.ClosePrice as AMZN_Close, Date\
               INTO AMZN\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'AMZN'")
#GE,Industrial Goods
cursor.execute("SELECT P.ClosePrice as GE_Close, Date\
               INTO GE\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'GE'")
#KO,Consumer Defensive
cursor.execute("SELECT P.ClosePrice as KO_Close, Date\
               INTO KO\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'KO'")

#VLO,Energy
cursor.execute("SELECT P.ClosePrice as VLO_Close, Date\
               INTO VLO\
               FROM MFM_Financial.FinData.HistPrice P\
               join MFM_Financial.FinData.Instrument I on I.ID = P.InstID\
               WHERE I.StockTicker = 'VLO'")
# extract the close prices of GOOG, AAPL,AMZN,MSFT to form dataset "SameSector"
cursor.execute("SELECT GOOG_Close, AAPL_Close, MSFT_Close, AMZN_Close\
               INTO SameSector\
               FROM GOOG, AAPL, AMZN, MSFT\
               WHERE GOOG.Date = AAPL.Date AND GOOG.Date = MSFT.Date AND GOOG.Date = AMZN.Date")
# extract the close prices of MSFT,GE,KO,VLO to form dataset "DiffSector"
cursor.execute("SELECT MSFT_Close,GE_Close,KO_Close,VLO_Close\
               INTO DiffSector\
               FROM MSFT,GE,KO,VLO\
               WHERE MSFT.Date = GE.Date AND MSFT.Date = KO.Date AND MSFT.Date = VLO.Date")

# Import 'SameSector' and 'DiffSector' datasets into python
onesector = pd.read_sql('SELECT * FROM SameSector',conn)
foursector = pd.read_sql('SELECT * FROM DiffSector',conn)

#calculate returns
returns1 = pd.DataFrame() #returns1 represents returns calculated from stocks from the same sector"Technology"
for i in onesector:
    returns1[i] = np.log(onesector[i][1:].values/onesector[i][:-1].values)
returns1_array = returns1.values

returns2 = pd.DataFrame()#returns2 represents returns calculated from stocks from the different sectors
for i in foursector:
    returns2[i] = np.log(foursector[i][1:].values/foursector[i][:-1].values)
returns2_array = returns2.values

##########step2: Build a covariance matrix
cov_matrix1 = np.cov(returns1_array, rowvar = False)
cov_matrix2 = np.cov(returns2_array, rowvar = False)

##########step3:eigendecomposition
eigenresults1= np.linalg.eig(cov_matrix1)
eigenresults2= np.linalg.eig(cov_matrix2)

#sort the eigenvalues from smallest to largest
index1=np.argsort(eigenresults1[0])
sorteigenvalues1 = eigenresults1[0][index1]
proportion1 = sorteigenvalues1[3]/np.sum(sorteigenvalues1)#calculate proportion1(same sector) of variation accounted for by the largest eigenvalue

index2=np.argsort(eigenresults2[0])
sorteigenvalues2 = eigenresults2[0][index2]
proportion2 = sorteigenvalues2[3]/np.sum(sorteigenvalues2)#calculate proportion2(different sectors) of variation accounted for by the largest eigenvalue
 

#print results
print('Samesector:','\nThe four ticker symbols:',['GOOG', 'AAPL', 'AMZN', 'MSFT'])
print('The matrix of eigenvalues:',sorteigenvalues1)
print('The proportion of variation accounted for by the largest eigenvalue:',proportion1)

print('Foursector:','\nThe four ticker symbols:',['MSFT','GE','KO','VLO'])
print('The matrix of eigenvalues:',sorteigenvalues2)
print('The proportion of variation accounted for by the largest eigenvalue:',proportion2)


####################### Analysis of PCA results
#When four stocks come from one sector, the biggest eigenvalue is 1.00343384e-03, 
#the proportion of variation accounted for by which is 77.85%. When it comes to four stocks
#from different sectors, the biggest eigenvalue is 0.00095088, the proportion of 
#variation accounted for by which is 59.97%. As we can see, 59.97%<77.85%.
#The difference is mainly because stocks from the same sector have larger correlations than stocks from different sectors.









