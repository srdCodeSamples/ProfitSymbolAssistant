using System;
using System.Collections.Generic;
using System.Text;

namespace ProfitSymbolAssistant.Classes
{
    public class NewSymbolTemplate
    {
        public string UIDisplayName { get; set; }
        public string DisplayNamePattern { get; set; }
        public string DescriptionPattern { get; set; }
        public string AssetPatern { get; set; }
        public string TCCode { get; set; }
        public string MainSuppCodePattern { get; set; }
        public string BackupSuppCodePattern { get; set; }
    }
}
