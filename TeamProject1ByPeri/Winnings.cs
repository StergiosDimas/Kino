using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject1ByPeri
{
    public class Winnings
    {
        private Dictionary<string, decimal> amountsPerScore;


        public Winnings()
        {
            amountsPerScore = new Dictionary<string, decimal>()
            {
                { "6of6+", 0 },
                { "6of6", 0 },
                { "5of6+", 0 },
                { "5of6", 0 },
                { "4of6+", 0 },
                { "4of6", 0},
                { "3of6+", 0 },
                { "3of6", 0 },
                { "2of6+", 0 },
                { "2of6", 0 },
                { "1of6+", 0 },
                { "1of6", 0 },
            };
        }

        public decimal this[string key]
        {
            get { return amountsPerScore[key]; }

            set { amountsPerScore[key] = value; }
        }

        public decimal GetTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (var amountPerScore in amountsPerScore)
            {
                totalAmount += amountPerScore.Value;
            }
            return totalAmount;
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = KinoTicket.TotalNumbersToSelect; i > 0; i--)
            {
                sb.AppendLine($"{i}of{KinoTicket.TotalNumbersToSelect}+ : {amountsPerScore[$"{i}of{KinoTicket.TotalNumbersToSelect}+"].ToString("C")}");
                sb.AppendLine($"{i}of{KinoTicket.TotalNumbersToSelect} : {amountsPerScore[$"{i}of{KinoTicket.TotalNumbersToSelect}"].ToString("C")}");
            }
            return sb.ToString();
        }
    }
}
