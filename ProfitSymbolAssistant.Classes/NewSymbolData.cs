using System;

namespace ProfitSymbolAssistant.Classes
{
    public class NewSymbolData
    {
        public string UIDisplayNeme { get; set; }
        public string NewDisplayName { get; set; }
        public string NewDescription { get; set; }
        public string NewAsset { get; set; }
        public DateTime NewExpireyDate { get; set; }
        public DateTime NewCloseOnlyDate { get; set; }
        public string NewTcCode { get; set; }
        public string NewMainSuppCode { get; set; }
        public string NewBackupSuppCode { get; set; }
        public string NewCombinedSuppCode
        {
            get
            {
                string combinedCode = null;
                if (!(String.IsNullOrEmpty(NewMainSuppCode) && (String.IsNullOrEmpty(NewBackupSuppCode))))
                {
                    combinedCode = String.Join(" | ", new string[] { NewMainSuppCode, NewBackupSuppCode });
                }
                else if (!String.IsNullOrEmpty(NewMainSuppCode))
                {
                    combinedCode = NewMainSuppCode;
                }
                else if (!String.IsNullOrEmpty(NewBackupSuppCode))
                {
                    combinedCode = NewBackupSuppCode;
                }
                return combinedCode;
            }
        }
        public string OldDisplayName { get; set; }
        public int OldSymbolId { get; set; }
        public float OldBid { get; set; }
        public float OldAsk { get; set; }
    }
}
