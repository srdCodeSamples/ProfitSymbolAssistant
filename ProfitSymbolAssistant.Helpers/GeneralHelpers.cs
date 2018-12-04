using System;
using System.Collections.Generic;
using ProfitSymbolAssistant.Classes;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Data;

namespace ProfitSymbolAssistant.Helpers
{
    public static class GeneralHelpers
    {
        public static List<NewSymbolTemplate> LoadTemplateData(string dbPath)
        {
            List<NewSymbolTemplate> result = new List<NewSymbolTemplate>();
            using (StreamReader reader = new StreamReader(dbPath))
            {
                string input = reader.ReadToEnd();
                result = JsonConvert.DeserializeObject<List<NewSymbolTemplate>>(input);
            }
            return result;
        }

        public static Dictionary<char, string> GetMonthsCodeMap(string dbMonthCodesPath)
        {
            using (StreamReader reader = new StreamReader(dbMonthCodesPath))
            {
                return new Dictionary<char, string>(JsonConvert.DeserializeObject<Dictionary<char,string>>(reader.ReadToEnd()));
            }               
        }

        public static NewSymbolData GetNewSymbolData(List<NewSymbolTemplate> tempalteData, DAL dbData, NewSymbolUserInput usrInput, string monthsCodeMapPath)
        {
            NewSymbolData result = new NewSymbolData();
            NewSymbolTemplate template = tempalteData.Where(item => item.UIDisplayName == usrInput.UIDisplayName).First();
            result.NewAsset = String.Format(template.AssetPatern, usrInput.MonthCode);
            result.NewDescription = String.Format(template.DescriptionPattern, usrInput.ExpireyDate.ToString("dd/MM/yyyy"));
            result.NewDisplayName = String.Format(template.DisplayNamePattern, usrInput.ExpireyDate.ToString("dd/MM/yyyy"));
            result.NewExpireyDate = usrInput.ExpireyDate.AddDays(1).Date;
            result.NewCloseOnlyDate = usrInput.ExpireyDate.AddDays(-1).Date;
            result.UIDisplayNeme = usrInput.UIDisplayName;
            if (!String.IsNullOrEmpty(usrInput.MonthCode))
            {
                char monthChar = usrInput.MonthCode.ToCharArray()[0];
                GetMonthsCodeMap(monthsCodeMapPath).TryGetValue(monthChar, out string monthString);
                switch (usrInput.UIDisplayName)
                {
                    case "MIB":
                        result.NewMainSuppCode = String.Format(template.MainSuppCodePattern, usrInput.ExpireyDate.ToString("dd-MM-yy"));
                        break;
                    default:
                        result.NewMainSuppCode = String.Format(template.MainSuppCodePattern, $"{monthString}{usrInput.ExpireyDate.ToString("yy")}");
                        break;
                }              
                if (!String.IsNullOrEmpty(template.BackupSuppCodePattern))
                {
                    result.NewBackupSuppCode = String.Format(template.BackupSuppCodePattern, $"{monthString}{usrInput.ExpireyDate.ToString("yy")}");
                }              
            }
            OldSymbolData oldSymbolData = dbData.GetOldSymbolData(String.Format(template.DisplayNamePattern, String.Empty));
            result.NewTcCode = oldSymbolData.TcCode;
            result.OldSymbolId = oldSymbolData.SymbolId;
            result.OldDisplayName = oldSymbolData.DisplayName;
            result.OldAsk = oldSymbolData.Ask;
            result.OldBid = oldSymbolData.Bid;
            return result;
        }

        public static IList<NewSymbolData> GetNewSymbolData(List<NewSymbolTemplate> tempalteData, DAL dbData, IList<NewSymbolUserInput> usrInputList, string monthsCodeMapPath)
        {
            IList<NewSymbolData> result = new List<NewSymbolData>();
            foreach (NewSymbolUserInput entry in usrInputList)
            {
                result.Add(GetNewSymbolData(tempalteData, dbData, entry, monthsCodeMapPath));
            }
            return result;
        }

        public static DataTable GetNewSymbolDataTable(IList<NewSymbolData> newSymbolList)
        {
            DataTable symDataTable = new DataTable();
            string[] colomnNames = new string[] 
            {
                "Display name","Description","NewAsset","Expirey date","Close-only date","TC Code","Supp. Codes","Old Symbol","Old Symbold ID","BID","ASK"
            };
            DataColumn[] colomns = new DataColumn[colomnNames.Length];
            for (int i = 0; i < colomnNames.Length; i++)
            {
                colomns[i] = new DataColumn(colomnNames[i]);
                switch (colomnNames[i])
                {
                    case "Expirey date":
                    case "Close-only date":
                        colomns[i].DataType = Type.GetType("System.DateTime");
                        break;
                    case "Old Symbol ID":
                        colomns[i].DataType = Type.GetType("System.Int32");
                        break;
                    case "BID":
                    case "ASK":
                        colomns[i].DataType = Type.GetType("System.Decimal");
                        break;
                    case "TC Code":
                        colomns[i].DataType = Type.GetType("System.String");
                        colomns[i].AllowDBNull = true;
                        break;
                    default:
                        colomns[i].DataType = Type.GetType("System.String");
                        break;
                }
            }
            symDataTable.Columns.AddRange(colomns);

            foreach (NewSymbolData item in newSymbolList)
            {
                DataRow row = symDataTable.NewRow();
                row[0] = item.NewDisplayName;
                row[1] = item.NewDescription;
                row[2] = item.NewAsset;
                row[3] = item.NewExpireyDate;
                row[4] = item.NewCloseOnlyDate;
                row[5] = item.NewTcCode;
                row[6] = item.NewCombinedSuppCode;
                row[7] = item.OldDisplayName;
                row[8] = item.OldSymbolId;
                row[9] = item.OldBid;
                row[10] = item.OldAsk;
                symDataTable.Rows.Add(row);
            }

            return symDataTable;
        }

        public static string GenerateSqlScript(DataTable newSymbolData, string sqlTemplatePath)
        {
            string template = File.ReadAllText(sqlTemplatePath);
            string genScript = null;
            if (newSymbolData != null)
            {
                foreach (DataRow symRow in newSymbolData.Rows)
                {
                    string symDisplayName = symRow["Display name"].ToString();
                    string symOldId = symRow["Old Symbold ID"].ToString();
                    string symAsk = symRow["ASK"].ToString();
                    string symBid = symRow["BID"].ToString();
                    if (String.IsNullOrEmpty(genScript))
                    {
                        genScript = String.Format(template, symDisplayName, symOldId, symAsk, symBid);
                    }
                    else
                    {
                        genScript = String.Join("\r\n", genScript, String.Format(template, symDisplayName, symOldId, symAsk, symBid));
                    }
                }
            }
            return genScript;
        }
    }
}
