using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProfitSymbolAssistant.Classes
{
    public class NewSymbolUserInput
    {
        public DateTime ExpireyDate { get; set; }
        public string MonthCode { get; set; }
        public string UIDisplayName { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is NewSymbolUserInput castObj)
            {
                if (castObj.UIDisplayName == this.UIDisplayName)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return UIDisplayName.GetHashCode();
        }

        public override string ToString()
        {
            return String.Format($"{UIDisplayName} {ExpireyDate.ToString("dd/MM/yyyy")}");
        }
    }
}
