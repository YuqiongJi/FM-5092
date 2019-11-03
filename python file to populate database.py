
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
