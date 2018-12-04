using System;
using System.Collections.Generic;
using System.Text;
using ProfitSymbolAssistant.Classes;
using System.Data;
using System.Data.SqlClient;

namespace ProfitSymbolAssistant.Helpers
{
    public class DAL
    {
        private DataSet SymbolsDB;
        public DAL(string dbConnection)
        {
            string symbolsQuerryString = @"SELECT [TradeNetworks].[Dealing].[Symbols].[TradingCentralSymbolCode]
	                                                ,[TradeNetworks].[Dealing].[Symbols].[DisplayName]
                                                    ,[TradeNetworks].[dbo].[CurrentQuotes].[SymbolId]
	                                                ,[Bid]
                                                    ,[Ask]
                                      FROM [TradeNetworks].[dbo].[CurrentQuotes]
                                      JOIN [TradeNetworks].[Dealing].[Symbols] on ([TradeNetworks].[Dealing].[Symbols].[SymbolId] = [TradeNetworks].[dbo].[CurrentQuotes].[SymbolId])";
            SymbolsDB = new DataSet();
            using (SqlDataAdapter adapter = new SqlDataAdapter(symbolsQuerryString, dbConnection))
            {
                adapter.Fill(SymbolsDB, "Symbols");
            }          
        }
        public OldSymbolData GetOldSymbolData(string oldSymbolInitalChars)
        {
            if (SymbolsDB != null)
            {
                DataRow[] symbolData = SymbolsDB.Tables["Symbols"].Select($"DisplayName like '{oldSymbolInitalChars}%'", "SymbolId desc");
                if (symbolData != null)
                {
                    OldSymbolData result = new OldSymbolData();
                    {
                        DataRow latestSymbolData = symbolData[0];
                        result.DisplayName = (string)latestSymbolData["DisplayName"];
                        if (!(latestSymbolData["TradingCentralSymbolCode"] is DBNull))
                        {
                            result.TcCode = (string)latestSymbolData["TradingCentralSymbolCode"];
                        }
                        result.SymbolId = (int)latestSymbolData["SymbolId"];
                        result.Bid = (float)(decimal)latestSymbolData["Bid"];
                        result.Ask = (float)(decimal)latestSymbolData["Ask"];
                    }
                    return result;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
    }
}
